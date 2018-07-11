namespace Tax
{
    partial class frm_taxPaid_Rpt
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.paieddatto = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.paieddatFrm = new System.Windows.Forms.MaskedTextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.btnfrjob = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.comboBox2);
            this.panel4.Controls.Add(this.label31);
            this.panel4.Controls.Add(this.paieddatto);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.paieddatFrm);
            this.panel4.Controls.Add(this.label26);
            this.panel4.ForeColor = System.Drawing.Color.DarkRed;
            this.panel4.Location = new System.Drawing.Point(4, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(447, 102);
            this.panel4.TabIndex = 0;
            // 
            // comboBox2
            // 
            this.comboBox2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.ForeColor = System.Drawing.Color.DarkBlue;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "مدين",
            "دائن"});
            this.comboBox2.Location = new System.Drawing.Point(233, 67);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(99, 24);
            this.comboBox2.TabIndex = 2;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.DarkBlue;
            this.label31.Location = new System.Drawing.Point(356, 72);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(37, 16);
            this.label31.TabIndex = 19;
            this.label31.Text = "النوع";
            // 
            // paieddatto
            // 
            this.paieddatto.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.paieddatto.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paieddatto.ForeColor = System.Drawing.Color.DarkBlue;
            this.paieddatto.Location = new System.Drawing.Point(49, 28);
            this.paieddatto.Mask = "00/00/0000";
            this.paieddatto.Name = "paieddatto";
            this.paieddatto.Size = new System.Drawing.Size(88, 23);
            this.paieddatto.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DarkBlue;
            this.label10.Location = new System.Drawing.Point(139, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 16);
            this.label10.TabIndex = 18;
            this.label10.Text = "الي تاريخ";
            // 
            // paieddatFrm
            // 
            this.paieddatFrm.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.paieddatFrm.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paieddatFrm.ForeColor = System.Drawing.Color.DarkBlue;
            this.paieddatFrm.Location = new System.Drawing.Point(244, 30);
            this.paieddatFrm.Mask = "00/00/0000";
            this.paieddatFrm.Name = "paieddatFrm";
            this.paieddatFrm.Size = new System.Drawing.Size(88, 23);
            this.paieddatFrm.TabIndex = 0;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.DarkBlue;
            this.label26.Location = new System.Drawing.Point(334, 31);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(59, 16);
            this.label26.TabIndex = 16;
            this.label26.Text = "من تاريخ";
            // 
            // btnfrjob
            // 
            this.btnfrjob.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnfrjob.ForeColor = System.Drawing.Color.DarkRed;
            this.btnfrjob.Location = new System.Drawing.Point(115, 168);
            this.btnfrjob.Name = "btnfrjob";
            this.btnfrjob.Size = new System.Drawing.Size(224, 35);
            this.btnfrjob.TabIndex = 2;
            this.btnfrjob.Text = "مهن حرة";
            this.btnfrjob.UseVisualStyleBackColor = true;
            this.btnfrjob.Click += new System.EventHandler(this.btnfrjob_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.DarkRed;
            this.button8.Location = new System.Drawing.Point(115, 209);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(224, 37);
            this.button8.TabIndex = 3;
            this.button8.Text = "ارباح تجارية و صناعية";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.DarkRed;
            this.button6.Location = new System.Drawing.Point(115, 252);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(224, 37);
            this.button6.TabIndex = 4;
            this.button6.Text = "دمغة";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.Color.DarkRed;
            this.button7.Location = new System.Drawing.Point(115, 120);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(224, 37);
            this.button7.TabIndex = 1;
            this.button7.Text = "كسب عمل";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // frm_taxPaid_Rpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 353);
            this.Controls.Add(this.btnfrjob);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button8);
            this.KeyPreview = true;
            this.Name = "frm_taxPaid_Rpt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بيان الضريبة المسددة ";
            this.Load += new System.EventHandler(this.frm_taxPaid_Rpt_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_taxAnalaysis_Rpt_KeyDown);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.MaskedTextBox paieddatto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox paieddatFrm;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btnfrjob;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;

    }
}