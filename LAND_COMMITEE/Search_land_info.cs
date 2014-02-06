using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAND_COMMITEE
{
    public partial class Search_land_info : Form
    {
        public Search_land_info()
        {
            InitializeComponent();
        }

        public int perm = 0;

        private Connection connect;

        internal Connection Connect
        {
            get { return connect; }
            set { connect = value; }
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            Result_Search_Land_Info r = new Result_Search_Land_Info();
            r.key = textBox_search.Text;
            r.perm = perm;
            Form a = this.MdiParent;
            r.MdiParent = a;
            r.Connect = connect;
            r.Show();
            this.Close();
        }
    }
}