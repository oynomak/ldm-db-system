using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LAND_COMMITEE
{
    public partial class Result_Search_Land_Info : Form
    {
        public Result_Search_Land_Info()
        {
            InitializeComponent();
        }

        #region

        private Connection connect;
        public int cat = 0;
        public string key;
        public int perm = 0;

        internal Connection Connect
        {
            get { return connect; }
            set { connect = value; }
        }

        private void ClearAll()
        {
            textBox_CELLULE.Text = textBox_CELLULE_OWNER.Text = textBox_DISTRICT.Text = "";
            textBox_DISTRICT_OWNER.Text = textBox_FORMER_OWNER.Text = textBox_LAND_No.Text = "";
            textBox_LAND_SIZE.Text = textBox_No_IDENTITE.Text = textBox_OWNER_AUTRENOM.Text = "";
            textBox_OWNER_PRENOM.Text = textBox_PROV.Text = textBox_PROVINCE.Text = "";
            textBox_SECTEUR.Text = textBox_SECTEUR_OWNER.Text = textBox_SUPERVISOR.Text = "";
            textBox_USAGE.Text = textBox1.Text = "";
        }

        private void EnableDesable(int i)
        {
            if (i == 1)
            {
                comboBox_PROVINCE.Text = textBox_PROVINCE.Text;
                comboBox_DISTRICT.Text = textBox_DISTRICT_OWNER.Text;
                comboBox_SECTEUR.Text = textBox_SECTEUR_OWNER.Text;
                comboBox_CELLULE.Text = textBox_CELLULE_OWNER.Text;
                comboBox_usage.Visible = comboBox_PROVINCE.Visible = comboBox_DISTRICT.Visible = comboBox_CELLULE.Visible = comboBox_SECTEUR.Visible = true;
                comboBox_usage.Text = textBox_USAGE.Text;
                textBox_USAGE.Visible = textBox_PROVINCE.Visible = textBox_SECTEUR_OWNER.Visible = textBox_DISTRICT_OWNER.Visible = textBox_CELLULE_OWNER.Visible = false;
                textBox_LAND_SIZE.Enabled = textBox_USAGE.Enabled = textBox1.Enabled = textBox_OWNER_PRENOM.Enabled = textBox_OWNER_AUTRENOM.Enabled = textBox_No_IDENTITE.Enabled = true;
                textBox1.Focus();
                button_edit.Enabled = button_Search.Enabled = false;
                button_Save.Enabled = dataGridView_BOUNDARY.Enabled = true;
                dataGridView_BOUNDARY.Columns[0].ReadOnly = true;
                radioButton1.Enabled = radioButton2.Enabled = comboBox_category_New_Ben.Enabled = true;
                radioButton1.Checked = true;
                comboBox_FORMER_OWNER.Visible = comboBox_SUPERVISOR.Visible = true;
                comboBox_SUPERVISOR.Text = textBox_SUPERVISOR.Text;
                comboBox_FORMER_OWNER.Text = textBox_FORMER_OWNER.Text;
                textBox_SUPERVISOR.Visible = textBox_FORMER_OWNER.Visible = false;
            }
            else
            {
                textBox_USAGE.Visible = textBox_PROVINCE.Visible = textBox_SECTEUR_OWNER.Visible = textBox_DISTRICT_OWNER.Visible = textBox_CELLULE_OWNER.Visible = true;
                textBox_USAGE.Text = comboBox_usage.Text;
                comboBox_usage.Visible = comboBox_PROVINCE.Visible = comboBox_DISTRICT.Visible = comboBox_CELLULE.Visible = comboBox_SECTEUR.Visible = false;
                textBox_LAND_SIZE.Enabled = textBox_USAGE.Enabled = textBox1.Enabled = textBox_OWNER_PRENOM.Enabled = textBox_OWNER_AUTRENOM.Enabled = textBox_No_IDENTITE.Enabled = false;
                button_edit.Enabled = button_Search.Enabled = true;
                button_Save.Enabled = dataGridView_BOUNDARY.Enabled = false;
                radioButton1.Enabled = radioButton2.Enabled = comboBox_category_Former_Owner.Enabled = comboBox_category_New_Ben.Enabled = false;
                comboBox_FORMER_OWNER.Visible = comboBox_SUPERVISOR.Visible = false;
                textBox_SUPERVISOR.Visible = textBox_FORMER_OWNER.Visible = true;
            }
        }

        private void clearDataBinding()
        {
            textBox1.DataBindings.Clear();
            textBox_OWNER_PRENOM.DataBindings.Clear();
            textBox_OWNER_AUTRENOM.DataBindings.Clear();
            textBox_PROVINCE.DataBindings.Clear();
            textBox_DISTRICT_OWNER.DataBindings.Clear();
            textBox_SECTEUR_OWNER.DataBindings.Clear();
            textBox_CELLULE_OWNER.DataBindings.Clear();
            textBox_PROV.DataBindings.Clear();
            textBox_DISTRICT.DataBindings.Clear();
            textBox_SECTEUR.DataBindings.Clear();
            textBox_CELLULE.DataBindings.Clear();
            textBox_USAGE.DataBindings.Clear();
            textBox_LAND_SIZE.DataBindings.Clear();
            textBox_FORMER_OWNER.DataBindings.Clear();
            textBox_SUPERVISOR.DataBindings.Clear();
            textBox_No_IDENTITE.DataBindings.Clear();
            textBox_NUMREFERENCE.DataBindings.Clear();
            textBox_DATE.DataBindings.Clear();
            textBox_Category.DataBindings.Clear();
        }

        private void SelectAllInfo()
        {
            try
            {
                ClearAll();//clear textbox fields

                DataView dv = connect.getDataView("exec selectAllInfo '" + key + "'", "SelectAllInfo_1");

                clearDataBinding();//clear bindings
                //data binding
                textBox1.DataBindings.Add("text", dv, "nom");
                textBox_OWNER_PRENOM.DataBindings.Add("text", dv, "prenom");
                textBox_OWNER_AUTRENOM.DataBindings.Add("text", dv, "autre_nom");
                textBox_PROVINCE.DataBindings.Add("text", dv, "ProvinceOwner");
                textBox_DISTRICT_OWNER.DataBindings.Add("text", dv, "DistrictOwner");
                textBox_SECTEUR_OWNER.DataBindings.Add("text", dv, "sectorOwner");
                textBox_CELLULE_OWNER.DataBindings.Add("text", dv, "celluleOwner");
                textBox_PROV.DataBindings.Add("text", dv, "ProvinceLand");
                textBox_DISTRICT.DataBindings.Add("text", dv, "DistrictLand");
                textBox_SECTEUR.DataBindings.Add("text", dv, "SectorLand");
                textBox_CELLULE.DataBindings.Add("text", dv, "CelluleLand");
                textBox_USAGE.DataBindings.Add("text", dv, "Usage");
                textBox_LAND_SIZE.DataBindings.Add("text", dv, "LandSize");
                textBox_FORMER_OWNER.DataBindings.Add("text", dv, "FormerOwnerName");
                textBox_SUPERVISOR.DataBindings.Add("text", dv, "SupervisorName");
                textBox_No_IDENTITE.DataBindings.Add("text", dv, "noidentite");
                textBox_NUMREFERENCE.DataBindings.Add("text", dv, "numreference");
                textBox_DATE.DataBindings.Add("text", dv, "dateofcreation");
                textBox_Category.DataBindings.Add("text", dv, "cat");

                int i = textBox_DATE.Text.Length;
                if (i == 19)
                {
                    textBox_DATE.Text = textBox_DATE.Text.Substring(0, 10);
                }
                else if (i == 20)
                {
                    textBox_DATE.Text = textBox_DATE.Text.Substring(0, 10);
                }
                else textBox_DATE.Text = textBox_DATE.Text.Substring(0, 10);
                textBox_LAND_No.Text = textBox_search.Text = key.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured : \n" + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        //load values
        #region

        private void loadSurveyor()
        {
            comboBox_SUPERVISOR.DataSource = connect.getDataSet("SELECT  No_SUPERVISOR, upper(nom)+' '+prenom+' '+autre_nom as FullName FROM SUPERVISOR order by fullname asc", "Surveyor_1");
            comboBox_SUPERVISOR.DisplayMember = "Surveyor_1.FullName";
            comboBox_SUPERVISOR.ValueMember = "Surveyor_1.No_SUPERVISOR";
        }

        private void loadFormerOwner()
        {
            comboBox_FORMER_OWNER.DataSource = connect.getDataSet("SELECT  ID_FORMER_OWNER, UPPER(NOM) + ' ' + PRENOM + ' ' + AUTRE_NOM AS former_owner FROM FORMER_OWNERS order by former_owner asc", "FormerOwner_2");
            comboBox_FORMER_OWNER.DisplayMember = "FormerOwner_2.former_owner";
            comboBox_FORMER_OWNER.ValueMember = "FormerOwner_2.ID_FORMER_OWNER";
        }

        private void loadProvince()
        {
            comboBox_PROVINCE.DataSource = connect.getDataSet("SELECT  ID_PROVINCE, DESCRIPTION_PROVINCE FROM PROVINCE order by DESCRIPTION_PROVINCE asc", "Province_1");
            comboBox_PROVINCE.DisplayMember = "Province_1.DESCRIPTION_PROVINCE";
            comboBox_PROVINCE.ValueMember = "Province_1.ID_PROVINCE";
        }

        private void loadDistricts(int province)
        {
            comboBox_DISTRICT.DataSource = connect.getDataSet("SELECT ID_DISTRICT, DESCRIPTION_DISTRICT FROM DISTRICT WHERE  (ID_PROVINCE = '" + province + "') order by DESCRIPTION_DISTRICT asc", "District_2");
            comboBox_DISTRICT.DisplayMember = "District_2.DESCRIPTION_DISTRICT";
            comboBox_DISTRICT.ValueMember = "District_2.ID_DISTRICT";
        }

        private void loadSectors(int district)
        {
            comboBox_SECTEUR.DataSource = connect.getDataSet("SELECT SECTEUR.ID_SECTEUR, SECTEUR.DESCRIPTION_SECTEUR FROM SECTEUR INNER JOIN DISTRICT ON SECTEUR.ID_DISTRICT = DISTRICT.ID_DISTRICT WHERE (DISTRICT.ID_DISTRICT = '" + district + "') order by DESCRIPTION_SECTEUR asc", "Sector_2");
            comboBox_SECTEUR.DisplayMember = "Sector_2.DESCRIPTION_SECTEUR";
            comboBox_SECTEUR.ValueMember = "Sector_2.ID_SECTEUR";
        }

        private void loadCells(int sector)
        {
            comboBox_CELLULE.DataSource = connect.getDataSet("SELECT CellID, CellName FROM Cells WHERE (id_secteur = '" + sector + "') order by CellName asc", "Cell_2");
            comboBox_CELLULE.DisplayMember = "Cell_2.CellName";
            comboBox_CELLULE.ValueMember = "Cell_2.CellID";
        }

        private void loadFormerOwnerCategory()
        {
            comboBox_category_Former_Owner.DataSource = connect.getDataSet("SELECT idcategory, description FROM FormerOwnerCategory order by DESCRIPTION asc", "FormerOwnerCategory_1");
            comboBox_category_Former_Owner.DisplayMember = "FormerOwnerCategory_1.DESCRIPTION";
            comboBox_category_Former_Owner.ValueMember = "FormerOwnerCategory_1.idcategory";
        }

        private void loadNewBeneficiaryCategory()
        {
            comboBox_category_New_Ben.DataSource = connect.getDataSet("SELECT idcategory, description FROM BeneficiaryCategory order by DESCRIPTION asc", "BeneficiaryCategory_1");
            comboBox_category_New_Ben.DisplayMember = "BeneficiaryCategory_1.DESCRIPTION";
            comboBox_category_New_Ben.ValueMember = "BeneficiaryCategory_1.idcategory";
        }

        List<string> landNoList=null;
        int current = 0;
        private void loadLandList(){
            landNoList=connect.getListOfIdentifier("select land_no from land_info");
        }

        private void next(object sender, EventArgs e)
        {
            current = (current == landNoList.Count - 1) ? 0:(current + 1);
            textBox_search.Text=landNoList[current];
            button_Search_Click(sender,e);
        }

        private void previous(object sender, EventArgs e)
        {
            current = (current == 0) ? (landNoList.Count - 1) : (current-1);
            textBox_search.Text = landNoList[current];
            button_Search_Click(sender, e);
        }

        private void initializeValues()
        {
            loadSurveyor();
            loadFormerOwner();
            loadProvince();
            loadDistricts(Convert.ToInt16(comboBox_PROVINCE.SelectedValue));
            loadSectors(Convert.ToInt16(comboBox_DISTRICT.SelectedValue));
            loadCells(Convert.ToInt16(comboBox_SECTEUR.SelectedValue));
            loadFormerOwnerCategory();
            loadNewBeneficiaryCategory();
            loadLandList();
        }

        #endregion

        private void Result_Search_Land_Info_Load(object sender, EventArgs e)
        {
            initializeValues();

            // TODO: This line of code loads data into the 'lAND_COMMITEE_Data_Set.BOUNDARY_DETAILS' table. You can move, or remove it, as needed.
            this.bOUNDARY_DETAILSTableAdapter.FillBy_LAND_NO(this.lAND_COMMITEE_Data_Set.BOUNDARY_DETAILS, key);
            
            SelectAllInfo();

            if (textBox_PROV.Text == "")
                MessageBox.Show("No Land with LAND_NO " + key, "Information...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cat = 0;
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            if (perm == 1)
                MessageBox.Show("You do not have enough permission to do this task!\n\nContact your Administrator.", "Information...", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            else
            {
                this.EnableDesable(1);

            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                DialogResult di = MessageBox.Show("Are you sure you want to Modify those Information ?\nClick Yes to Confirm.", "Confirm...", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (di == DialogResult.Yes)
                {
                    int categ = 0;
                    if (cat == 1)
                    {
                        if (radioButton1.Checked == true)
                            categ = Convert.ToInt16(comboBox_category_New_Ben.SelectedValue);
                        else categ = Convert.ToInt16(comboBox_category_Former_Owner.SelectedValue);
                    }
                    this.EnableDesable(0);
                    string commandString = "EXEC UPDATE_LES_DONNEES_PAR_ADMINISTRATOR '" + textBox_NUMREFERENCE.Text + "','" + textBox1.Text + "','"
                        + textBox_OWNER_PRENOM.Text + "','" + textBox_OWNER_AUTRENOM.Text + "','" + textBox_No_IDENTITE.Text + "','"
                        + Convert.ToInt16(comboBox_PROVINCE.SelectedValue) + "','" + Convert.ToInt16(comboBox_DISTRICT.SelectedValue) + "','"
                        + Convert.ToInt16(comboBox_SECTEUR.SelectedValue) + "','" + Convert.ToInt16(comboBox_CELLULE.SelectedValue) + "','" + categ + "','"
                        + textBox_LAND_No.Text + "','" + comboBox_usage.SelectedItem + "','" + textBox_LAND_SIZE.Text + "','"
                        + Convert.ToInt16(comboBox_SUPERVISOR.SelectedValue) + "','" + Convert.ToInt16(comboBox_FORMER_OWNER.SelectedValue) + "' ";

                    connect.executeMyQuery(commandString);
                    Modifier_Boundary_DataGrid();
                    textBox_search.Text = textBox_LAND_No.Text;
                    button_Search_Click(sender, e);
                    cat = 0;
                }
            }
            else MessageBox.Show("Be sure that you have enter the name of the Land Owner\nand that the Land Size is not 0.", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            this.EnableDesable(0);
            dataGridView_BOUNDARY_DETAILS.EndEdit();
        }

        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            if (textBox_search.Text.Length == 7)
                button_Search.Enabled = true;
            else
                button_Search.Enabled = false;
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            this.key = textBox_search.Text;
            this.Result_Search_Land_Info_Load(sender, e);
        }

        private void textBox_search_Enter(object sender, EventArgs e)
        {
            this.AcceptButton = button_Search;
        }
        private void Modifier_Boundary_DataGrid()
        {
            DataSet myChangedDataset = this.lAND_COMMITEE_Data_Set.GetChanges();
            if (myChangedDataset != null)
            {
                int modifiedRows = this.bOUNDARY_DETAILSTableAdapter.Update(lAND_COMMITEE_Data_Set.BOUNDARY_DETAILS);
                this.lAND_COMMITEE_Data_Set.AcceptChanges();
            }
            else
            {
                this.lAND_COMMITEE_Data_Set.RejectChanges();
            }
        }

        private void comboBox_PROVINCE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_PROVINCE.SelectedValue != null)
            {
                loadDistricts(Convert.ToInt16(comboBox_PROVINCE.SelectedValue));
            }
        }

        private void comboBox_DISTRICT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_DISTRICT.SelectedValue != null)
            {
                loadSectors(Convert.ToInt16(comboBox_DISTRICT.SelectedValue));
            }
        }

        private void comboBox_SECTEUR_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_SECTEUR.Text != "")
            {
                loadCells(Convert.ToInt16(comboBox_SECTEUR.SelectedValue));
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                radioButton2.Checked = comboBox_category_Former_Owner.Enabled = false;
                comboBox_category_New_Ben.Enabled = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                radioButton1.Checked = comboBox_category_New_Ben.Enabled = false;
                comboBox_category_Former_Owner.Enabled = true;
            }
        }

        private void comboBox_category_New_Ben_SelectedIndexChanged(object sender, EventArgs e)
        {
            cat = 1;
        }

        private void comboBox_category_Former_Owner_SelectedIndexChanged(object sender, EventArgs e)
        {
            cat = 1;
        }

        private void dataGridView_BOUNDARY_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            dataGridView_BOUNDARY.CurrentRow.Cells[0].Value = textBox_LAND_No.Text;
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            next(sender,e);
        }

        private void btPrevious_Click(object sender, EventArgs e)
        {
            previous(sender, e);
        }
    }
}