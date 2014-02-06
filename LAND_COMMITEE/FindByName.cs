using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LAND_COMMITEE
{
    public partial class FindByName : Form
    {
        public FindByName()
        {
            InitializeComponent();
        }

        private Connection connect;

        internal Connection Connect
        {
            get { return connect; }
            set { connect = value; }
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            if (textBox_search.Text == " ")
                textBox_search.Text = "";
            if (textBox_search.Text.Trim().Length > 0)
                button_Search.Enabled = true;
            else
                button_Search.Enabled = false;
        }

        private void textBox_search_Enter(object sender, EventArgs e)
        {
            AcceptButton = button_Search;
        }

        private void RefreshFindName()
        {
            if (textBox_search.Text != "")
            {
                string com = "exec SelectOwnerName '" + textBox_search.Text + "'";
                connect.executeMyQuery(com);
            }
        }
        private void button_Search_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshFindName();
                dataGridView1.DataSource = Connect.getDataView("SELECT landno, fullname FROM FindByName", "FindByName_1");
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[2].Width = 200;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred when trying to load data from the database: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public int perm = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Form mdi = this.MdiParent;
            if (0 == dataGridView1.CurrentCell.ColumnIndex)
            {
                string a = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                Result_Search_Land_Info r = new Result_Search_Land_Info();
                r.key = a;
                r.perm = perm;
                r.MdiParent = mdi;
                r.Connect = connect;
                r.Show();
            }
        }
    }
}