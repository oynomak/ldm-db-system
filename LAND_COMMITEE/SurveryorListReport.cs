using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAND_COMMITEE
{
    public partial class SurveryorListReport : Form
    {
        public SurveryorListReport()
        {
            InitializeComponent();
        }

        private void SurveryorListReport_Load(object sender, EventArgs e)
        {
            SurveyorsList s = new SurveyorsList();
            crystalReportViewer1.ReportSource = s;
            crystalReportViewer1.Zoom(60);
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            
        }
    }
}