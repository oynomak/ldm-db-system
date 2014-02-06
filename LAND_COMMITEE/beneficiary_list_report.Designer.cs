namespace LAND_COMMITEE
{
    partial class beneficiary_list_report
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(beneficiary_list_report));
            this.crystal_rpt_ben_list_vi = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystal_rpt_ben_list_vi
            // 
            this.crystal_rpt_ben_list_vi.ActiveViewIndex = -1;
            this.crystal_rpt_ben_list_vi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystal_rpt_ben_list_vi.DisplayGroupTree = false;
            this.crystal_rpt_ben_list_vi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystal_rpt_ben_list_vi.Location = new System.Drawing.Point(0, 0);
            this.crystal_rpt_ben_list_vi.Name = "crystal_rpt_ben_list_vi";
            this.crystal_rpt_ben_list_vi.SelectionFormula = "";
            this.crystal_rpt_ben_list_vi.ShowCloseButton = false;
            this.crystal_rpt_ben_list_vi.ShowExportButton = false;
            this.crystal_rpt_ben_list_vi.ShowGroupTreeButton = false;
            this.crystal_rpt_ben_list_vi.ShowRefreshButton = false;
            this.crystal_rpt_ben_list_vi.Size = new System.Drawing.Size(1028, 746);
            this.crystal_rpt_ben_list_vi.TabIndex = 0;
            this.crystal_rpt_ben_list_vi.ViewTimeSelectionFormula = "";
            this.crystal_rpt_ben_list_vi.Load += new System.EventHandler(this.crystal_rpt_ben_list_vi_Load);
            // 
            // beneficiary_list_report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 746);
            this.Controls.Add(this.crystal_rpt_ben_list_vi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1036, 780);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1022, 736);
            this.Name = "beneficiary_list_report";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LAND COMMITEE : Beneficiary List by PROVINCE";
            this.Load += new System.EventHandler(this.beneficiary_list_report_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystal_rpt_ben_list_vi;
    }
}