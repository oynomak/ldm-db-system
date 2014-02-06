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
    public partial class LAND_INFORMATION : Form
    {
        public LAND_INFORMATION ( )
        {
            InitializeComponent();
        }

        public string title;
        public string district;
        private int iRowIndex = 0;

        #region FONCTION

        private void ResetControls_Fn ( )
        {
            comboBox_LAND_DISTRICT.ResetText();
            comboBox_LAND_DISTRICT.Text = "---Select a District---";
            comboBox_LAND_SECTEUR.ResetText();
            comboBox_LAND_SECTEUR.Text = "---Select a Sector---";
            //textBox_CELLULE.ResetText();
            textBox_LAND_No.ResetText();
            textBox_OWNER_NAME.ResetText();
            textBox_OWNER_PRENOM.ResetText();
            textBox_OWNER_AUTRENOM.ResetText();
            textBox_No_IDENTITE.ResetText();
            comboBox_PROVINCE.ResetText();
            //comboBox_DISTRICT.ResetText();
            //comboBox_DISTRICT.Text = "---Select a District---";
            comboBox_SECTEUR.ResetText();
            comboBox_SECTEUR.Text = "---Select a Sector---";
            //textBox_CELLULE_OWNER.ResetText();
            comboBox_USAGE.ResetText();
            comboBox_USAGE.Text = "--- Select Usage ---";
            textBox_LAND_SIZE.ResetText();
            comboBox_FORMER_OWNER.ResetText();
            comboBox_FORMER_OWNER.Text = "-- Select a Former Owner --";
            comboBox_SUPERVISOR.ResetText();
            comboBox_SUPERVISOR.Text = "-- Select a Supervisor --";
            //comboBox3.ResetText();
            comboBox3.Refresh();
        }

        private int TextBox_Status ( )
        {
            if (textBox_LAND_SIZE.Text != "" && textBox_No_IDENTITE.Text != "" && textBox_OWNER_NAME.Text != "" && textBox_LAND_No.Text != "" && comboBox_USAGE.Text != "---Select Usage---")
            {
                //DataTable myChangedDataTable = this.lAND_COMMITEE_Data_Set.BOUNDARY_DETAILS.GetChanges();
                //if (myChangedDataTable != null)
                return 1;
                //else return 2;
            }
            else return 0;
        }

        private void Secteur_De_District ( )
        {
            if (comboBox_LAND_DISTRICT.Text == "Gatsibo")
            {
                comboBox_LAND_SECTEUR.Items.Clear();
                comboBox_LAND_SECTEUR.Items.Add("Gasange");
                comboBox_LAND_SECTEUR.Items.Add("Gatsibo");
                comboBox_LAND_SECTEUR.Items.Add("Gitoki");
                comboBox_LAND_SECTEUR.Items.Add("Kabarore");
                comboBox_LAND_SECTEUR.Items.Add("Kageyo");
                comboBox_LAND_SECTEUR.Items.Add("Kiramuruzi");
                comboBox_LAND_SECTEUR.Items.Add("Kiziguro");
                comboBox_LAND_SECTEUR.Items.Add("Muhura");
                comboBox_LAND_SECTEUR.Items.Add("Murambi");
                comboBox_LAND_SECTEUR.Items.Add("Ngarama");
                comboBox_LAND_SECTEUR.Items.Add("Nyagihanga");
                comboBox_LAND_SECTEUR.Items.Add("Remera");
                comboBox_LAND_SECTEUR.Items.Add("Rugarama");
                comboBox_LAND_SECTEUR.Items.Add("Rwimbogo");
            }
            else if (comboBox_LAND_DISTRICT.Text == "Kayonza")
            {
                comboBox_LAND_SECTEUR.Items.Clear();
                comboBox_LAND_SECTEUR.Items.Add("Gahini");
                comboBox_LAND_SECTEUR.Items.Add("Kabare");
                comboBox_LAND_SECTEUR.Items.Add("Kabarondo");
                comboBox_LAND_SECTEUR.Items.Add("Mukarange");
                comboBox_LAND_SECTEUR.Items.Add("Murama");
                comboBox_LAND_SECTEUR.Items.Add("Murundi");
                comboBox_LAND_SECTEUR.Items.Add("Mwiri");
                comboBox_LAND_SECTEUR.Items.Add("Ndego");
                comboBox_LAND_SECTEUR.Items.Add("Nyamirama");
                comboBox_LAND_SECTEUR.Items.Add("Rukara");
                comboBox_LAND_SECTEUR.Items.Add("Ruramira");
                comboBox_LAND_SECTEUR.Items.Add("Rwinkavu");
            }
            else if (comboBox_LAND_DISTRICT.Text == "Nyagatare")
            {
                comboBox_LAND_SECTEUR.Items.Clear();
                comboBox_LAND_SECTEUR.Items.Add("Gatunda");
                comboBox_LAND_SECTEUR.Items.Add("Karama");
                comboBox_LAND_SECTEUR.Items.Add("Karangazi");
                comboBox_LAND_SECTEUR.Items.Add("Katabagemu");
                comboBox_LAND_SECTEUR.Items.Add("Kiyombe");
                comboBox_LAND_SECTEUR.Items.Add("Matimba");
                comboBox_LAND_SECTEUR.Items.Add("Mimuli");
                comboBox_LAND_SECTEUR.Items.Add("Mukama");
                comboBox_LAND_SECTEUR.Items.Add("Musheli");
                comboBox_LAND_SECTEUR.Items.Add("Nyagatare");
                comboBox_LAND_SECTEUR.Items.Add("Rukomo");
                comboBox_LAND_SECTEUR.Items.Add("Rwempasha");
                comboBox_LAND_SECTEUR.Items.Add("Rwimiyaga");
                comboBox_LAND_SECTEUR.Items.Add("Tabagwe");
            }
            else if (comboBox_LAND_DISTRICT.Text == "Kirehe")
            {
                comboBox_LAND_SECTEUR.Items.Clear();
                comboBox_LAND_SECTEUR.Items.Add("Gahara");
                comboBox_LAND_SECTEUR.Items.Add("Gatore");
                comboBox_LAND_SECTEUR.Items.Add("Kigarama");
                comboBox_LAND_SECTEUR.Items.Add("Kigina");
                comboBox_LAND_SECTEUR.Items.Add("Kirehe");
                comboBox_LAND_SECTEUR.Items.Add("Mahama");
                comboBox_LAND_SECTEUR.Items.Add("Mpaga");
                comboBox_LAND_SECTEUR.Items.Add("Musaza");
                comboBox_LAND_SECTEUR.Items.Add("Mushikiri");
                comboBox_LAND_SECTEUR.Items.Add("Nasho");
                comboBox_LAND_SECTEUR.Items.Add("Nyamugali");
                comboBox_LAND_SECTEUR.Items.Add("Nyarubuye");
            }
        }

        private void Insert_Into_Land_Owner ( )
        {
            string No_Identite = textBox_No_IDENTITE.Text;
            string Owner_Nom = textBox_OWNER_NAME.Text;
            string Owner_Prenom = textBox_OWNER_PRENOM.Text;
            string Owner_AutreNom = textBox_OWNER_AUTRENOM.Text;
            int LandProvince = Convert.ToInt32(comboBox_PROVINCE.SelectedValue);
            int LandDistrict = Convert.ToInt32(comboBox_DISTRICT.SelectedValue);
            int LandSector = Convert.ToInt16(comboBox_SECTEUR.SelectedValue);
            int LandCellule = Convert.ToInt16(comboBox_CELLULE.SelectedValue);
            int modifiedRows = this.lAND_OWNERTableAdapter.Update(this.lAND_COMMITEE_Data_Set.LAND_OWNER.AddLAND_OWNERRow(No_Identite, Owner_Nom,
                Owner_Prenom, Owner_AutreNom, LandProvince, LandDistrict, LandSector, LandCellule));
        }

        private void Insert_Into_Land_Info ( )
        {
            string Land_No = textBox_LAND_No.Text;
            int LandDistrict = Convert.ToInt16(comboBox_LAND_DISTRICT.SelectedValue);
            int LandSector = Convert.ToInt16(comboBox_LAND_SECTEUR.SelectedValue);
            int LandCellule = Convert.ToInt16(comboBox_Land_CELLULE.SelectedValue);
            int Land_Former_Owner = Convert.ToInt32(comboBox_FORMER_OWNER.SelectedValue);
            string Land_usage = comboBox_USAGE.Text;
            double Land_Size = Convert.ToDouble(textBox_LAND_SIZE.Text);
            int Land_NumReference = Convert.ToInt32(comboBox3.SelectedValue);
            int Land_Supervisor = Convert.ToInt32(comboBox_SUPERVISOR.SelectedValue);
            int modifiedRows = this.lAND_OWNERTableAdapter.Update(this.lAND_COMMITEE_Data_Set.LAND_INFO.AddLAND_INFORow(Land_No, "EASTERN PROVINCE", LandDistrict, LandSector, LandCellule, Land_usage, Land_Size, Land_Supervisor, Land_Former_Owner, Land_NumReference));
        }

        private void fnajouter_BOUNDARY_DETAILS ( )
        {
            try
            {
                DataSet myChangedDataset = this.lAND_COMMITEE_Data_Set.GetChanges();

                if (myChangedDataset != null)
                {
                    int modifiedRows = this.bOUNDARY_DETAILSTableAdapter.Update(lAND_COMMITEE_Data_Set.BOUNDARY_DETAILS);
                    this.lAND_COMMITEE_Data_Set.AcceptChanges();
                }
                else
                {
                    MessageBox.Show("Boundary Details are not inserted !\n -->>CLICK OK TO CONTINUE.", "NO BOUNDARY DETAILS!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred updating the database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.lAND_COMMITEE_Data_Set.RejectChanges();
            }
        }

        private void fnSupprimer_BOUNDARY_DETAILS ( )
        {
            try
            {
                DialogResult dr = MessageBox.Show("Etes Vous sure de Vouloir Supprimer cette ligne ? ", "Confirmer la suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    DataTable tbl = new DataTable("BOUNDARY_DETAILS");
                    tbl = this.lAND_COMMITEE_Data_Set.Tables[0];
                    this.iRowIndex = this.dataGridView_BOUNDARY_DETAILS.CurrentRow.Index;
                    int i = this.iRowIndex;
                    tbl.Rows[i].Delete();
                    this.bOUNDARY_DETAILSTableAdapter.Update(lAND_COMMITEE_Data_Set.BOUNDARY_DETAILS);
                    //this.fnRefresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured !\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //this.fnRefresh();
            }
        }

        private void fnModifier_BOUNDARY_DETAILS ( )
        {
            try
            {
                DataSet myChangedDataset = this.lAND_COMMITEE_Data_Set.GetChanges();
                if (myChangedDataset != null)
                {
                    DialogResult dr = MessageBox.Show("Are you sure you want to Modify the information ? ", "Confirm...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        int modifiedRows = this.bOUNDARY_DETAILSTableAdapter.Update(lAND_COMMITEE_Data_Set.BOUNDARY_DETAILS);
                        MessageBox.Show("The Informations was successifully Modified.", "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                        this.lAND_COMMITEE_Data_Set.AcceptChanges();
                    }
                    fnRefresh_BOUNDARY_DETAILS();
                }
                else
                {
                    MessageBox.Show("Nothing to Modify !", "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred updating the database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.lAND_COMMITEE_Data_Set.RejectChanges();
            }
        }

        private void add_Info ( )
        {
            int categ=0;
            if (radioButton1.Checked == true)
                categ = Convert.ToInt16(comboBox_category_New_Ben.SelectedValue);
            else if (radioButton2.Checked == true)
                categ = Convert.ToInt16(comboBox_category_Former_Owner.SelectedValue);
            string com = "exec dbo.Insert_Info '" + textBox_No_IDENTITE.Text + "','" + textBox_OWNER_NAME.Text + "','" + textBox_OWNER_PRENOM.Text + "','" + textBox_OWNER_AUTRENOM.Text + "','" 
                + Convert.ToInt32(comboBox_PROVINCE.SelectedValue) + "','" + Convert.ToInt32(comboBox_DISTRICT.SelectedValue) + "','" 
                + comboBox_SECTEUR.SelectedValue + "','" + comboBox_CELLULE.SelectedValue + "','" + textBox_LAND_No.Text 
                + "','EASTERN PROVINCE','" + Convert.ToInt16(comboBox_LAND_DISTRICT.SelectedValue) + "','" 
                + Convert.ToInt16(comboBox_LAND_SECTEUR.SelectedValue) + "','" + Convert.ToInt16(comboBox_Land_CELLULE.SelectedValue) 
                + "','" + Convert.ToInt32(comboBox_FORMER_OWNER.SelectedValue) + "','" + comboBox_USAGE.Text + "','" 
                + Convert.ToDouble(textBox_LAND_SIZE.Text) + "','" + Convert.ToInt32(comboBox3.Text) + "','" 
                + Convert.ToInt32(comboBox_SUPERVISOR.SelectedValue) + "','" + user + "','" + categ + "'";
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LAND_COMMITEE;Integrated Security=True");
            con.Open();
            SqlCommand SQLcom = new SqlCommand(com, con);
            SQLcom.ExecuteNonQuery();
            SQLcom.Dispose();
            con.Close();
        }

        private void fnRefresh_BOUNDARY_DETAILS ( )
        {
            this.lAND_COMMITEE_Data_Set.Clear();
            this.bOUNDARY_DETAILSTableAdapter.Fill(this.lAND_COMMITEE_Data_Set.BOUNDARY_DETAILS);
            this.dataGridView_BOUNDARY_DETAILS.DataSource = this.lAND_COMMITEE_Data_Set.Tables["BOUNDARY_DETAILS"].DefaultView;
        }
        #endregion

        private void LAND_INFORMATION_Load (object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lAND_COMMITEE_Data_Set.FormerOwnerCategory' table. You can move, or remove it, as needed.
            this.formerOwnerCategoryTableAdapter.Fill(this.lAND_COMMITEE_Data_Set.FormerOwnerCategory);
            // TODO: This line of code loads data into the 'lAND_COMMITEE_Data_Set.BeneficiaryCategory' table. You can move, or remove it, as needed.
            this.beneficiaryCategoryTableAdapter.Fill(this.lAND_COMMITEE_Data_Set.BeneficiaryCategory);
            // TODO: This line of code loads data into the 'lAND_COMMITEE_Data_Set.DISTRICT_Land' table. You can move, or remove it, as needed.
            this.dISTRICT_LandTableAdapter.Fill(this.lAND_COMMITEE_Data_Set.DISTRICT_Land);

            // TODO: This line of code loads data into the 'lAND_COMMITEE_Data_Set.Select_Max_NumRef' table. You can move, or remove it, as needed.
            this.select_Max_NumRefTableAdapter.Fill(this.lAND_COMMITEE_Data_Set.Select_Max_NumRef);
            // TODO: This line of code loads data into the 'lAND_COMMITEE_Data_Set.Select_Max_NumRef' table. You can move, or remove it, as needed.
            this.select_Max_NumRefTableAdapter.Fill(this.lAND_COMMITEE_Data_Set.Select_Max_NumRef);
            // TODO: This line of code loads data into the 'lAND_COMMITEE_Data_Set.LAND_INFO' table. You can move, or remove it, as needed.
            this.lAND_INFOTableAdapter.Fill(this.lAND_COMMITEE_Data_Set.LAND_INFO);
            // TODO: This line of code loads data into the 'lAND_COMMITEE_Data_Set.FORMER_OWNERS' table. You can move, or remove it, as needed.
            this.fORMER_OWNERSTableAdapter.Fill(this.lAND_COMMITEE_Data_Set.FORMER_OWNERS);

            // TODO: This line of code loads data into the 'lAND_COMMITEE_Data_Set.PROVINCE' table. You can move, or remove it, as needed.
            this.pROVINCE_TableAdapter.Fill(this.lAND_COMMITEE_Data_Set.PROVINCE);
            // TODO: This line of code loads data into the 'lAND_COMMITEE_Data_Set.DISTRICT' table. You can move, or remove it, as needed.
            this.dISTRICT_TableAdapter.FillBy_PROVINCE(this.lAND_COMMITEE_Data_Set.DISTRICT, Convert.ToInt32(comboBox_PROVINCE.SelectedValue));
            // TODO: This line of code loads data into the 'lAND_COMMITEE_Data_Set.Select_Max_NumRef' table. You can move, or remove it, as needed.
            this.select_Max_NumRefTableAdapter.Fill(this.lAND_COMMITEE_Data_Set.Select_Max_NumRef);
            // TODO: This line of code loads data into the 'lAND_COMMITEE_Data_Set.LAND_OWNER' table. You can move, or remove it, as needed.
            this.lAND_OWNERTableAdapter.Fill(this.lAND_COMMITEE_Data_Set.LAND_OWNER);
            // TODO: This line of code loads data into the 'lAND_COMMITEE_Data_Set.SUPERVISOR' table. You can move, or remove it, as needed.
            this.sUPERVISORTableAdapter.Fill(this.lAND_COMMITEE_Data_Set.SUPERVISOR);
            // TODO: This line of code loads data into the 'lAND_COMMITEE_Data_Set.BOUNDARY_DETAILS' table. You can move, or remove it, as needed.
            this.bOUNDARY_DETAILSTableAdapter.Fill(this.lAND_COMMITEE_Data_Set.BOUNDARY_DETAILS);
            // TODO: This line of code loads data into the 'lAND_COMMITEE_Data_Set.SECTEUR' table. You can move, or remove it, as needed.
            this.sECTEURTableAdapter.FillBy(this.lAND_COMMITEE_Data_Set.SECTEUR, Convert.ToInt16(comboBox_DISTRICT.SelectedValue));
            this.cellsTableAdapter.Fill(this.lAND_COMMITEE_Data_Set.Cells, Convert.ToInt16(comboBox_SECTEUR.SelectedValue));
            this.sECTEUR_LandTableAdapter.Fill(lAND_COMMITEE_Data_Set.SECTEUR_Land,Convert.ToInt16(comboBox_LAND_DISTRICT.SelectedValue));
            this.cells_LandTableAdapter.Fill(lAND_COMMITEE_Data_Set.Cells_Land, Convert.ToInt16(comboBox_LAND_SECTEUR.SelectedValue));
            this.button1_Click(sender, e);
        }

        #region BUTTONS
        public int sum,formersiz;
        private int VerifyOwnerSize ( )
        {
            string com = "select dbo.SelectTotalSizeDistribByFormer ('" + Convert.ToString(comboBox_FORMER_OWNER.SelectedValue) + "')";
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LAND_COMMITEE;Integrated Security=True");
            SqlCommand comm = new SqlCommand(com, con);
            con.Open();
            string ab = comm.ExecuteScalar().ToString();
            comm.Dispose();
            con.Close();
            int m = 0,count=0,compt;
            string formersize="",distrsize="";
            if (ab != "")
            {
                //char[] tab;
                //tab = ab.ToCharArray();
                //int nbre = ab.Length;
                //for (compt = 0; compt < nbre; compt++)
                //{
                //    if(tab[compt]!='/')
                //        formersize = formersize + tab[compt];
                //    else if (tab[compt] == '/')
                //    {
                //        for (compt = compt + 1; compt < nbre; compt++)
                //        {
                //            distrsize = distrsize + tab[compt];
                //        }
                //        compt = nbre + 1;//sortie
                //    }
                    
                //}
                                
                m = ab.IndexOf("/");
                formersiz = Convert.ToInt16(ab.Substring(0, m));
                sum = Convert.ToInt16(ab.Substring(m + 1));
                //MessageBox.Show(""+m.ToString()+"-"+formersiz.ToString()+"-"+sum.ToString());
                if (sum + (Convert.ToInt16(textBox_LAND_SIZE.Text)) > formersiz)
                    m = -1;
                else m = -2;
            }
            return m;
        }
        public string user;
        private void button_ADD_Click (object sender, EventArgs e)
        {
            int res = this.VerifyOwnerSize();
            if (res == -2)
            {
                int rep = TextBox_Status();
                if (rep == 1)
                {
                    DialogResult dr = MessageBox.Show("Are you sure you want to save ? ", "Confirm...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        add_Info();
                        fnajouter_BOUNDARY_DETAILS();
                        this.select_Max_NumRefTableAdapter.Fill(this.lAND_COMMITEE_Data_Set.Select_Max_NumRef);
                        comboBox3.DataSource = this.selectMaxNumRefBindingSource;
                        //comboBox3.DisplayMember = this.selectMaxNumRefBindingSource;
                        comboBox3.DisplayMember = "Select_Max_NumRef.max_NumReference";
                        //int x = (Convert.ToInt32(comboBox3.Text) + 1);
                        //comboBox3.Text = Convert.ToString(x);
                        ResetControls_Fn();
                        this.LAND_INFORMATION_Load(sender, e);
                    }
                    MessageBox.Show("All the information has been saved !", "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);

                }
                else if (rep == 2)
                {
                    MessageBox.Show("Boundary Details cannot be Empty !\n\nPlease Complete the Table.", "Error in Boundary Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("Some boxes are Empty !\n\nPlease Complete all boxes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("The LAND SIZE of Mr(Mrs) " + comboBox_FORMER_OWNER.Text.ToUpper() + " is " + formersiz + " Hactares.\nYou need more size than the actual land size.\nClick OK for more information.", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FormerOwnerLandDistribution f = new FormerOwnerLandDistribution();
                f.id = Convert.ToString(comboBox_FORMER_OWNER.SelectedValue);
                f.ShowDialog();
            }


        }

        private void button2_Click (object sender, EventArgs e)
        {
            fnSupprimer_BOUNDARY_DETAILS();
        }

        private void button3_Click (object sender, EventArgs e)
        {
            fnModifier_BOUNDARY_DETAILS();
        }

        private void label18_Click (object sender, EventArgs e)
        {

        }

        private void button1_Click (object sender, EventArgs e)
        {
            if (comboBox_LAND_DISTRICT.Text != "--Select a District--")
            {
                string key = comboBox_LAND_DISTRICT.Text.Substring(0, 2);
                string com = "select dbo.Select_Land_No('" + comboBox_LAND_DISTRICT.Text.Substring(0, 2) + "')";
                SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LAND_COMMITEE;Integrated Security=True");
                SqlCommand comm = new SqlCommand(com, con);
                con.Open();
                string a = comm.ExecuteScalar().ToString();
                comm.Dispose();
                con.Close();
                string re;
                int b = Convert.ToInt32(a);
                b = ++b;
                re = b.ToString();
                int len = re.Length;
                for (int i = 0; i < 4 - len; i++)
                {
                    re = "0" + re.ToString();
                }
                textBox_LAND_No.Text = comboBox_LAND_DISTRICT.Text.Substring(0, 2) + "-" + re;
            }
            else
                MessageBox.Show("Choose District First !\n\nClick OK to Choose the District.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        private void VerifyDataGrid ( )
        {
            if (dataGridView_BOUNDARY_DETAILS.Rows.Count > 0)
            {
                for(int i=0;i<dataGridView_BOUNDARY_DETAILS.Rows.Count-1;i++)
                    dataGridView_BOUNDARY_DETAILS.Rows[i].Cells[0].Value=textBox_LAND_No.Text;
            }
        }
        private void comboBox_LAND_SECTEUR_SelectedIndexChanged (object sender, EventArgs e)
        {
            if (comboBox_LAND_SECTEUR.Text != "")
            {
                cells_LandTableAdapter.Fill(lAND_COMMITEE_Data_Set.Cells_Land, Convert.ToInt16(comboBox_LAND_SECTEUR.SelectedValue));
            }
            //textBox_LAND_No.Text = "";
        }

        private void dataGridView_BOUNDARY_DETAILS_CellBeginEdit (object sender, DataGridViewCellCancelEventArgs e)
        {
            dataGridView_BOUNDARY_DETAILS.CurrentRow.Cells[0].Value = textBox_LAND_No.Text;
            dataGridView_BOUNDARY_DETAILS.CurrentRow.Cells[4].Value = dataGridView_BOUNDARY_DETAILS.CurrentRow.Cells[1].Value;
        }

        private void closeToolStripMenuItem_Click (object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox_LAND_DISTRICT_SelectedIndexChanged (object sender, EventArgs e)
        {
            if (comboBox_LAND_DISTRICT.Text != "")
            {
                sECTEUR_LandTableAdapter.Fill(lAND_COMMITEE_Data_Set.SECTEUR_Land, Convert.ToInt16(comboBox_LAND_DISTRICT.SelectedValue));
                comboBox_LAND_SECTEUR_SelectedIndexChanged(sender, e);
                this.button1_Click(sender,e);
                VerifyDataGrid();
            }
            else textBox_LAND_No.Text = "";
        }

        private void button2_Click_1 (object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox_PROVINCE_SelectedIndexChanged_1 (object sender, EventArgs e)
        {
                this.dISTRICT_TableAdapter.FillBy_PROVINCE(this.lAND_COMMITEE_Data_Set.DISTRICT, Convert.ToInt32(comboBox_PROVINCE.SelectedValue));
                comboBox_DISTRICT.DataSource = dISTRICTBindingSource;
                comboBox_DISTRICT_SelectedIndexChanged(sender, e);
        }

        private void textBox_LAND_SIZE_TextChanged (object sender, EventArgs e)
        {
            //int size = 0;
            //if (textBox_LAND_SIZE.Text != "")
            //    size = Convert.ToUInt16(textBox_LAND_SIZE.Text);
            //if (size > 25)
            //{
            //    MessageBox.Show("Land Size cannot be greater than 25 Hectares!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    textBox_LAND_SIZE.Text = "";
            //}
        }

        private void button3_Click_2 (object sender, EventArgs e)
        {
            FormerOwnerLandDistribution f = new FormerOwnerLandDistribution();
            f.id = Convert.ToString(comboBox_FORMER_OWNER.SelectedValue);
            f.ShowDialog();
        }

        private void comboBox_DISTRICT_SelectedIndexChanged (object sender, EventArgs e)
        {
            if (comboBox_DISTRICT.Text != "")
            {
                this.sECTEURTableAdapter.FillBy(this.lAND_COMMITEE_Data_Set.SECTEUR, Convert.ToInt16(comboBox_DISTRICT.SelectedValue));
                this.comboBox_SECTEUR.DataSource = sECTEURBindingSource;
                this.comboBox_SECTEUR_SelectedIndexChanged(sender, e);
            }

        }

        private void comboBox_SECTEUR_SelectedIndexChanged (object sender, EventArgs e)
        {
            if (comboBox_SECTEUR.Text != "")
            {
                this.cellsTableAdapter.Fill(this.lAND_COMMITEE_Data_Set.Cells, Convert.ToInt16(comboBox_SECTEUR.SelectedValue));
                this.comboBox_CELLULE.DataSource = cellsBindingSource;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                radioButton2.Checked =comboBox_category_Former_Owner.Enabled= false;
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
    }
}