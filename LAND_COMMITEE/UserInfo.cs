using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAND_COMMITEE
{
    public partial class UserInfo : Form
    {
        public UserInfo()
        {
            InitializeComponent();
        }

        private Connection connect;

        internal Connection Connect
        {
            get { return connect; }
            set { connect = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string user;
        private void UserInfo_Load(object sender, EventArgs e)
        {
            this.selectUserInfoTableAdapter.Fill(lAND_COMMITEE_Data_Set.SelectUserInfo,user);
            this.dataGridView1.DataSource = this.selectUserInfoBindingSource;
            if (dataGridView1.Rows.Count > 0)
            {
                textBox_nom.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[0].Value);
                textBox_prenom.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                textBox_createdon.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
                textBox_date_on.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                textBox_hour_on.Text = textBox_date_on.Text;
                textBox_date_out.Text = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
                textBox_hour_out.Text = textBox_date_out.Text;
            }
            textBox_createdon.Text = textBox_createdon.Text.Substring(0,10);
            textBox_date_on.Text = textBox_date_on.Text.Substring(0,10);
            textBox_date_out.Text = textBox_date_out.Text.Substring(0,10);
            textBox_hour_on.Text = textBox_hour_on.Text.Substring(11,5);
            textBox_hour_out.Text = textBox_hour_out.Text.Substring(11,5);
            if (textBox_date_out.Text.Equals("01/01/1900"))
            {
                textBox_date_out.Visible = textBox_hour_out.Visible = false;
                label7.Text = "   LOGIN NOW";
            }
            Security s=new Security();
            textBox_username.Text = s.encrypt((Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value)), "", 0);
        }
    }
}