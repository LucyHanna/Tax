using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Tax
{
    public partial class FrmEarnJob : Form
    {
        SqlDataAdapter da_earnCheckNo;
        DataTable dt_earnCheckNo = new DataTable();

        SqlCommand cmd;

        public FrmEarnJob()
        {
            InitializeComponent();
        }

        private void FrmEarnJob_Load(object sender, EventArgs e)
        {
            cmd = new SqlCommand("",Static_class.con);
            if (Static_class.con.State != ConnectionState.Open) Static_class.con.Open();
        }

        private void yyyy_ValueChanged(object sender, EventArgs e)
        {
            string qry = @"SELECT  [yr],[mn],[checkNo],[bank]    
            FROM [TAXDB].[dbo].[earnCheckNo]
            where yr="+yyyy.Value.ToString();
            da_earnCheckNo = new SqlDataAdapter(qry, Static_class.con);
            dt_earnCheckNo = new DataTable();
            da_earnCheckNo.Fill(dt_earnCheckNo);

            dataGridView1.DataSource = dt_earnCheckNo;
            num_yy.Value = yyyy.Value;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
          
                try
                {
                    string yr =num_yy.Value.ToString();
                    string mn = num_mn.Value.ToString();
                    string checkNo = checkno.Text;
                    string bnk = bank.Text;

                    cmd.CommandText = @"INSERT INTO [dbo].[earnCheckNo]
                    ([yr]
                    ,[mn]
                    ,[checkNo]
                    ,[bank])
                    VALUES
                    (" + yr + @"
                    ," + mn + @"
                    ,'" + checkNo + @"'
                    ,'" + bnk + "')";


                    cmd.ExecuteNonQuery();


                    yyyy_ValueChanged(null, null);

                    MessageBox.Show("قد تم الحفظ");
                    num_mn.Value = (num_mn.Value.IfNullThenZero()>=12)? 1:  num_mn.Value.IfNullThenZero() + 1;
                    checkno.Text = "";
                    bank.Text = "";
                    this.ActiveControl = num_yy;
                }
                catch 
                {
                    MessageBox.Show("خطأ في الحفظ");
                   
                }

            
           
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string yr = dataGridView1.Rows[e.RowIndex].Cells["col_yr"].Value.ToString();
                string mn = dataGridView1.Rows[e.RowIndex].Cells["col_mn"].Value.ToString();
                string checkNo = dataGridView1.Rows[e.RowIndex].Cells["col_checkNo"].Value.ToString();
                string bank = dataGridView1.Rows[e.RowIndex].Cells["col_bank"].Value.ToString();

                cmd.CommandText = @"UPDATE [dbo].[earnCheckNo]
                SET
                [checkNo] ='" + checkNo + @"'
                ,[bank] = '" + bank + @"'
                WHERE  [yr] =" + yr + @"
                and [mn] = " + mn + "   ";

                cmd.ExecuteNonQuery();
            }
            catch 
            {
                dataGridView1.CancelEdit();
                MessageBox.Show("بيان خطأ");

            }

        }

        private void btn_paid_needed_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            #region  create_dt_master
            DataTable dt_master = new DataTable();
            dt_master.Columns.Add("yr", typeof(int));
            dt_master.Columns.Add("mn", typeof(int));
            dt_master.Columns.Add("paid", typeof(decimal));
            dt_master.Columns.Add("needed", typeof(decimal));
            dt_master.Columns.Add("checkNo", typeof(string));
            dt_master.Columns.Add("bank", typeof(string));



            for (int i = 1; i < 13; i++)
            {
                dt_master.Rows.Add(new Object[]{
                yyyy.Value.ToString(),
                i,
                0,0,"",""
             });

            }

            dt_master.Rows.Add(new Object[]{
                (yyyy.Value.IfNullThenZero()+1),
                1,
                0,0,"",""
             });


            dt_master.PrimaryKey = new DataColumn[2] { dt_master.Columns[0], dt_master.Columns[1] };
            #endregion

            
            
            string qry = "";
            string yr = yyyy.Value.IfNullThenZero().ToString();
            string yr_1 = (yyyy.Value.IfNullThenZero()+1).ToString();
            #region المسدد
            qry = @"SELECT  YEAR([move_date]),month ([move_date]), SUM(dbo.tblMovment.earndep) AS sum
            FROM         dbo.tblMovment
            WHERE     doccd=2 and (cast( [move_date] as datetime)  
            BETWEEN  cast ( '"+yr+@"/01/01' as datetime) AND cast ( '"+yr_1+@"/01/01' as datetime) )
            group by  YEAR([move_date]),month ([move_date])
            order by YEAR([move_date]),month ([move_date]) ";

            SqlDataAdapter da_paid = new SqlDataAdapter(qry, Static_class.con);
            DataTable dt_paid = new DataTable();
            da_paid.Fill(dt_paid);
            dt_paid.PrimaryKey = new DataColumn[2] { dt_paid.Columns[0], dt_paid.Columns[1] };

            Static_class.EditMasterDataTable(dt_master, dt_paid, 2, 2, 2);
            #endregion




            #region المستحق
            qry = @"  SELECT  year ([move_date]),month([move_date]), SUM(dbo.tblMovment.earncred) AS sum
            FROM         dbo.tblMovment
            WHERE     (cast( [move_date] as datetime)  
            BETWEEN  cast ( '" + yr + @"/01/01' as datetime) AND cast ( '" + yr_1 + @"/01/01' as datetime) )
            group by  YEAR([move_date]),month ([move_date])
            order by YEAR([move_date]),month ([move_date]) ";

            SqlDataAdapter da_needed = new SqlDataAdapter(qry, Static_class.con);
            DataTable dt_needed = new DataTable();
            da_needed.Fill(dt_needed);
            dt_needed.PrimaryKey = new DataColumn[2] { dt_needed.Columns[0], dt_needed.Columns[1] };

            Static_class.EditMasterDataTable(dt_master, dt_needed, 2, 3, 2);
            #endregion


            #region رقم الشيك
            qry = @"SELECT  [yr],[mn],[checkNo],[bank]    
            FROM [TAXDB].[dbo].[earnCheckNo]
            where yr="+yr + "  OR (yr="+yr_1+" and mn =1 )";

            SqlDataAdapter da_check = new SqlDataAdapter(qry, Static_class.con);
            DataTable dt_check = new DataTable();
            da_check.Fill(dt_check);
            dt_check.PrimaryKey = new DataColumn[2] { dt_check.Columns[0], dt_check.Columns[1] };

            Static_class.EditMasterDataTable(dt_master, dt_check, 2, 4, 2);
            Static_class.EditMasterDataTable(dt_master, dt_check, 2, 5, 3);
            #endregion

            dt_master.Rows[0]["paid"] = "0";

            dt_master.Rows[dt_master.Rows.Count - 1]["needed"] = "0";


            FrmReportViewer frm = new FrmReportViewer(dt_master, @"\report\earnCheck.rpt",yr.ToString());

            this.Cursor = Cursors.Arrow;


            frm.ShowDialog();

         
        }

        private void FrmEarnJob_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { SendKeys.Send("{Tab}"); }
        }

        private void num_yy_Enter(object sender, EventArgs e)
        {
            num_yy.Select(0, 99999);
        }

        private void num_mn_Enter(object sender, EventArgs e)
        {
            num_yy.Select(0, 99999);
        }

        private void checkno_Enter(object sender, EventArgs e)
        {
            checkno.SelectAll() ;
        }

        private void bank_Enter(object sender, EventArgs e)
        {
            bank.SelectAll();
        }

       

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            MessageBox.Show("delete");
            dataGridView1.CancelEdit();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count ==0)
            {
                MessageBox.Show("لابد من اختيار الشهر");
                return;
            }
             string chkno= dataGridView1.SelectedRows[0].Cells["Col_checkNo"].Value.ToString();
            int ndex=dataGridView1.SelectedRows[0].Index;

             MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show("تاكيد حذف رقم الشيك " + chkno, "رسالة تحذيرية ", buttons, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                


                try
                {
                    string yr = dataGridView1.Rows[ndex].Cells["col_yr"].Value.ToString();
                    string mn = dataGridView1.Rows[ndex].Cells["col_mn"].Value.ToString();
                    

                    cmd.CommandText = @"delete from [dbo].[earnCheckNo]
                    where 
                    [yr]=" + yr + @"
                    and [mn]=" + mn ;


                    cmd.ExecuteNonQuery();


                    MessageBox.Show("قد تم الحذف بنجاح");
                    dataGridView1.Rows.RemoveAt(ndex);

                }
                catch
                {
                    MessageBox.Show("خطأ في الحفظ");

                }
            }

        }

       
    }
}
