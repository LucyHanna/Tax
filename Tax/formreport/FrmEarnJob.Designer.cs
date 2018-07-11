namespace Tax
{
    partial class FrmEarnJob
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
            this.yyyy = new System.Windows.Forms.NumericUpDown();
            this.btn_paid_needed = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.col_yr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_mn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_checkNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_bank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_save = new System.Windows.Forms.Button();
            this.num_yy = new System.Windows.Forms.NumericUpDown();
            this.checkno = new System.Windows.Forms.TextBox();
            this.num_mn = new System.Windows.Forms.NumericUpDown();
            this.bank = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_delete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_yy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_mn)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // yyyy
            // 
            this.yyyy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yyyy.Location = new System.Drawing.Point(48, 18);
            this.yyyy.Maximum = new decimal(new int[] {
            2099,
            0,
            0,
            0});
            this.yyyy.Minimum = new decimal(new int[] {
            2010,
            0,
            0,
            0});
            this.yyyy.Name = "yyyy";
            this.yyyy.Size = new System.Drawing.Size(82, 26);
            this.yyyy.TabIndex = 0;
            this.yyyy.Value = new decimal(new int[] {
            2010,
            0,
            0,
            0});
            this.yyyy.ValueChanged += new System.EventHandler(this.yyyy_ValueChanged);
            // 
            // btn_paid_needed
            // 
            this.btn_paid_needed.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_paid_needed.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_paid_needed.Location = new System.Drawing.Point(136, 12);
            this.btn_paid_needed.Name = "btn_paid_needed";
            this.btn_paid_needed.Size = new System.Drawing.Size(265, 37);
            this.btn_paid_needed.TabIndex = 1;
            this.btn_paid_needed.Text = "بيان المسدد و المستحق ض كسب عمل";
            this.btn_paid_needed.UseVisualStyleBackColor = true;
            this.btn_paid_needed.Click += new System.EventHandler(this.btn_paid_needed_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_yr,
            this.Col_mn,
            this.Col_checkNo,
            this.Col_bank});
            this.dataGridView1.Location = new System.Drawing.Point(11, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.Size = new System.Drawing.Size(394, 269);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // col_yr
            // 
            this.col_yr.DataPropertyName = "yr";
            this.col_yr.HeaderText = "السنة";
            this.col_yr.Name = "col_yr";
            this.col_yr.ReadOnly = true;
            this.col_yr.Width = 40;
            // 
            // Col_mn
            // 
            this.Col_mn.DataPropertyName = "mn";
            this.Col_mn.HeaderText = "الشهر";
            this.Col_mn.Name = "Col_mn";
            this.Col_mn.ReadOnly = true;
            this.Col_mn.Width = 40;
            // 
            // Col_checkNo
            // 
            this.Col_checkNo.DataPropertyName = "checkNo";
            this.Col_checkNo.HeaderText = "رقم الشيك";
            this.Col_checkNo.Name = "Col_checkNo";
            // 
            // Col_bank
            // 
            this.Col_bank.DataPropertyName = "bank";
            this.Col_bank.HeaderText = "البنك";
            this.Col_bank.Name = "Col_bank";
            this.Col_bank.Width = 150;
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Location = new System.Drawing.Point(7, 173);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(148, 30);
            this.btn_save.TabIndex = 4;
            this.btn_save.Text = "حفظ";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // num_yy
            // 
            this.num_yy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_yy.Location = new System.Drawing.Point(48, 35);
            this.num_yy.Maximum = new decimal(new int[] {
            2099,
            0,
            0,
            0});
            this.num_yy.Minimum = new decimal(new int[] {
            2010,
            0,
            0,
            0});
            this.num_yy.Name = "num_yy";
            this.num_yy.Size = new System.Drawing.Size(82, 26);
            this.num_yy.TabIndex = 0;
            this.num_yy.Value = new decimal(new int[] {
            2010,
            0,
            0,
            0});
            this.num_yy.Enter += new System.EventHandler(this.num_yy_Enter);
            // 
            // checkno
            // 
            this.checkno.Location = new System.Drawing.Point(3, 99);
            this.checkno.Name = "checkno";
            this.checkno.Size = new System.Drawing.Size(123, 20);
            this.checkno.TabIndex = 2;
            this.checkno.Enter += new System.EventHandler(this.checkno_Enter);
            // 
            // num_mn
            // 
            this.num_mn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num_mn.Location = new System.Drawing.Point(48, 67);
            this.num_mn.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.num_mn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_mn.Name = "num_mn";
            this.num_mn.Size = new System.Drawing.Size(82, 26);
            this.num_mn.TabIndex = 1;
            this.num_mn.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.num_mn.Enter += new System.EventHandler(this.num_mn_Enter);
            // 
            // bank
            // 
            this.bank.Location = new System.Drawing.Point(2, 136);
            this.bank.Name = "bank";
            this.bank.Size = new System.Drawing.Size(123, 20);
            this.bank.TabIndex = 3;
            this.bank.Enter += new System.EventHandler(this.bank_Enter);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_delete);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.bank);
            this.groupBox1.Controls.Add(this.num_mn);
            this.groupBox1.Controls.Add(this.checkno);
            this.groupBox1.Controls.Add(this.num_yy);
            this.groupBox1.Controls.Add(this.btn_save);
            this.groupBox1.Location = new System.Drawing.Point(411, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(188, 274);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "إضافة رقم الشيك";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(142, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "البنك";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(130, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "رقم الشيك";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "الشهر";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "السنة";
            // 
            // btn_delete
            // 
            this.btn_delete.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.ForeColor = System.Drawing.Color.DarkRed;
            this.btn_delete.Location = new System.Drawing.Point(6, 221);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(148, 30);
            this.btn_delete.TabIndex = 19;
            this.btn_delete.Text = "حذف";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // FrmEarnJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 369);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.yyyy);
            this.Controls.Add(this.btn_paid_needed);
            this.KeyPreview = true;
            this.Name = "FrmEarnJob";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بيان المسدد و المستحق ض كسب عمل";
            this.Load += new System.EventHandler(this.FrmEarnJob_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmEarnJob_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.yyyy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_yy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_mn)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown yyyy;
        private System.Windows.Forms.Button btn_paid_needed;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.NumericUpDown num_yy;
        private System.Windows.Forms.TextBox checkno;
        private System.Windows.Forms.NumericUpDown num_mn;
        private System.Windows.Forms.TextBox bank;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_yr;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_mn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_checkNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_bank;
        private System.Windows.Forms.Button btn_delete;
    }
}