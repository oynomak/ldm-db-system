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
    public partial class NewUser : Form
    {
        public NewUser()
        {
            InitializeComponent();
        }

        private Connection connect;

        internal Connection Connect
        {
            get { return connect; }
            set { connect = value; }
        }

        private bool verify_all(string log, string pass1, string pass2)
        {
            if (log.Length < 5 || !pass1.Equals(pass2) || pass1.Length<5)
                return false;
            else
                return true;
        }
        //private int verify_Login()
        //{
        //    if (textBox_login.Text == "")
        //        return 1;
        //    else return 0;
        //}
        //private int verify_Password()
        //{
        //    if (textBox_password.Text == "")
        //        return 0;
        //    else if (textBox_password.Text.Length < 5)
        //        return 1;
        //    else return 0;
        //}
        private void add_Info()
        {
            string com = "exec dbo.add_user '" + encr1 + "','" + textBox_name.Text + "','" + textBox_surname.Text + "'";
            Connect.executeMyQuery(com);

            //SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LAND_COMMITEE;Integrated Security=True");
            //con.Open();
            //SqlCommand SQLcom = new SqlCommand(com, con);
            //SQLcom.ExecuteNonQuery();
            //SQLcom.Dispose();
            //con.Close();

        }
        public string encr1;
        private void button1_Click(object sender, EventArgs e)
        {
            //int max = Convert.ToInt16(comboBox1.SelectedValue);
            bool re = this.verify_all(textBox_Login.Text, textBox1.Text, textBox2.Text);
            if (re == false || textBox_name.Text=="")
            {
                label5.Text = label6.Text = label7.Text = label11.Text = "*";
                label4.Text = ("* The Minimum length of LoginName is 5 Characters !\n  The password have to be the same in the two boxes!");
            }
            else
            {
                label4.Text = label5.Text = label6.Text = label7.Text = "";
                Security s = new Security();
                encr1 = s.encrypt(textBox_Login.Text, "", 1);
                string encr2 = s.encrypt(textBox1.Text, comboBox2.Text, 0);
                try
                {
                    this.userTablesTableAdapter.Update(this.lAND_COMMITEE_Data_Set.UserTables.AddUserTablesRow(encr1, encr2));
                    add_Info();
                    MessageBox.Show(textBox_Login.Text.ToUpper() + " added as " + comboBox2.Text.ToUpper());
                    textBox_Login.Text = textBox1.Text = textBox2.Text =textBox_name.Text=textBox_surname.Text= "";
                    tabControl1.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void NewUser_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lAND_COMMITEE_Data_Set.UserTables' table. You can move, or remove it, as needed.
            this.userTablesTableAdapter.Fill(this.lAND_COMMITEE_Data_Set.UserTables);

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            //tabControl1.DeselectTab();

            //tabControl1.TabPages[0].Focus();
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Administrator")
            {
                DialogResult di = MessageBox.Show("You are about to Create an Administrator.\n\nAre you sure you want to SET THE USER AS AN ADMINISTRATOR ??", "Warning...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (DialogResult.No == di)
                    comboBox2.Text = "Guest";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1_Click(sender,e);
            tabControl1.SelectedIndex = 0;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

    }
}