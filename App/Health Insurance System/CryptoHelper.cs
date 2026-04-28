using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Health_Insurance_System
{
    // AES reversible encryption helper. Protect the passphrase securely (not hard-coded).
    public static class CryptoHelper
    {
        // Encrypt plaintext -> base64
        public static string EncryptString(string plainText, string passphrase)
        {
            if (plainText == null) return null;
            var salt = Encoding.UTF8.GetBytes("ReplaceWithASaltValue"); // replace & protect
            using (var aes = Aes.Create())
            {
                var key = new Rfc2898DeriveBytes(passphrase, salt, 10000);
                aes.Key = key.GetBytes(32);
                aes.GenerateIV();
                using (var ms = new MemoryStream())
                {
                    // Prepend IV
                    ms.Write(aes.IV, 0, aes.IV.Length);
                    using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    using (var sw = new StreamWriter(cs, Encoding.UTF8))
                    {
                        sw.Write(plainText);
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }

        // Decrypt base64 -> plaintext
        public static string DecryptString(string cipherTextBase64, string passphrase)
        {
            if (string.IsNullOrEmpty(cipherTextBase64)) return cipherTextBase64;
            var salt = Encoding.UTF8.GetBytes("ReplaceWithASaltValue"); // must match Encrypt
            byte[] cipherBytes;
            try { cipherBytes = Convert.FromBase64String(cipherTextBase64); }
            catch { throw new FormatException("Cipher text is not valid base64."); }

            using (var aes = Aes.Create())
            {
                var key = new Rfc2898DeriveBytes(passphrase, salt, 10000);
                aes.Key = key.GetBytes(32);

                // Extract IV (first 16 bytes for AES)
                var iv = new byte[aes.BlockSize / 8];
                Array.Copy(cipherBytes, 0, iv, 0, iv.Length);
                aes.IV = iv;

                using (var ms = new MemoryStream())
                {
                    ms.Write(cipherBytes, iv.Length, cipherBytes.Length - iv.Length);
                    ms.Position = 0;
                    using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    using (var sr = new StreamReader(cs, Encoding.UTF8))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }
    }

    public static class PasswordHelper
    {
        // Format stored: iteration:saltBase64:hashBase64
        private const int SaltSize = 16; // 128 bit
        private const int HashSize = 32; // 256 bit
        private const int Iterations = 10000;

        public static string CreateHash(string password)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));

            using (var rng = new RNGCryptoServiceProvider())
            {
                var salt = new byte[SaltSize];
                rng.GetBytes(salt);

                using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations))
                {
                    var hash = pbkdf2.GetBytes(HashSize);
                    return $"{Iterations}:{Convert.ToBase64String(salt)}:{Convert.ToBase64String(hash)}";
                }
            }
        }

        public static bool VerifyHash(string password, string storedHash)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            if (string.IsNullOrEmpty(storedHash)) return false;

            var parts = storedHash.Split(':');
            if (parts.Length != 3) return false;

            if (!int.TryParse(parts[0], out int iterations)) return false;
            var salt = Convert.FromBase64String(parts[1]);
            var hash = Convert.FromBase64String(parts[2]);

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                var computed = pbkdf2.GetBytes(hash.Length);
                return AreEqual(computed, hash);
            }
        }

        // Constant-time comparison
        private static bool AreEqual(byte[] a, byte[] b)
        {
            if (a.Length != b.Length) return false;
            var diff = 0;
            for (int i = 0; i < a.Length; i++) diff |= a[i] ^ b[i];
            return diff == 0;
        }
    }
}