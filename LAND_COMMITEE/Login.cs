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
    public partial class Login : Form
    {
        private Connection connect = new Connection();
        private string encr;

        public Login()
        {
            InitializeComponent();
        }
        private int verify_Login()
        {
            if (textBox_login.Text.Trim() == null || textBox_login.Text.Trim().Length < 5 || textBox_login.Text.Trim() == "")
                return 1;
            else return 0;
        }
        private int verify_Password()
        {
            if (textBox_password.Text.Trim() == "" || textBox_password.Text.Trim().Length < 5 || textBox_password.Text.Trim() == null)
                return 1;
            else return 0;
        }

        private void Access()
        {
            string com = "exec dbo.adduserin '" + encr + "'";
            connect.executeMyQuery(com);
        }

        private void Out()
        {
            string com = "exec dbo.userout '" + encr + "'";
            connect.executeMyQuery(com);
        }

        private void textBox_login_TextChanged(object sender, EventArgs e)
        {
            if (textBox_login.Text == " ")
                textBox_login.Text = "";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                connect.ConnectionString = "Data Source=" + textBox_server.Text + ";Initial Catalog=LAND_COMMITEE;Integrated Security=True";
                connect.DatabaseName = "LAND_COMMITEE";
                connect.ServerName = textBox_server.Text;

                int res = verify_Login();
                int res1 = verify_Password();
                switch (res)
                {
                    case 1: label_error_ut.Text = "*  Fill this box !"; break;
                    case 0: label_error_ut.Text = ""; break;
                }
                switch (res1)
                {
                    case 1: label_error_pass.Text = "*  The minimum length for a valid password is 5 !"; break;
                    case 0: label_error_pass.Text = ""; break;
                }
                if (res == 0 && res1 == 0)
                {                    
                    Security s = new Security();
                    string log = s.encrypt(textBox_login.Text, "", 1);

                    string com = "select dbo.Select_Password ('" + log + "')";
                    string a = (connect.executeMyMethod(com)).ToString();

                    if (a.Equals("-1") || a == null)
                    {
                        MessageBox.Show("Unknown User!", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        textBox_login.Focus();
                    }
                    else if (a.Equals(""))
                    {
                        MessageBox.Show("Server not found!", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        textBox_server.Focus();
                    }
                    else
                    {
                        encr = s.encrypt(textBox_password.Text, "", 1);
                        bool b = s.Valid_Pass(s.encrypt(textBox_password.Text, "", 1), a);
                        bool m = s.VerifyPrivilege(textBox_password.Text, a);

                        string priv;
                        if (m == true)
                            priv = "Administrator";
                        else
                            priv = "Guest";

                        if (b == true)
                        {
                            textBox_password.Text = "";
                            Form_LAND_COMMITEE f = new Form_LAND_COMMITEE();
                            f.user = encr;
                            f.Connect = connect;
                            if (m == false)
                                f.perm = 1;
                            f.priv = priv.ToUpper();
                            f.util = textBox_login.Text.ToUpper();
                            f.Show();
                            Access();



                            this.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Password incorrect; Try again !", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                            textBox_password.Focus();
                        }
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("An error occured when trying to connect to database.\n"+ex.Message.ToString(), "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Out();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBox_server.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}