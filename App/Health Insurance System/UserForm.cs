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
    public partial class UserForm : Form
    {
        private const string ConnectionString = "User Id = HealthAdmin; Password =mypassword; Data Source = orcl";
        string loggedInUserNationalID = null;
        private Button activeButton = null;
        public UserForm(String id)
        {
            InitializeComponent();
            this.loggedInUserNationalID = id;
        }
        //GUI Code 
        //nav bar color chnage 
        private void SetActiveButton(Button btn)
        {
            Color clickedColor = Color.FromArgb(98, 127, 249);
            Color unclickedColor = Color.FromArgb(210, 241, 255);

            // Reset previous button
            if (activeButton != null)
            {
                activeButton.BackColor = unclickedColor;
            }

            // Set new active button
            activeButton = btn;
            activeButton.BackColor = clickedColor;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            SetActiveButton((Button)sender);
            Plans_panel.BringToFront();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            Balance_panel.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetActiveButton((Button)sender);
            Balance_panel.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetActiveButton((Button)sender);
            Profile_panel.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
