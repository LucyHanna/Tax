using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO ;


namespace Tax.formreport
{
    public partial class frmrptgnrl : Form
    {
        public frmrptgnrl()
        {
            InitializeComponent();
        }

        private void taxdecl_Click(object sender, EventArgs e)
        {
            foreach (Control gb in this.Controls)
            {

                if (gb is Panel)
                {
                    gb.Visible = false;
                }
            }
            pantax.Visible = true;




        }

        public SqlDataAdapter TBLsuppliers_da = new SqlDataAdapter
      (" SELECT     supcd, supnm, stcd , taxcd  FROM         TBLsuppliers "
      , Static_class.con);
        public DataTable TBLsuppliers_Table = new DataTable();


        public SqlDataAdapter TBLMovTyp_da = new SqlDataAdapter("SELECT     movcd, movnm  FROM         TBLMovTyp", Static_class.con);
        public DataTable TBLMovTyp_tbl = new DataTable();


        public SqlDataAdapter TBLdocTyp_da = new SqlDataAdapter("SELECT  doccd,docnm   FROM tbldoctyp", Static_class.con);
        public DataTable TBLdocTyp_tbl = new DataTable();



        private void taxview_Click(object sender, EventArgs e)
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

                tblsql = @"SELECT    ' " + txt + @" '  as notes , dbo.tblMovment.credsum, supnm,  dbo.tblMovment.mov_date  as date, CASE WHEN MONTH(convert(datetime,dbo.tblMovment.mov_date,103)) < 4 THEN 'الأولــــى' WHEN MONTH(convert(datetime,dbo.tblMovment.mov_date,103)) < 7 THEN 'الثانية' WHEN MONTH(convert(datetime,dbo.tblMovment.mov_date,103)) 
                      < 10 THEN 'الثالثة' ELSE 'الرابعة' END AS period, dbo.taxkd.taxprc
FROM         dbo.tblMovment INNER JOIN
                      dbo.TBLsuppliers ON dbo.tblMovment.supcd = dbo.TBLsuppliers.supcd INNER JOIN
                      dbo.taxkd ON dbo.TBLsuppliers.taxcd = dbo.taxkd.taxcd  
                      WHERE   tblMovment.yr= " + txtyr.Text + @" AND MONTH(CONVERT(datetime, tblMovment.mov_date, 103))>=" + frm + @"  and MONTH(CONVERT(datetime, tblMovment.mov_date, 103))<=" + tom + @"  and tblMovment.supcd='" + txtsupcd.Text + "'  order by mov_date";

                Static_class.fillTbl(tblsql);


                //Static_class.tblreport = "bscsupdt";
                Static_class.reportname = "taxdecl";


                Static_class.sysprint();
            }
        }

        private void elbow_Click(object sender, EventArgs e)
        {

            foreach (Control gb in this.Controls)
            {

                if (gb is Panel)
                {
                    gb.Visible = false;
                }
            }
            paNelbow.Visible = true;


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

        private void frmrptgnrl_Load(object sender, EventArgs e)
        {
            TBLsuppliers_da.Fill(TBLsuppliers_Table);

            TBLMovTyp_da.Fill(TBLMovTyp_tbl);



            movcd.DataSource = TBLMovTyp_tbl;
            movcd.DisplayMember = "movnm";
            movcd.ValueMember = "movcd";



            TBLdocTyp_da.Fill(TBLdocTyp_tbl);

            doccd.DataSource = TBLdocTyp_tbl;
            doccd.DisplayMember = "docnm";
            doccd.ValueMember = "doccd";


            comboBox1.DataSource = TBLdocTyp_tbl;
            comboBox1.DisplayMember = "docnm";
            comboBox1.ValueMember = "doccd";




            DataColumn[] dpk = new DataColumn[1];
            dpk[0] = TBLsuppliers_Table.Columns[0];
            TBLsuppliers_Table.PrimaryKey = dpk;
            DataTable month_dt = new DataTable();
            month_dt.Columns.Add("mnvl", typeof(int));
            month_dt.Columns.Add("mnnm", typeof(string));

            month_dt.Rows.Add(0, "عام كامل");
            month_dt.Rows.Add(1, "يناير");
            month_dt.Rows.Add(2, "فبراير");
            month_dt.Rows.Add(3, "مارس");
            month_dt.Rows.Add(4, "ابريل");
            month_dt.Rows.Add(5, "مايو");
            month_dt.Rows.Add(6, "يونيو");
            month_dt.Rows.Add(7, "يوليو");
            month_dt.Rows.Add(8, "أغسطس");
            month_dt.Rows.Add(9, "سبتمبر");
            month_dt.Rows.Add(10, "أكتوبر");
            month_dt.Rows.Add(11, "نوفمبر");
            month_dt.Rows.Add(12, "ديسمبر");

            cmbmonth.DataSource = month_dt;
            cmbmonth.DisplayMember = "mnnm";
            cmbmonth.ValueMember = "mnvl";

            new ManageControls().AllowDecimalNumbersOnly(yr);
            new ManageControls().AllowDecimalNumbersOnly(txtyr);
            new ManageControls().AllowDecimalNumbersOnly(docno);


        }

        private void balancerev_Click(object sender, EventArgs e)
        {

            foreach (Control gb in this.Controls)
            {

                if (gb is Panel)
                {
                    gb.Visible = false;
                }
            }
            pan.Visible = true;
        }

        private void panview_Click(object sender, EventArgs e)
        {
            if (checkEmptyComp(pan) == 0)
            {
                Static_class.reportdb = 2;
                Static_class.rptlbl5 = "الكــل";
                string tblsql;
                string lb = "";



                tblsql = @" SELECT     SUM(dbo.tblMovment.depsum) AS dep, SUM(dbo.tblMovment.credsum) AS cred, dbo.tblTyp.typnm, dbo.TBLdoctyp.docnm
FROM         dbo.tblMovment LEFT OUTER JOIN
                      dbo.TBLdoctyp ON dbo.tblMovment.doccd = dbo.TBLdoctyp.doccd LEFT OUTER JOIN
                      dbo.tblTyp ON dbo.tblMovment.typcd = dbo.tblTyp.typcd
WHERE     (MONTH(dbo.tblMovment.move_date) = " + (compan.SelectedIndex + 1).ToString() + @") AND (YEAR(dbo.tblMovment.move_date) = " + year.Text + @")
GROUP BY dbo.tblTyp.typnm, dbo.TBLdoctyp.docnm";
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(tblsql, Static_class.con);
                da.Fill(dt);

                DataTable rptdt = new DataTable();


                rptdt.Columns.Add("date", typeof(DateTime));

                rptdt.Columns.Add("dep_nkdy_doc", typeof(decimal));
                rptdt.Columns.Add("dep_nkdy_tsw", typeof(decimal));
                rptdt.Columns.Add("cred_nkdy_doc", typeof(decimal));
                rptdt.Columns.Add("cred_nkdy_tsw", typeof(decimal));
                rptdt.Columns.Add("dep_tsw_doc", typeof(decimal));
                rptdt.Columns.Add("dep_tsw_tsw", typeof(decimal));
                rptdt.Columns.Add("cred_tsw_doc", typeof(decimal));
                rptdt.Columns.Add("cred_tsw_tsw", typeof(decimal));


                object dep_nkdy_doc = dt.Compute(" sum(dep)", "typnm='نقدي' and docnm='مستند'");

                object dep_nkdy_tsw = dt.Compute(" sum(dep)", "typnm='نقدي' and docnm='تسوية'");

                object cred_nkdy_doc = dt.Compute(" sum(cred)", "typnm='نقدي' and docnm='مستند'");

                object cred_nkdy_tsw = dt.Compute(" sum(cred)", "typnm='نقدي' and docnm='تسوية'");



                object dep_tsw_doc = dt.Compute(" sum(dep)", "typnm='تسوية' and docnm='مستند'");

                object dep_tsw_tsw = dt.Compute(" sum(dep)", "typnm='تسوية' and docnm='تسوية'");

                object cred_tsw_doc = dt.Compute(" sum(cred)", "typnm='تسوية' and docnm='مستند'");

                object cred_tsw_tsw = dt.Compute(" sum(cred)", "typnm='تسوية' and docnm='تسوية'");




                DataRow dr = rptdt.NewRow();
               // dr["date"] = "01/" + (compan.SelectedIndex + 1).ToString() + "/" + year.Text;
                dr["date"] = year.Text + "/" + (compan.SelectedIndex + 1).ToString() + "/01";
                dr["dep_nkdy_doc"] = Converter.IfNullThenZero(dep_nkdy_doc);
                dr["dep_nkdy_tsw"] = Converter.IfNullThenZero(dep_nkdy_tsw);

                dr["cred_nkdy_doc"] = Converter.IfNullThenZero(cred_nkdy_doc);
                dr["cred_nkdy_tsw"] = Converter.IfNullThenZero(cred_nkdy_tsw);


                dr["dep_tsw_doc"] = Converter.IfNullThenZero(dep_tsw_doc);
                dr["dep_tsw_tsw"] = Converter.IfNullThenZero(dep_tsw_tsw);
                dr["cred_tsw_doc"] = Converter.IfNullThenZero(cred_tsw_doc);
                dr["cred_tsw_tsw"] = Converter.IfNullThenZero(cred_tsw_tsw);




                rptdt.Rows.Add(dr);









                //Static_class.fillTbl(tblsql);

                Static_class.reportDataSrc.Clear();
                Static_class.reportDataSrc = (rptdt);


                Static_class.reportname = "balancerev";



                Static_class.sysprint();
            }
        }

        private void elbowview_Click(object sender, EventArgs e)
        {
            Static_class.reportdb = 2;
            Static_class.rptlbl5 = "الكــل";
            string tblsql;
            string lb = "";
            // // //

            //tblsql = " SELECT     SUM(dbo.TBLmovdet.earncred) AS earncred, SUM(dbo.TBLmovdet.prftcred) AS prftcred, SUM(dbo.TBLmovdet.stmpcred) AS stmpcred, " +
            //   " SUM(dbo.TBLmovdet.fincombcred) AS fincombcred, SUM(dbo.TBLmovdet.suppcomcred) AS suppcomcred, SUM(dbo.TBLmovdet.stmpdep) AS stmpdep, " +
            //   " SUM(dbo.TBLmovdet.earndep) AS earndep, SUM(dbo.TBLmovdet.prftdep) AS prftdep, SUM(dbo.TBLmovdet.fincombdep) AS fincombdep, " +
            //   " SUM(dbo.TBLmovdet.suppcomdep) AS suppcomdep FROM         dbo.TBLmovdet INNER JOIN " +
            //   " dbo.TBLmovheader ON dbo.TBLmovdet.docno = dbo.TBLmovheader.docno " +
            //   " WHERE     CONVERT(varchar, (dbo.TBLmovheader.date) ,103)>='01/07/" + finyfrm.Text + " 00:00:00'  and CONVERT(varchar, (dbo.TBLmovheader.date) ,103)<='30/06/" + finyto.Text + " 00:00:00'";


            ////Static_class.fillTbl(tblsql);



            //Static_class.reportname = "elbowrpt";
            //Static_class.sysprint();



        }



        private void view_Click(object sender, EventArgs e)
        {
            if (checkEmptyComp(panbscsupdt) == 0)
            {

                Static_class.reportdb = 2;
                Static_class.rptlbl5 = "الكــل";
                string tblsql = "";
                if (cmbmonth.SelectedIndex == 0)

                    tblsql = @" SELECT     dbo.tblMovment.docno, dbo.tblMovment.docsubno, dbo.TBLsuppliers.supnm, dbo.tblMovment.mov_date as date , dbo.tblMovment.prftcred,  dbo.tblMovment.prftdep,
                      dbo.tblMovment.freejbscred, dbo.tblMovment.freejbsdep,dbo.taxkd.taxnm, dbo.tblMovment.supcd ,taxfileNo,taxrecNo , dbo.taxkd.taxprc as prc
                FROM         dbo.TBLsuppliers INNER JOIN
                      dbo.taxkd ON dbo.TBLsuppliers.taxcd = dbo.taxkd.taxcd RIGHT OUTER JOIN
                      dbo.tblMovment ON dbo.TBLsuppliers.supcd = dbo.tblMovment.supcd where dbo.tblMovment.supcd ='" + supcd.Text + "' and  yr=" + yr.Text + " order by dbo.tblMovment.docno ";

                else
                    tblsql = @" SELECT     dbo.tblMovment.docno, dbo.tblMovment.docsubno, dbo.TBLsuppliers.supnm, dbo.tblMovment.mov_date as date, dbo.tblMovment.prftcred, dbo.tblMovment.prftdep,
                      dbo.tblMovment.freejbscred,dbo.tblMovment.freejbsdep, dbo.taxkd.taxnm, dbo.tblMovment.supcd,taxfileNo,taxrecNo
                FROM         dbo.TBLsuppliers INNER JOIN
                      dbo.taxkd ON dbo.TBLsuppliers.taxcd = dbo.taxkd.taxcd RIGHT OUTER JOIN
                      dbo.tblMovment ON dbo.TBLsuppliers.supcd = dbo.tblMovment.supcd where dbo.tblMovment.supcd ='" + supcd.Text + "' and  yr=" + yr.Text + " and month(convert(datetime ,mov_date,103))=" + cmbmonth.SelectedValue.ToString() + " order by dbo.tblMovment.docno ";

                Static_class.fillTbl(tblsql);
                Static_class.rptlbl1 = "";

                Static_class.rptlbl2 = "";
                Static_class.rptlbl3 = "";
                Static_class.rptlbl4 = "";


                Static_class.reportname = "rptbscsupdt";


                Static_class.sysprint();
            }
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

        private void frmrptgnrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { SendKeys.Send("{Tab}"); }
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

        private void txtsupcd_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtsupnm.Text = TBLsuppliers_Table.Rows[TBLsuppliers_Table.Rows.IndexOf(TBLsuppliers_Table.Rows.Find(txtsupcd.Text))]["supnm"].ToString();

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

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void btnmalysh_Click(object sender, EventArgs e)
        {
            if (checkEmptyComp(panel2) == 0)
            {
                Static_class.reportdb = 2;
                Static_class.rptlbl5 = "الكــل";
                string tblsql;
                string mov = movcd.Text ;

                if (mov == "مالي")
                {
                 tblsql = @"SELECT     dbo.tblMovment.docno, dbo.tblMovment.fincombcred AS cred, dbo.tblMovment.fincombdep AS dep, dbo.TBLlabel.lblnm AS lbl, dbo.TBLmovtyp.movnm as 'typ', 
                      '" + datfrmsh.Text + @"' AS datefrm, '" + datetosh.Text + @"' AS dateto
FROM         dbo.tblMovment LEFT OUTER JOIN
                      dbo.TBLmovtyp ON dbo.tblMovment.movcd = dbo.TBLmovtyp.movcd LEFT OUTER JOIN
                      dbo.TBLlabel ON dbo.tblMovment.lblcd = dbo.TBLlabel.lblcd
WHERE     (cast( [move_date] as datetime) BETWEEN  cast ( '" + datfrmsh.Text.Substring(6, 4) + @"/" + datfrmsh.Text.Substring(3, 2) + @"/" + datfrmsh.Text.Substring(0, 2) + @"' as datetime) AND cast ( '" + datetosh.Text.Substring(6, 4) + @"/" + datetosh.Text.Substring(3, 2) + @"/" + datetosh.Text.Substring(0, 2) + @"' as datetime) ) AND 
                      (dbo.tblMovment.movcd = N'" + movcd.SelectedValue.ToString() + "')  order by dbo.tblMovment.docno ";
                }
                else 
                {
                    tblsql = @"SELECT     dbo.tblMovment.docno, dbo.tblMovment.suppcomcred AS cred, dbo.tblMovment.suppcomdep AS dep, dbo.TBLlabel.lblnm AS lbl, dbo.TBLmovtyp.movnm as 'typ', 
                      '" + datfrmsh.Text + @"' AS datefrm, '" + datetosh.Text + @"' AS dateto
FROM         dbo.tblMovment LEFT OUTER JOIN
                      dbo.TBLmovtyp ON dbo.tblMovment.movcd = dbo.TBLmovtyp.movcd LEFT OUTER JOIN
                      dbo.TBLlabel ON dbo.tblMovment.lblcd = dbo.TBLlabel.lblcd
WHERE     (cast( [move_date] as datetime) BETWEEN  cast ( '" + datfrmsh.Text.Substring(6, 4) + @"/" + datfrmsh.Text.Substring(3, 2) + @"/" + datfrmsh.Text.Substring(0, 2) + @"' as datetime) AND cast ( '" + datetosh.Text.Substring(6, 4) + @"/" + datetosh.Text.Substring(3, 2) + @"/" + datetosh.Text.Substring(0, 2) + @"' as datetime) ) AND 
                      (dbo.tblMovment.movcd = N'" + movcd.SelectedValue.ToString() + "')  order by dbo.tblMovment.docno ";
                }



                Static_class.fillTbl(tblsql);
                Static_class.rptlbl1 = "";

                Static_class.rptlbl2 = "";
                Static_class.rptlbl3 = "";
                Static_class.rptlbl4 = "";


                Static_class.reportname = "taxsharingrpt";


                Static_class.sysprint();

            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (checkEmptyComp(panel3) == 0)
            {
                Static_class.reportdb = 2;
                Static_class.rptlbl5 = "الكــل";



                string tblsql = @" SELECT     dbo.tblMovment.docno, dbo.tblMovment.earncred AS cred, TBLlabel.lblnm As lbl , dbo.tblMovment.earndep AS dep, '" + datfrmearn.Text
                    + @"' AS datefrm, '" + dattoearn.Text + @"' AS dateto, 
                      dbo.TBLdoctyp.docnm AS typ
FROM         TBLlabel RIGHT OUTER JOIN
                      tblMovment ON TBLlabel.lblcd = tblMovment.lblcd LEFT OUTER JOIN
                      TBLdoctyp ON tblMovment.doccd = TBLdoctyp.doccd
WHERE     (CONVERT(datetime, dbo.tblMovment.mov_date, 103) BETWEEN CONVERT(datetime, '" + datfrmearn.Text + @"', 103) AND CONVERT(datetime, '" + dattoearn.Text + @"', 103)) AND 
                      (dbo.tblMovment.doccd = N'" + doccd.SelectedValue.ToString() + "')  and  (dbo.tblMovment.earndep+dbo.tblMovment.earncred)>0   order by dbo.tblMovment.docno ";


                Static_class.fillTbl(tblsql);
                Static_class.rptlbl1 = "";

                Static_class.rptlbl2 = "";
                Static_class.rptlbl3 = "";
                Static_class.rptlbl4 = "";


                Static_class.reportname = "workEarnrpt";


                Static_class.sysprint();

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkEmptyComp(panel1) == 0)
            {

                Static_class.reportdb = 2;
                Static_class.rptlbl5 = "الكــل";
                string knd = cmb_lsbxnd.Text;
                string tblsql = "";
                if (knd == "مدين")
                {
                    if (docno.Text != "")
                    {
                        tblsql = @" SELECT '" + knd + "' AS knd  , dbo.tblMovment.typcd, cast( dbo.tblMovment.docno  as int )as docno, '" + datfrmclc.Text + "' AS datfrm, '" + dattocalc.Text + @"' AS datto, dbo.TBLdoctyp.docnm AS doctyp, 
                      dbo.tblMovment.stmpdmnddep , 
                      dbo.tblMovment.earndep ,
                      dbo.tblMovment.stmpknddep , 
                      dbo.tblMovment.stmpndusdep, 
                      dbo.tblMovment.stmpconsdep + dbo.tblMovment.stmpconscred AS stmpcons, 

                      (dbo.tblMovment.stmpsupdep )+  (dbo.tblMovment.stmpcontdep ) AS stmpsup, dbo.tblMovment.suppcomdep AS suppcom, 
                      dbo.tblMovment.fincombdep  AS fincomb, dbo.tblMovment.freejbsdep AS freejbs, 
                      dbo.tblMovment.prftdep AS prft, dbo.tblMovment.stmpdep  AS stmp, dbo.tblMovment.depsum ,0 AS credsum 
                      
FROM         dbo.tblMovment LEFT OUTER JOIN
                      dbo.TBLdoctyp ON dbo.tblMovment.doccd = dbo.TBLdoctyp.doccd
WHERE        (cast( [move_date] as datetime) BETWEEN  cast ( '" + datfrmclc.Text.Substring(6, 4) + @"/" + datfrmclc.Text.Substring(3, 2) + @"/" + datfrmclc.Text.Substring(0, 2) + @"' as datetime) AND cast ( '" + dattocalc.Text.Substring(6, 4) + @"/" + dattocalc.Text.Substring(3, 2) + @"/" + dattocalc.Text.Substring(0, 2) + @"' as datetime) )  AND 
                      (dbo.tblMovment.doccd = N'" + comboBox1.SelectedValue.ToString() + "') and dbo.tblMovment.depsum <>0 and docno=" + docno.Text + " order by cast( dbo.tblMovment.docno  as int ) ";
                    }



                    else
                    {
                        tblsql = @" SELECT   '" + knd + "' AS knd , dbo.tblMovment.typcd ,cast( dbo.tblMovment.docno  as int )as docno, '" + datfrmclc.Text + "' AS datfrm, '" + dattocalc.Text + @"' AS datto, dbo.TBLdoctyp.docnm AS doctyp, 
                      dbo.tblMovment.stmpdmnddep AS stmpdmnd, 
                      dbo.tblMovment.earndep  AS earn,
                      dbo.tblMovment.stmpknddep  AS stmpknd, 
                      dbo.tblMovment.stmpndusdep AS stmpndus, 
                      dbo.tblMovment.stmpconsdep AS stmpcons, 
                      (dbo.tblMovment.stmpsupdep )+  (dbo.tblMovment.stmpcontdep ) AS stmpsup, dbo.tblMovment.suppcomdep AS suppcom, 
                      dbo.tblMovment.fincombdep  AS fincomb, dbo.tblMovment.freejbsdep  AS freejbs, 
                      dbo.tblMovment.prftdep  AS prft, dbo.tblMovment.stmpdep  AS stmp, dbo.tblMovment.depsum,0 AS credsum
FROM         dbo.tblMovment LEFT OUTER JOIN
                      dbo.TBLdoctyp ON dbo.tblMovment.doccd = dbo.TBLdoctyp.doccd
WHERE     (cast( [move_date] as datetime) BETWEEN   cast ( '" + datfrmclc.Text.Substring(6, 4) + @"/" + datfrmclc.Text.Substring(3, 2) + @"/" + datfrmclc.Text.Substring(0, 2) + @"' as datetime) AND cast ( '" + dattocalc.Text.Substring(6, 4) + @"/" + dattocalc.Text.Substring(3, 2) + @"/" + dattocalc.Text.Substring(0, 2) + @"' as datetime) )  AND dbo.tblMovment.depsum <>0 AND 
                      (dbo.tblMovment.doccd = N'" + comboBox1.SelectedValue.ToString() + "')  order by cast( dbo.tblMovment.docno  as int ) ";
                    }
                }
                else
                {
                    if (docno.Text != "")


                        tblsql = @" SELECT    '" + knd + "' AS knd  , dbo.tblMovment.typcd, dbo.tblMovment.docno, '" + datfrmclc.Text + "' AS datfrm, '" + dattocalc.Text + @"' AS datto, dbo.TBLdoctyp.docnm AS doctyp, 
                      dbo.tblMovment.stmpdmndcred AS stmpdmnd, 
                      dbo.tblMovment.earncred AS earn,
                      dbo.tblMovment.stmpkndcred AS stmpknd, 
                      dbo.tblMovment.stmpnduscred AS stmpndus, 
                      dbo.tblMovment.stmpconscred AS stmpcons, 

                      ( dbo.tblMovment.stmpsupcred)+  ( dbo.tblMovment.stmpcontcred) AS stmpsup,  dbo.tblMovment.suppcomcred AS suppcom, 
                      dbo.tblMovment.fincombcred AS fincomb, dbo.tblMovment.freejbscred AS freejbs, 
                      dbo.tblMovment.prftcred AS prft, dbo.tblMovment.stmpcred AS stmp, 0 AS depsum, 
                      dbo.tblMovment.credsum
FROM         dbo.tblMovment LEFT OUTER JOIN
                      dbo.TBLdoctyp ON dbo.tblMovment.doccd = dbo.TBLdoctyp.doccd
WHERE     (cast( [move_date] as datetime) BETWEEN   cast ( '" + datfrmclc.Text.Substring(6, 4) + @"/" + datfrmclc.Text.Substring(3, 2) + @"/" + datfrmclc.Text.Substring(0, 2) + @"' as datetime) AND cast ( '" + dattocalc.Text.Substring(6, 4) + @"/" + dattocalc.Text.Substring(3, 2) + @"/" + dattocalc.Text.Substring(0, 2) + @"' as datetime) ) AND 
                      (dbo.tblMovment.doccd = N'" + comboBox1.SelectedValue.ToString() + "') AND dbo.tblMovment.credsum <>0 and docno=" + docno.Text + " order by cast( dbo.tblMovment.docno  as int ) ";



                    else
                        tblsql = @" SELECT    '" + knd + "' AS knd  , dbo.tblMovment.typcd, dbo.tblMovment.docno, '" + datfrmclc.Text + "' AS datfrm, '" + dattocalc.Text + @"' AS datto, dbo.TBLdoctyp.docnm AS doctyp, 
                      dbo.tblMovment.stmpdmndcred AS stmpdmnd, 
                      dbo.tblMovment.earncred AS earn,
                      dbo.tblMovment.stmpkndcred AS stmpknd, 
                      dbo.tblMovment.stmpnduscred AS stmpndus, 
                      dbo.tblMovment.stmpconscred AS stmpcons, 
                      (dbo.tblMovment.stmpsupcred)+  (dbo.tblMovment.stmpcontcred) AS stmpsup, dbo.tblMovment.suppcomcred AS suppcom, 
                      dbo.tblMovment.fincombcred AS fincomb, dbo.tblMovment.freejbscred AS freejbs, 
                      dbo.tblMovment.prftcred AS prft, dbo.tblMovment.stmpcred AS stmp, 0 AS depsum, 
                      dbo.tblMovment.credsum
FROM         dbo.tblMovment LEFT OUTER JOIN
                      dbo.TBLdoctyp ON dbo.tblMovment.doccd = dbo.TBLdoctyp.doccd
WHERE     (cast( [move_date] as datetime) BETWEEN  cast  ( '" + datfrmclc.Text.Substring(6, 4) + @"/" + datfrmclc.Text.Substring(3, 2) + @"/" + datfrmclc.Text.Substring(0, 2) + @"' as datetime) AND cast ( '" + dattocalc.Text.Substring(6, 4) + @"/" + dattocalc.Text.Substring(3, 2) + @"/" + dattocalc.Text.Substring(0, 2) + @"' as datetime) ) AND dbo.tblMovment.credsum <>0 AND 
                      (dbo.tblMovment.doccd = N'" + comboBox1.SelectedValue.ToString() + "')  order by cast( dbo.tblMovment.docno  as int )";
                }


                Static_class.fillTbl(tblsql);
                Static_class.rptlbl1 = "";

                Static_class.rptlbl2 = "";
                Static_class.rptlbl3 = "";
                Static_class.rptlbl4 = "";

                
                { Static_class.reportname = "taxclcRpt_dep"; }
                
                //{ Static_class.reportname = "taxclcRpt"; }


                Static_class.sysprint();


            }


        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (checkEmptyComp(panel4) == 0)
            {
                Static_class.reportdb = 2;
                Static_class.rptlbl5 = "الكــل";
                

                string fieldnm = (comboBox2.Text == "مدين" ? "earndep" : "earncred");

                string tblsql = @" SELECT  '" + button7.Text + @" / " + comboBox2.Text + @"'  as taxtyp,  '" + paieddatFrm.Text + @"' as datfrm,'" + paieddatto.Text + @"' as datto, SUM(dbo.tblMovment." + fieldnm + @") AS sum, dbo.TBLlabel.lblnm,dbo.TBLdoctyp.docnm
FROM         dbo.tblMovment LEFT OUTER JOIN
                      dbo.TBLdoctyp ON dbo.tblMovment.doccd = dbo.TBLdoctyp.doccd LEFT OUTER JOIN
                      dbo.TBLlabel ON dbo.tblMovment.lblcd = dbo.TBLlabel.lblcd
WHERE     (cast( [move_date] as datetime) BETWEEN  cast ( '" + paieddatFrm.Text.Substring(6, 4) + @"/" + paieddatFrm.Text.Substring(3, 2) + @"/" + paieddatFrm.Text.Substring(0, 2) + @"' as datetime) AND cast ( '" + paieddatto.Text.Substring(6, 4) + @"/" + paieddatto.Text.Substring(3, 2) + @"/" + paieddatto.Text.Substring(0, 2) + @"' as datetime) )  GROUP BY dbo.TBLlabel.lblnm,  dbo.TBLdoctyp.docnm ";


                Static_class.fillTbl(tblsql);
                Static_class.rptlbl1 = "";

                Static_class.rptlbl2 = "";
                Static_class.rptlbl3 = "";
                Static_class.rptlbl4 = "";


                Static_class.reportname = "taxPaiedRpt";


                Static_class.sysprint();

            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            string fieldnm = comboBox2.Text; //== "مدين" 
            string tblsql;

            if (checkEmptyComp(panel4) == 0)
            {

                Static_class.reportdb = 2;
                Static_class.rptlbl5 = "الكــل";
                if (fieldnm == "مدين")
                {
                    tblsql = @" SELECT  '" + button6.Text + @" / " + comboBox2.Text + @"'  as taxtyp,  '" + paieddatFrm.Text + @"' as datfrm,'" + paieddatto.Text + @"' as datto,sum( (dbo.tblMovment.depsum - dbo.tblMovment.suppcomdep)) AS sum, dbo.TBLlabel.lblnm,dbo.TBLdoctyp.docnm   
                    FROM         dbo.tblMovment LEFT OUTER JOIN
                                          dbo.TBLdoctyp ON dbo.tblMovment.doccd = dbo.TBLdoctyp.doccd LEFT OUTER JOIN
                                          dbo.TBLlabel ON dbo.tblMovment.lblcd = dbo.TBLlabel.lblcd
                    WHERE    (cast( [move_date] as datetime) BETWEEN  cast ( '" + paieddatFrm.Text.Substring(6, 4) + @"/" + paieddatFrm.Text.Substring(3, 2) + @"/" + paieddatFrm.Text.Substring(0, 2) + @"' as datetime) AND cast ( '" + paieddatto.Text.Substring(6, 4) + @"/" + paieddatto.Text.Substring(3, 2) + @"/" + paieddatto.Text.Substring(0, 2) + @"' as datetime) )  AND (dbo.tblMovment.movcd ='2')GROUP BY dbo.TBLlabel.lblnm,  dbo.TBLdoctyp.docnm ";

                }
                else
                {
                    tblsql = @" SELECT  '" + button6.Text + @" / " + comboBox2.Text + @"'  as taxtyp,  '" + paieddatFrm.Text + @"' as datfrm,'" + paieddatto.Text + @"' as datto,sum( (dbo.tblMovment.credsum - dbo.tblMovment.suppcomcred)) AS sum, dbo.TBLlabel.lblnm,dbo.TBLdoctyp.docnm   
                    FROM         dbo.tblMovment LEFT OUTER JOIN
                                          dbo.TBLdoctyp ON dbo.tblMovment.doccd = dbo.TBLdoctyp.doccd LEFT OUTER JOIN
                                          dbo.TBLlabel ON dbo.tblMovment.lblcd = dbo.TBLlabel.lblcd
                    WHERE    (cast( [move_date] as datetime) BETWEEN  cast ( '" + paieddatFrm.Text.Substring(6, 4) + @"/" + paieddatFrm.Text.Substring(3, 2) + @"/" + paieddatFrm.Text.Substring(0, 2) + @"' as datetime) AND cast ( '" + paieddatto.Text.Substring(6, 4) + @"/" + paieddatto.Text.Substring(3, 2) + @"/" + paieddatto.Text.Substring(0, 2) + @"' as datetime) )  AND (dbo.tblMovment.movcd ='2')GROUP BY dbo.TBLlabel.lblnm,  dbo.TBLdoctyp.docnm ";

                }


                //                Static_class.reportdb = 2;
                //                Static_class.rptlbl5 = "الكــل";

                //                string fieldnm = (comboBox2.Text == "مدين" ? "stmpdep" : "stmpcred");

                //                string tblsql = @" SELECT  '" + button6.Text + @" / " + comboBox2.Text + @"'  as taxtyp,  '" + paieddatFrm.Text + @"' as datfrm,'" + paieddatto.Text + @"' as datto, SUM(dbo.tblMovment." + fieldnm + @") AS sum, dbo.TBLlabel.lblnm,dbo.TBLdoctyp.docnm
                //FROM         dbo.tblMovment LEFT OUTER JOIN
                //                      dbo.TBLdoctyp ON dbo.tblMovment.doccd = dbo.TBLdoctyp.doccd LEFT OUTER JOIN
                //                      dbo.TBLlabel ON dbo.tblMovment.lblcd = dbo.TBLlabel.lblcd
                //WHERE     (CONVERT(datetime, dbo.tblMovment.date, 103) BETWEEN CONVERT(datetime, '" + paieddatFrm.Text + @"', 103) AND CONVERT(datetime, '" + paieddatto.Text + @"', 103))GROUP BY dbo.TBLlabel.lblnm,  dbo.TBLdoctyp.docnm ";


                Static_class.fillTbl(tblsql);
                Static_class.rptlbl1 = "";

                Static_class.rptlbl2 = "";
                Static_class.rptlbl3 = "";
                Static_class.rptlbl4 = "";


                Static_class.reportname = "taxPaiedRpt";


                Static_class.sysprint();

            }   
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (checkEmptyComp(panel4) == 0)
            {
                Static_class.reportdb = 2;
                Static_class.rptlbl5 = "الكــل";

                string fieldnm = (comboBox2.Text == "مدين" ? "prftdep" : "prftcred");

                string tblsql = @" SELECT  '" + button8.Text + @" / " + comboBox2.Text + @"'  as taxtyp,  '" + paieddatFrm.Text + @"' as datfrm,'" + paieddatto.Text + @"' as datto, SUM(dbo.tblMovment." + fieldnm + @") AS sum, dbo.TBLlabel.lblnm,dbo.TBLdoctyp.docnm
FROM         dbo.tblMovment LEFT OUTER JOIN
                      dbo.TBLdoctyp ON dbo.tblMovment.doccd = dbo.TBLdoctyp.doccd LEFT OUTER JOIN
                      dbo.TBLlabel ON dbo.tblMovment.lblcd = dbo.TBLlabel.lblcd
WHERE     (cast( [move_date] as datetime) BETWEEN  cast ( '" + paieddatFrm.Text.Substring(6, 4) + @"/" + paieddatFrm.Text.Substring(3, 2) + @"/" + paieddatFrm.Text.Substring(0, 2) + @"' as datetime) AND cast ( '" + paieddatto.Text.Substring(6, 4) + @"/" + paieddatto.Text.Substring(3, 2) + @"/" + paieddatto.Text.Substring(0, 2) + @"' as datetime) ) 
GROUP BY dbo.TBLlabel.lblnm,  dbo.TBLdoctyp.docnm
";


                Static_class.fillTbl(tblsql);
                Static_class.rptlbl1 = "";

                Static_class.rptlbl2 = "";
                Static_class.rptlbl3 = "";
                Static_class.rptlbl4 = "";


                Static_class.reportname = "taxPaiedRpt";


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
            tblsql = @" SELECT      dbo.tblMovment.docno, dbo.tblMovment.docsubno,dbo.taxkd.taxcd,
substring( [mov_date],4,7) as dt, dbo.TBLsuppliers.supnm, 
CASE WHEN MONTH(cast( [move_date] as datetime)) < 4 THEN 'الأولــــى' 
WHEN MONTH(cast( [move_date] as datetime)) 
                      < 7 THEN 'الثانية' WHEN MONTH(cast( [move_date] as datetime)) < 10 THEN 'الثالثة' ELSE 'الرابعة' END AS date, dbo.tblMovment.prftcred, 
                      dbo.tblMovment.prftdep, dbo.taxkd.taxprc AS prc, dbo.tblMovment.freejbscred, dbo.tblMovment.freejbsdep, dbo.taxkd.taxnm, dbo.tblMovment.supcd, 
                      dbo.TBLsuppliers.taxfileNo, dbo.TBLsuppliers.taxrecNo, dbo.tblTxDep.txDep_Nm
FROM         dbo.TBLsuppliers INNER JOIN
                      dbo.taxkd ON dbo.TBLsuppliers.taxcd = dbo.taxkd.taxcd LEFT OUTER JOIN
                      dbo.tblTxDep ON dbo.TBLsuppliers.txdep_cd = dbo.tblTxDep.txDep_Cd RIGHT OUTER JOIN
                      dbo.tblMovment ON dbo.TBLsuppliers.supcd = dbo.tblMovment.supcd
                where   dbo.TBLsuppliers.supnm is not null and yr=" + yr.Text
                + " and MONTH(cast( [move_date] as datetime)) >= " + frm + "  and MONTH(cast( [move_date] as datetime))<= " + tom + "  order by  cast( [move_date] as datetime) ";
            //dbo.TBLsuppliers.supnm is not null and
            Static_class.fillTbl(tblsql);
            Static_class.rptlbl1 = "";

            Static_class.rptlbl2 = "";
            Static_class.rptlbl3 = "";
            Static_class.rptlbl4 = "";


            Static_class.reportname = "rptbscsupdt_tot";


            Static_class.sysprint();
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

        private void btnfrjob_Click(object sender, EventArgs e)
        {
            if (checkEmptyComp(panel4) == 0)
            {
                Static_class.reportdb = 2;
                Static_class.rptlbl5 = "الكــل";

                string fieldnm = (comboBox2.Text == "مدين" ? "freejbsdep" : "freejbscred");

                string tblsql = @" SELECT  '" + btnfrjob.Text + @" / " + comboBox2.Text + @"'  as taxtyp,  '" + paieddatFrm.Text + @"' as datfrm,'" + paieddatto.Text + @"' as datto, SUM(dbo.tblMovment." + fieldnm + @") AS sum, dbo.TBLlabel.lblnm,dbo.TBLdoctyp.docnm
FROM         dbo.tblMovment LEFT OUTER JOIN
                      dbo.TBLdoctyp ON dbo.tblMovment.doccd = dbo.TBLdoctyp.doccd LEFT OUTER JOIN
                      dbo.TBLlabel ON dbo.tblMovment.lblcd = dbo.TBLlabel.lblcd
WHERE     (cast( [move_date] as datetime) BETWEEN  cast ( '" + paieddatFrm.Text.Substring(6, 4) + @"/" + paieddatFrm.Text.Substring(3, 2) + @"/" + paieddatFrm.Text.Substring(0, 2) + @"' as datetime) AND cast ( '" + paieddatto.Text.Substring(6, 4) + @"/" + paieddatto.Text.Substring(3, 2) + @"/" + paieddatto.Text.Substring(0, 2) + @"' as datetime) ) 
GROUP BY dbo.TBLlabel.lblnm,  dbo.TBLdoctyp.docnm
";


                Static_class.fillTbl(tblsql);
                Static_class.rptlbl1 = "";

                Static_class.rptlbl2 = "";
                Static_class.rptlbl3 = "";
                Static_class.rptlbl4 = "";


                Static_class.reportname = "taxPaiedRpt";


                Static_class.sysprint();

            }


        }

        private void lsbxnd_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (checkEmptyComp(panel4) == 0)
            {
                Static_class.reportdb = 2;
                Static_class.rptlbl5 = "الكــل";


                string fieldnm = (comboBox2.Text == "مدين" ? "internalTaxdep" : "internalTaxcred");

                string tblsql = @" SELECT  '" + button2.Text + @" / " + comboBox2.Text + @"'  as taxtyp,  '" + paieddatFrm.Text + @"' as datfrm,'" + paieddatto.Text + @"' as datto, SUM(dbo.tblMovment." + fieldnm + @") AS sum, dbo.TBLlabel.lblnm,dbo.TBLdoctyp.docnm
FROM         dbo.tblMovment LEFT OUTER JOIN
                      dbo.TBLdoctyp ON dbo.tblMovment.doccd = dbo.TBLdoctyp.doccd LEFT OUTER JOIN
                      dbo.TBLlabel ON dbo.tblMovment.lblcd = dbo.TBLlabel.lblcd
WHERE     (cast( [move_date] as datetime) BETWEEN  cast ( '" + paieddatFrm.Text.Substring(6, 4) + @"/" + paieddatFrm.Text.Substring(3, 2) + @"/" + paieddatFrm.Text.Substring(0, 2) + @"' as datetime) AND cast ( '" + paieddatto.Text.Substring(6, 4) + @"/" + paieddatto.Text.Substring(3, 2) + @"/" + paieddatto.Text.Substring(0, 2) + @"' as datetime) )  GROUP BY dbo.TBLlabel.lblnm,  dbo.TBLdoctyp.docnm ";


                Static_class.fillTbl(tblsql);
                Static_class.rptlbl1 = "";

                Static_class.rptlbl2 = "";
                Static_class.rptlbl3 = "";
                Static_class.rptlbl4 = "";


                Static_class.reportname = "taxPaiedRpt";


                Static_class.sysprint();

            }

        }
    }
}
