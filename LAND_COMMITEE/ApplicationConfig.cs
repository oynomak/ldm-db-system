using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace LAND_COMMITEE
{
    class ApplicationConfig
    {
        private string bckgroundImgFile = "", imageFolder = "";

        public ApplicationConfig getInstance()
        {
            return new ApplicationConfig();
        }

        public void initializeApplicationConfiguration(string mySettingsFileName)
        {
            try
            {
                loadGeneralSettings(Application.StartupPath + "\\" + mySettingsFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: \n" + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadGeneralSettings(string mySettingsFileName)
        {
            try
            {
                StreamReader stream = new StreamReader(@mySettingsFileName);
                XmlTextReader reader = null;
                reader = new XmlTextReader(stream);
                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element: // The node is an Element.
                            if (reader.Name.Equals("bckgroundImg"))
                            {
                                while (reader.MoveToNextAttribute()) // Read attributes.
                                    if (reader.Name.Equals("value"))
                                        bckgroundImgFile = reader.Value;
                            }
                            else if (reader.Name.Equals("flder"))
                            {
                                while (reader.MoveToNextAttribute()) // Read attributes.
                                    if (reader.Name.Equals("value"))
                                        imageFolder = reader.Value;
                            };
                            break;
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: \n" + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public string getImageFolder()
        {
            return imageFolder;
        }

        public string getbckgroundImgFile()
        {
            return bckgroundImgFile;
        }
    }
}
