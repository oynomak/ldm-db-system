using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAND_COMMITEE
{
    public partial class SUPERVISOR : Form
    {
        public SUPERVISOR()
        {
            InitializeComponent();
        }

        #region

        private Connection connect;
        private int current = 0;
        private string photoFileName = "";

        internal Connection Connect
        {
            get { return connect; }
            set { connect = value; }
        }

        private void nombreEnregistr()
        {
            int nbre = dataGridView1.Rows.Count;
            label19.Text = nbre.ToString();
        }

        private void initializeValues()
        {
            try
            {
                dataGridView1.DataSource = Connect.getDataView("SELECT UPPER(dbo.SUPERVISOR.NOM)+' '+dbo.SUPERVISOR.PRENOM+' '+dbo.SUPERVISOR.AUTRE_NOM as Names, dbo.CATEG_SUPERVISOR.description as Category, dbo.SUPERVISOR.DOCUMENT_ID AS [Doc. ID] FROM dbo.SUPERVISOR INNER JOIN dbo.CATEG_SUPERVISOR ON dbo.SUPERVISOR.ID_CATEGORY = dbo.CATEG_SUPERVISOR.idcategory order by dbo.SUPERVISOR.NOM", "Surveyor_1");

                dataGridView1.Columns[0].Width = 240;
                dataGridView1.Columns[1].Width = 180;
                dataGridView1.Columns[2].Width = 120;

                nombreEnregistr();

                comboBox_name.DataSource = connect.getDataSet("SELECT dbo.SUPERVISOR.No_SUPERVISOR, UPPER(dbo.SUPERVISOR.NOM) + ' ' + dbo.SUPERVISOR.PRENOM + ' (' + dbo.CATEG_SUPERVISOR.description + ' )' AS Surveyor FROM dbo.SUPERVISOR INNER JOIN dbo.CATEG_SUPERVISOR ON dbo.SUPERVISOR.ID_CATEGORY = dbo.CATEG_SUPERVISOR.idcategory ORDER BY dbo.SUPERVISOR.NOM", "Surveyor_2");
                comboBox_name.DisplayMember = "Surveyor_2.Surveyor";
                comboBox_name.ValueMember = "Surveyor_2.No_SUPERVISOR";

                comboBox_surveyor_category.DataSource = connect.getDataSet("SELECT  idcategory, description FROM CATEG_SUPERVISOR order by description asc", "CATEG_SUPERVISOR_1");
                comboBox_surveyor_category.DisplayMember = "CATEG_SUPERVISOR_1.description";
                comboBox_surveyor_category.ValueMember = "CATEG_SUPERVISOR_1.idcategory";

                comboBox_upd_surveyor_category.DataSource = comboBox_surveyor_category.DataSource;
                comboBox_upd_surveyor_category.DisplayMember = "CATEG_SUPERVISOR_1.description";
                comboBox_upd_surveyor_category.ValueMember = "CATEG_SUPERVISOR_1.idcategory";
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred when trying to load data from the database: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void SUPERVISOR_Load(object sender, EventArgs e)
        {
            try
            {
                initializeValues();
                LoadNewPict();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred when trying to load data: \n" + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_name.Text != "")
                {
                    DataView dv = connect.getDataView("SELECT dbo.SUPERVISOR.NOM, dbo.SUPERVISOR.PRENOM, dbo.SUPERVISOR.AUTRE_NOM, dbo.CATEG_SUPERVISOR.idcategory,dbo.SUPERVISOR.DOCUMENT_ID FROM dbo.SUPERVISOR INNER JOIN dbo.CATEG_SUPERVISOR ON dbo.SUPERVISOR.ID_CATEGORY = dbo.CATEG_SUPERVISOR.idcategory WHERE (dbo.supervisor.no_supervisor = '" + Convert.ToInt16(comboBox_name.SelectedValue) + "')", "Surveyor_3");
                    textBox_upd_name.DataBindings.Clear();
                    textBox_upd_name.DataBindings.Add("text", dv, "nom");
                    textBox_upd_surname.DataBindings.Clear();
                    textBox_upd_surname.DataBindings.Add("text", dv, "prenom");
                    textBox_upd_other.DataBindings.Clear();
                    textBox_upd_other.DataBindings.Add("text", dv, "autre_nom");
                    textBox_upd_ID_Card.DataBindings.Clear();
                    textBox_upd_ID_Card.DataBindings.Add("text", dv, "DOCUMENT_ID");

                    textBox_surveyorCateg.DataBindings.Clear();
                    textBox_surveyorCateg.DataBindings.Add("text", dv, "idcategory");
                    comboBox_upd_surveyor_category.SelectedValue = Convert.ToInt16(textBox_surveyorCateg.Text);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("An error occurred when trying to load data from the database: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            r.key = 4;
            r.MdiParent = this.MdiParent;
            r.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox_Other_Name.Text = textBox_Last_Name.Text = textBox_First_Name.Text =textBox_IDCard.Text= "";
            this.pictureBox.Image = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_First_Name.Text.Trim() != "")
                {
                    DialogResult di = MessageBox.Show("Are you sure you want to SAVE?", "Quetion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (di == DialogResult.Yes)
                    {
                        Connect.executeMyQuery("exec INSERT_INTO_SUPERVISOR '" + textBox_First_Name.Text + "','" + textBox_Last_Name.Text + "','" + textBox_Other_Name.Text + "','" + Convert.ToInt16(comboBox_surveyor_category.SelectedValue) + "','"+textBox_IDCard.Text+"','"+photoFileName+"'");

                        MessageBox.Show("Saved !");
                        button3_Click(sender, e);

                        initializeValues();
                    }
                }
                else MessageBox.Show("Some boxes are Empty !\n\nFill all boxes before Saving.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred when trying to save: \n" + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox_upd_ID_Card.Enabled=comboBox_upd_surveyor_category.Enabled = textBox_upd_surname.Enabled = textBox_upd_other.Enabled = textBox_upd_name.Enabled = button4.Enabled = false;
            btNext.Enabled = btPrevious.Enabled = comboBox_name.Enabled = button6.Enabled = true;
            comboBox_name_SelectedIndexChanged(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connect.executeMyQuery("update SUPERVISOR set NOM='" + textBox_upd_name.Text + "' ,PRENOM='" + textBox_upd_surname.Text + "' ,AUTRE_NOM='" + textBox_upd_other.Text + "' ,DOCUMENT_ID='" + textBox_upd_ID_Card.Text + "' ,ID_CATEGORY='" + Convert.ToInt16(comboBox_upd_surveyor_category.SelectedValue) + "' where no_supervisor='" + Convert.ToInt16(comboBox_name.SelectedValue) + "'");
            button5_Click(sender, e);

            initializeValues();
            comboBox_name.SelectedIndex = current;
            comboBox_name_SelectedIndexChanged(sender, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox_upd_ID_Card.Enabled = comboBox_upd_surveyor_category.Enabled = textBox_upd_surname.Enabled = textBox_upd_other.Enabled = textBox_upd_name.Enabled = button4.Enabled = true;
            btNext.Enabled = btPrevious.Enabled = comboBox_name.Enabled = button6.Enabled = false;
        }

        public void ShowMyImage()
        {
            try
            {
                this.openFileDialog1.Filter = "Jpeg Files (.jpg ou .jpeg)|*.jpg;*.jpeg|Bmp Files (.bmp)|*.bmp|Gif files (.gif)|*.gif";
                this.openFileDialog1.Multiselect = true;
                this.openFileDialog1.Title = "Choose a Picture";
                openFileDialog1.FileName = "";
                string strFn = "";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    strFn = this.openFileDialog1.FileName;
                    this.pictureBox.Image = Image.FromFile(strFn);
                    photoFileName = strFn.Substring(strFn.LastIndexOf("\\")+1);
                    MessageBox.Show(photoFileName);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred when trying to load the picture: \n" + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadNewPict()
        {
            pictureBox.Image = Image.FromFile(@""+Application.StartupPath+"\\default.jpg");
            //(System.Environment.GetFolderPath(Environment.SpecialFolder.MyComputer)
        }

        private void btLoadImage_Click(object sender, EventArgs e)
        {
            ShowMyImage();
        }

        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            ShowMyImage();
        }
    }
}