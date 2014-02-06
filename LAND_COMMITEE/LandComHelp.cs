using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAND_COMMITEE
{
    public partial class LandComHelp : Form
    {
        public LandComHelp()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            switch (treeView1.SelectedNode.Name)
            {
                case "Node0":
                    header.Text = "Home Information";
                    body.Text = "This is an example of a header and a body text in their respectively";
                    body.Text=body.Text+"\nplaces. The rest of the help text will be written by Kamonyo Mugabo Richard!";
                    body.Text = body.Text + "\nIbi kandi ni ukuri ni Kamonyo ugomba kubyandika 100 blague!";
                    break;
                case "Node2":
                    header.Text = "Supervisor Information";
                    body.Text="this text also will be written by Mugabo richad!";
                    break;
                case "Node3":
                    header.Text = ("Land Information");
                    body.Text="the same!";
                    break;
            }
        }

        
        private void LandComHelp_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lAND_COMMITEE_Data_Set.PROVINCE' table. You can move, or remove it, as needed.
            this.pROVINCE_TableAdapter.Fill(this.lAND_COMMITEE_Data_Set.PROVINCE);

        }
    }
}