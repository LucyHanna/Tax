namespace Tax
{
    partial class frm_SalaryTax_Rpt
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.label28 = new System.Windows.Forms.Label();
            this.doccd = new System.Windows.Forms.ComboBox();
            this.dattoearn = new System.Windows.Forms.MaskedTextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.datfrmearn = new System.Windows.Forms.MaskedTextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DarkRed;
            this.button1.Location = new System.Drawing.Point(123, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(209, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "بيان ضريبة كسب العمل";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.label28);
            this.panel3.Controls.Add(this.doccd);
            this.panel3.Controls.Add(this.dattoearn);
            this.panel3.Controls.Add(this.label24);
            this.panel3.Controls.Add(this.datfrmearn);
            this.panel3.Controls.Add(this.label25);
            this.panel3.ForeColor = System.Drawing.Color.DarkRed;
            this.panel3.Location = new System.Drawing.Point(3, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(440, 103);
            this.panel3.TabIndex = 4;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.DarkBlue;
            this.label28.Location = new System.Drawing.Point(320, 70);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(101, 16);
            this.label28.TabIndex = 31;
            this.label28.Text = "نوع إذن التوجية";
            // 
            // doccd
            // 
            this.doccd.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.doccd.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.doccd.ForeColor = System.Drawing.Color.DarkBlue;
            this.doccd.FormattingEnabled = true;
            this.doccd.Location = new System.Drawing.Point(195, 66);
            this.doccd.Name = "doccd";
            this.doccd.Size = new System.Drawing.Size(124, 24);
            this.doccd.TabIndex = 2;
            // 
            // dattoearn
            // 
            this.dattoearn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.dattoearn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dattoearn.ForeColor = System.Drawing.Color.DarkBlue;
            this.dattoearn.Location = new System.Drawing.Point(46, 24);
            this.dattoearn.Mask = "00/00/0000";
            this.dattoearn.Name = "dattoearn";
            this.dattoearn.Size = new System.Drawing.Size(88, 23);
            this.dattoearn.TabIndex = 1;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.DarkBlue;
            this.label24.Location = new System.Drawing.Point(136, 27);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(63, 16);
            this.label24.TabIndex = 18;
            this.label24.Text = "الي تاريخ";
            // 
            // datfrmearn
            // 
            this.datfrmearn.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.datfrmearn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datfrmearn.ForeColor = System.Drawing.Color.DarkBlue;
            this.datfrmearn.Location = new System.Drawing.Point(280, 27);
            this.datfrmearn.Mask = "00/00/0000";
            this.datfrmearn.Name = "datfrmearn";
            this.datfrmearn.Size = new System.Drawing.Size(88, 23);
            this.datfrmearn.TabIndex = 0;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.DarkBlue;
            this.label25.Location = new System.Drawing.Point(370, 30);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(59, 16);
            this.label25.TabIndex = 16;
            this.label25.Text = "من تاريخ";
            // 
            // frm_SalaryTax_Rpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 225);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.button1);
            this.KeyPreview = true;
            this.Name = "frm_SalaryTax_Rpt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بيان قيمة ضريبة كسب العمل";
            this.Load += new System.EventHandler(this.frm_SalaryTax_Rpt_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_taxAnalaysis_Rpt_KeyDown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox doccd;
        private System.Windows.Forms.MaskedTextBox dattoearn;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.MaskedTextBox datfrmearn;
        private System.Windows.Forms.Label label25;
    }
}