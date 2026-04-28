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
    public partial class CoverageGapReportForm : Form
    {
        CoverageGap cg;
        public CoverageGapReportForm()
        {
            InitializeComponent();
        }

        private void GenerateReport_Click(object sender, EventArgs e)
        {
            cg.SetParameterValue(0, StartDatePicker);
            cg.SetParameterValue(1, EndDatePicker);
            coverageGapReportViewer.ReportSource = cg;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            cg = new CoverageGap();
        }
    }
}
