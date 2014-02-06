using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAND_COMMITEE
{
    public partial class beneficiary_list_by_sector : Form
    {
        public beneficiary_list_by_sector()
        {
            InitializeComponent();
        }
        public string val;
        private void beneficiary_list_by_sector_Load(object sender, EventArgs e)
        {
            ben_by_sector b = new ben_by_sector();
            if (val != null)
                b.SetParameterValue("sector",val);
            crystal_sector.ReportSource = b;
            crystal_sector.Zoom(60);
        }

        private void crystal_sector_Load(object sender, EventArgs e)
        {
            
        }
    }
}