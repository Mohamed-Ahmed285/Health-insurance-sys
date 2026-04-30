using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Health_Insurance_System
{
    // Add 'partial' to match the designer-generated partial class and fix CS0260.
    public partial class Main : Form
    {
        private Button btnUserPanel;
        private Button btnAdminPanel;
        private Button btnHealthProviderPanel;
        private Label lblTitle;

        public Main()
        {
            //InitializeComponent();
            InitializeCustomComponents();
        }

        // Renamed from InitializeComponent to avoid duplicate definition with the designer file
        private void InitializeCustomComponents()
        {
            this.Text = "Health Insurance System - Launcher";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(420, 220);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            lblTitle = new Label
            {
                Text = "Choose your panel",
                Font = new Font("Tahoma", 14F, FontStyle.Bold),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 48
            };

            btnUserPanel = new Button
            {
                Text = "Login Panel",
                Size = new Size(340, 36),
                Location = new Point(40, 64)
            };
            btnUserPanel.Click += BtnUserPanel_Click;

            btnAdminPanel = new Button
            {
                Text = "Admin Panel",
                Size = new Size(340, 36),
                Location = new Point(40, 106)
            };
            btnAdminPanel.Click += BtnAdminPanel_Click;

            btnHealthProviderPanel = new Button
            {
                Text = "User Panel",
                Size = new Size(340, 36),
                Location = new Point(40, 148)
            };
            btnHealthProviderPanel.Click += BtnHealthProviderPanel_Click;

            this.Controls.Add(lblTitle);
            this.Controls.Add(btnUserPanel);
            this.Controls.Add(btnAdminPanel);
            this.Controls.Add(btnHealthProviderPanel);
        }

        private void BtnUserPanel_Click(object sender, EventArgs e)
        {
            // Show Login form modally, then return here
            using (var login = new Login())
            {
                this.Hide();
                login.StartPosition = FormStartPosition.CenterScreen;
                login.ShowDialog();
                this.Show();
            }
        }

        private void BtnAdminPanel_Click(object sender, EventArgs e)
        {
            // Show AdminForm modally to preserve application lifetime
            using (var admin = new AdminForm())
            {
                this.Hide();
                admin.StartPosition = FormStartPosition.CenterScreen;
                admin.ShowDialog();
                this.Show();
            }
        }

        private void BtnHealthProviderPanel_Click(object sender, EventArgs e)
        {
            // Show HospitalForm (create one if missing)
            using (var hospital = new UserForm("29901012345678"))
            {
                this.Hide();
                hospital.StartPosition = FormStartPosition.CenterScreen;
                hospital.ShowDialog();
                this.Show();
            }
        }
    }
}
