using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAND_COMMITEE
{
    public partial class list_owners_by_usage : Form
    {
        public list_owners_by_usage()
        {
            InitializeComponent();
        }
        public string i;
        private void list_owners_by_usage_Load(object sender, EventArgs e)
        {
            list_by_usage l = new list_by_usage();
            if (i != null)
                l.SetParameterValue("Usage (FARMING or CULTIVATION)", i);
            crystalReportViewer1.ReportSource = l;
            crystalReportViewer1.Zoom(75);
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            
        }
    }
}