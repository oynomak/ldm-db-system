using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAND_COMMITEE
{
    public partial class NotCheckedByAdministrator : Form
    {
        public NotCheckedByAdministrator()
        {
            InitializeComponent();
        }

        #region

        private Connection connect;

        public string user;

        internal Connection Connect
        {
            get { return connect; }
            set { connect = value; }
        }

        #endregion

        private void NotCheckedByAdministrator_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = connect.getDataView("SELECT  LAND_No, byWho FROM LAND_INFO WHERE (Checked = 0)", "NotCheckedByAdministrator");
            label2.Text = dataGridView1.Rows.Count.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Form mdi = this.MdiParent;
            if (0 == dataGridView1.CurrentCell.ColumnIndex)
            {
                string a = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                Result_Search_Land_Info r = new Result_Search_Land_Info();
                r.Connect = connect;
                r.key = a;
                r.MdiParent = mdi;
                r.Show();
            }
            if (1 == dataGridView1.CurrentCell.ColumnIndex)
            {
                int y = dataGridView1.Location.Y;
                int x = dataGridView1.Location.X;
                string a = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
                UserInfo u = new UserInfo();
                u.Connect = connect;
                u.user = a;
                u.SetDesktopLocation((x + 600), (y + 270));
                u.MdiParent = mdi;
                u.Show();
            }
        }

        private void NotCheckedByAdministrator_MouseHover(object sender, EventArgs e)
        {
            NotCheckedByAdministrator_Load(sender, e);
        }

        private void dataGridView1_MouseHover(object sender, EventArgs e)
        {
            NotCheckedByAdministrator_Load(sender, e);
        }
    }
}