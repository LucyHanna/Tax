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
    public partial class FrmCheckNo : Form
    {
        public FrmCheckNo()
        {
            InitializeComponent();
        }
        SqlCommandBuilder update_Dv_result = new SqlCommandBuilder();
        SqlDataAdapter dgv_da;
        DataTable dgv_dt;

        string qry_main = @" SELECT yr, checkNo,checkPeriod,  checkDate , bank 
        FROM tblCheckNo ";

        DataTable dt_period = new DataTable();
      

        private void FrmCheckNo_Load(object sender, EventArgs e)
        {
            #region create_dt_period
            dt_period.Columns.Add("checkPeriod", typeof(int));
            dt_period.Columns.Add("checkPeriod_nm", typeof(string));

            dt_period.PrimaryKey = new DataColumn[1] { dt_period.Columns["checkPeriod"] };

            DataRow row = dt_period.NewRow();
            row["checkPeriod"] = 1;
            row["checkPeriod_nm"] = "الاولي";
            dt_period.Rows.Add(row);

            row = dt_period.NewRow();
            row["checkPeriod"] = 2;
            row["checkPeriod_nm"] = "الثانية";
            dt_period.Rows.Add(row);


            row = dt_period.NewRow();
            row["checkPeriod"] = 3;
            row["checkPeriod_nm"] = "الثالثة";
            dt_period.Rows.Add(row);


            row = dt_period.NewRow();
            row["checkPeriod"] = 4;
            row["checkPeriod_nm"] = "الرابعة";
            dt_period.Rows.Add(row); 
            #endregion


            col_checkPeriod.DataSource = dt_period;
            col_checkPeriod.DisplayMember = "checkPeriod_nm";
            col_checkPeriod.ValueMember = "checkPeriod";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            fillDGV();
        }


        private void fillDGV()
        {

           
            string qry = qry_main + " where yr ="+yr.Value.ToString();

            dgv_da = new SqlDataAdapter(qry, Static_class.con);

            update_Dv_result = new SqlCommandBuilder(dgv_da);

            dgv_dt = new DataTable();

            dgv_dt.PrimaryKey = new DataColumn[3] { dgv_dt.Columns["accountid"], dgv_dt.Columns["End_YY"], dgv_dt.Columns["End_MM"] };

            update_Dv_result.DataAdapter.Fill(dgv_dt);


            if (dgv_dt.Rows.Count == 0)
            {
                for (int i = 1; i <= 4; i++)
                {
                    DataRow dr = dgv_dt.NewRow();
                    dr["yr"] = yr.Value.ToString();
                    dr["checkPeriod"] = i;
                    //dr["checkNo"]="";
                    //dr["checkDate"] = "";

                    dgv_dt.Rows.Add(dr);
                    //dgv_dt.AcceptChanges();

                }
            }

            dataGridView1.DataSource = dgv_dt;





        }


        private void updateDv_Result()
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;


                BindingContext[dgv_dt].EndCurrentEdit();

                using (new SqlCommandBuilder(dgv_da))
                {
                    int xx = dgv_da.Update(dgv_dt);

                }


                dgv_dt.AcceptChanges();
              
                this.Cursor = Cursors.Arrow;



            }
            catch (Exception ex)
            {

                this.Cursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
                return;

            }




        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            updateDv_Result();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            dataGridView1.CancelEdit();
            MessageBox.Show("خطأ في الادخال","خطأ",MessageBoxButtons.OK,MessageBoxIcon.Hand);
             
        }
    }
}
