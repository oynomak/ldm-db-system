using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAND_COMMITEE
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        #region

        public int key;

        #endregion

        private void ReportForm_Load(object sender, EventArgs e)
        {
            if (key == 0)
            {
                this.Text = "LAND COMMITEE: List of category of former owners";
                CrystalReport_FormerOwnerCategoryList c = new CrystalReport_FormerOwnerCategoryList();
                crystalReportViewer1.ReportSource = c;
            }
            else if (key == 1)
            {
                this.Text = "LAND COMMITEE: List of former owners";
                FormerOwnerList c = new FormerOwnerList();
                crystalReportViewer1.ReportSource = c;
            }
            else if (key == 2)
            {
                this.Text = "LAND COMMITEE: List of category of new owners";
                CrystalReport_ListOfNewBeneficiaryCategory c = new CrystalReport_ListOfNewBeneficiaryCategory();
                crystalReportViewer1.ReportSource = c;
            }
            else if (key == 3)
            {
                this.Text = "LAND COMMITEE: List of category of Surveyor";
                CrystalReport_ListOfSurveyorCategory c = new CrystalReport_ListOfSurveyorCategory();
                crystalReportViewer1.ReportSource = c;
            }
            else if (key == 4)
            {
                this.Text = "LAND COMMITEE: List of Surveyor";
                SurveyorsList c = new SurveyorsList();
                crystalReportViewer1.ReportSource = c;
            }
        }
    }
}