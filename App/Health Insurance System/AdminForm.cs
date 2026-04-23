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
    public partial class AdminForm : Form
    {
        private Button activeButton = null;
        public AdminForm()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            SetActiveButton((Button)sender);
            Dashboard_panel.BringToFront();
        }
       
        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetActiveButton((Button)sender);
            Add_Admin_Panel.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SetActiveButton((Button)sender);
            Add_Hospital_Panel.BringToFront();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
        
        }

        private void button6_Click(object sender, EventArgs e)
        {
          
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
