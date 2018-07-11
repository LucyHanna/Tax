namespace Tax
{
    partial class miniSupp
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
            this.label14 = new System.Windows.Forms.Label();
            this.taxknd = new System.Windows.Forms.ComboBox();
            this.sts = new System.Windows.Forms.ComboBox();
            this.supcd = new System.Windows.Forms.TextBox();
            this.supnm = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.stcd = new System.Windows.Forms.TextBox();
            this.taxcd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(42, 140);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 16);
            this.label14.TabIndex = 37;
            this.label14.Text = "نوع الضريبة";
            // 
            // taxknd
            // 
            this.taxknd.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.taxknd.Enabled = false;
            this.taxknd.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.taxknd.FormattingEnabled = true;
            this.taxknd.Location = new System.Drawing.Point(120, 136);
            this.taxknd.Name = "taxknd";
            this.taxknd.Size = new System.Drawing.Size(163, 24);
            this.taxknd.TabIndex = 36;
            // 
            // sts
            // 
            this.sts.Enabled = false;
            this.sts.FormattingEnabled = true;
            this.sts.Location = new System.Drawing.Point(121, 106);
            this.sts.Name = "sts";
            this.sts.Size = new System.Drawing.Size(163, 21);
            this.sts.TabIndex = 32;
            // 
            // supcd
            // 
            this.supcd.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.supcd.Location = new System.Drawing.Point(121, 49);
            this.supcd.MaxLength = 5;
            this.supcd.Name = "supcd";
            this.supcd.ReadOnly = true;
            this.supcd.Size = new System.Drawing.Size(92, 20);
            this.supcd.TabIndex = 30;
            // 
            // supnm
            // 
            this.supnm.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.supnm.Location = new System.Drawing.Point(121, 79);
            this.supnm.Name = "supnm";
            this.supnm.ReadOnly = true;
            this.supnm.Size = new System.Drawing.Size(269, 20);
            this.supnm.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "كود المورد";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 34;
            this.label2.Text = "اسم المورد";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 35;
            this.label3.Text = "الجــــهة";
            // 
            // stcd
            // 
            this.stcd.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.stcd.Enabled = false;
            this.stcd.Location = new System.Drawing.Point(121, 107);
            this.stcd.MaxLength = 3;
            this.stcd.Name = "stcd";
            this.stcd.ReadOnly = true;
            this.stcd.Size = new System.Drawing.Size(36, 20);
            this.stcd.TabIndex = 29;
            this.stcd.TabStop = false;
            // 
            // taxcd
            // 
            this.taxcd.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.taxcd.Enabled = false;
            this.taxcd.Location = new System.Drawing.Point(121, 140);
            this.taxcd.MaxLength = 3;
            this.taxcd.Name = "taxcd";
            this.taxcd.ReadOnly = true;
            this.taxcd.Size = new System.Drawing.Size(36, 20);
            this.taxcd.TabIndex = 38;
            this.taxcd.TabStop = false;
            // 
            // miniSupp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 205);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.taxknd);
            this.Controls.Add(this.supcd);
            this.Controls.Add(this.supnm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.taxcd);
            this.Controls.Add(this.sts);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.stcd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "miniSupp";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "الموردين";
            this.Load += new System.EventHandler(this.miniSupp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox taxknd;
        private System.Windows.Forms.ComboBox sts;
        private System.Windows.Forms.TextBox supcd;
        private System.Windows.Forms.TextBox supnm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox stcd;
        private System.Windows.Forms.TextBox taxcd;
    }
}