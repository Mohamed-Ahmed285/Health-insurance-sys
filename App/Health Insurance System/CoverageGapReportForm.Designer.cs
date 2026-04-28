
namespace Health_Insurance_System
{
    partial class CoverageGapReportForm
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
            this.GenerateReport = new System.Windows.Forms.Button();
            this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.EndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.coverageGapReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GenerateReport
            // 
            this.GenerateReport.Location = new System.Drawing.Point(317, 113);
            this.GenerateReport.Name = "GenerateReport";
            this.GenerateReport.Size = new System.Drawing.Size(163, 33);
            this.GenerateReport.TabIndex = 0;
            this.GenerateReport.Text = "Generate Report";
            this.GenerateReport.UseVisualStyleBackColor = true;
            this.GenerateReport.Click += new System.EventHandler(this.GenerateReport_Click);
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.Location = new System.Drawing.Point(155, 85);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(200, 22);
            this.StartDatePicker.TabIndex = 1;
            // 
            // EndDatePicker
            // 
            this.EndDatePicker.Location = new System.Drawing.Point(445, 85);
            this.EndDatePicker.Name = "EndDatePicker";
            this.EndDatePicker.Size = new System.Drawing.Size(200, 22);
            this.EndDatePicker.TabIndex = 2;
            // 
            // coverageGapReportViewer
            // 
            this.coverageGapReportViewer.ActiveViewIndex = -1;
            this.coverageGapReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.coverageGapReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.coverageGapReportViewer.Location = new System.Drawing.Point(12, 152);
            this.coverageGapReportViewer.Name = "coverageGapReportViewer";
            this.coverageGapReportViewer.Size = new System.Drawing.Size(776, 286);
            this.coverageGapReportViewer.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Start Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(445, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "End Date";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.coverageGapReportViewer);
            this.Controls.Add(this.EndDatePicker);
            this.Controls.Add(this.StartDatePicker);
            this.Controls.Add(this.GenerateReport);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GenerateReport;
        private System.Windows.Forms.DateTimePicker StartDatePicker;
        private System.Windows.Forms.DateTimePicker EndDatePicker;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer coverageGapReportViewer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}