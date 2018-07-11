namespace Tax
{
    partial class frm_taxStamp_Rpt
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.movcd = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.datetosh = new System.Windows.Forms.MaskedTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.datfrmsh = new System.Windows.Forms.MaskedTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DarkRed;
            this.button1.Location = new System.Drawing.Point(123, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(209, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "بيان ضرائب مساهمة ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.movcd);
            this.panel2.Controls.Add(this.label27);
            this.panel2.Controls.Add(this.datetosh);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.datfrmsh);
            this.panel2.Controls.Add(this.label22);
            this.panel2.ForeColor = System.Drawing.Color.DarkRed;
            this.panel2.Location = new System.Drawing.Point(4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(447, 99);
            this.panel2.TabIndex = 7;
            // 
            // movcd
            // 
            this.movcd.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.movcd.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.movcd.ForeColor = System.Drawing.Color.DarkBlue;
            this.movcd.FormattingEnabled = true;
            this.movcd.Location = new System.Drawing.Point(196, 64);
            this.movcd.Name = "movcd";
            this.movcd.Size = new System.Drawing.Size(124, 24);
            this.movcd.TabIndex = 2;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.DarkBlue;
            this.label27.Location = new System.Drawing.Point(330, 66);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(73, 16);
            this.label27.TabIndex = 28;
            this.label27.Text = "نوع الحركة";
            // 
            // datetosh
            // 
            this.datetosh.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.datetosh.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datetosh.ForeColor = System.Drawing.Color.DarkBlue;
            this.datetosh.Location = new System.Drawing.Point(39, 28);
            this.datetosh.Mask = "00/00/0000";
            this.datetosh.Name = "datetosh";
            this.datetosh.Size = new System.Drawing.Size(88, 23);
            this.datetosh.TabIndex = 1;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.DarkBlue;
            this.label21.Location = new System.Drawing.Point(129, 31);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(63, 16);
            this.label21.TabIndex = 18;
            this.label21.Text = "الي تاريخ";
            // 
            // datfrmsh
            // 
            this.datfrmsh.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.datfrmsh.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datfrmsh.ForeColor = System.Drawing.Color.DarkBlue;
            this.datfrmsh.Location = new System.Drawing.Point(254, 30);
            this.datfrmsh.Mask = "00/00/0000";
            this.datfrmsh.Name = "datfrmsh";
            this.datfrmsh.Size = new System.Drawing.Size(88, 23);
            this.datfrmsh.TabIndex = 0;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.DarkBlue;
            this.label22.Location = new System.Drawing.Point(344, 31);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(59, 16);
            this.label22.TabIndex = 16;
            this.label22.Text = "من تاريخ";
            // 
            // frm_taxStamp_Rpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 185);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button1);
            this.KeyPreview = true;
            this.Name = "frm_taxStamp_Rpt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بيان ضرائب المساهمة ";
            this.Load += new System.EventHandler(this.frm_taxStamp_Rpt_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_taxAnalaysis_Rpt_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox movcd;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.MaskedTextBox datetosh;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.MaskedTextBox datfrmsh;
        private System.Windows.Forms.Label label22;
    }
}