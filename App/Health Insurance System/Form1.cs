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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            label4.TabStop = true;
            AddPlaceholder(textBox1, "Enter your email");
            AddPlaceholder(textBox2, "Enter your password");
        }
        // GUI Functions
            //Place holder
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click_1(object sender, EventArgs e)
        {
            Sign_up_panel.SendToBack();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            Sign_in_panel.SendToBack();
        }
    }
}
