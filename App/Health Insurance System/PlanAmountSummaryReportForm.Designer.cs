
namespace Health_Insurance_System
{
    partial class PlanAmountSummaryReportForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.StartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.GenerateReport = new System.Windows.Forms.Button();
            this.planAmountSummaryViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(165, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(427, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "End Date";
            // 
            // EndDatePicker
            // 
            this.EndDatePicker.Location = new System.Drawing.Point(430, 86);
            this.EndDatePicker.Name = "EndDatePicker";
            this.EndDatePicker.Size = new System.Drawing.Size(200, 22);
            this.EndDatePicker.TabIndex = 2;
            // 
            // StartDatePicker
            // 
            this.StartDatePicker.Location = new System.Drawing.Point(168, 86);
            this.StartDatePicker.Name = "StartDatePicker";
            this.StartDatePicker.Size = new System.Drawing.Size(200, 22);
            this.StartDatePicker.TabIndex = 3;
            // 
            // GenerateReport
            // 
            this.GenerateReport.Location = new System.Drawing.Point(335, 114);
            this.GenerateReport.Name = "GenerateReport";
            this.GenerateReport.Size = new System.Drawing.Size(130, 39);
            this.GenerateReport.TabIndex = 4;
            this.GenerateReport.Text = "Generate Report";
            this.GenerateReport.UseVisualStyleBackColor = true;
            this.GenerateReport.Click += new System.EventHandler(this.GenerateReport_Click);
            // 
            // planAmountSummaryViewer
            // 
            this.planAmountSummaryViewer.ActiveViewIndex = -1;
            this.planAmountSummaryViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.planAmountSummaryViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.planAmountSummaryViewer.Location = new System.Drawing.Point(12, 159);
            this.planAmountSummaryViewer.Name = "planAmountSummaryViewer";
            this.planAmountSummaryViewer.Size = new System.Drawing.Size(776, 279);
            this.planAmountSummaryViewer.TabIndex = 5;
            // 
            // PlanAmountSummaryReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.planAmountSummaryViewer);
            this.Controls.Add(this.GenerateReport);
            this.Controls.Add(this.StartDatePicker);
            this.Controls.Add(this.EndDatePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PlanAmountSummaryReportForm";
            this.Text = "PlanAmountSummaryReportForm";
            this.Load += new System.EventHandler(this.PlanAmountSummaryReportForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker EndDatePicker;
        private System.Windows.Forms.DateTimePicker StartDatePicker;
        private System.Windows.Forms.Button GenerateReport;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer planAmountSummaryViewer;
    }
}