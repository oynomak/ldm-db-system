using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAND_COMMITEE
{
    public partial class SurveyorWorkReport : Form
    {
        public SurveyorWorkReport()
        {
            InitializeComponent();
        }
        public string id;
        private void SurveyorWorkReport_Load(object sender, EventArgs e)
        {
            SurveyorWork s = new SurveyorWork();
            if (id != "")
                s.SetParameterValue("surveyor name",id);
            crystalReportViewer1.ReportSource = s;
            crystalReportViewer1.Zoom(60);
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            
        }
    }
}