using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAND_COMMITEE
{
    public partial class SEARCH_By_FROMER_OWNER : Form
    {
        public SEARCH_By_FROMER_OWNER()
        {
            InitializeComponent();
        }
        public string val;
        private void SEARCH_By_FROMER_OWNER_Load(object sender, EventArgs e)
        {
            search_by_former_owner b = new search_by_former_owner();
            if (val != null)
                b.SetParameterValue("Former Owner Name(e.g: KAMANA JEAN MICHEL,...)", val);
            crystalReportViewer1.ReportSource = b;
            crystalReportViewer1.Zoom(75);
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            
        }
    }
}