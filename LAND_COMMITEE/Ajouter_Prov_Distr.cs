using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAND_COMMITEE
{
    public partial class Ajouter_Prov_Distr : Form
    {
        public Ajouter_Prov_Distr()
        {
            InitializeComponent();
        }
        public int iRowIndex;

        private void Ajouter_Prov_Distr_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lAND_COMMITEE_Data_Set.SECTEUR' table. You can move, or remove it, as needed.
            this.sECTEURTableAdapter.Fill(this.lAND_COMMITEE_Data_Set.SECTEUR);
            fnRefresh_Prov();

        }


        #region PROVINCE
        private void fnRefresh_Prov()
        {
            try
            {
                this.lAND_COMMITEE_Data_Set.Clear();
                this.sECTEURTableAdapter.Fill(this.lAND_COMMITEE_Data_Set.SECTEUR);
                this.dataGridView_PROV.DataSource = this.lAND_COMMITEE_Data_Set.Tables["PROVINCE"].DefaultView;
                this.dataGridView_DISTR.DataSource = this.lAND_COMMITEE_Data_Set.Tables["DISTRICT"].DefaultView;
                this.dataGridView_SECT.DataSource = this.lAND_COMMITEE_Data_Set.Tables["SECTEUR"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void fnadd_Prov()
        {
            try
            {
                DataSet myChangedDataset = this.lAND_COMMITEE_Data_Set.GetChanges();

                if (myChangedDataset != null)
                {
                    DialogResult dr = MessageBox.Show("Are you sure you want to ADD those Informations ? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        //int modifiedRows = this.pROVINCETableAdapter.Update(lAND_COMMITEE_Data_Set.PROVINCE);
                        MessageBox.Show("Informations Saved !", "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                        this.lAND_COMMITEE_Data_Set.AcceptChanges();
                    }
                    fnRefresh_Prov();
                }
                else
                {
                    MessageBox.Show("Nothing to Save !", "Nothing Change !", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred updating the database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.lAND_COMMITEE_Data_Set.RejectChanges();
                this.fnRefresh_Prov();
            }
        }
        private void button_REFLESH_PROV_Click(object sender, EventArgs e)
        {
            this.fnRefresh_Prov();
        }
        private void button_ADD_PROV_Click(object sender, EventArgs e)
        {
            this.fnadd_Prov();
        }
        #endregion

        #region DISTRICT
        private void button_REFRESH_DISTR_Click(object sender, EventArgs e)
        {
            fnRefresh_Prov();
        }
        private void fnadd_Distr()
        {
            try
            {
                DataSet myChangedDataset = this.lAND_COMMITEE_Data_Set.GetChanges();

                if (myChangedDataset != null)
                {
                    DialogResult dr = MessageBox.Show("Are you sure you want to ADD those Informations ? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        //int modifiedRows = this.dISTRICTTableAdapter.Update(lAND_COMMITEE_Data_Set.DISTRICT);
                        MessageBox.Show("Informations Saved !", "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                        this.lAND_COMMITEE_Data_Set.AcceptChanges();
                    }
                    fnRefresh_Prov();
                }
                else
                {
                    MessageBox.Show("Nothing to Save !", "Nothing Change !", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred updating the database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.lAND_COMMITEE_Data_Set.RejectChanges();
                this.fnRefresh_Prov();
            }
        }
        private void button_ADD_DISTR_Click(object sender, EventArgs e)
        {
            this.fnadd_Distr();
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //this.dISTRICTTableAdapter.FillBy_PROVINCE(this.lAND_COMMITEE_Data_Set.DISTRICT, Convert.ToInt32(comboBox4.SelectedValue));
                this.dataGridView_DISTR.DataSource = this.lAND_COMMITEE_Data_Set.Tables["DISTRICT"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region SECTOR
        private void button_REFRESH_SECT_Click(object sender, EventArgs e)
        {
            fnRefresh_Prov();
        }
        private void fnadd_Sector()
        {
            try
            {
                DataSet myChangedDataset = this.lAND_COMMITEE_Data_Set.GetChanges();

                if (myChangedDataset != null)
                {
                    DialogResult dr = MessageBox.Show("Are you sure you want to ADD those Informations ? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        int modifiedRows = this.sECTEURTableAdapter.Update(lAND_COMMITEE_Data_Set.SECTEUR);
                        MessageBox.Show("Informations Saved !", "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                        this.lAND_COMMITEE_Data_Set.AcceptChanges();
                    }
                    fnRefresh_Prov();
                }
                else
                {
                    MessageBox.Show("Nothing to Save !", "Nothing Change !", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred updating the database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.lAND_COMMITEE_Data_Set.RejectChanges();
                fnRefresh_Prov();
            }
        }
        private void fnDel_Sector()
        {
            try
            {
                DialogResult dr = MessageBox.Show("Etes Vous sure de Vouloir Supprimer cette ligne ? ", "Confirmer la suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    DataTable tbl = new DataTable("SECTEUR");
                    tbl = this.lAND_COMMITEE_Data_Set.Tables[0];
                    this.iRowIndex = this.dataGridView_SECT.CurrentRow.Index;
                    int i = this.iRowIndex;
                    tbl.Rows[i].Delete();
                    this.sECTEURTableAdapter.Update(lAND_COMMITEE_Data_Set.SECTEUR);
                    fnRefresh_Prov(); ;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une Erreur a été Détectée !\n\n" + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.fnRefresh_Prov();
            }
        }
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.sECTEURTableAdapter.FillBy(this.lAND_COMMITEE_Data_Set.SECTEUR, Convert.ToInt32(comboBox5.SelectedValue));
                this.dataGridView_SECT.DataSource = this.lAND_COMMITEE_Data_Set.Tables["SECTEUR"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button_ADD_SECT_Click(object sender, EventArgs e)
        {
            fnadd_Sector();
        }

        private void button_DEL_SECT_Click(object sender, EventArgs e)
        {
            fnDel_Sector();
        }
        #endregion




    }
}