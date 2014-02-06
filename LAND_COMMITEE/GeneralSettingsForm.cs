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
    public partial class GeneralSettingsForm : Form
    {
        public GeneralSettingsForm()
        {
            InitializeComponent();
        }

        private ApplicationConfig appConfig;
        internal ApplicationConfig AppConfig
        {
            get { return appConfig; }
            set { appConfig = value; }
        }

        #region

        private void saveGeneralSettings(string mySettingsFileName)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml("<?xml version='1.0'?>"
                            +"<generalsettings>"
                                +"<bckgroundImg value='"+@textBox2.Text+"' />"
                                +"<flder value='"+@textBox1.Text+"' />"
                            +"</generalsettings>");
                doc.Save(@"" + Application.StartupPath + "\\" + mySettingsFileName);

                MessageBox.Show("General settings Saved successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: \n" + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.folderBrowserDialog1.Description = "Choose the folder";
                this.folderBrowserDialog1.SelectedPath = (textBox1.Text!="") ? textBox1.Text : "";
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = this.folderBrowserDialog1.SelectedPath;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: \n" + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.openFileDialog1.Filter = "Jpeg Files (.jpg ou .jpeg)|*.jpg;*.jpeg|Bmp Files (.bmp)|*.bmp|Gif files (.gif)|*.gif";
                this.openFileDialog1.Multiselect = true;
                this.openFileDialog1.Title = "Choose a Picture";
                openFileDialog1.FileName = (textBox2.Text != "") ? textBox2.Text : "";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox2.Text = this.openFileDialog1.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: \n" + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GeneralSettingsForm_Load(object sender, EventArgs e)
        {
            textBox2.Text = this.appConfig.getbckgroundImgFile();
            textBox1.Text = this.appConfig.getImageFolder();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveGeneralSettings("settings.xml");
            this.appConfig.initializeApplicationConfiguration("settings.xml");
        }
    }
}