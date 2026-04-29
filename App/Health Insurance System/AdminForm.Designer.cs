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
            this.button1.Location = new System.Drawing.Point(151, 14);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 51);
            this.button1.TabIndex = 0;
            this.button1.Text = "Dashboard";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Dashboard_panel
            // 
            this.Dashboard_panel.Location = new System.Drawing.Point(15, 76);
            this.Dashboard_panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Dashboard_panel.Name = "Dashboard_panel";
            this.Dashboard_panel.Size = new System.Drawing.Size(956, 521);
            this.Dashboard_panel.TabIndex = 1;
            // 
            // Add_Admin_Panel
            // 
            this.Add_Admin_Panel.Controls.Add(this.Load_Data);
            this.Add_Admin_Panel.Controls.Add(this.groupBox1);
            this.Add_Admin_Panel.Controls.Add(this.button3);
            this.Add_Admin_Panel.Controls.Add(this.dataGridView2);
            this.Add_Admin_Panel.Controls.Add(this.label5);
            this.Add_Admin_Panel.Location = new System.Drawing.Point(4, 65);
            this.Add_Admin_Panel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Add_Admin_Panel.Name = "Add_Admin_Panel";
            this.Add_Admin_Panel.Size = new System.Drawing.Size(957, 531);
            this.Add_Admin_Panel.TabIndex = 2;
            this.Add_Admin_Panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Add_Admin_Panel_Paint);
            // 
            // Load_Data
            // 
            this.Load_Data.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Load_Data.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Load_Data.Location = new System.Drawing.Point(655, 94);
            this.Load_Data.Name = "Load_Data";
            this.Load_Data.Size = new System.Drawing.Size(90, 26);
            this.Load_Data.TabIndex = 8;
            this.Load_Data.Text = "Load Data";
            this.Load_Data.UseVisualStyleBackColor = true;
            this.Load_Data.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdo_Hospitals);
            this.groupBox1.Controls.Add(this.rdo_admins);
            this.groupBox1.Location = new System.Drawing.Point(588, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 77);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // rdo_Hospitals
            // 
            this.rdo_Hospitals.AutoSize = true;
            this.rdo_Hospitals.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_Hospitals.Location = new System.Drawing.Point(167, 33);
            this.rdo_Hospitals.Name = "rdo_Hospitals";
            this.rdo_Hospitals.Size = new System.Drawing.Size(98, 24);
            this.rdo_Hospitals.TabIndex = 1;
            this.rdo_Hospitals.Text = "Hospitals";
            this.rdo_Hospitals.UseVisualStyleBackColor = true;
            // 
            // rdo_admins
            // 
            this.rdo_admins.AutoSize = true;
            this.rdo_admins.Checked = true;
            this.rdo_admins.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdo_admins.Location = new System.Drawing.Point(61, 33);
            this.rdo_admins.Name = "rdo_admins";
            this.rdo_admins.Size = new System.Drawing.Size(83, 24);
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
            this.button3.Location = new System.Drawing.Point(769, 94);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 26);
            this.button3.TabIndex = 5;
            this.button3.Text = "SUBMIT";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(14, 143);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 26;
            this.dataGridView2.Size = new System.Drawing.Size(933, 361);
            this.dataGridView2.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label5.Location = new System.Drawing.Point(81, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(269, 33);
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
            this.button2.Location = new System.Drawing.Point(345, 14);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(337, 51);
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
            this.button8.Location = new System.Drawing.Point(732, 14);
            this.button8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(164, 51);
            this.button8.TabIndex = 5;
            this.button8.Text = "Logout";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(177)))), ((int)(((byte)(224)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(963, 596);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Add_Admin_Panel);
            this.Controls.Add(this.Dashboard_panel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
    }
}