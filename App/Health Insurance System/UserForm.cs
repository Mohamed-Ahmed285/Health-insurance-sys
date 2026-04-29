    using Oracle.ManagedDataAccess.Client;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
using System.Xml.Linq;

    namespace Health_Insurance_System
    {
        public partial class UserForm : Form
        {

            string connString = "User Id=system;Password=123;Data Source=localhost:1521/orcl";
      
            string loggedInUserNationalID = "123";
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
            try
            {
                using (OracleConnection conn = new OracleConnection(connString))
                {
                    string sql = "SELECT Plan_ID, Plan_Name, Premium_Fee FROM Insurance_Plans";
                    OracleDataAdapter da = new OracleDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    label13.Text = label2.Text;
                    comboBox1.DataSource = dt;
                    comboBox1.DisplayMember = "Plan_Name";
                    comboBox1.ValueMember = "Plan_ID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(" Erorr loading data" + ex.Message);
            }
        }

            private void UserForm_Load(object sender, EventArgs e)
            {
                
                string connString = "User Id=system;Password=123;Data Source=localhost:1521/orcl";

            string nationalID = loggedInUserNationalID;

            using (OracleConnection conn = new OracleConnection(connString))
                {
                    try
                    {
                        conn.Open();
                   
                        string sql = "SELECT Current_Balance FROM Patients WHERE National_ID = :id";

                        using (OracleCommand cmd = new OracleCommand(sql, conn))
                        {
                            cmd.Parameters.Add(new OracleParameter("id", nationalID));

                            object result = cmd.ExecuteScalar();
                            if (result != null)
                            {
                          
                                label2.Text = result.ToString() + " $";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("مش عارف أجيب الرصيد: " + ex.Message);
                    }
                }
            }



        private void button4_Click(object sender, EventArgs e)
        {
           
            
                using (OracleConnection con = new OracleConnection(connString))
                {
                    try
                    {
                        con.Open();
                       
                        string sql = @"UPDATE Patients 
                           SET FULL_NAME = :name, 
                               EMAIL = :email, 
                               PHONE = :phone, 
                               PASSWORD_HASH = :pass
                           WHERE NATIONAL_ID = :id";

                        using (OracleCommand cmd = new OracleCommand(sql, con))
                        {
                            cmd.Parameters.Add(new OracleParameter("name", textBox4.Text));
                            cmd.Parameters.Add(new OracleParameter("email", textBox1.Text));
                            cmd.Parameters.Add(new OracleParameter("phone", textBox2.Text));
                            cmd.Parameters.Add(new OracleParameter("pass", textBox3.Text));
                        cmd.Parameters.Add(new OracleParameter("id", loggedInUserNationalID));


                        int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("change your data completed");
                            }
                            else
                            {
                                MessageBox.Show("لم يتم العثور على المريض لتعديله.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erorr in save" + ex.Message);
                    }
                }
            }
        
                
               
                
           
        

            private void button5_Click(object sender, EventArgs e)
            {
            button3_Click(button3, null);
            MessageBox.Show("cancel change done.");
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

            using (OracleConnection con = new OracleConnection(connString))
            {
                try
                {
                    con.Open();
                    string sql = "SELECT Full_Name, National_ID, Phone, Email, Password_Hash FROM Patients WHERE National_ID = '" + loggedInUserNationalID + "'";
                    OracleCommand cmd = new OracleCommand(sql, con);
                    OracleDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                       
                        textBox1.Text = reader["Email"].ToString();
                        textBox2.Text = reader["Phone"].ToString();
                        textBox3.Text = reader["Password_Hash"].ToString();
                        textBox4.Text = reader["Full_Name"].ToString();
                        textBox5.Text = reader["National_ID"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("erorr loading data " + ex.Message);
                }
            }
        }

            private void button6_Click(object sender, EventArgs e)
            {
            DialogResult result = MessageBox.Show("هل أنت متأكد من تسجيل الخروج؟", "تسجيل الخروج", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Health_Insurance_System.Login loginPage = new Health_Insurance_System.Login();
                loginPage.Show();
                this.Close();
            }
        }

            private void Balance_panel_Paint(object sender, PaintEventArgs e)
            {

            }

            private void Plans_panel_Paint(object sender, PaintEventArgs e)
            {
                
            }

        private void button8_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text) || comboBox1.SelectedValue == null)
            {
                MessageBox.Show("من فضلك دخل بيانات الكارت واختار الخطة");
                return;
            }

            using (OracleConnection con = new OracleConnection(connString))
            {
                try
                {
                    con.Open();
                   
                    OracleCommand cmd = new OracleCommand("SubscribeToPlan", con);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("p_national_id", OracleDbType.Varchar2).Value = loggedInUserNationalID;
                    cmd.Parameters.Add("p_plan_id", OracleDbType.Int32).Value = comboBox1.SelectedValue;

                   
                    DataRowView drv = (DataRowView)comboBox1.SelectedItem;
                    decimal price = Convert.ToDecimal(drv["Premium_Fee"]);
                    cmd.Parameters.Add("p_amount", OracleDbType.Decimal).Value = price;
                    decimal currentBalance = Convert.ToDecimal(label2.Text.Replace(" $", ""));
                    decimal planCost = Convert.ToDecimal(label12.Text.Replace(" $", ""));
                    label2.Text = (currentBalance - planCost).ToString() + " $";

                    
                    label13.Text = label2.Text;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Congratulations, you have subscribed! " + comboBox1.Text + " The amount was deducted.");

                    
                    label2.Text = (Convert.ToDecimal(label2.Text.Replace(" $", "")) - price).ToString() + " $";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("erorr of sale " + ex.Message);
                }
            }
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                
                DataRowView drv = (DataRowView)comboBox1.SelectedItem;
                label12.Text = drv["Premium_Fee"].ToString() + " $";
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void Profile_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
    }
