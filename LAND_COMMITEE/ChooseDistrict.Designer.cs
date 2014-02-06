namespace LAND_COMMITEE
{
    partial class ChooseDistrict
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_Province = new System.Windows.Forms.ComboBox();
            this.comboBox_District = new System.Windows.Forms.ComboBox();
            this.button_Suivant = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Province :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "District :";
            // 
            // comboBox_Province
            // 
            this.comboBox_Province.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Province.FormattingEnabled = true;
            this.comboBox_Province.Items.AddRange(new object[] {
            "NORTHERN PROVINCE",
            "EASTERN PROVINCE"});
            this.comboBox_Province.Location = new System.Drawing.Point(145, 39);
            this.comboBox_Province.Name = "comboBox_Province";
            this.comboBox_Province.Size = new System.Drawing.Size(198, 24);
            this.comboBox_Province.TabIndex = 2;
            this.comboBox_Province.Text = "----Select Province----";
            this.comboBox_Province.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox_District
            // 
            this.comboBox_District.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_District.FormattingEnabled = true;
            this.comboBox_District.Location = new System.Drawing.Point(145, 81);
            this.comboBox_District.Name = "comboBox_District";
            this.comboBox_District.Size = new System.Drawing.Size(198, 24);
            this.comboBox_District.TabIndex = 3;
            this.comboBox_District.Text = "----Select a District----";
            // 
            // button_Suivant
            // 
            this.button_Suivant.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Suivant.Location = new System.Drawing.Point(227, 117);
            this.button_Suivant.Name = "button_Suivant";
            this.button_Suivant.Size = new System.Drawing.Size(116, 33);
            this.button_Suivant.TabIndex = 4;
            this.button_Suivant.Text = "Suivant >>";
            this.button_Suivant.UseVisualStyleBackColor = true;
            this.button_Suivant.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChooseDistrict
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(355, 162);
            this.Controls.Add(this.button_Suivant);
            this.Controls.Add(this.comboBox_District);
            this.Controls.Add(this.comboBox_Province);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChooseDistrict";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChooseDistrict";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_Province;
        private System.Windows.Forms.ComboBox comboBox_District;
        private System.Windows.Forms.Button button_Suivant;
    }
}