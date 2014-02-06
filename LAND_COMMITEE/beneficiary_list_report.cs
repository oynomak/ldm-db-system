using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAND_COMMITEE
{
    public partial class beneficiary_list_report : Form
    {
        public beneficiary_list_report()
        {
            InitializeComponent();
        }
        public string val;
        private void beneficiary_list_report_Load(object sender, EventArgs e)
        {
            Beneficiary_List b = new Beneficiary_List();
            if(val!=null)
                b.SetParameterValue("district",val);
            crystal_rpt_ben_list_vi.ReportSource = b;
            crystal_rpt_ben_list_vi.Zoom(60);
        }

        private void crystal_rpt_ben_list_vi_Load(object sender, EventArgs e)
        {
            
        }

    }
}