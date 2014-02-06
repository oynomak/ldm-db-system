namespace LAND_COMMITEE
{
    partial class beneficiary_by_cell
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(beneficiary_by_cell));
            this.crystal_cell = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystal_cell
            // 
            this.crystal_cell.ActiveViewIndex = -1;
            this.crystal_cell.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystal_cell.DisplayGroupTree = false;
            this.crystal_cell.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystal_cell.Location = new System.Drawing.Point(0, 0);
            this.crystal_cell.Name = "crystal_cell";
            this.crystal_cell.SelectionFormula = "";
            this.crystal_cell.ShowCloseButton = false;
            this.crystal_cell.ShowExportButton = false;
            this.crystal_cell.ShowGroupTreeButton = false;
            this.crystal_cell.ShowRefreshButton = false;
            this.crystal_cell.Size = new System.Drawing.Size(1028, 746);
            this.crystal_cell.TabIndex = 0;
            this.crystal_cell.ViewTimeSelectionFormula = "";
            this.crystal_cell.Load += new System.EventHandler(this.crystal_cell_Load);
            // 
            // beneficiary_by_cell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 746);
            this.Controls.Add(this.crystal_cell);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1036, 780);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1022, 736);
            this.Name = "beneficiary_by_cell";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LAND COMMITEE : Beneficiary List by CELLULE";
            this.Load += new System.EventHandler(this.beneficiary_by_cell_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystal_cell;
    }
}