using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;



namespace Tax
{
    public partial class frm_SupBasicData_Rpt : Form
    {
        public frm_SupBasicData_Rpt()
        {
            InitializeComponent();
        }

        private void frm_SupBasicData_Rpt_Load(object sender, EventArgs e)
        {
            TBLsuppliers_da.Fill(TBLsuppliers_Table);
            DataColumn[] dpk = new DataColumn[1];
            dpk[0] = TBLsuppliers_Table.Columns[0];
            TBLsuppliers_Table.PrimaryKey = dpk;
        }

        public SqlDataAdapter TBLsuppliers_da = new SqlDataAdapter
       (" SELECT     supcd, supnm, stcd , taxcd  FROM         TBLsuppliers "
       , Static_class.con);
        public DataTable TBLsuppliers_Table = new DataTable();


        ErrorProvider erPrv = new ErrorProvider();
        public int checkEmptyComp(Control con)
        {
            erPrv.Clear();
            int x = 0;
            foreach (Control c in con.Controls)
            {


                if (c.GetType().ToString() == "System.Windows.Forms.TextBox" && c.Visible)
                {

                    if (c.Text == "" && c.Name != "docno")
                    {

                        erPrv.SetError(c, "لابد من ادخال هذا البيان");
                        x = 1;
                        c.Focus();
                        return x;

                    }
                }
                else if (c.GetType().ToString() == "System.Windows.Forms.MaskedTextBox" && c.Visible)
                {

                    if (c.Text.Length != 10)
                    {
                        erPrv.SetError(c, "لابد من ادخال هذا البيان");
                        x = 1;
                        c.Focus();
                        return x;
                    }
                }


                else if (c.GetType().ToString() == "System.Windows.Forms.ComboBox" && c.Visible)
                {


                    if (c.Text == "")
                    {
                        erPrv.SetError(c, "لابد من ادخال هذا البيان");
                        x = 1;
                        c.Focus();
                        return x;
                    }
                }
            }

            return x;

        }

        private void view_Click(object sender, EventArgs e)
        {
            if (checkEmptyComp(panbscsupdt) == 0)
            {

                Static_class.reportdb = 2;
                Static_class.rptlbl5 = "الكــل";
                string tblsql = "";
                //if (cmbmonth.SelectedIndex == 0)

                    tblsql = @" SELECT     dbo.tblMovment.docno, dbo.tblMovment.docsubno, dbo.TBLsuppliers.supnm, dbo.tblMovment.mov_date, dbo.tblMovment.prftcred,  dbo.tblMovment.prftdep,
                      dbo.tblMovment.freejbscred, dbo.tblMovment.freejbsdep,dbo.taxkd.taxnm, dbo.tblMovment.supcd ,taxfileNo,taxrecNo , dbo.taxkd.taxprc as prc
                FROM         dbo.TBLsuppliers INNER JOIN
                      dbo.taxkd ON dbo.TBLsuppliers.taxcd = dbo.taxkd.taxcd RIGHT OUTER JOIN
                      dbo.tblMovment ON dbo.TBLsuppliers.supcd = dbo.tblMovment.supcd where dbo.tblMovment.supcd ='" + supcd.Text + "' and  yr=" + yr.Text + " order by dbo.tblMovment.docno ";

//                else
//                    tblsql = @" SELECT     dbo.tblMovment.docno, dbo.tblMovment.docsubno, dbo.TBLsuppliers.supnm, dbo.tblMovment.mov_date, dbo.tblMovment.prftcred, dbo.tblMovment.prftdep,
//                      dbo.tblMovment.freejbscred,dbo.tblMovment.freejbsdep, dbo.taxkd.taxnm, dbo.tblMovment.supcd,taxfileNo,taxrecNo
//                FROM         dbo.TBLsuppliers INNER JOIN
//                      dbo.taxkd ON dbo.TBLsuppliers.taxcd = dbo.taxkd.taxcd RIGHT OUTER JOIN
//                      dbo.tblMovment ON dbo.TBLsuppliers.supcd = dbo.tblMovment.supcd where dbo.tblMovment.supcd ='" + supcd.Text + "' and  yr=" + yr.Text + " and month(convert(datetime ,mov_date,103))=" + cmbmonth.SelectedValue.ToString() + " order by dbo.tblMovment.docno ";

                Static_class.fillTbl(tblsql);
                Static_class.rptlbl1 = "";

                Static_class.rptlbl2 = "";
                Static_class.rptlbl3 = "";
                Static_class.rptlbl4 = "";


                Static_class.reportname = "rptbscsupdt";


                Static_class.sysprint();
            }
        }

        private void btncstm_Click(object sender, EventArgs e)
        {
            Static_class.reportdb = 2;
            Static_class.rptlbl5 = "الكــل";
            string frm = "", tom = "";
            switch (combTAX1.SelectedIndex)
            {

                case 0:
                    {
                        frm = "1"; tom = "12";
                    } break;

                case 1:
                    {
                        frm = "1"; tom = "3";
                    } break;
                case 2:
                    {
                        frm = "4"; tom = "6";
                    } break;

                case 3:
                    {
                        frm = "7"; tom = "9";
                    } break;
                case 4:
                    {
                        frm = "10"; tom = "12";
                    } break;
            }

            string tblsql = "";
            //            if (cmbmonth.SelectedIndex == 0)

            //                tblsql = @" SELECT     dbo.tblMovment.docno, dbo.tblMovment.docsubno, dbo.TBLsuppliers.supnm, CASE WHEN MONTH(dbo.tblMovment.date) < 4 THEN 'الأولــــى' WHEN MONTH(dbo.tblMovment.date) < 7 THEN 'الثانية' WHEN MONTH(dbo.tblMovment.date) 
            //                      < 10 THEN 'الثالثة' ELSE 'الرابعة' END AS date, dbo.tblMovment.prftcred, 
            //                      dbo.tblMovment.freejbscred, dbo.taxkd.taxnm, dbo.tblMovment.supcd ,taxfileNo,taxrecNo
            //                FROM         dbo.TBLsuppliers INNER JOIN
            //                      dbo.taxkd ON dbo.TBLsuppliers.taxcd = dbo.taxkd.taxcd RIGHT OUTER JOIN
            //                      dbo.tblMovment ON dbo.TBLsuppliers.supcd = dbo.tblMovment.supcd
            //                where  dbo.TBLsuppliers.supnm is not null and  yr=" + yr.Text + " order by dbo.tblMovment.docno ";

            //            else
            tblsql = @" SELECT      dbo.tblMovment.docno, dbo.tblMovment.docsubno,TBLsuppliers.taxcd,
substring( [mov_date],4,7) as dt, dbo.TBLsuppliers.supnm, 
CASE WHEN MONTH(cast( [move_date] as datetime)) < 4 THEN 'الأولــــى' 
WHEN MONTH(cast( [move_date] as datetime)) 
                      < 7 THEN 'الثانية' WHEN MONTH(cast( [move_date] as datetime)) < 10 THEN 'الثالثة' ELSE 'الرابعة' END AS date, dbo.tblMovment.prftcred, 
                      dbo.tblMovment.prftdep, dbo.taxkd.taxprc AS prc, dbo.tblMovment.freejbscred, dbo.tblMovment.freejbsdep, dbo.taxkd.taxnm, dbo.tblMovment.supcd, 
                      dbo.TBLsuppliers.taxfileNo, dbo.TBLsuppliers.taxrecNo, dbo.tblTxDep.txDep_Nm
FROM         dbo.TBLsuppliers INNER JOIN
                      dbo.taxkd ON dbo.TBLsuppliers.taxcd = dbo.taxkd.taxcd LEFT OUTER JOIN
                      dbo.tblMovment ON dbo.TBLsuppliers.supcd = dbo.tblMovment.supcd LEFT OUTER JOIN
                      dbo.tblTxDep ON dbo.TBLsuppliers.txdep_cd = dbo.tblTxDep.txDep_Cd


                where    yr=" + yr.Text
                ;
            if (numericUpDown1.Value > 0)
            {
                //tblsql += "   and  cast( dbo.tblMovment.docno as int)  between "+numericUpDown1.Value.ToString()+"  and  "+numericUpDown2.Value.ToString();

                tblsql += " and MONTH(cast( [move_date] as datetime)) >= " + numericUpDown1.Value.ToString() + "  and MONTH(cast( [move_date] as datetime))<= " + numericUpDown2.Value.ToString();
            }
            else
            {
                tblsql += " and MONTH(cast( [move_date] as datetime)) >= " + frm + "  and MONTH(cast( [move_date] as datetime))<= " + tom;
            }


            tblsql+="  order by  cast( [move_date] as datetime) ";
            
            //dbo.TBLsuppliers.supnm is not null and
            Static_class.fillTbl(tblsql);
            Static_class.rptlbl1 = "";

            Static_class.rptlbl2 = "";
            Static_class.rptlbl3 = "";
            Static_class.rptlbl4 = "";


            Static_class.reportname = "rptbscsupdt_tot";


            Static_class.sysprint();
        }

        public static void WriteToTxt(DataTable dt, string filePath, string terminator)
        {
            int i = 0;
            StreamWriter sw = null;
            sw = new StreamWriter(filePath, false, Encoding.GetEncoding(1256));

            #region Table_Header

            //for (i = 0; i < dt.Columns.Count - 1; i++)
            //{
            //    sw.Write(dt.Columns[i].ColumnName + " ");
            //}
            //sw.Write(dt.Columns[i].ColumnName);
            //sw.WriteLine();

            #endregion

            foreach (DataRow row in dt.Rows)
            {
                object[] array = row.ItemArray;
                for (i = 0; i < array.Length - 1; i++)
                {
                    sw.Write(array[i].ToString().Trim() + terminator);
                }
                sw.Write(array[i].ToString().Trim());
                sw.WriteLine();
            }
            sw.Close();
        }

        private void btnfl_Click(object sender, EventArgs e)
        {
            DataTable txtfl_dt = new DataTable();


            string pth = @" C:\With-HolingTax\Ttransactions.txt";

            string txtfl = "";
            txtfl = @" SELECT  CASE WHEN MONTH(CONVERT(datetime, dbo.tblMovment.mov_date, 103)) < 4 THEN '1' WHEN MONTH(CONVERT(datetime, dbo.tblMovment.mov_date, 103)) < 7 THEN '2' WHEN MONTH(CONVERT(datetime, dbo.tblMovment.mov_date, 103)) 
                      < 10 THEN '3' ELSE '4' END AS prd, ' " + yr.Text + @" ' as year, SUBSTRING(TBLsuppliers.taxrecNo, 1, 3) + SUBSTRING(TBLsuppliers.taxrecNo, 5, 3) + SUBSTRING(TBLsuppliers.taxrecNo,9,3),
                        SUBSTRING(TBLsuppliers.taxfileNo, 1, 1) + SUBSTRING(TBLsuppliers.taxfileNo, 3, 5) + SUBSTRING(TBLsuppliers.taxfileNo, 9, 3) 
                      + SUBSTRING(TBLsuppliers.taxfileNo, 13, 2) + SUBSTRING(TBLsuppliers.taxfileNo, 16, 2), dbo.TBLsuppliers.txdep_cd, dbo.tblMovment.mov_date, ' ' as nrcd,
                      dbo.tblMovment.depsum + dbo.tblMovment.credsum AS totval, ' ' as discd,
                      dbo.tblMovment.freejbscred + dbo.tblMovment.freejbsdep + dbo.tblMovment.prftcred + dbo.tblMovment.prftdep AS netval, dbo.taxkd.taxprc, 
                      dbo.taxkd.taxprc,dbo.TBLsuppliers.supnm , ' ' as supadd,'01' as crncd
                      FROM             dbo.tblMovment LEFT OUTER JOIN
                      dbo.TBLsuppliers ON dbo.tblMovment.supcd = dbo.TBLsuppliers.supcd LEFT OUTER JOIN
                      dbo.taxkd ON dbo.TBLsuppliers.taxcd = dbo.taxkd.taxcd
                      where  dbo.tblMovment.yr = ' " + yr.Text + "'";

            SqlDataAdapter txtfl_da = new SqlDataAdapter(txtfl, Static_class.con);
            txtfl_da.Fill(txtfl_dt);
            WriteToTxt(txtfl_dt, pth, "+");
            MessageBox.Show("تم اصدار الملف");


        }

        private void frm_SupBasicData_Rpt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { SendKeys.Send("{Tab}"); }
        }

        private void supcd_TextChanged(object sender, EventArgs e)
        {
            try
            {
                supnm.Text = TBLsuppliers_Table.Rows[TBLsuppliers_Table.Rows.IndexOf(TBLsuppliers_Table.Rows.Find(supcd.Text))]["supnm"].ToString();

            }
            catch (Exception)
            {
                supnm.Text = "";
            }
        }

        private void supcd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                SearchForm search = new SearchForm(TBLsuppliers_da
                              , "supcd", "supnm", 2, 3);
                search.ShowDialog();

                supcd.Text =
                 Static_class.search_output[0];



            }
        }
    }
}
