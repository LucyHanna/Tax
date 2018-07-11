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
    public partial class frm_SupTax_Rpt : Form
    {
        public frm_SupTax_Rpt()
        {
            InitializeComponent();
        }


        string taxcd = "";
        public SqlDataAdapter TBLsuppliers_da = new SqlDataAdapter
   (" SELECT     supcd, supnm, stcd , taxcd  FROM         TBLsuppliers "
   , Static_class.con);
        public DataTable TBLsuppliers_Table = new DataTable();
       


        private void frm_SupTax_Rpt_Load(object sender, EventArgs e)
        {
            TBLsuppliers_da.Fill(TBLsuppliers_Table);
            DataColumn[] dpk = new DataColumn[1];
            dpk[0] = TBLsuppliers_Table.Columns[0];
            TBLsuppliers_Table.PrimaryKey = dpk;

        }

        private void frm_taxAnalaysis_Rpt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { SendKeys.Send("{Tab}"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkEmptyComp(pantax) == 0)
            {
                Static_class.reportdb = 2;
                Static_class.rptlbl5 = "الكــل";

                string frm = "", tom = "";

                switch (combTAX.SelectedIndex)
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

                string txt = "  جميع الشيكات مسددة باسم / الادارة العامة لتجميع نماذج الخصم و التحصيل تحت حساب الضريبة باسم / مأمورية ضرائب الشركات المساهمة شارع حسين حجازي- الفلكي-القاهرة  ";

                if (taxcd == "03")
                {
                    tblsql = @"SELECT    ' " + txt + @" '  as notes , dbo.tblMovment.prftcred as [credsum], supnm,  dbo.tblMovment.mov_date  as date, CASE WHEN MONTH(convert(datetime,dbo.tblMovment.mov_date,103)) < 4 THEN 'الأولــــى' WHEN MONTH(convert(datetime,dbo.tblMovment.mov_date,103)) < 7 THEN 'الثانية' WHEN MONTH(convert(datetime,dbo.tblMovment.mov_date,103)) 
                      < 10 THEN 'الثالثة' ELSE 'الرابعة' END AS period, dbo.taxkd.taxprc
FROM         dbo.tblMovment INNER JOIN
                      dbo.TBLsuppliers ON dbo.tblMovment.supcd = dbo.TBLsuppliers.supcd INNER JOIN
                      dbo.taxkd ON dbo.TBLsuppliers.taxcd = dbo.taxkd.taxcd  
                      WHERE   tblMovment.yr= " + txtyr.Text + @" AND MONTH(CONVERT(datetime, tblMovment.mov_date, 103))>=" + frm + @"  and MONTH(CONVERT(datetime, tblMovment.mov_date, 103))<=" + tom + @"  and tblMovment.supcd='" + txtsupcd.Text + "'  order by mov_date";
                
                }
                else
                {
                    tblsql = @"SELECT    ' " + txt + @" '  as notes , dbo.tblMovment.credsum, supnm,  dbo.tblMovment.mov_date  as date, CASE WHEN MONTH(convert(datetime,dbo.tblMovment.mov_date,103)) < 4 THEN 'الأولــــى' WHEN MONTH(convert(datetime,dbo.tblMovment.mov_date,103)) < 7 THEN 'الثانية' WHEN MONTH(convert(datetime,dbo.tblMovment.mov_date,103)) 
                      < 10 THEN 'الثالثة' ELSE 'الرابعة' END AS period, dbo.taxkd.taxprc
FROM         dbo.tblMovment INNER JOIN
                      dbo.TBLsuppliers ON dbo.tblMovment.supcd = dbo.TBLsuppliers.supcd INNER JOIN
                      dbo.taxkd ON dbo.TBLsuppliers.taxcd = dbo.taxkd.taxcd  
                      WHERE   tblMovment.yr= " + txtyr.Text + @" AND MONTH(CONVERT(datetime, tblMovment.mov_date, 103))>=" + frm + @"  and MONTH(CONVERT(datetime, tblMovment.mov_date, 103))<=" + tom + @"  and tblMovment.supcd='" + txtsupcd.Text + "'  order by mov_date";
                }

                SqlDataAdapter adreport = new SqlDataAdapter(tblsql, Static_class.con);
                DataTable dt = new DataTable();
                adreport.Fill(dt);

                dt.Columns.Add("checkNo", typeof(string));
                dt.Columns.Add("checkDate", typeof(DateTime));
                dt.Columns.Add("bank", typeof(string));


                SqlDataAdapter da_tblCheckNo = new SqlDataAdapter(@"SELECT  checkPeriod, checkNo, checkDate,bank
                FROM tblCheckNo  where yr=" + txtyr.Text, Static_class.con);

                DataTable dt_tblCheckNo = new DataTable();

                da_tblCheckNo.Fill(dt_tblCheckNo);
                dt_tblCheckNo.PrimaryKey=new DataColumn[1]{dt_tblCheckNo.Columns["checkPeriod"]};
                if (dt_tblCheckNo.Rows.Count > 0)
                {
                    #region checkRegion
                    foreach (DataRow dr in dt.Rows)
                    {
                        string period = dr["period"].ToString();

                        switch (period)
                        {
                            case "الأولــــى":
                                {
                                    dr["checkNo"] = dt_tblCheckNo.Rows[dt_tblCheckNo.Rows.IndexOf(dt_tblCheckNo.Rows.Find(1))]["checkNo"];
                                    dr["checkDate"] = dt_tblCheckNo.Rows[dt_tblCheckNo.Rows.IndexOf(dt_tblCheckNo.Rows.Find(1))]["checkDate"];
                                    dr["bank"] = dt_tblCheckNo.Rows[dt_tblCheckNo.Rows.IndexOf(dt_tblCheckNo.Rows.Find(1))]["bank"];

                                } break;
                            case "الثانية":
                                {
                                    dr["checkNo"] = dt_tblCheckNo.Rows[dt_tblCheckNo.Rows.IndexOf(dt_tblCheckNo.Rows.Find(2))]["checkNo"];
                                    dr["checkDate"] = dt_tblCheckNo.Rows[dt_tblCheckNo.Rows.IndexOf(dt_tblCheckNo.Rows.Find(2))]["checkDate"];
                                    dr["bank"] = dt_tblCheckNo.Rows[dt_tblCheckNo.Rows.IndexOf(dt_tblCheckNo.Rows.Find(2))]["bank"];

                                } break;
                            case "الثالثة":
                                {
                                    dr["checkNo"] = dt_tblCheckNo.Rows[dt_tblCheckNo.Rows.IndexOf(dt_tblCheckNo.Rows.Find(3))]["checkNo"];
                                    dr["checkDate"] = dt_tblCheckNo.Rows[dt_tblCheckNo.Rows.IndexOf(dt_tblCheckNo.Rows.Find(3))]["checkDate"];
                                    dr["bank"] = dt_tblCheckNo.Rows[dt_tblCheckNo.Rows.IndexOf(dt_tblCheckNo.Rows.Find(3))]["bank"];

                                } break;
                            case "الرابعة":
                                {
                                    dr["checkNo"] = dt_tblCheckNo.Rows[dt_tblCheckNo.Rows.IndexOf(dt_tblCheckNo.Rows.Find(4))]["checkNo"];
                                    dr["checkDate"] = dt_tblCheckNo.Rows[dt_tblCheckNo.Rows.IndexOf(dt_tblCheckNo.Rows.Find(4))]["checkDate"];
                                    dr["bank"] = dt_tblCheckNo.Rows[dt_tblCheckNo.Rows.IndexOf(dt_tblCheckNo.Rows.Find(4))]["bank"];
                                } break;
                        }


                    }
                    #endregion
                }
                Static_class.reportDataSrc.Clear();
                Static_class.reportDataSrc = dt;
                Static_class.reportname = "taxdecl";


                formreport.frmrpt frmrpt = new formreport.frmrpt();
                frmrpt.ShowDialog();
            }
        }


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

        private void txtsupcd_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int supp_pos=TBLsuppliers_Table.Rows.IndexOf(TBLsuppliers_Table.Rows.Find(txtsupcd.Text));
                if (supp_pos > -1)
                {
                        txtsupnm.Text = TBLsuppliers_Table.Rows[supp_pos]["supnm"].ToString();
                        taxcd =  TBLsuppliers_Table.Rows[supp_pos]["taxcd"].ToString();
                    
                }
                else
                {
                    txtsupnm.Text = "";
                    taxcd = "";
                }

            }
            catch (Exception)
            {
                txtsupnm.Text = "";
            }
        }

        private void txtsupcd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                SearchForm search = new SearchForm(TBLsuppliers_da
                              , "supcd", "supnm", 2, 3);
                search.ShowDialog();

                txtsupcd.Text =
                 Static_class.search_output[0];



            }
        }

    }
}
