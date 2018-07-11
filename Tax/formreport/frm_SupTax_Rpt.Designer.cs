namespace Tax
{
    partial class frm_SupTax_Rpt
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
            this.button1 = new System.Windows.Forms.Button();
            this.pantax = new System.Windows.Forms.Panel();
            this.label32 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtyr = new System.Windows.Forms.TextBox();
            this.txtsupcd = new System.Windows.Forms.TextBox();
            this.txtsupnm = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.combTAX = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pantax.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DarkRed;
            this.button1.Location = new System.Drawing.Point(123, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(209, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "بيان التعاملات الضربية للمولين";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pantax
            // 
            this.pantax.BackColor = System.Drawing.SystemColors.Control;
            this.pantax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pantax.Controls.Add(this.label32);
            this.pantax.Controls.Add(this.label11);
            this.pantax.Controls.Add(this.txtyr);
            this.pantax.Controls.Add(this.txtsupcd);
            this.pantax.Controls.Add(this.txtsupnm);
            this.pantax.Controls.Add(this.label9);
            this.pantax.Controls.Add(this.combTAX);
            this.pantax.Controls.Add(this.label5);
            this.pantax.ForeColor = System.Drawing.Color.DarkBlue;
            this.pantax.Location = new System.Drawing.Point(1, 1);
            this.pantax.Name = "pantax";
            this.pantax.Size = new System.Drawing.Size(446, 153);
            this.pantax.TabIndex = 5;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.DarkBlue;
            this.label32.Location = new System.Drawing.Point(355, 46);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(77, 16);
            this.label32.TabIndex = 22;
            this.label32.Text = "اسم المورد";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DarkBlue;
            this.label11.Location = new System.Drawing.Point(396, 78);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 16);
            this.label11.TabIndex = 21;
            this.label11.Text = "سنة";
            // 
            // txtyr
            // 
            this.txtyr.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtyr.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtyr.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtyr.Location = new System.Drawing.Point(243, 78);
            this.txtyr.MaxLength = 5;
            this.txtyr.Name = "txtyr";
            this.txtyr.Size = new System.Drawing.Size(92, 23);
            this.txtyr.TabIndex = 2;
            // 
            // txtsupcd
            // 
            this.txtsupcd.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtsupcd.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsupcd.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtsupcd.Location = new System.Drawing.Point(245, 20);
            this.txtsupcd.MaxLength = 5;
            this.txtsupcd.Name = "txtsupcd";
            this.txtsupcd.Size = new System.Drawing.Size(91, 23);
            this.txtsupcd.TabIndex = 0;
            this.txtsupcd.TextChanged += new System.EventHandler(this.txtsupcd_TextChanged);
            this.txtsupcd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtsupcd_KeyDown);
            // 
            // txtsupnm
            // 
            this.txtsupnm.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtsupnm.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsupnm.ForeColor = System.Drawing.Color.DarkBlue;
            this.txtsupnm.Location = new System.Drawing.Point(5, 47);
            this.txtsupnm.Name = "txtsupnm";
            this.txtsupnm.ReadOnly = true;
            this.txtsupnm.Size = new System.Drawing.Size(331, 23);
            this.txtsupnm.TabIndex = 1;
            this.txtsupnm.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DarkBlue;
            this.label9.Location = new System.Drawing.Point(362, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 16);
            this.label9.TabIndex = 18;
            this.label9.Text = "كود المورد";
            // 
            // combTAX
            // 
            this.combTAX.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combTAX.ForeColor = System.Drawing.Color.DarkBlue;
            this.combTAX.FormattingEnabled = true;
            this.combTAX.Items.AddRange(new object[] {
            "عام كامل",
            "اولي",
            "ثانية",
            "ثالثة",
            "رابعة"});
            this.combTAX.Location = new System.Drawing.Point(195, 114);
            this.combTAX.Name = "combTAX";
            this.combTAX.Size = new System.Drawing.Size(140, 24);
            this.combTAX.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkBlue;
            this.label5.Location = new System.Drawing.Point(373, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "عن فترة";
            // 
            // frm_SupTax_Rpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 225);
            this.Controls.Add(this.pantax);
            this.Controls.Add(this.button1);
            this.KeyPreview = true;
            this.Name = "frm_SupTax_Rpt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بيان التعاملات الضربية للمولين";
            this.Load += new System.EventHandler(this.frm_SupTax_Rpt_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_taxAnalaysis_Rpt_KeyDown);
            this.pantax.ResumeLayout(false);
            this.pantax.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pantax;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtyr;
        private System.Windows.Forms.TextBox txtsupcd;
        private System.Windows.Forms.TextBox txtsupnm;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox combTAX;
        private System.Windows.Forms.Label label5;
    }
}