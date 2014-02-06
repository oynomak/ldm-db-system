using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAND_COMMITEE
{
    public partial class BenList_BY_NewBenCategoryRPT : Form
    {
        public BenList_BY_NewBenCategoryRPT ( )
        {
            InitializeComponent();
        }
        public int key=0;
        private void BenList_BY_NewBenCategoryRPT_Load (object sender, EventArgs e)
        {
            CrystalReport_Ben_By_NewBeneficiary_Category cry = new CrystalReport_Ben_By_NewBeneficiary_Category();
            cry.SetParameterValue("key",key);
            crystalReportViewer1.ReportSource = cry;
        }
    }
}