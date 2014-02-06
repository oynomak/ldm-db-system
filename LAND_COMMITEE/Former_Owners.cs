using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace LAND_COMMITEE
{
    public partial class Former_Owners : Form
    {
        public Former_Owners()
        {
            InitializeComponent();
        }

        #region

        private Connection connect;
        private int current = 0;
        private long m_lImageFileLength = 0;
        private byte[] m_barrImg;

        internal Connection Connect
        {
            get { return connect; }
            set { connect = value; }
        }

        private void nombreEnregistr()
        {
            long sum = 0;
            int nbre = dataGridView1.Rows.Count;
            label13.Text = nbre.ToString();
            if (nbre > 0)
            {
                for (int j = 0; j < nbre; j++)
                {
                    sum = sum + (Convert.ToInt16(dataGridView1.Rows[j].Cells[3].Value));
                }
            }
            label15.Text = sum.ToString();
        }

        private void initializeValues()
        {
            try
            {
                dataGridView1.DataSource = Connect.getDataView("SELECT UPPER(dbo.FORMER_OWNERS.NOM) + ' ' + dbo.FORMER_OWNERS.PRENOM + ' ' + dbo.FORMER_OWNERS.AUTRE_NOM AS NAMES," 
                                                +"dbo.FORMER_OWNERS.ID_CARD, dbo.Activity.Description AS [MAIN ACTIVITY], dbo.FORMER_OWNERS.FORMER_LAND_SIZE AS [LAND SIZE(Ha)], "
                                                +"dbo.Cells.CellName AS CELL FROM dbo.FORMER_OWNERS INNER JOIN dbo.Cells ON dbo.FORMER_OWNERS.CELL = dbo.Cells.CellID INNER JOIN "
                                                +"dbo.Activity ON dbo.FORMER_OWNERS.MAIN_ACTIVITY = dbo.Activity.Id_Activity order by Names", "Former_Owner_2");

                dataGridView1.Columns[0].Width = 180;
                dataGridView1.Columns[1].Width = 110;
                dataGridView1.Columns[2].Width = 130;
                dataGridView1.Columns[3].Width = 120;
                dataGridView1.Columns[4].Width = 110;

                nombreEnregistr();

                comboBox_name.DataSource = connect.getDataSet("SELECT  ID_FORMER_OWNER, NOM + ' ' + PRENOM + ' ' + AUTRE_NOM AS former_owner FROM FORMER_OWNERS order by former_owner asc", "Former_Owner_3");
                comboBox_name.DisplayMember = "Former_Owner_3.former_owner";
                comboBox_name.ValueMember = "Former_Owner_3.ID_FORMER_OWNER";

                loadActivity(1);
                loadActivity(2);

                loadProvinces(1);
                loadDistricts(Convert.ToInt16(comboBox_Province.SelectedValue), 1);
                loadSectors(Convert.ToInt16(comboBox_District.SelectedValue), 1);
                loadCells(Convert.ToInt16(comboBox_Sector.SelectedValue), 1);

                loadProvinces(2);
                loadDistricts(Convert.ToInt16(comboBox_upd_Province.SelectedValue), 2);
                loadSectors(Convert.ToInt16(comboBox_upd_District.SelectedValue), 2);
                loadCells(Convert.ToInt16(comboBox_upd_Sector.SelectedValue), 2);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("An error occurred when trying to load data from the database: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadActivity(int key)
        {
            try
            {
                if (key == 1)
                {
                    comboBox_Activity.DataSource = connect.getDataSet("SELECT  id_activity, description FROM Activity order by description asc", "ACTIVITY_" + key);
                    comboBox_Activity.DisplayMember = "ACTIVITY_" + key + ".description";
                    comboBox_Activity.ValueMember = "ACTIVITY_" + key + ".id_Activity";
                }
                else
                {
                    comboBox_upd_Activity.DataSource = connect.getDataSet("SELECT  id_activity, description FROM Activity order by description asc", "ACTIVITY_" + key);
                    comboBox_upd_Activity.DisplayMember = "ACTIVITY_" + key + ".description";
                    comboBox_upd_Activity.ValueMember = "ACTIVITY_" + key + ".id_Activity";
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("An error occurred when trying to load Provinces from database: \n" + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadProvinces(int key)
        {
            try
            {
                if (key == 1)
                {
                    comboBox_Province.DataSource = connect.getDataSet("SELECT ID_PROVINCE,DESCRIPTION_PROVINCE FROM PROVINCE order by DESCRIPTION_PROVINCE asc", "Province_" + key);
                    comboBox_Province.ValueMember = "Province_" + key + ".ID_PROVINCE";
                    comboBox_Province.DisplayMember = "Province_" + key + ".DESCRIPTION_PROVINCE";
                }
                else
                {
                    comboBox_upd_Province.DataSource = connect.getDataSet("SELECT ID_PROVINCE,DESCRIPTION_PROVINCE FROM PROVINCE order by DESCRIPTION_PROVINCE asc", "Province_" + key);
                    comboBox_upd_Province.ValueMember = "Province_" + key + ".ID_PROVINCE";
                    comboBox_upd_Province.DisplayMember = "Province_" + key + ".DESCRIPTION_PROVINCE";
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("An error occurred when trying to load Provinces from database: \n" + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadDistricts(int province, int key)
        {
            try
            {
                if (key == 1)
                {
                    comboBox_District.DataSource = connect.getDataSet("SELECT ID_DISTRICT, DESCRIPTION_DISTRICT FROM DISTRICT WHERE  (ID_PROVINCE = '" + province + "') order by DESCRIPTION_DISTRICT asc", "District_" + key);
                    comboBox_District.DisplayMember = "District_" + key + ".DESCRIPTION_DISTRICT";
                    comboBox_District.ValueMember = "District_" + key + ".ID_DISTRICT";
                }
                else
                {
                    comboBox_upd_District.DataSource = connect.getDataSet("SELECT ID_DISTRICT, DESCRIPTION_DISTRICT FROM DISTRICT WHERE  (ID_PROVINCE = '" + province + "') order by DESCRIPTION_DISTRICT asc", "District_" + key);
                    comboBox_upd_District.DisplayMember = "District_" + key + ".DESCRIPTION_DISTRICT";
                    comboBox_upd_District.ValueMember = "District_" + key + ".ID_DISTRICT";
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("An error occurred when trying to load Districts from database: \n" + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadSectors(int district, int key)
        {
            try
            {
                if (key == 1)
                {
                    comboBox_Sector.DataSource = connect.getDataSet("SELECT ID_SECTEUR, DESCRIPTION_SECTEUR FROM SECTEUR WHERE (ID_DISTRICT = '" + district + "') order by DESCRIPTION_SECTEUR asc", "Sector_" + key);
                    comboBox_Sector.DisplayMember = "Sector_" + key + ".DESCRIPTION_SECTEUR";
                    comboBox_Sector.ValueMember = "Sector_" + key + ".ID_SECTEUR";
                }
                else
                {
                    comboBox_upd_Sector.DataSource = connect.getDataSet("SELECT ID_SECTEUR, DESCRIPTION_SECTEUR FROM SECTEUR WHERE (ID_DISTRICT = '" + district + "') order by DESCRIPTION_SECTEUR asc", "Sector_" + key);
                    comboBox_upd_Sector.DisplayMember = "Sector_" + key + ".DESCRIPTION_SECTEUR";
                    comboBox_upd_Sector.ValueMember = "Sector_" + key + ".ID_SECTEUR";
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("An error occurred when trying to load Sectors from database: \n" + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadCells(int sector, int key)
        {
            try
            {
                if (key == 1)
                {
                    comboBox_Cell.DataSource = connect.getDataSet("SELECT CellID, CellName FROM Cells WHERE (id_secteur = '" + sector + "') order by CellName asc", "Cell_" + key);
                    comboBox_Cell.DisplayMember = "Cell_" + key + ".CellName";
                    comboBox_Cell.ValueMember = "Cell_" + key + ".CellID";
                }
                else
                {
                    comboBox_upd_Cell.DataSource = connect.getDataSet("SELECT CellID, CellName FROM Cells WHERE (id_secteur = '" + sector + "') order by CellName asc", "Cell_" + key);
                    comboBox_upd_Cell.DisplayMember = "Cell_" + key + ".CellName";
                    comboBox_upd_Cell.ValueMember = "Cell_" + key + ".CellID";
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("An error occurred when trying to load Cells from database: \n" + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        protected void LoadImage(int pictureboxId)
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
                    if (pictureboxId == 0)
                        this.pictureBox.Image = Image.FromFile(strFn);
                    else this.pictureBox1.Image = Image.FromFile(strFn);
                    FileInfo fiImage = new FileInfo(strFn);
                    this.m_lImageFileLength = fiImage.Length;
                    FileStream fs = new FileStream(strFn, FileMode.Open, FileAccess.Read, FileShare.Read);
                    m_barrImg = new byte[Convert.ToInt32(this.m_lImageFileLength)];
                    int iBytesRead = fs.Read(m_barrImg, 0, Convert.ToInt32(this.m_lImageFileLength));
                    fs.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred when trying to load the picture: \n" + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getImage(string val)
        {
            SqlConnection con = connect.getCurrentConnection();
            try
            {
                SqlCommand cmdSelect = new SqlCommand("select photo from FORMER_OWNERS where ID_FORMER_OWNER=@ID", con);
                cmdSelect.Parameters.Add("@ID", SqlDbType.VarChar, 50);
                cmdSelect.Parameters["@ID"].Value = val;

                con.Open();
                pictureBox1.Image = null;

                byte[] barrImg = (byte[])cmdSelect.ExecuteScalar();
                string strfn = Convert.ToString(DateTime.Now.ToFileTime());
                FileStream fs = new FileStream(strfn, FileMode.CreateNew, FileAccess.Write);
                fs.Write(barrImg, 0, barrImg.Length);
                fs.Flush();
                fs.Close();
                pictureBox1.Image = Image.FromFile(strfn);

            }
            catch (Exception ex)
            {
                //MessageBox.Show("An error occurred when trying to load the picture: \n" + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void save()
        {
            try
            {
                if (connect.getCurrentConnection().State == ConnectionState.Closed)
                    connect.getCurrentConnection().Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connect.getCurrentConnection();

                if (command.Parameters.Count == 0)
                {
                    command.CommandText = "insert into Former_Owners(NOM,PRENOM,AUTRE_NOM,FORMER_LAND_SIZE,SEXE,CATEGORY,ID_CARD,CELL,MAIN_ACTIVITY,PHOTO)values(@NOM,@PRENOM,@AUTRE_NOM,@FORMER_LAND_SIZE,@SEXE,@CATEGORY,@ID_CARD,@CELL,@MAIN_ACTIVITY,@PHOTO )";
                    command.Parameters.Add("@PHOTO", System.Data.SqlDbType.Image);
                    command.Parameters.Add("@NOM", System.Data.SqlDbType.VarChar, 50);
                    command.Parameters.Add("@PRENOM", System.Data.SqlDbType.VarChar, 50);
                    command.Parameters.Add("@AUTRE_NOM", System.Data.SqlDbType.VarChar, 50);
                    command.Parameters.Add("@FORMER_LAND_SIZE", System.Data.SqlDbType.Float);
                    command.Parameters.Add("@SEXE", System.Data.SqlDbType.VarChar, 1);
                    command.Parameters.Add("@CATEGORY", System.Data.SqlDbType.SmallInt);
                    command.Parameters.Add("@ID_CARD", System.Data.SqlDbType.VarChar, 50);
                    command.Parameters.Add("@CELL", System.Data.SqlDbType.SmallInt);
                    command.Parameters.Add("@MAIN_ACTIVITY", System.Data.SqlDbType.SmallInt);
                }
                string gender = (rdbtGenderFemale.Checked == true) ? "F" : "M";
                command.Parameters["@PHOTO"].Value = this.m_barrImg;
                command.Parameters["@NOM"].Value = textBox_First_Name.Text;
                command.Parameters["@PRENOM"].Value = textBox_Last_Name.Text;
                command.Parameters["@AUTRE_NOM"].Value = textBox_Other_Name.Text;
                command.Parameters["@FORMER_LAND_SIZE"].Value = Convert.ToDouble(textBox_Former_Size.Text);
                command.Parameters["@SEXE"].Value = gender;
                command.Parameters["@CATEGORY"].Value = 1;
                command.Parameters["@ID_CARD"].Value = textBox_IDCard.Text;
                command.Parameters["@CELL"].Value = Convert.ToInt16(comboBox_Cell.SelectedValue);
                command.Parameters["@MAIN_ACTIVITY"].Value = Convert.ToInt16(comboBox_Activity.SelectedValue);

                int iresult = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred when trying to save the picture: \n" + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { connect.getCurrentConnection().Close(); }
        }

        private void update(string id)
        {
            try
            {
                if (connect.getCurrentConnection().State == ConnectionState.Closed)
                    connect.getCurrentConnection().Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connect.getCurrentConnection();

                if (command.Parameters.Count == 0)
                {
                    command.CommandText = "update Former_Owners set NOM=@NOM,PRENOM=@PRENOM,AUTRE_NOM=@AUTRE_NOM,FORMER_LAND_SIZE=@FORMER_LAND_SIZE,SEXE=@SEXE,ID_CARD=@ID_CARD,CELL=@CELL,MAIN_ACTIVITY=@MAIN_ACTIVITY,PHOTO=@PHOTO where ID_FORMER_OWNER=@ID";
                    command.Parameters.Add("@PHOTO", System.Data.SqlDbType.Image);
                    command.Parameters.Add("@NOM", System.Data.SqlDbType.VarChar, 50);
                    command.Parameters.Add("@PRENOM", System.Data.SqlDbType.VarChar, 50);
                    command.Parameters.Add("@AUTRE_NOM", System.Data.SqlDbType.VarChar, 50);
                    command.Parameters.Add("@FORMER_LAND_SIZE", System.Data.SqlDbType.Float);
                    command.Parameters.Add("@SEXE", System.Data.SqlDbType.VarChar, 1);
                    command.Parameters.Add("@ID_CARD", System.Data.SqlDbType.VarChar, 50);
                    command.Parameters.Add("@CELL", System.Data.SqlDbType.SmallInt);
                    command.Parameters.Add("@MAIN_ACTIVITY", System.Data.SqlDbType.SmallInt);
                    command.Parameters.Add("@ID", SqlDbType.Int);
                }
                string gender = (rdbt_upd_GenderFemale.Checked == true) ? "F" : "M";
                command.Parameters["@PHOTO"].Value = this.m_barrImg;
                command.Parameters["@NOM"].Value = textBox_upd_name.Text;
                command.Parameters["@PRENOM"].Value = textBox_upd_surname.Text;
                command.Parameters["@AUTRE_NOM"].Value = textBox_upd_other.Text;
                command.Parameters["@FORMER_LAND_SIZE"].Value = Convert.ToDouble(textBox_upd_size.Text);
                command.Parameters["@SEXE"].Value = gender;
                command.Parameters["@ID_CARD"].Value = textBox_upd_IDCard.Text;
                command.Parameters["@CELL"].Value = Convert.ToInt16(comboBox_upd_Cell.SelectedValue);
                command.Parameters["@MAIN_ACTIVITY"].Value = Convert.ToInt16(comboBox_upd_Activity.SelectedValue);
                command.Parameters["@ID"].Value = Convert.ToInt16(id);

                int iresult = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred when trying to save the picture: \n" + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { connect.getCurrentConnection().Close(); }
        }

        #endregion

        private void Former_Owners_Load(object sender, EventArgs e)
        {
            initializeValues();
            comboBox_Province.Visible = comboBox_District.Visible = comboBox_Cell.Visible = comboBox_Sector.Visible = true;
            comboBox_upd_Province.Visible = comboBox_upd_District.Visible = comboBox_upd_Cell.Visible = comboBox_upd_Sector.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_Former_Size.Text != "" && textBox_First_Name.Text.Trim() != "")
                {
                    DialogResult di = MessageBox.Show("Are you sure you want to SAVE?", "Quetion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (di == DialogResult.Yes)
                    {
                        save();
                        MessageBox.Show("Saved !");
                        button1_Click(sender, e);

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

        private void button1_Click(object sender, EventArgs e)
        {
            textBox_Other_Name.Text = textBox_Last_Name.Text = textBox_Former_Size.Text = textBox_First_Name.Text = "";
            pictureBox.Image = null;
        }

        private void comboBox_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_name.Text != "")
                {
                    DataView dv = connect.getDataView("SELECT dbo.FORMER_OWNERS.ID_FORMER_OWNER, dbo.FORMER_OWNERS.NOM, dbo.FORMER_OWNERS.PRENOM, "
                                                    + "dbo.FORMER_OWNERS.AUTRE_NOM, dbo.FORMER_OWNERS.FORMER_LAND_SIZE, dbo.FORMER_OWNERS.ID_CARD, "
                                                    + "dbo.FORMER_OWNERS.MAIN_ACTIVITY, dbo.FORMER_OWNERS.SEXE, dbo.Cells.CellID, dbo.SECTEUR.ID_SECTEUR, dbo.DISTRICT.ID_DISTRICT, "
                                                    + "dbo.PROVINCE.ID_PROVINCE FROM dbo.FORMER_OWNERS INNER JOIN dbo.Cells ON dbo.FORMER_OWNERS.CELL = dbo.Cells.CellID INNER JOIN "
                                                    + "dbo.SECTEUR ON dbo.Cells.id_secteur = dbo.SECTEUR.ID_SECTEUR INNER JOIN dbo.DISTRICT ON dbo.SECTEUR.ID_DISTRICT = dbo.DISTRICT.ID_DISTRICT INNER JOIN "
                                                    + "dbo.PROVINCE ON dbo.DISTRICT.ID_PROVINCE = dbo.PROVINCE.ID_PROVINCE WHERE (dbo.FORMER_OWNERS.ID_FORMER_OWNER = '" + Convert.ToInt16(comboBox_name.SelectedValue) + "')", "Former_Owner_4");
                    textBox_upd_name.DataBindings.Clear();
                    textBox_upd_name.DataBindings.Add("text", dv, "nom");
                    textBox_upd_surname.DataBindings.Clear();
                    textBox_upd_surname.DataBindings.Add("text", dv, "prenom");
                    textBox_upd_other.DataBindings.Clear();
                    textBox_upd_other.DataBindings.Add("text", dv, "autre_nom");
                    textBox_upd_size.DataBindings.Clear();
                    textBox_upd_size.DataBindings.Add("text", dv, "former_land_size");
                    textBox_upd_IDCard.DataBindings.Clear();
                    textBox_upd_IDCard.DataBindings.Add("text", dv, "id_card");
                    textBox_main_Act.DataBindings.Clear();
                    textBox_main_Act.DataBindings.Add("text", dv, "MAIN_ACTIVITY");
                    comboBox_upd_Activity.SelectedValue = Convert.ToInt16(textBox_main_Act.Text);
                    textBox_Gender.DataBindings.Clear();
                    textBox_Gender.DataBindings.Add("text", dv, "SEXE");
                    if ("F" == textBox_Gender.Text)
                        rdbt_upd_GenderFemale_Click(sender, e);
                    else rdbt_upd_GenderMale_Click(sender, e);

                    textBox_prov.DataBindings.Clear();
                    textBox_prov.DataBindings.Add("text", dv, "ID_PROVINCE");
                    comboBox_upd_Province.SelectedValue = Convert.ToInt16(textBox_prov.Text);

                    textBox_distr.DataBindings.Clear();
                    textBox_distr.DataBindings.Add("text", dv, "ID_DISTRICT");
                    comboBox_upd_District.SelectedValue = Convert.ToInt16(textBox_distr.Text);

                    textBox_sect.DataBindings.Clear();
                    textBox_sect.DataBindings.Add("text", dv, "ID_SECTEUR");
                    comboBox_upd_Sector.SelectedValue = Convert.ToInt16(textBox_sect.Text);

                    textBox_cell.DataBindings.Clear();
                    textBox_cell.DataBindings.Add("text", dv, "CellID");
                    comboBox_upd_Cell.SelectedValue = Convert.ToInt16(textBox_cell.Text);

                    getImage("" + comboBox_name.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("An error occurred when trying to load data from the database: \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rdbt_upd_GenderMale.Enabled = rdbt_upd_GenderFemale.Enabled = comboBox_upd_Sector.Enabled = comboBox_upd_Province.Enabled = comboBox_upd_District.Enabled = comboBox_upd_Cell.Enabled = comboBox_upd_Activity.Enabled = pictureBox1.Enabled = textBox_upd_IDCard.Enabled = btUpdLoadImage.Enabled = textBox_upd_surname.Enabled = textBox_upd_other.Enabled = textBox_upd_name.Enabled = button3.Enabled = true;
            btNext.Enabled = btPrevious.Enabled = comboBox_name.Enabled = button4.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //connect.executeMyQuery("update former_owners set NOM='" + textBox_upd_name.Text + "' ,PRENOM='" + textBox_upd_surname.Text + "' ,AUTRE_NOM='" + textBox_upd_other.Text + "' ,FORMER_LAND_SIZE='" + Convert.ToDouble(textBox_upd_size.Text) + "' where ID_FORMER_OWNER='" + Convert.ToInt16(comboBox_name.SelectedValue) + "'");//, CATEGORY='" + Convert.ToInt16(comboBox_upd_owner_category.SelectedValue) + "'
            update("" + comboBox_name.SelectedValue);
            button5_Click(sender, e);

            initializeValues();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            rdbt_upd_GenderMale.Enabled = rdbt_upd_GenderFemale.Enabled = comboBox_upd_Sector.Enabled = comboBox_upd_Province.Enabled = comboBox_upd_District.Enabled = comboBox_upd_Cell.Enabled = comboBox_upd_Activity.Enabled = pictureBox1.Enabled = textBox_upd_IDCard.Enabled = btUpdLoadImage.Enabled = textBox_upd_surname.Enabled = textBox_upd_other.Enabled = textBox_upd_name.Enabled = button3.Enabled = false;
            btNext.Enabled = btPrevious.Enabled = comboBox_name.Enabled = button4.Enabled = true;
            comboBox_name_SelectedIndexChanged(sender, e);
        }

        private void btPrevious_Click(object sender, EventArgs e)
        {
            previous(sender, e);
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            next(sender, e);
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            ReportForm r = new ReportForm();
            r.key = 1;
            r.MdiParent = this.MdiParent;
            r.Show();
        }

        private void rdbtGenderMale_Click(object sender, EventArgs e)
        {
            rdbtGenderFemale.Checked = false;
        }

        private void rdbtGenderFemale_Click(object sender, EventArgs e)
        {
            rdbtGenderMale.Checked = false;
        }

        private void comboBox_Province_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Province.SelectedValue != null)
            {
                loadDistricts(Convert.ToInt16(comboBox_Province.SelectedValue), 1);
            }
        }

        private void comboBox_District_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_District.SelectedValue != null)
            {
                loadSectors(Convert.ToInt16(comboBox_District.SelectedValue), 1);
            }
        }

        private void comboBox_Sector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Sector.SelectedValue != null)
            {
                loadCells(Convert.ToInt16(comboBox_Sector.SelectedValue), 1);
            }
        }

        private void btLoadImage_Click(object sender, EventArgs e)
        {
            LoadImage(0);
        }

        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {
            LoadImage(0);
        }

        private void rdbt_upd_GenderMale_Click(object sender, EventArgs e)
        {
            rdbt_upd_GenderMale.Checked = true;
            rdbt_upd_GenderFemale.Checked = false;
        }

        private void rdbt_upd_GenderFemale_Click(object sender, EventArgs e)
        {
            rdbt_upd_GenderFemale.Checked = true;
            rdbt_upd_GenderMale.Checked = false;
        }

        private void btUpdLoadImage_Click(object sender, EventArgs e)
        {
            LoadImage(1);
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            LoadImage(1);
        }

        private void comboBox_upd_Province_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_upd_Province.SelectedValue != null)
            {
                loadDistricts(Convert.ToInt16(comboBox_upd_Province.SelectedValue), 2);
            }
        }

        private void comboBox_upd_District_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_upd_District.SelectedValue != null)
            {
                loadSectors(Convert.ToInt16(comboBox_upd_District.SelectedValue), 2);
            }
        }

        private void comboBox_upd_Sector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_upd_Sector.SelectedValue != null)
            {
                loadCells(Convert.ToInt16(comboBox_upd_Sector.SelectedValue), 2);
            }
        }
    }
}