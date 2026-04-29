namespace Health_Insurance_System
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.Dashboard_panel = new System.Windows.Forms.Panel();
            this.crystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.EndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.Add_Admin_Panel = new System.Windows.Forms.Panel();
            this.Load_Data = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdo_Hospitals = new System.Windows.Forms.RadioButton();
            this.rdo_admins = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.CoverageGapReport_rdo = new System.Windows.Forms.RadioButton();
            this.PlanAmountSumReport_rdo = new System.Windows.Forms.RadioButton();
            this.Dashboard_panel.SuspendLayout();
            this.Add_Admin_Panel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(127)))), ((int)(((byte)(249)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(201, 17);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(219, 63);
            this.button1.TabIndex = 0;
            this.button1.Text = "Dashboard";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Dashboard_panel
            // 
            this.Dashboard_panel.Location = new System.Drawing.Point(15, 76);
            this.Dashboard_panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Dashboard_panel.Controls.Add(this.PlanAmountSumReport_rdo);
            this.Dashboard_panel.Controls.Add(this.CoverageGapReport_rdo);
            this.Dashboard_panel.Controls.Add(this.crystalReportViewer);
            this.Dashboard_panel.Controls.Add(this.EndDatePicker);
            this.Dashboard_panel.Controls.Add(this.StartDatePicker);
            this.Dashboard_panel.Controls.Add(this.label2);
            this.Dashboard_panel.Controls.Add(this.label1);
            this.Dashboard_panel.Controls.Add(this.button4);
            this.Dashboard_panel.Location = new System.Drawing.Point(20, 94);
            this.Dashboard_panel.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Dashboard_panel.Name = "Dashboard_panel";
            this.Dashboard_panel.Size = new System.Drawing.Size(1275, 641);
            this.Dashboard_panel.TabIndex = 1;
            // 
            // crystalReportViewer
            // 
            this.crystalReportViewer.ActiveViewIndex = -1;
            this.crystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer.Location = new System.Drawing.Point(4, 162);
            this.crystalReportViewer.Name = "crystalReportViewer";
            this.crystalReportViewer.Size = new System.Drawing.Size(1244, 453);
            this.crystalReportViewer.TabIndex = 5;
            // 
            // EndDatePicker
            // 
            this.EndDatePicker.Location = new System.Drawing.Point(348, 102);
            this.EndDatePicker.Name = "EndDatePicker";
            this.EndDatePicker.Size = new System.Drawing.Size(200, 22);
            this.EndDatePicker.TabIndex = 4;
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.Location = new System.Drawing.Point(348, 25);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(200, 22);
            this.StartDatePicker.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(345, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "End Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(345, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Start Date";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(554, 113);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(145, 38);
            this.button4.TabIndex = 0;
            this.button4.Text = "Generate Report";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // Add_Admin_Panel
            // 
            this.Add_Admin_Panel.Controls.Add(this.Load_Data);
            this.Add_Admin_Panel.Controls.Add(this.groupBox1);
            this.Add_Admin_Panel.Controls.Add(this.button3);
            this.Add_Admin_Panel.Controls.Add(this.dataGridView2);
            this.Add_Admin_Panel.Controls.Add(this.label5);
            this.Add_Admin_Panel.Location = new System.Drawing.Point(5, 80);
            this.Add_Admin_Panel.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Add_Admin_Panel.Name = "Add_Admin_Panel";
            this.Add_Admin_Panel.Size = new System.Drawing.Size(1276, 654);
            this.Add_Admin_Panel.TabIndex = 2;
            this.Add_Admin_Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Add_Admin_Panel_Paint);
            // 
            // Load_Data
            // 
            this.Load_Data.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Load_Data.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Load_Data.Location = new System.Drawing.Point(873, 116);
            this.Load_Data.Margin = new System.Windows.Forms.Padding(4);
            this.Load_Data.Name = "Load_Data";
            this.Load_Data.Size = new System.Drawing.Size(120, 32);
            this.Load_Data.TabIndex = 8;
            this.Load_Data.Text = "Load Data";
            this.Load_Data.UseVisualStyleBackColor = true;
            this.Load_Data.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdo_Hospitals);
            this.groupBox1.Controls.Add(this.rdo_admins);
            this.groupBox1.Location = new System.Drawing.Point(784, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(405, 95);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // rdo_Hospitals
            // 
            this.rdo_Hospitals.AutoSize = true;
            this.rdo_Hospitals.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_Hospitals.Location = new System.Drawing.Point(223, 41);
            this.rdo_Hospitals.Margin = new System.Windows.Forms.Padding(4);
            this.rdo_Hospitals.Name = "rdo_Hospitals";
            this.rdo_Hospitals.Size = new System.Drawing.Size(122, 29);
            this.rdo_Hospitals.TabIndex = 1;
            this.rdo_Hospitals.Text = "Hospitals";
            this.rdo_Hospitals.UseVisualStyleBackColor = true;
            // 
            // rdo_admins
            // 
            this.rdo_admins.AutoSize = true;
            this.rdo_admins.Checked = true;
            this.rdo_admins.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_admins.Location = new System.Drawing.Point(81, 41);
            this.rdo_admins.Margin = new System.Windows.Forms.Padding(4);
            this.rdo_admins.Name = "rdo_admins";
            this.rdo_admins.Size = new System.Drawing.Size(104, 29);
            this.rdo_admins.TabIndex = 0;
            this.rdo_admins.TabStop = true;
            this.rdo_admins.Text = "Admins";
            this.rdo_admins.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(127)))), ((int)(((byte)(249)))));
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.button3.Location = new System.Drawing.Point(1025, 116);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 32);
            this.button3.TabIndex = 5;
            this.button3.Text = "SUBMIT";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(19, 176);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 26;
            this.dataGridView2.Size = new System.Drawing.Size(1244, 444);
            this.dataGridView2.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(108, 60);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(330, 40);
            this.label5.TabIndex = 0;
            this.label5.Text = "Control Data Panel";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(127)))), ((int)(((byte)(249)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(460, 17);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(449, 63);
            this.button2.TabIndex = 0;
            this.button2.Text = "Admin Control Panel";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(241)))), ((int)(((byte)(255)))));
            this.button8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(98)))), ((int)(((byte)(127)))), ((int)(((byte)(249)))));
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(976, 17);
            this.button8.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(219, 63);
            this.button8.TabIndex = 5;
            this.button8.Text = "Logout";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // CoverageGapReport_rdo
            // 
            this.CoverageGapReport_rdo.AutoSize = true;
            this.CoverageGapReport_rdo.Checked = true;
            this.CoverageGapReport_rdo.Location = new System.Drawing.Point(697, 25);
            this.CoverageGapReport_rdo.Name = "CoverageGapReport_rdo";
            this.CoverageGapReport_rdo.Size = new System.Drawing.Size(168, 21);
            this.CoverageGapReport_rdo.TabIndex = 6;
            this.CoverageGapReport_rdo.TabStop = true;
            this.CoverageGapReport_rdo.Text = "Coverage Gap Report";
            this.CoverageGapReport_rdo.UseVisualStyleBackColor = true;
            // 
            // PlanAmountSumReport_rdo
            // 
            this.PlanAmountSumReport_rdo.AutoSize = true;
            this.PlanAmountSumReport_rdo.Location = new System.Drawing.Point(697, 53);
            this.PlanAmountSumReport_rdo.Name = "PlanAmountSumReport_rdo";
            this.PlanAmountSumReport_rdo.Size = new System.Drawing.Size(219, 21);
            this.PlanAmountSumReport_rdo.TabIndex = 7;
            this.PlanAmountSumReport_rdo.TabStop = true;
            this.PlanAmountSumReport_rdo.Text = "Plan Amount Summary Report";
            this.PlanAmountSumReport_rdo.UseVisualStyleBackColor = true;
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(224)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1284, 734);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Dashboard_panel);
            this.Controls.Add(this.Add_Admin_Panel);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.Add_Admin_Panel.ResumeLayout(false);
            this.Add_Admin_Panel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel Dashboard_panel;
        private System.Windows.Forms.Panel Add_Admin_Panel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdo_Hospitals;
        private System.Windows.Forms.RadioButton rdo_admins;
        private System.Windows.Forms.Button Load_Data;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer;
        private System.Windows.Forms.DateTimePicker EndDatePicker;
        private System.Windows.Forms.DateTimePicker StartDatePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RadioButton PlanAmountSumReport_rdo;
        private System.Windows.Forms.RadioButton CoverageGapReport_rdo;
    }
}