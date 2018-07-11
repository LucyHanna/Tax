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
    public partial class frm_taxAnalaysis_Rpt : Form
    {
        public frm_taxAnalaysis_Rpt()
        {
            InitializeComponent();
        }


        public SqlDataAdapter TBLdocTyp_da = new SqlDataAdapter("SELECT  doccd,docnm   FROM tbldoctyp", Static_class.con);
        public DataTable TBLdocTyp_tbl = new DataTable();


        private void frm_taxAnalaysis_Rpt_Load(object sender, EventArgs e)
        {
            TBLdocTyp_da.Fill(TBLdocTyp_tbl);
            comboBox1.DataSource = TBLdocTyp_tbl;
            comboBox1.DisplayMember = "docnm";
            comboBox1.ValueMember = "doccd";


            comMostndTswya.SelectedIndex = 1;
            comMalyTogary.SelectedIndex = 1;
            comMadynDaan.SelectedIndex = 1;

        }

        private void frm_taxAnalaysis_Rpt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { SendKeys.Send("{Tab}"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkEmptyComp(panel1) == 0)
            {

                Static_class.reportdb = 2;
                Static_class.rptlbl5 = "الكــل";
                
                string tblsql = "";
                if (radioButton1.Checked)
                {
                    if (docno.Text != "")
                    {
                        if (docno.Text != "")
                        {
                            tblsql = @" SELECT 'مدين' AS knd  
                         , dbo.tblMovment.typcd, cast( dbo.tblMovment.docno  as int )as docno, '" + datfrmclc.Text + "' AS datfrm, '" + dattocalc.Text + @"' AS datto, dbo.TBLdoctyp.docnm AS doctyp, 
                       dbo.tblMovment.[internalTaxdep] as internaltax ,
                    dbo.tblMovment.stmpcheckdep , 
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
                                              (dbo.tblMovment.doccd = N'" + comboBox1.SelectedValue.ToString() + "') and dbo.tblMovment.depsum <>0 and ( cast (docno as int ) between " + docno.Text +" and  "+docno2.Text + ") order by cast( dbo.tblMovment.docno  as int ) ";
                        
                        }
                        else
                        tblsql = @" SELECT 'مدين' AS knd  , dbo.tblMovment.typcd, cast( dbo.tblMovment.docno  as int )as docno, '" + datfrmclc.Text + "' AS datfrm, '" + dattocalc.Text + @"' AS datto, dbo.TBLdoctyp.docnm AS doctyp, 
                     dbo.tblMovment.[internalTaxdep] as internaltax ,
                        dbo.tblMovment.stmpcheckdep ,
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
                        tblsql = @" SELECT   'مدين' AS knd , dbo.tblMovment.typcd ,cast( dbo.tblMovment.docno  as int )as docno, '" + datfrmclc.Text + "' AS datfrm, '" + dattocalc.Text + @"' AS datto, dbo.TBLdoctyp.docnm AS doctyp, 
                        dbo.tblMovment.[internalTaxdep] as internaltax ,
                        dbo.tblMovment.stmpcheckdep  ,
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
                        if (docno2.Text != "")
                        {

                            tblsql = @" SELECT    'دائن' AS knd  , dbo.tblMovment.typcd, dbo.tblMovment.docno, '" + datfrmclc.Text + "' AS datfrm, '" + dattocalc.Text + @"' AS datto, dbo.TBLdoctyp.docnm AS doctyp, 
                                dbo.tblMovment.[internalTaxcred] as internaltax ,
                                dbo.tblMovment.stmpcheckcred ,
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
                                (dbo.tblMovment.doccd = N'" + comboBox1.SelectedValue.ToString() + "') AND dbo.tblMovment.credsum <>0 and (cast (docno as int ) between " + docno.Text +" and " +docno2.Text+") order by cast( dbo.tblMovment.docno  as int ) ";

                        
                        }
                        else
                        {

                                tblsql = @" SELECT    'دائن' AS knd  , dbo.tblMovment.typcd, dbo.tblMovment.docno, '" + datfrmclc.Text + "' AS datfrm, '" + dattocalc.Text + @"' AS datto, dbo.TBLdoctyp.docnm AS doctyp, 
                                
                                dbo.tblMovment.[internalTaxcred] as internaltax ,
                                dbo.tblMovment.stmpcheckcred ,
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

                        }

                    else
                        tblsql = @" SELECT    'دائن' AS knd  , dbo.tblMovment.typcd, dbo.tblMovment.docno, '" + datfrmclc.Text + "' AS datfrm, '" + dattocalc.Text + @"' AS datto, dbo.TBLdoctyp.docnm AS doctyp, 
                      dbo.tblMovment.[internalTaxcred] as internaltax ,
                        dbo.tblMovment.stmpcheckcred ,
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            string choice = comMalyTogary.SelectedIndex.ToString()+comMadynDaan.SelectedIndex.ToString();


            switch (choice)
            {
                case "11":
                {
                    string qry = @"SELECT  docno, dbo.tblMovment.stmpcheckcred AS [check], 
                    dbo.tblMovment.stmpdmndcred AS stmpdmnd, dbo.tblMovment.stmpkndcred AS stmpknd, dbo.tblMovment.stmpnduscred AS stmpndus, dbo.tblMovment.stmpconscred AS stmpcons, dbo.tblMovment.stmpsupcred AS stmpsup, 
                    dbo.tblMovment.suppcomcred AS suppcom, dbo.tblMovment.stmpcontcred AS contract, dbo.tblMovment.credsum, 
                    dbo.tblMovment.stmpcred + dbo.tblMovment.earncred + dbo.tblMovment.prftcred + dbo.tblMovment.freejbscred + dbo.tblMovment.fincombcred + dbo.tblMovment.stmpdmndcred + dbo.tblMovment.stmpkndcred + dbo.tblMovment.stmpnduscred
                    + dbo.tblMovment.stmpcheckcred + dbo.tblMovment.stmpconscred + dbo.tblMovment.stmpsupcred + dbo.tblMovment.stmpcontcred + dbo.tblMovment.suppcomcred + dbo.tblMovment.internalTaxcred AS tswya
                    FROM            dbo.tblMovment 
                    WHERE        (cast( [move_date] as datetime) BETWEEN  cast ( '" + txtdateFrm.Text.Substring(6, 4) +
                    @"/" + txtdateFrm.Text.Substring(3, 2) + @"/" + txtdateFrm.Text.Substring(0, 2)
                    + @"' as datetime) AND cast ( '" + txtdatTo.Text.Substring(6, 4) + @"/" + txtdatTo.Text.Substring(3, 2) + @"/" +
                    txtdatTo.Text.Substring(0, 2) + @"' as datetime) )  AND 
                    (dbo.tblMovment.doccd = N'" + (comMostndTswya.SelectedIndex + 1).ToString() +
                    @"') and dbo.tblMovment.credsum <>0  ORDER BY CAST(dbo.tblMovment.docno AS int)";





                    SqlDataAdapter adreport = new SqlDataAdapter(qry, Static_class.con);
                    DataTable dt = new DataTable();

                    adreport.Fill(dt);


                    FrmReportViewer frm = new FrmReportViewer(dt, @"\report\taxclcRpt_Com.rpt",

                     txtdateFrm.Text,
                     txtdatTo.Text,
                     comMadynDaan.Text,
                     comMostndTswya.Text);

                    this.Cursor = Cursors.Arrow;


                    frm.ShowDialog();
                } break;

                case "10":
                    {
                        string qry = @"SELECT  docno, dbo.tblMovment.stmpcheckdep AS [check], 
                        dbo.tblMovment.stmpdmnddep AS stmpdmnd, dbo.tblMovment.stmpknddep AS stmpknd, dbo.tblMovment.stmpndusdep AS stmpndus, dbo.tblMovment.stmpconsdep AS stmpcons, dbo.tblMovment.stmpsupdep AS stmpsup, 
                        dbo.tblMovment.suppcomdep AS suppcom, dbo.tblMovment.stmpcontdep AS contract, dbo.tblMovment.depsum, 
                        dbo.tblMovment.stmpdep + dbo.tblMovment.earndep + dbo.tblMovment.prftdep + dbo.tblMovment.freejbsdep + dbo.tblMovment.fincombdep + dbo.tblMovment.stmpdmnddep + dbo.tblMovment.stmpknddep + dbo.tblMovment.stmpndusdep
                        + dbo.tblMovment.stmpcheckdep + dbo.tblMovment.stmpconsdep + dbo.tblMovment.stmpsupdep + dbo.tblMovment.stmpcontdep + dbo.tblMovment.suppcomdep + dbo.tblMovment.internalTaxdep AS tswya
                        FROM            dbo.tblMovment 
                        WHERE        (cast( [move_date] as datetime) BETWEEN  cast ( '" + txtdateFrm.Text.Substring(6, 4) +
                       @"/" + txtdateFrm.Text.Substring(3, 2) + @"/" + txtdateFrm.Text.Substring(0, 2)
                       + @"' as datetime) AND cast ( '" + txtdatTo.Text.Substring(6, 4) + @"/" + txtdatTo.Text.Substring(3, 2) + @"/" +
                       txtdatTo.Text.Substring(0, 2) + @"' as datetime) )  AND 
                        (dbo.tblMovment.doccd = N'" + (comMostndTswya.SelectedIndex + 1).ToString() +
                       @"') and dbo.tblMovment.depsum <>0  ORDER BY CAST(dbo.tblMovment.docno AS int)";





                        SqlDataAdapter adreport = new SqlDataAdapter(qry, Static_class.con);
                        DataTable dt = new DataTable();

                        adreport.Fill(dt);


                        FrmReportViewer frm = new FrmReportViewer(dt, @"\report\taxclcRpt_Com.rpt",

                         txtdateFrm.Text,
                         txtdatTo.Text,
                         comMadynDaan.Text,
                         comMostndTswya.Text);

                        this.Cursor = Cursors.Arrow;


                        frm.ShowDialog();

                    } break;

                case "00":
                    {



                        string qry = @"
                        SELECT        docno, stmpdep AS stmp, earndep AS earn, prftdep AS prft, freejbsdep AS freejbs, fincombdep AS finComb, internalTaxdep AS internaltax, 
                        stmpdep + earndep + prftdep + freejbsdep + fincombdep + stmpdmnddep + stmpknddep + stmpndusdep + stmpcheckdep + stmpconsdep + stmpsupdep + stmpcontdep + suppcomdep + internalTaxdep AS tswya
                        
                        FROM            dbo.tblMovment 
                        WHERE        (cast( [move_date] as datetime) BETWEEN  cast ( '" + txtdateFrm.Text.Substring(6, 4) +
                       @"/" + txtdateFrm.Text.Substring(3, 2) + @"/" + txtdateFrm.Text.Substring(0, 2)
                       + @"' as datetime) AND cast ( '" + txtdatTo.Text.Substring(6, 4) + @"/" + txtdatTo.Text.Substring(3, 2) + @"/" +
                       txtdatTo.Text.Substring(0, 2) + @"' as datetime) )  AND 
                        (dbo.tblMovment.doccd = N'" + (comMostndTswya.SelectedIndex + 1).ToString() +
                       @"') and dbo.tblMovment.depsum <>0  ORDER BY CAST(dbo.tblMovment.docno AS int)";





                        SqlDataAdapter adreport = new SqlDataAdapter(qry, Static_class.con);
                        DataTable dt = new DataTable();

                        adreport.Fill(dt);


                        FrmReportViewer frm = new FrmReportViewer(dt, @"\report\taxclcRpt_Fin.rpt",

                         txtdateFrm.Text,
                         txtdatTo.Text,
                         comMadynDaan.Text,
                         comMostndTswya.Text);

                        this.Cursor = Cursors.Arrow;


                        frm.ShowDialog();


                    } break;


                case "01":
                    {



                        string qry = @"
                        SELECT        docno, stmpcred AS stmp, earncred AS earn, prftcred AS prft, freejbscred AS freejbs, fincombcred AS finComb, internalTaxcred AS internaltax, 
                        stmpcred + earncred + prftcred + freejbscred + fincombcred + stmpdmndcred + stmpkndcred + stmpnduscred + stmpcheckcred + stmpconscred + stmpsupcred + stmpcontcred + suppcomcred + internalTaxcred AS tswya
                        
                        FROM            dbo.tblMovment 
                        WHERE        (cast( [move_date] as datetime) BETWEEN  cast ( '" + txtdateFrm.Text.Substring(6, 4) +
                       @"/" + txtdateFrm.Text.Substring(3, 2) + @"/" + txtdateFrm.Text.Substring(0, 2)
                       + @"' as datetime) AND cast ( '" + txtdatTo.Text.Substring(6, 4) + @"/" + txtdatTo.Text.Substring(3, 2) + @"/" +
                       txtdatTo.Text.Substring(0, 2) + @"' as datetime) )  AND 
                        (dbo.tblMovment.doccd = N'" + (comMostndTswya.SelectedIndex + 1).ToString() +
                       @"') and dbo.tblMovment.credsum <>0  ORDER BY CAST(dbo.tblMovment.docno AS int)";





                        SqlDataAdapter adreport = new SqlDataAdapter(qry, Static_class.con);
                        DataTable dt = new DataTable();

                        adreport.Fill(dt);


                        FrmReportViewer frm = new FrmReportViewer(dt, @"\report\taxclcRpt_Fin.rpt",

                         txtdateFrm.Text,
                         txtdatTo.Text,
                         comMadynDaan.Text,
                         comMostndTswya.Text);

                        this.Cursor = Cursors.Arrow;


                        frm.ShowDialog();


                    } break;
            }
        }

    }
}
