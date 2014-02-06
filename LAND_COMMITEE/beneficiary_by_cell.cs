using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAND_COMMITEE
{
    public partial class beneficiary_by_cell : Form
    {
        public beneficiary_by_cell()
        {
            InitializeComponent();
        }
        public string val;
        private void beneficiary_by_cell_Load(object sender, EventArgs e)
        {
            ben_list_by_cell b = new ben_list_by_cell();
            if (val != null)
                b.SetParameterValue("cell", val);
            crystal_cell.ReportSource = b;
            crystal_cell.Zoom(60);
        }

        private void crystal_cell_Load(object sender, EventArgs e)
        {
            
        }
    }
}