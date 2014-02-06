namespace LAND_COMMITEE
{
    partial class LandComHelp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Home");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Supervisor Information");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Land Informantion");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Forms", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LandComHelp));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.header = new System.Windows.Forms.Label();
            this.body = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pROVINCEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lAND_COMMITEE_Data_Set = new LAND_COMMITEE.LAND_COMMITEE_Data_Set();
            this.pROVINCE_TableAdapter = new LAND_COMMITEE.LAND_COMMITEE_Data_SetTableAdapters.PROVINCE_TableAdapter();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pROVINCEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lAND_COMMITEE_Data_Set)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            treeNode1.Checked = true;
            treeNode1.Name = "Node0";
            treeNode1.Text = "Home";
            treeNode2.Name = "Node2";
            treeNode2.Text = "Supervisor Information";
            treeNode3.Name = "Node3";
            treeNode3.Text = "Land Informantion";
            treeNode4.Name = "Node1";
            treeNode4.Text = "Forms";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode4});
            this.treeView1.Size = new System.Drawing.Size(166, 470);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // header
            // 
            this.header.AutoSize = true;
            this.header.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.header.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.header.Location = new System.Drawing.Point(15, 24);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(71, 18);
            this.header.TabIndex = 1;
            this.header.Text = "header";
            // 
            // body
            // 
            this.body.AutoSize = true;
            this.body.Location = new System.Drawing.Point(211, 120);
            this.body.Name = "body";
            this.body.Size = new System.Drawing.Size(30, 13);
            this.body.TabIndex = 2;
            this.body.Text = "body";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.header);
            this.panel1.Location = new System.Drawing.Point(184, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(608, 83);
            this.panel1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Land Commitee Project Help Document ";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(202, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(589, 3);
            this.label2.TabIndex = 4;
            this.label2.Text = "                                                                                 " +
                "                                                             ";
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(202, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(3, 359);
            this.label1.TabIndex = 5;
            this.label1.Text = "                                                                                 " +
                "                                                             ";
            // 
            // pROVINCEBindingSource
            // 
            this.pROVINCEBindingSource.DataMember = "PROVINCE";
            this.pROVINCEBindingSource.DataSource = this.lAND_COMMITEE_Data_Set;
            // 
            // lAND_COMMITEE_Data_Set
            // 
            this.lAND_COMMITEE_Data_Set.DataSetName = "LAND_COMMITEE_Data_Set";
            this.lAND_COMMITEE_Data_Set.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pROVINCE_TableAdapter
            // 
            this.pROVINCE_TableAdapter.ClearBeforeFill = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(-19, -49);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(100, 96);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // LandComHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 503);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.body);
            this.Controls.Add(this.treeView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LandComHelp";
            this.Text = "Help";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LandComHelp_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pROVINCEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lAND_COMMITEE_Data_Set)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label header;
        private System.Windows.Forms.Label body;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private LAND_COMMITEE_Data_Set lAND_COMMITEE_Data_Set;
        private System.Windows.Forms.BindingSource pROVINCEBindingSource;
        private LAND_COMMITEE.LAND_COMMITEE_Data_SetTableAdapters.PROVINCE_TableAdapter pROVINCE_TableAdapter;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}