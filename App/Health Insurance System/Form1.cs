using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;

namespace Health_Insurance_System
{
    public partial class Login : Form
    {
        private const string EncryptionPassphrase = "ReplaceWithStrongPassphrase";

        private const string ConnectionString = "User Id = HealthAdmin; Password =mypassword; Data Source = orcl";

        public Login()
        {
            InitializeComponent();
            label4.TabStop = true;
            AddPlaceholder(textBox1, "Enter your email");
            AddPlaceholder(textBox2, "Enter your password");
            //============================================
            AddPlaceholder(textBox3, "Enter your name");
            AddPlaceholder(textBox4, "Enter your email");
            AddPlaceholder(textBox5, "Enter your phone");
            AddPlaceholder(textBox6, "Enter your password");
            AddPlaceholder(textBox7, "Enter your national ID");
        }

        // GUI Functions
        // Place holder helper
        private void AddPlaceholder(TextBox txt, string placeholder)
        {
            txt.Text = placeholder;
            txt.ForeColor = Color.Gray;

            txt.Enter += (sender, e) =>
            {
                if (txt.Text == placeholder)
                {
                    txt.Text = "";
                    txt.ForeColor = Color.Black;
                }
            };

            txt.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(txt.Text))
                {
                    txt.Text = placeholder;
                    txt.ForeColor = Color.Gray;
                }
            };
        }

        // Helper to read a textbox value ignoring placeholder
        private string ReadText(TextBox txt, string placeholder)
        {
            if (txt == null) return string.Empty;
            if (txt.ForeColor == Color.Gray && txt.Text == placeholder) return string.Empty;
            return txt.Text?.Trim() ?? string.Empty;
        }

        // unfocus from textbox
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            label4.Focus();   // move focus away from textboxes
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Sign_up_panel.SendToBack();
        }

        private void pictureBox2_Click(object sender, EventArgs e) { }

        private void pictureBox1_Click(object sender, EventArgs e) { }

        private void panel2_Paint(object sender, PaintEventArgs e) { }

        private void textBox3_TextChanged(object sender, EventArgs e) { }

        private void label14_Click_1(object sender, EventArgs e)
        {
            Sign_up_panel.SendToBack();
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void label2_Click_1(object sender, EventArgs e)
        {
            Sign_in_panel.SendToBack();
        }

        // LOGIN button - authenticate user by email + password
        private void button2_Click(object sender, EventArgs e)
        {
            var email = ReadText(textBox1, "Enter your email");
            var password = ReadText(textBox2, "Enter your password");

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter email and password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new OracleConnection(ConnectionString))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "SELECT PASSWORD_HASH FROM PATIENTS WHERE EMAIL = :email";
                    cmd.Parameters.Add(new OracleParameter("email", OracleDbType.Varchar2, email, ParameterDirection.Input));

                    using (var rdr = cmd.ExecuteReader(CommandBehavior.SingleRow))
                    {
                        if (!rdr.Read())
                        {
                            MessageBox.Show("Invalid email or password.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        var storedEnc = rdr.IsDBNull(0) ? null : rdr.GetString(0);
                        if (string.IsNullOrEmpty(storedEnc))
                        {
                            MessageBox.Show("Account has no stored password.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Decrypt and compare
                        string storedPlain;
                        try
                        {
                            storedPlain = CryptoHelper.DecryptString(storedEnc, EncryptionPassphrase);
                        }
                        catch
                        {
                            MessageBox.Show("Unable to decrypt stored password. Contact admin.", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (string.Equals(password, storedPlain, StringComparison.Ordinal))
                        {
                            this.Hide();
                            using (var admin = new UserForm())
                            {
                                admin.ShowDialog();
                            }
                            this.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid email or password.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // SIGN UP button (assumed button1) - insert new patient with encrypted password
        private void button1_Click(object sender, EventArgs e)
        {
            var name = ReadText(textBox3, "Enter your name");
            var email = ReadText(textBox4, "Enter your email");
            var phone = ReadText(textBox5, "Enter your phone");
            var password = ReadText(textBox6, "Enter your password");
            var nationalId = ReadText(textBox7, "Enter your national ID");

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Name, email and password are required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new OracleConnection(ConnectionString))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();

                    // Optional: check if email already exists
                    cmd.CommandText = "SELECT COUNT(1) FROM PATIENTS WHERE EMAIL = :email";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new OracleParameter("email", OracleDbType.Varchar2, email, ParameterDirection.Input));
                    var exists = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
                    if (exists)
                    {
                        MessageBox.Show("An account with this email already exists.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Prepare encrypted password
                    var encrypted = CryptoHelper.EncryptString(password, EncryptionPassphrase);

                    // Direct INSERT via parameterized OracleCommand (no stored procedures)
                    cmd.CommandText = "INSERT INTO PATIENTS (FULL_NAME, EMAIL, PHONE, PASSWORD_HASH, NATIONAL_ID) " +
                                      "VALUES (:name, :email, :phone, :pwd, :nid)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new OracleParameter("name", OracleDbType.Varchar2, name, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("email", OracleDbType.Varchar2, email, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("phone", OracleDbType.Varchar2, string.IsNullOrEmpty(phone) ? (object)DBNull.Value : phone, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("pwd", OracleDbType.Varchar2, encrypted, ParameterDirection.Input));
                    cmd.Parameters.Add(new OracleParameter("nid", OracleDbType.Varchar2, string.IsNullOrEmpty(nationalId) ? (object)DBNull.Value : nationalId, ParameterDirection.Input));

                    var rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Registration successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Optionally switch to sign-in panel
                        Sign_in_panel.BringToFront();
                    }
                    else
                    {
                        MessageBox.Show("Registration failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sign up failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdo_actors_CheckedChanged(object sender, EventArgs e) { }

    }
}
