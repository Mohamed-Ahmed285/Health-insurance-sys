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
    public partial class UserForm : Form
    {
        private const string EncryptionPassphrase = "ReplaceWithStrongPassphrase";
        private const string ConnectionString = "User Id = scott; Password =tiger; Data Source = orcl";
        string loggedInUserNationalID = null;
        decimal loggedInUserBalance = 0m;
        private Button activeButton = null;
        public UserForm(String id)
        {
            InitializeComponent();
            this.loggedInUserNationalID = id;
            // wire events and load data
            this.comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            LoadPlans();
            loggedInUserBalance = GetUserBalance();
            // show initial balance
            label2.Text = $"${loggedInUserBalance:F2}";
            SetActiveButton(button1);
            Balance_panel.BringToFront();
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

            // If the user already has a subscription show the subscribe panel,
            // otherwise show available plans.
            try
            {
                using (var conn = new OracleConnection(ConnectionString))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();

                    cmd.CommandText = "SELECT PLAN_ID FROM (SELECT PLAN_ID FROM SUBSCRIPTIONS WHERE PATIENT_NATIONAL_ID = :nid ORDER BY SUBSCRIPTION_ID DESC) WHERE ROWNUM = 1";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add(new OracleParameter("nid", OracleDbType.Varchar2, loggedInUserNationalID, ParameterDirection.Input));

                    var obj = cmd.ExecuteScalar();
                    if (obj == null || obj == DBNull.Value)
                    {
                        Plans_panel.BringToFront();
                        return;
                    }

                    int planId;
                    if (obj is OracleDecimal od)
                        planId = Convert.ToInt32(od.Value);
                    else
                        planId = Convert.ToInt32(obj);

        
                    cmd.Parameters.Clear();
                    cmd.CommandText = "SELECT PLAN_NAME FROM INSURANCE_PLANS WHERE PLAN_ID = :pid";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new OracleParameter("pid", OracleDbType.Decimal, planId, ParameterDirection.Input));
                    var nameObj = cmd.ExecuteScalar();
                    var planName = (nameObj == null || nameObj == DBNull.Value) ? "(unknown)" : nameObj.ToString();

                    label15.Text = planName;
                    subscribe_plan.BringToFront();
                }
            }
            catch (Exception ex)
            {
                // on error fall back to showing plans
                MessageBox.Show($"Failed to determine subscription status: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Plans_panel.BringToFront();
            }
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            Balance_panel.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetActiveButton((Button)sender);
            Balance_panel.BringToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetActiveButton((Button)sender);
            LoadProfile();
            Profile_panel.BringToFront();
        }

        // Loads the patient's profile into the Profile_panel textboxes using a stored procedure
        private void LoadProfile()
        {
            try
            {
                using (var conn = new OracleConnection(ConnectionString))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "GET_PATIENT_PROFILE";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();

                    cmd.Parameters.Add(new OracleParameter("p_nid", OracleDbType.Varchar2, loggedInUserNationalID, ParameterDirection.Input));

                    var p_name = new OracleParameter("p_full_name", OracleDbType.Varchar2, 200) { Direction = ParameterDirection.Output };
                    var p_email = new OracleParameter("p_email", OracleDbType.Varchar2, 200) { Direction = ParameterDirection.Output };
                    var p_phone = new OracleParameter("p_phone", OracleDbType.Varchar2, 50) { Direction = ParameterDirection.Output };
                    var p_password = new OracleParameter("p_password", OracleDbType.Varchar2, 200) { Direction = ParameterDirection.Output };
                    var p_balance = new OracleParameter("p_balance", OracleDbType.Decimal, ParameterDirection.Output);

                    cmd.Parameters.Add(p_name);
                    cmd.Parameters.Add(p_email);
                    cmd.Parameters.Add(p_phone);
                    cmd.Parameters.Add(p_password);
                    cmd.Parameters.Add(p_balance);

                    cmd.ExecuteNonQuery();

                    // Read outputs and set UI fields (match designer mapping)
                    label19.Text = (p_name.Value == null || p_name.Value == DBNull.Value) ? string.Empty : p_name.Value.ToString();
                    label20.Text = (p_email.Value == null || p_email.Value == DBNull.Value) ? string.Empty : p_email.Value.ToString();
                    label21.Text = (p_phone.Value == null || p_phone.Value == DBNull.Value) ? string.Empty : p_phone.Value.ToString();

                    var plain = (p_password.Value == null || p_password.Value == DBNull.Value) ? string.Empty : p_password.Value.ToString();
                    label22.Text = CryptoHelper.DecryptString(plain, EncryptionPassphrase);

                    decimal balance = 0m;
                    if (p_balance.Value != null && p_balance.Value != DBNull.Value)
                    {
                        if (p_balance.Value is OracleDecimal od)
                            balance = od.Value;
                        else
                            balance = Convert.ToDecimal(p_balance.Value);
                    }

                    loggedInUserBalance = balance;
                    label2.Text = $"${loggedInUserBalance:F2}";
                    label23.Text = loggedInUserNationalID;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load profile: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private class PlanItem
        {
            public int Id { get; }
            public string Name { get; }
            public decimal Premium { get; }
            public decimal Coverage { get; }

            public PlanItem(int id, string name, decimal premium, decimal coverage)
            {
                Id = id; Name = name; Premium = premium; Coverage = coverage;
            }

            public override string ToString() => Name;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = comboBox1.SelectedItem as PlanItem;
            if (item == null) return;

            label12.Text = $"${item.Premium:F2}";
            label13.Text = $"${item.Coverage:F2}";
        }

        private void LoadPlans()
        {
            try
            {
                using (var conn = new OracleConnection(ConnectionString))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "GET_INSURANCE_PLANS";
                    cmd.CommandType = CommandType.StoredProcedure;
                    var outParam = new OracleParameter("p_cursor", OracleDbType.RefCursor, ParameterDirection.Output);
                    cmd.Parameters.Add(outParam);

                    using (var rdr = cmd.ExecuteReader())
                    {
                        comboBox1.Items.Clear();
                        while (rdr.Read())
                        {
                            var id = rdr.IsDBNull(rdr.GetOrdinal("PLAN_ID")) ? 0 : Convert.ToInt32(rdr["PLAN_ID"]);
                            var name = rdr.IsDBNull(rdr.GetOrdinal("PLAN_NAME")) ? string.Empty : rdr["PLAN_NAME"].ToString();
                            var premium = rdr.IsDBNull(rdr.GetOrdinal("PREMIUM_FEE")) ? 0m : Convert.ToDecimal(rdr["PREMIUM_FEE"]);
                            var coverage = rdr.IsDBNull(rdr.GetOrdinal("COVERAGE_AMOUNT")) ? 0m : Convert.ToDecimal(rdr["COVERAGE_AMOUNT"]);

                            comboBox1.Items.Add(new PlanItem(id, name, premium, coverage));
                        }
                    }

                    if (comboBox1.Items.Count > 0)
                        comboBox1.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load plans: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal GetUserBalance()
        {
            try
            {
                using (var conn = new OracleConnection(ConnectionString))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "SELECT CURRENT_BALANCE FROM PATIENTS WHERE NATIONAL_ID = :nid";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add(new OracleParameter("nid", OracleDbType.Varchar2, loggedInUserNationalID, ParameterDirection.Input));
                    var obj = cmd.ExecuteScalar();
                    if (obj == null || obj == DBNull.Value) return 0m;
                    return Convert.ToDecimal(obj);
                }
            }
            catch
            {
                return 0m;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var item = comboBox1.SelectedItem as PlanItem;
            if (item == null)
            {
                MessageBox.Show("Please select a plan.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new OracleConnection(ConnectionString))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    using (var tx = conn.BeginTransaction())
                    {
                        cmd.Transaction = tx;

                        cmd.CommandText = "GET_SUBSCRIPTION_ID";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Clear();
                        var outParam = new OracleParameter("p_next", OracleDbType.Decimal, ParameterDirection.Output);
                        cmd.Parameters.Add(outParam);
                        cmd.ExecuteNonQuery();
                        var nextIdObj = outParam.Value;
                        int subscriptionId = 0;
                        if (nextIdObj == null || nextIdObj == DBNull.Value)
                        {
                            subscriptionId = 0;
                        }
                        else if (nextIdObj is OracleDecimal oracleDec)
                        {
                            // OracleDecimal -> use Value (decimal) then convert
                            subscriptionId = Convert.ToInt32(oracleDec.Value);
                        }
                        else
                        {
                            subscriptionId = Convert.ToInt32(nextIdObj);
                        }

                        cmd.CommandText = "INSERT INTO SUBSCRIPTIONS (SUBSCRIPTION_ID, PATIENT_NATIONAL_ID, PLAN_ID, PAYMENT_DATE, AMOUNT_PAID) " +
                                          "VALUES (:sid, :nid, :pid, :pdate, :amount)";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new OracleParameter("sid", OracleDbType.Decimal, subscriptionId, ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter("nid", OracleDbType.Varchar2, loggedInUserNationalID, ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter("pid", OracleDbType.Decimal, item.Id, ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter("pdate", OracleDbType.Date, DateTime.UtcNow, ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter("amount", OracleDbType.Decimal, item.Premium, ParameterDirection.Input));
                        cmd.ExecuteNonQuery();

                        // 3) Update patient's balance by adding the plan coverage amount

                        cmd.CommandText = "UPDATE PATIENTS SET CURRENT_BALANCE = NVL(CURRENT_BALANCE,0) + :coverage WHERE NATIONAL_ID = :nid";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new OracleParameter("coverage", OracleDbType.Decimal, item.Coverage, ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter("nid", OracleDbType.Varchar2, loggedInUserNationalID, ParameterDirection.Input));
                        var rows = cmd.ExecuteNonQuery();
                        tx.Commit();

                        MessageBox.Show("Subscription successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // refresh balance shown in UI
                        loggedInUserBalance = GetUserBalance();
                        label2.Text = $"${loggedInUserBalance:F2}";
                        label3.Text = "Your Current Plan ";
                        subscribe_plan.BringToFront();
                        label15.Text = $"${item.Name:F2}";

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to subscribe: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Cancel the latest subscription for the logged-in user
            if (MessageBox.Show("Are you sure you want to cancel your current plan?",
                    "Confirm cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                using (var conn = new OracleConnection(ConnectionString))
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    using (var tx = conn.BeginTransaction())
                    {
                        cmd.Transaction = tx;

                        // 1) Find latest subscription id for this patient
                        cmd.CommandText = "SELECT MAX(SUBSCRIPTION_ID) FROM SUBSCRIPTIONS WHERE PATIENT_NATIONAL_ID = :nid";
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new OracleParameter("nid", OracleDbType.Varchar2, loggedInUserNationalID, ParameterDirection.Input));
                        var maxObj = cmd.ExecuteScalar();
                        if (maxObj == null || maxObj == DBNull.Value)
                        {
                            MessageBox.Show("No subscription found to cancel.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        int subscriptionId;
                        if (maxObj is OracleDecimal od)
                            subscriptionId = Convert.ToInt32(od.Value);
                        else
                            subscriptionId = Convert.ToInt32(maxObj);

                        // 2) Get plan id from that subscription
                        cmd.CommandText = "SELECT PLAN_ID FROM SUBSCRIPTIONS WHERE SUBSCRIPTION_ID = :sid";
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new OracleParameter("sid", OracleDbType.Decimal, subscriptionId, ParameterDirection.Input));
                        var pidObj = cmd.ExecuteScalar();
                        if (pidObj == null || pidObj == DBNull.Value)
                        {
                            MessageBox.Show("Subscription row not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tx.Rollback();
                            return;
                        }

                        int planId;
                        if (pidObj is OracleDecimal od2)
                            planId = Convert.ToInt32(od2.Value);
                        else
                            planId = Convert.ToInt32(pidObj);

                        // 3) Read coverage amount for that plan
                        cmd.CommandText = "SELECT COVERAGE_AMOUNT FROM INSURANCE_PLANS WHERE PLAN_ID = :pid";
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new OracleParameter("pid", OracleDbType.Decimal, planId, ParameterDirection.Input));
                        var covObj = cmd.ExecuteScalar();
                        decimal coverage = 0m;
                        if (covObj != null && covObj != DBNull.Value)
                        {
                            if (covObj is OracleDecimal od3)
                                coverage = od3.Value;
                            else
                                coverage = Convert.ToDecimal(covObj);
                        }

                        // 4) Delete the subscription
                        cmd.CommandText = "DELETE FROM SUBSCRIPTIONS WHERE SUBSCRIPTION_ID = :sid";
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new OracleParameter("sid", OracleDbType.Decimal, subscriptionId, ParameterDirection.Input));
                        var delRows = cmd.ExecuteNonQuery();

                        // 5) Subtract coverage from patient's balance
                        cmd.CommandText = "UPDATE PATIENTS SET CURRENT_BALANCE = GREATEST(NVL(CURRENT_BALANCE,0) - :coverage, 0) WHERE NATIONAL_ID = :nid";
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add(new OracleParameter("coverage", OracleDbType.Decimal, coverage, ParameterDirection.Input));
                        cmd.Parameters.Add(new OracleParameter("nid", OracleDbType.Varchar2, loggedInUserNationalID, ParameterDirection.Input));
                        var updRows = cmd.ExecuteNonQuery();

                        tx.Commit();

                        MessageBox.Show("Plan cancelled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // refresh UI
                        loggedInUserBalance = GetUserBalance();
                        label2.Text = $"${loggedInUserBalance:F2}";
                        label15.Text = "No Current Plan";
                        label3.Text = string.Empty;
                        Plans_panel.BringToFront();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to cancel plan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Balance_panel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
