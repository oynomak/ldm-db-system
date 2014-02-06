using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAND_COMMITEE
{
    public partial class UserListReport : Form
    {
        public UserListReport()
        {
            InitializeComponent();
        }

        private Connection connect;

        internal Connection Connect
        {
            get { return connect; }
            set { connect = value; }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            UserReport1.SetDatabaseLogon("sa","",connect.ServerName,connect.DatabaseName);
            UserReport1.Refresh();
            UserReport1.VerifyDatabase();
            crystalReportViewer1.Zoom(60);
        }

        private void UserListReport_Load(object sender, EventArgs e)
        {
        }

    }
}