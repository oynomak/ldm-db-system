using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAND_COMMITEE
{
    public partial class FormerOwnerListForm : Form
    {
        public FormerOwnerListForm()
        {
            InitializeComponent();
        }

        private void FormerOwnerListForm_Load(object sender, EventArgs e)
        {
            FormerOwnerList f = new FormerOwnerList();
            crystalReportViewer1.ReportSource = f;
            crystalReportViewer1.Zoom(60);
            
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            
        }
    }
}