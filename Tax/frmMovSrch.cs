using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tax
{
    public partial class frmMovSrch : Form
    {
        public frmMovSrch()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();

    

        public string[] pk = new string[4];


        public frmMovSrch(DataTable dt)
        {
            this.dt = dt;
            InitializeComponent();
            this.dataGridView1.DataSource = dt;
            label2.Text = " عدد الملفات المطابقة للبحث (" + dt.Rows.Count + ")";
            textBox1.Text = dt.Compute("sum (credsum) ","").IfNullThenZero().ToString();
        }

        private void frmMovSrch_Load(object sender, EventArgs e)
        {
            dt.PrimaryKey = new DataColumn[4] { dt.Columns["docno"], dt.Columns["docsubno"], dt.Columns["yr"], dt.Columns["doccd"] }; 


            
        }

        private void viewFile_Click(object sender, EventArgs e)
        {
            int gvpos = this.dataGridView1.CurrentCell.RowIndex;
            
            pk[0]=dataGridView1.Rows[gvpos].Cells["docno"].Value.ToString();
            pk[1]=dataGridView1.Rows[gvpos].Cells["docsubno"].Value.ToString();
            pk[2]=dataGridView1.Rows[gvpos].Cells["yr"].Value.ToString();
            pk[3] = dataGridView1.Rows[gvpos].Cells["doccd"].Value.ToString();

            this.Close();

        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int gvpos = this.dataGridView1.CurrentCell.RowIndex;
            pk[0] = dataGridView1.Rows[gvpos].Cells["docno"].Value.ToString();
            pk[1] = dataGridView1.Rows[gvpos].Cells["docsubno"].Value.ToString();
            pk[2] = dataGridView1.Rows[gvpos].Cells["yr"].Value.ToString();
            pk[3] = dataGridView1.Rows[gvpos].Cells["doccd"].Value.ToString();
            this.Close();
        }
    }
}
