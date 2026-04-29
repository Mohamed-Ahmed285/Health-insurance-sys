using Oracle.DataAccess.Client;
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

        string ordb = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl)));User Id=HealthAdmin;Password=mypassword;";
        OracleConnection con;

        string loggedInUserNationalID;
        private Button activeButton = null;

        public UserForm(String id)
        {
            InitializeComponent();
            this.loggedInUserNationalID = id;

            con = new OracleConnection(ordb);
        }

        private void SetActiveButton(Button btn)
        {
            if (btn == null) return;
            Color clickedColor = Color.FromArgb(98, 127, 249);
            Color unclickedColor = Color.FromArgb(210, 241, 255);

            if (activeButton != null)
            {
                activeButton.BackColor = unclickedColor;
            }

            activeButton = btn;
            activeButton.BackColor = clickedColor;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            Balance_panel.BringToFront();
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                string sql = "SELECT Current_Balance FROM Patients WHERE National_ID = :id";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.Parameters.Add("id", loggedInUserNationalID);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    label2.Text = result.ToString() + " $";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("مش عارف أجيب الرصيد: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetActiveButton((Button)sender);
            Profile_panel.BringToFront();

            try
            {
                if (con.State == ConnectionState.Closed) con.Open();

                string sql = "SELECT Full_Name, National_ID, Phone, Email, Password_Hash FROM Patients WHERE National_ID = :id";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.Parameters.Add("id", loggedInUserNationalID);

                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    textBox1.Text = reader["Email"].ToString();
                    textBox2.Text = reader["Phone"].ToString();
                    textBox3.Text = reader["Password_Hash"].ToString();
                    textBox4.Text = reader["Full_Name"].ToString();
                    textBox5.Text = reader["National_ID"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("erorr loading data " + ex.Message);
            }
        }

    
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Closed) con.Open();

                string sql = @"UPDATE Patients 
                               SET FULL_NAME = :name, 
                                   EMAIL = :email, 
                                   PHONE = :phone, 
                                   PASSWORD_HASH = :pass
                               WHERE NATIONAL_ID = :id";

                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.Parameters.Add("name", textBox4.Text);
                cmd.Parameters.Add("email", textBox1.Text);
                cmd.Parameters.Add("phone", textBox2.Text);
                cmd.Parameters.Add("pass", textBox3.Text);
                cmd.Parameters.Add("id", loggedInUserNationalID);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("change your data completed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erorr in save" + ex.Message);
            }
        }

 
       

        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (con != null)
            {
                con.Dispose();
            }
        }

    
        private void button1_Click(object sender, EventArgs e) { SetActiveButton((Button)sender); Balance_panel.BringToFront(); }
        private void button2_Click(object sender, EventArgs e)
        {
            SetActiveButton((Button)sender);
            Plans_panel.BringToFront();
            try
            {
                
                if (con.State == ConnectionState.Closed)
                    con.Open();

               
                string sql = "SELECT Plan_ID, Plan_Name, Premium_Fee FROM Insurance_Plans";

                
                OracleDataAdapter da = new OracleDataAdapter(sql, con);
                DataTable dt = new DataTable();

               
                da.Fill(dt);

                
                label13.Text = label2.Text;
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "Plan_Name";
                comboBox1.ValueMember = "Plan_ID";     
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }


        }
        private void button5_Click(object sender, EventArgs e) { button3_Click(button3, null); MessageBox.Show("cancel change done."); }
        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("هل أنت متأكد من تسجيل الخروج؟", "تسجيل الخروج", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) { this.Close(); }
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text) || comboBox1.SelectedValue == null)
            {
                MessageBox.Show("من فضلك دخل بيانات الكارت واختار الخطة");
                return;
            }

            try
            {
                if (con.State == ConnectionState.Closed) con.Open();

               
                decimal planCost = Convert.ToDecimal(label12.Text.Replace(" $", ""));
                decimal currentBalance = Convert.ToDecimal(label2.Text.Replace(" $", ""));

               
                if (currentBalance < planCost)
                {
                    MessageBox.Show("رصيدك غير كافي للاشتراك");
                    return;
                }

             
                OracleCommand cmd = new OracleCommand("system.SubscribeToPlan", con); 
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("p_national_id", OracleDbType.Varchar2).Value = loggedInUserNationalID;
                cmd.Parameters.Add("p_plan_id", OracleDbType.Int32).Value = comboBox1.SelectedValue;
                cmd.Parameters.Add("p_amount", OracleDbType.Decimal).Value = planCost;

                cmd.ExecuteNonQuery();

               
                decimal newBalance = currentBalance - planCost;
                label2.Text = newBalance.ToString() + " $";   
                label13.Text = newBalance.ToString() + " $"; 

                MessageBox.Show("تم الاشتراك بنجاح وخصم المبلغ!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
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
    }
}