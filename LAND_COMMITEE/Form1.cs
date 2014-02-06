using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace LAND_COMMITEE
{
    public partial class Form_LAND_COMMITEE : Form
    {
        public Form_LAND_COMMITEE()
        {
            InitializeComponent();
        }

        #region

        public int perm;
        public string user, priv = "", util = "";
        private Connection connect;
        private ApplicationConfig appConfig = new ApplicationConfig();

        internal Connection Connect
        {
            get { return connect; }
            set { connect = value; }
        }

        #endregion

        private void sUPERVISORCATEGORYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SUPERVISOR s = new SUPERVISOR();
            s.MdiParent = this;
            s.Connect = connect;
            s.Show();
        }

        private void lANDOWNERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LAND_INFORMATION ch = new LAND_INFORMATION();
            ch.MdiParent = this;
            ch.user = user;
            ch.Show();
        }

        private void cLOSEPROJECTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form a = this.ActiveMdiChild;
            if (a != null)
                a.Close();
        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LandComHelp land = new LandComHelp();
            land.MdiParent = this;
            land.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewUser n = new NewUser();
            n.MdiParent = this;
            n.Connect = connect;
            n.Show();
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetPassword r = new ResetPassword();
            r.MdiParent = this;
            r.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Ajouter_Prov_Distr a = new Ajouter_Prov_Distr();
            a.MdiParent = this;
            a.ShowDialog();
        }

        private void districtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            beneficiary_list_report b = new beneficiary_list_report();
            b.MdiParent = this;
            b.ShowDialog();
        }

        private void sectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            beneficiary_list_by_sector s = new beneficiary_list_by_sector();
            s.MdiParent = this;
            s.ShowDialog();
        }

        private void celluleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            beneficiary_by_cell c = new beneficiary_by_cell();
            c.MdiParent = this;
            c.ShowDialog();
        }

        private void landNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search_land_info s = new Search_land_info();
            s.MdiParent = this;
            s.perm = perm;
            s.Connect = connect;
            s.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Former_Owners f = new Former_Owners();
            f.MdiParent = this;
            f.Connect = connect;
            f.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            SEARCH_By_FROMER_OWNER ser = new SEARCH_By_FROMER_OWNER();
            ser.MdiParent = this;
            ser.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            list_owners_by_usage li = new list_owners_by_usage();
            li.MdiParent = this;
            li.Show();
        }

        private void Form_LAND_COMMITEE_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ownerNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindByName f = new FindByName();
            f.MdiParent = this;
            f.perm = perm;
            f.Connect = connect;
            f.Show();
        }

        private void access()
        {
            //DateTime dateLimite = new DateTime();
            //DateTime Minimum = new DateTime();
            //DateTime todaysDate = new DateTime();
            //todaysDate = DateTime.Today;
            //string dateLim = "5-4-2008";
            //string dateMin = "4-25-2008";
            //Minimum = Convert.ToDateTime(dateMin);
            //dateLimite = Convert.ToDateTime(dateLim);
            //if (todaysDate.CompareTo(dateLimite) == -1)
            //    if (todaysDate.CompareTo(Minimum) == 1)
            //    {
            toolStripStatusLabel1.Text = "Username: " + util;
            toolStripStatusLabel2.Text = "/Permission: " + priv;

            if (perm == 1)
            {
                sUPERVISORCATEGORYToolStripMenuItem.Enabled = newUserToolStripMenuItem.Enabled = toolStripMenuItem5.Enabled = newInfToolStripMenuItem.Enabled = toolStripMenuItem7.Enabled = toolStripMenuItem8.Enabled = toolStripMenuItem3.Enabled = toolStripMenuItem4.Enabled = toolStripMenuItem9.Enabled = toolStripMenuItem11.Enabled = toolStripMenuItem12.Enabled = sectorToolStripMenuItem.Enabled = cellToolStripMenuItem.Enabled = districtToolStripMenuItem.Enabled = false;
            }
            else
            {
                NotCheckedByAdministrator n = new NotCheckedByAdministrator();
                n.MdiParent = this;
                n.Connect = connect;
                n.user = user;
                n.Show();
            }
            //    }
            //    else
            //    {
            //        MessageBox.Show("Program out of Date !!", "There is a Problem.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        AboutUs a = new AboutUs();
            //        a.MdiParent = this;
            //        a.Show();
            //        sUPERVISORCATEGORYToolStripMenuItem.Enabled = toolStripMenuItem2.Enabled = lANDOWNERToolStripMenuItem.Enabled = newInfToolStripMenuItem.Enabled = landNumberToolStripMenuItem.Enabled = ownerNameToolStripMenuItem.Enabled = newUserToolStripMenuItem.Enabled = toolStripMenuItem1.Enabled = toolStripMenuItem3.Enabled = toolStripMenuItem4.Enabled = toolStripMenuItem5.Enabled = toolStripMenuItem7.Enabled = toolStripMenuItem8.Enabled = toolStripMenuItem9.Enabled = false;
            //    }
            //else
            //{
            //    MessageBox.Show("Program out of Date !!", "There is a Problem.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    AboutUs a = new AboutUs();
            //    a.MdiParent = this;
            //    a.Show();
            //    sUPERVISORCATEGORYToolStripMenuItem.Enabled = toolStripMenuItem2.Enabled = lANDOWNERToolStripMenuItem.Enabled = newInfToolStripMenuItem.Enabled = landNumberToolStripMenuItem.Enabled = ownerNameToolStripMenuItem.Enabled = newUserToolStripMenuItem.Enabled = toolStripMenuItem1.Enabled = toolStripMenuItem3.Enabled = toolStripMenuItem4.Enabled = toolStripMenuItem5.Enabled = toolStripMenuItem7.Enabled = toolStripMenuItem8.Enabled = toolStripMenuItem9.Enabled = false;
            //}
        }

        private void Form_LAND_COMMITEE_Load(object sender, EventArgs e)
        {
            access();
            try
            {
                appConfig.initializeApplicationConfiguration("settings.xml");

                this.BackgroundImage = System.Drawing.Image.FromFile(@appConfig.getbckgroundImgFile());     
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message.ToString()); }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            AboutUs a = new AboutUs();
            a.MdiParent = this;
            a.Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            QuickReport q = new QuickReport();
            q.MdiParent = this;
            q.Connect = connect;
            q.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            UserListReport u = new UserListReport();
            u.MdiParent = this;
            u.Show();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            SurveryorListReport s = new SurveryorListReport();
            s.MdiParent = this;
            s.Show();
        }

        private void newInfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotCheckedByAdministrator n = new NotCheckedByAdministrator();
            n.MdiParent = this;
            n.Connect = connect;
            n.Show();
        }

        private void districtToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            beneficiary_list_report b = new beneficiary_list_report();
            b.MdiParent = this;
            b.Show();
        }

        private void sectorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            beneficiary_list_by_sector b = new beneficiary_list_by_sector();
            b.MdiParent = this;
            b.Show();
        }

        private void cellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            beneficiary_by_cell b = new beneficiary_by_cell();
            b.MdiParent = this;
            b.Show();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            FormerOwnerListForm f = new FormerOwnerListForm();
            f.MdiParent = this;
            f.Show();
        }

        private void beneficiaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Category_New_Owner cate = new Category_New_Owner();
            cate.MdiParent = this;
            cate.Connect = connect;
            cate.Show();
        }

        private void formerOwnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formerOwnerCategory f = new formerOwnerCategory();
            f.MdiParent = this;
            f.Connect = connect;
            f.Show();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            NewBeneficiaryCategory_rpt n = new NewBeneficiaryCategory_rpt();
            n.MdiParent = this;
            n.Show();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            FormerOwnerCategoryList_rpt n = new FormerOwnerCategoryList_rpt();
            n.MdiParent = this;
            n.Show();
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form[] charr = this.MdiChildren;
            foreach (Form chform in charr)
                chform.Close();
        }

        private void surveyorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SurveyorCategory f = new SurveyorCategory();
            f.MdiParent = this;
            f.Connect = connect;
            f.Show();
        }

        private void generalSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneralSettingsForm g = new GeneralSettingsForm();
            g.MdiParent = this;
            g.AppConfig = this.appConfig;
            g.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            toolStripMenuItem6_Click(sender, e);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Form_LAND_COMMITEE_Load(sender, e);
        }

    }
}