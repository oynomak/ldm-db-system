namespace LAND_COMMITEE
{
    partial class beneficiary_list_by_sector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(beneficiary_list_by_sector));
            this.crystal_sector = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystal_sector
            // 
            this.crystal_sector.ActiveViewIndex = -1;
            this.crystal_sector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystal_sector.DisplayGroupTree = false;
            this.crystal_sector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystal_sector.Location = new System.Drawing.Point(0, 0);
            this.crystal_sector.Name = "crystal_sector";
            this.crystal_sector.SelectionFormula = "";
            this.crystal_sector.ShowCloseButton = false;
            this.crystal_sector.ShowExportButton = false;
            this.crystal_sector.ShowGroupTreeButton = false;
            this.crystal_sector.ShowRefreshButton = false;
            this.crystal_sector.Size = new System.Drawing.Size(1028, 746);
            this.crystal_sector.TabIndex = 0;
            this.crystal_sector.ViewTimeSelectionFormula = "";
            this.crystal_sector.Load += new System.EventHandler(this.crystal_sector_Load);
            // 
            // beneficiary_list_by_sector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 746);
            this.Controls.Add(this.crystal_sector);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1036, 780);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1022, 736);
            this.Name = "beneficiary_list_by_sector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LAND COMMITEE : Beneficiary List by SECTOR";
            this.Load += new System.EventHandler(this.beneficiary_list_by_sector_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystal_sector;
    }
}