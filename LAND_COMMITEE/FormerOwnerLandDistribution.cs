using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LAND_COMMITEE
{
    public partial class FormerOwnerLandDistribution : Form
    {
        public FormerOwnerLandDistribution()
        {
            InitializeComponent();
        }
        public string id;
        private void FormerOwnerLandDistribution_Load(object sender, EventArgs e)
        {
            selectFormerOwnerTableAdapter.Fill(lAND_COMMITEE_Data_Set.SelectFormerOwner,id);
            this.dataGridView2.DataSource = selectFormerOwnerBindingSource;

            textBox_nom.Text = Convert.ToString(dataGridView2.CurrentRow.Cells[0].Value);
            textBox_prenom.Text = Convert.ToString(dataGridView2.CurrentRow.Cells[1].Value);
            textBox_size.Text = Convert.ToString(dataGridView2.CurrentRow.Cells[2].Value);

            selectFormerOwnerDistributionTableAdapter.Fill(lAND_COMMITEE_Data_Set.SelectFormerOwnerDistribution,(Convert.ToInt16(id)));
            this.dataGridView1.DataSource = selectFormerOwnerDistributionBindingSource;

            int i=0,tot=0;
            i = dataGridView1.Rows.Count;
            for (int j = 0; j < i; j++)
            {
                tot=tot+(Convert.ToInt16(dataGridView1.Rows[j].Cells[2].Value));
            }
            textBox_total_size.Text = tot.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}