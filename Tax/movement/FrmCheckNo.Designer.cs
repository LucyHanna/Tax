namespace Tax
{
    partial class FrmCheckNo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.yr = new System.Windows.Forms.NumericUpDown();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.col_checkNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_checkPeriod = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.col_checkDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_yr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_bank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.yr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(622, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "السنة";
            // 
            // yr
            // 
            this.yr.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yr.ForeColor = System.Drawing.Color.DarkRed;
            this.yr.Location = new System.Drawing.Point(543, 28);
            this.yr.Maximum = new decimal(new int[] {
            2099,
            0,
            0,
            0});
            this.yr.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.yr.Name = "yr";
            this.yr.Size = new System.Drawing.Size(73, 23);
            this.yr.TabIndex = 4;
            this.yr.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_checkNo,
            this.col_checkPeriod,
            this.col_checkDate,
            this.col_yr,
            this.Col_bank});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Location = new System.Drawing.Point(12, 58);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.Size = new System.Drawing.Size(682, 192);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(397, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 30);
            this.button1.TabIndex = 6;
            this.button1.Text = "عرض";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // col_checkNo
            // 
            this.col_checkNo.DataPropertyName = "checkNo";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkRed;
            this.col_checkNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_checkNo.HeaderText = "رقم الشيك";
            this.col_checkNo.Name = "col_checkNo";
            this.col_checkNo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_checkNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.col_checkNo.Width = 150;
            // 
            // col_checkPeriod
            // 
            this.col_checkPeriod.DataPropertyName = "checkPeriod";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.col_checkPeriod.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_checkPeriod.HeaderText = "الفترة";
            this.col_checkPeriod.Name = "col_checkPeriod";
            this.col_checkPeriod.ReadOnly = true;
            this.col_checkPeriod.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_checkPeriod.Width = 120;
            // 
            // col_checkDate
            // 
            this.col_checkDate.DataPropertyName = "checkDate";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.col_checkDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.col_checkDate.HeaderText = "تاريخ الشيك";
            this.col_checkDate.Name = "col_checkDate";
            this.col_checkDate.Width = 150;
            // 
            // col_yr
            // 
            this.col_yr.DataPropertyName = "yr";
            this.col_yr.HeaderText = "yr";
            this.col_yr.Name = "col_yr";
            this.col_yr.Visible = false;
            // 
            // Col_bank
            // 
            this.Col_bank.DataPropertyName = "bank";
            this.Col_bank.HeaderText = "البنك";
            this.Col_bank.Name = "Col_bank";
            this.Col_bank.Width = 200;
            // 
            // FrmCheckNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 262);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.yr);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmCheckNo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بيانات الشيك";
            this.Load += new System.EventHandler(this.FrmCheckNo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.yr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown yr;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_checkNo;
        private System.Windows.Forms.DataGridViewComboBoxColumn col_checkPeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_checkDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_yr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_bank;
    }
}