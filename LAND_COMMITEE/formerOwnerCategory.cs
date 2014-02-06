using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAND_COMMITEE
{
    public partial class formerOwnerCategory : Form
    {
        public formerOwnerCategory()
        {
            InitializeComponent();
        }

        #region

        private Connection connect;
        private int current = 0;

        internal Connection Connect
        {
            get { return connect; }
            set { connect = value; }
        }

        private void initializeValues()
        {
            dataGridView1.DataSource = Connect.getDataView("select idcategory as ID,Description,Comment from FormerOwnerCategory", "FormerOwnerCategory");
            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 250;

            countColumns();

            comboBox_name.DataSource = connect.getDataSet("select idcategory ,Description,Comment from FormerOwnerCategory order by description", "FormerOwnerCategory_1");
            comboBox_name.DisplayMember = "FormerOwnerCategory_1.Description";
            comboBox_name.ValueMember = "FormerOwnerCategory_1.idcategory";
        }

        private void countColumns()
        {
            if (dataGridView1.Rows.Count > 0)
                label4.Text = Convert.ToString(dataGridView1.Rows.Count);
            else label4.Text = "0";
        }


        private void next(object sender, EventArgs e)
        {
            current = comboBox_name.SelectedIndex;
            current = (current == comboBox_name.Items.Count - 1) ? 0 : (current + 1);
            comboBox_name.SelectedIndex = current;
            comboBox_name_SelectedIndexChanged(sender, e);
        }

        private void previous(object sender, EventArgs e)
        {
            current = comboBox_name.SelectedIndex;
            current = (current == 0) ? (comboBox_name.Items.Count - 1) : (current - 1);
            comboBox_name.SelectedIndex = current;
            comboBox_name_SelectedIndexChanged(sender, e);
        }

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Trim() != "")
                {
                    DialogResult di = MessageBox.Show("Are you sure you want to Save this Category ?\nClick Yes to Confirm.", "Confirm...", System.Windows.Forms.MessageBoxButtons.YesNo);
                    if (di == DialogResult.Yes)
                    {
                        connect.executeMyQuery("insert into FormerOwnerCategory(description,comment) values('" + textBox1.Text + "','" + textBox2.Text + "')");
                        textBox1.Text = textBox2.Text = "";

                        initializeValues();
                    }
                }
                else MessageBox.Show("Fill all boxes before Saving!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred : \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void formerOwnerCategory_Load(object sender, EventArgs e)
        {
            try
            {
                initializeValues();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred when trying to load data from the database: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_name.Text != "")
                {
                    DataView dv = connect.getDataView("select Description,Comment from FormerOwnerCategory where idcategory='" + Convert.ToInt16(comboBox_name.SelectedValue) + "'", "FormerOwnerCategory_2");
                    textBox_upd_categName.DataBindings.Clear();
                    textBox_upd_categName.DataBindings.Add("text", dv, "description");
                    textBox_upd_categComment.DataBindings.Clear();
                    textBox_upd_categComment.DataBindings.Add("text", dv, "comment");
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("An error occurred when trying to load data from the database: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox_upd_categName.Enabled = textBox_upd_categComment.Enabled = button4.Enabled = false;
            btNext.Enabled = btPrevious.Enabled = comboBox_name.Enabled = button6.Enabled = true;
            comboBox_name_SelectedIndexChanged(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox_upd_categName.Enabled = textBox_upd_categComment.Enabled = button4.Enabled = true;
            btNext.Enabled = btPrevious.Enabled = comboBox_name.Enabled = button6.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connect.executeMyQuery("update FormerOwnerCategory set description='" + textBox_upd_categName.Text + "', comment='" + textBox_upd_categComment.Text + "' where idcategory='" + Convert.ToInt16(comboBox_name.SelectedValue) + "'");
            button5_Click(sender, e);

            initializeValues();
            comboBox_name.SelectedIndex = current;
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            next(sender, e);
        }

        private void btPrevious_Click(object sender, EventArgs e)
        {
            previous(sender, e);
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            ReportForm r = new ReportForm();
            r.key = 0;
            r.MdiParent = this.MdiParent;
            r.Show();
        }
    }
}