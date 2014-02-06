using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAND_COMMITEE
{
    public partial class QuickReport : Form
    {
        public QuickReport()
        {
            InitializeComponent();
        }

        #region

        private Connection connect;

        internal Connection Connect
        {
            get { return connect; }
            set { connect = value; }
        }

        private void loadDistricts()
        {
            comboBox1.DataSource = connect.getDataSet("SELECT DISTINCT LAND_INFO.DISTRICT, DISTRICT.DESCRIPTION_DISTRICT FROM LAND_INFO "
            + "INNER JOIN DISTRICT ON LAND_INFO.DISTRICT = DISTRICT.ID_DISTRICT order by DISTRICT.DESCRIPTION_DISTRICT asc", "distinctDistrict_1");
            comboBox1.DisplayMember = "distinctDistrict_1.DESCRIPTION_DISTRICT";
            comboBox1.ValueMember = "distinctDistrict_1.DISTRICT";
        }

        private void loadSectors()
        {
            comboBox2.DataSource = connect.getDataSet("SELECT DISTINCT LAND_INFO.SECTOR, SECTEUR.DESCRIPTION_SECTEUR FROM LAND_INFO "
            + "INNER JOIN SECTEUR ON LAND_INFO.SECTOR = SECTEUR.ID_SECTEUR order by SECTEUR.DESCRIPTION_SECTEUR asc", "distinctSector_1");
            comboBox2.DisplayMember = "distinctSector_1.DESCRIPTION_SECTEUR";
            comboBox2.ValueMember = "distinctSector_1.SECTOR";
        }

        private void loadCells()
        {
            comboBox6.DataSource = connect.getDataSet("SELECT DISTINCT LAND_INFO.CELLULE, Cells.CellName FROM LAND_INFO INNER JOIN Cells ON "
            + "LAND_INFO.CELLULE = Cells.CellID order by Cells.CellName asc", "distinctCells_1");
            comboBox6.DisplayMember = "distinctCells_1.CellName";
            comboBox6.ValueMember = "distinctCells_1.CELLULE";
        }

        private void loadFormerOwner()
        {
            comboBox4.DataSource = connect.getDataSet("SELECT  ID_FORMER_OWNER, NOM + ' ' + PRENOM + ' ' + AUTRE_NOM AS former_owner FROM "
            + "FORMER_OWNERS order by former_owner asc", "FormerOwner_1");
            comboBox4.DisplayMember = "FormerOwner_1.former_owner";
            comboBox4.ValueMember = "FormerOwner_1.ID_FORMER_OWNER";
        }

        private void loadSuperVisor()
        {
            comboBox3.DataSource = connect.getDataSet("SELECT  No_SUPERVISOR, NOM + ' ' + PRENOM + ' ' + AUTRE_NOM AS FullName FROM SUPERVISOR "
                + "order by FullName asc", "SuperVisor_1");
            comboBox3.DisplayMember = "SuperVisor_1.FullName";
            comboBox3.ValueMember = "SuperVisor_1.No_SUPERVISOR";
        }

        private void loadFormerOwnerCagegory()
        {
            comboBox7.DataSource = connect.getDataSet("SELECT idcategory, description, comment FROM FormerOwnerCategory "
                + "order by description asc", "FormerOwnerCategory_1");
            comboBox7.DisplayMember = "FormerOwnerCategory_1.description";
            comboBox7.ValueMember = "FormerOwnerCategory_1.idcategory";
        }

        private void loadBeneficiaryCagegory()
        {
            comboBox8.DataSource = connect.getDataSet("SELECT idcategory, description, comment FROM BeneficiaryCategory "
                + "order by description asc", "BeneficiaryCategory_1");
            comboBox8.DisplayMember = "BeneficiaryCategory_1.description";
            comboBox8.ValueMember = "BeneficiaryCategory_1.idcategory";
        }

        private void populateLandUsage()
        {
            comboBox5.Items.Clear();
            comboBox5.Items.Add("CULTIVATION");
            comboBox5.Items.Add("FARMING");
        }

        #endregion

        private void QuickReport_Load(object sender, EventArgs e)
        {
            try
            {
                populateLandUsage();
                loadCells();
                loadSectors();
                loadDistricts();
                loadFormerOwner();
                loadSuperVisor();
                loadFormerOwnerCagegory();
                loadBeneficiaryCagegory();
            }
            catch (Exception ex) { MessageBox.Show("An error occured : \n" + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void button_district_Click(object sender, EventArgs e)
        {
            beneficiary_list_report b = new beneficiary_list_report();
            b.val = comboBox1.Text;
            Form mdi = this.MdiParent;
            b.MdiParent = mdi;
            b.Show();

        }

        private void button_sector_Click(object sender, EventArgs e)
        {
            beneficiary_list_by_sector b = new beneficiary_list_by_sector();
            b.val = comboBox2.Text;
            Form mdi = this.MdiParent;
            b.MdiParent = mdi;
            b.Show();
        }

        private void button_user_Click(object sender, EventArgs e)
        {
            UserListReport u = new UserListReport();
            Form mdi = this.MdiParent;
            u.MdiParent = mdi;
            u.Connect = connect;
            u.Show();
        }

        private void button_usage_Click(object sender, EventArgs e)
        {
            if (comboBox5.Text.Trim() != "")
            {
                list_owners_by_usage l = new list_owners_by_usage();
                l.i = comboBox5.Text;
                Form mdi = this.MdiParent;
                l.MdiParent = mdi;
                l.Show();
            }
            else MessageBox.Show("Select the usage before submit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button_owner_Click(object sender, EventArgs e)
        {
            SEARCH_By_FROMER_OWNER s = new SEARCH_By_FROMER_OWNER();
            int temp = comboBox4.Text.Length;
            string value = "";
            int i;
            char[] tab = comboBox4.Text.ToString().ToCharArray();
            for (i = 0; i < temp; i++)
            {
                if (i < temp)
                    value = value + tab[i];
                else if (tab[i] != ' ')
                    value = value + tab[i];
            }
            s.val = value;
            Form mdi = this.MdiParent;
            s.MdiParent = mdi;
            s.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.QuickReport_Load(sender, e);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BenList_BY_FormerOwnerCategoryRPT ben = new BenList_BY_FormerOwnerCategoryRPT();
            ben.key = Convert.ToInt16(comboBox7.SelectedValue);
            Form mdi = this.MdiParent;
            ben.MdiParent = mdi;
            ben.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            beneficiary_by_cell b = new beneficiary_by_cell();
            b.val = comboBox6.Text;
            Form mdi = this.MdiParent;
            b.MdiParent = mdi;
            b.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SurveyorWorkReport s = new SurveyorWorkReport();
            s.id = Convert.ToString(comboBox3.SelectedValue);
            Form mdi = this.MdiParent;
            s.MdiParent = mdi;
            s.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            BenList_BY_NewBenCategoryRPT ben = new BenList_BY_NewBenCategoryRPT();
            ben.key = Convert.ToInt16(comboBox8.SelectedValue);
            Form mdi = this.MdiParent;
            ben.MdiParent = mdi;
            ben.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            FormerOwnerListForm f = new FormerOwnerListForm();
            Form mdi = this.MdiParent;
            f.MdiParent = mdi;
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SurveryorListReport s = new SurveryorListReport();
            Form mdi = this.MdiParent;
            s.MdiParent = mdi;
            s.Show();
        }
    }
}