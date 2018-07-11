namespace Tax
{
    partial class frmMovSrch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.docno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doccd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docsubno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.movcd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docnm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_credsum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_supnm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.viewFile = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.docno,
            this.doccd,
            this.yr,
            this.docsubno,
            this.movcd,
            this.docnm,
            this.date,
            this.col_credsum,
            this.Col_supnm});
            this.dataGridView1.Location = new System.Drawing.Point(4, 42);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(851, 212);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // docno
            // 
            this.docno.DataPropertyName = "docno";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkRed;
            this.docno.DefaultCellStyle = dataGridViewCellStyle2;
            this.docno.HeaderText = "رقم الملف";
            this.docno.Name = "docno";
            this.docno.ReadOnly = true;
            // 
            // doccd
            // 
            this.doccd.DataPropertyName = "doccd";
            this.doccd.HeaderText = "doccd";
            this.doccd.Name = "doccd";
            this.doccd.ReadOnly = true;
            this.doccd.Visible = false;
            // 
            // yr
            // 
            this.yr.DataPropertyName = "yr";
            this.yr.HeaderText = "yr";
            this.yr.Name = "yr";
            this.yr.ReadOnly = true;
            this.yr.Visible = false;
            // 
            // docsubno
            // 
            this.docsubno.DataPropertyName = "docsubno";
            this.docsubno.HeaderText = "رقم تكميلي";
            this.docsubno.Name = "docsubno";
            this.docsubno.ReadOnly = true;
            // 
            // movcd
            // 
            this.movcd.DataPropertyName = "movcd";
            this.movcd.HeaderText = "الحركة";
            this.movcd.Name = "movcd";
            this.movcd.ReadOnly = true;
            // 
            // docnm
            // 
            this.docnm.DataPropertyName = "docnm";
            this.docnm.HeaderText = "إذن التوجية";
            this.docnm.Name = "docnm";
            this.docnm.ReadOnly = true;
            // 
            // date
            // 
            this.date.DataPropertyName = "mov_date";
            this.date.HeaderText = "التاريخ";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            // 
            // col_credsum
            // 
            this.col_credsum.DataPropertyName = "credsum";
            this.col_credsum.HeaderText = "الاجمالي";
            this.col_credsum.Name = "col_credsum";
            this.col_credsum.ReadOnly = true;
            // 
            // Col_supnm
            // 
            this.Col_supnm.DataPropertyName = "supnm";
            this.Col_supnm.HeaderText = "اسم الممول";
            this.Col_supnm.Name = "Col_supnm";
            this.Col_supnm.ReadOnly = true;
            this.Col_supnm.Width = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(18, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "نتائج البحث في الحركة اليومية";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(18, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // viewFile
            // 
            this.viewFile.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewFile.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.viewFile.Location = new System.Drawing.Point(4, 284);
            this.viewFile.Name = "viewFile";
            this.viewFile.Size = new System.Drawing.Size(194, 38);
            this.viewFile.TabIndex = 3;
            this.viewFile.Text = "عرض الملف";
            this.viewFile.UseVisualStyleBackColor = true;
            this.viewFile.Click += new System.EventHandler(this.viewFile_Click);
            // 
            // close
            // 
            this.close.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.ForeColor = System.Drawing.Color.DarkRed;
            this.close.Location = new System.Drawing.Point(454, 288);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(144, 36);
            this.close.TabIndex = 4;
            this.close.Text = "إغلاق";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(256, 279);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "مجموع دائن";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.DarkRed;
            this.textBox1.Location = new System.Drawing.Point(223, 300);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(145, 26);
            this.textBox1.TabIndex = 6;
            // 
            // frmMovSrch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 334);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.close);
            this.Controls.Add(this.viewFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "frmMovSrch";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "بحث في الحركة اليومية";
            this.Load += new System.EventHandler(this.frmMovSrch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button viewFile;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn docno;
        private System.Windows.Forms.DataGridViewTextBoxColumn doccd;
        private System.Windows.Forms.DataGridViewTextBoxColumn yr;
        private System.Windows.Forms.DataGridViewTextBoxColumn docsubno;
        private System.Windows.Forms.DataGridViewTextBoxColumn movcd;
        private System.Windows.Forms.DataGridViewTextBoxColumn docnm;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_credsum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_supnm;

    }
}