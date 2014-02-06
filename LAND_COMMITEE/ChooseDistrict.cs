using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAND_COMMITEE
{
    public partial class ChooseDistrict : Form
    {
        public ChooseDistrict()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LAND_INFORMATION land = new LAND_INFORMATION();
            land.title = comboBox_Province.Text;
            land.district = comboBox_District.Text;
            land.Show();
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Province.Text == "EASTERN PROVINCE")
            {
                comboBox_District.Items.Clear();
                comboBox_District.Items.Add("Bugesera");
                comboBox_District.Items.Add("Gatsibo");
                comboBox_District.Items.Add("Kayonza");
                comboBox_District.Items.Add("Kirehe");
                comboBox_District.Items.Add("Ngoma");
                comboBox_District.Items.Add("Nyagatare");
                comboBox_District.Items.Add("Rwamagana");
            }
            else if (comboBox_Province.Text == "NORTHERN PROVINCE")
            {
                comboBox_District.Items.Clear();
                comboBox_District.Items.Add("Burera");
                comboBox_District.Items.Add("Gakenke");
                comboBox_District.Items.Add("Gicumbi");
                comboBox_District.Items.Add("Musanze");
                comboBox_District.Items.Add("Rulindo");
            }
        }
    }
}