using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;

namespace Health_Insurance_System
{
    public partial class PlanAmountSummaryReportForm : Form
    {
        PlanAmountSummary pas;
        public PlanAmountSummaryReportForm()
        {
            InitializeComponent();
        }

        private void PlanAmountSummaryReportForm_Load(object sender, EventArgs e)
        {
            pas = new PlanAmountSummary();
        }

        private void GenerateReport_Click(object sender, EventArgs e)
        {
            pas.SetParameterValue(0, StartDatePicker);
            pas.SetParameterValue(1, EndDatePicker);
            planAmountSummaryViewer.ReportSource = pas;
        }
    }
}
