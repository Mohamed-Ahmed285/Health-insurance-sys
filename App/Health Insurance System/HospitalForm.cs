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
    public partial class HospitalForm : Form
    {
        private Button btnClose;
        private Label lblInfo;
        public HospitalForm()
        {
            InitializeComponent();
            InitializebtnComponent();
           
        }

        private void InitializebtnComponent()
        {
            this.Text = "Hospital Panel";
            this.StartPosition = FormStartPosition.CenterScreen;
            //this.ClientSize = new Size(640, 360);

            lblInfo = new Label
            {
                Text = "Hospital / Health Provider Panel",
                Font = new Font("Tahoma", 14F, FontStyle.Bold),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 60
            };

            btnClose = new Button
            {
                Text = "Close",
                Size = new Size(100, 34),
                Location = new Point((this.ClientSize.Width - 150), 60)
            };
            btnClose.Click += (s, e) => this.Close();

            this.Controls.Add(lblInfo);
            this.Controls.Add(btnClose);
        }

  
    }
}
