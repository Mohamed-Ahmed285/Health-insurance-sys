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
using Oracle.DataAccess.Types;

namespace Health_Insurance_System
{
    public partial class AdminForm : Form
    {
        private Button activeButton = null;
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;

        // Use a reversible encrypted column in DB.
        private const string PasswordColumn = "PASSWORD_HASH";
        private const string EncryptionPassphrase = "ReplaceWithStrongPassphrase";

        public AdminForm()
        {
            InitializeComponent();

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView2.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridView2.RowTemplate.Height = 30;

            SetActiveButton(button1);
            Dashboard_panel.BringToFront();

        }

        private void SetActiveButton(Button btn)
        {
            Color clickedColor = Color.FromArgb(98, 127, 249);
            Color unclickedColor = Color.FromArgb(210, 241, 255);

            if (activeButton != null)
            {
                activeButton.BackColor = unclickedColor;
            }

            activeButton = btn;
            activeButton.BackColor = clickedColor;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetActiveButton((Button)sender);
            Dashboard_panel.BringToFront();
        }

        private void AdminForm_Load(object sender, EventArgs e) { }

        private void button2_Click(object sender, EventArgs e)
        {
            SetActiveButton((Button)sender);
            Add_Admin_Panel.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ds == null || ds.Tables.Count == 0) return;

            var table = ds.Tables[0];

            // Encrypt the PASSWORD_ENC column for rows being saved
            EncryptPasswordsInDataTable(table);

            builder = new OracleCommandBuilder(adapter);
            adapter.Update(table);

            // Decrypt again so UI continues to show plaintext
            DecryptPasswordsInDataTable(table);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string constr = "User Id = HealthAdmin; Password =mypassword; Data Source = orcl";
            string cmdstr = "";

            if (rdo_admins.Checked)
            {
                cmdstr = "SELECT ADMIN_ID, USERNAME, PASSWORD_HASH FROM ADMINS";
            }
            else if (rdo_Hospitals.Checked)
            {
                cmdstr = "SELECT PROVIDER_ID, PROVIDER_NAME, CONTACT_INFO FROM HEALTHCARE_PROVIDERS";
            }

            adapter = new OracleDataAdapter(cmdstr, constr);
            ds = new DataSet();
            adapter.Fill(ds);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Columns.Contains(PasswordColumn))
                {
                    DecryptPasswordsInDataTable(ds.Tables[0]);
                }
                dataGridView2.DataSource = ds.Tables[0];
            }
        }

        // Decrypt in-place for display. If decrypt fails, leave the stored value unchanged.
        private void DecryptPasswordsInDataTable(DataTable table)
        {
            if (table == null) return;
            if (!table.Columns.Contains(PasswordColumn)) return;

            foreach (DataRow row in table.Rows)
            {
                if (row[PasswordColumn] != DBNull.Value)
                {
                    var stored = row[PasswordColumn].ToString();
                    try
                    {
                        var plain = CryptoHelper.DecryptString(stored, EncryptionPassphrase);
                        row[PasswordColumn] = plain;
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void EncryptPasswordsInDataTable(DataTable table)
        {
            if (table == null) return;
            if (!table.Columns.Contains(PasswordColumn)) return;

            foreach (DataRow row in table.Rows)
            {
                try
                {
                    if (row.RowState == DataRowState.Added || row.RowState == DataRowState.Modified)
                    {
                        if (row[PasswordColumn] != DBNull.Value)
                        {
                            var plain = row[PasswordColumn].ToString();
                            if (!string.IsNullOrEmpty(plain))
                            {
                                row[PasswordColumn] = CryptoHelper.EncryptString(plain, EncryptionPassphrase);
                            }
                        }
                    }
                }
                catch
                {

                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

            // Ensure LoginForm exists in the project. This hides current admin UI and shows login.
            this.Hide();
            using (var login = new Login())
            {
                // ShowDialog keeps the application alive while login is displayed.
                login.ShowDialog();
            }
            // After login window is closed, close admin form to end or continue application flow.
            this.Close();
        }
    }
}
