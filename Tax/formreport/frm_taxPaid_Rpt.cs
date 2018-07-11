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
    public partial class frm_taxPaid_Rpt : Form
    {
        public frm_taxPaid_Rpt()
        {
            InitializeComponent();
        }


        private void frm_taxPaid_Rpt_Load(object sender, EventArgs e)
        {
            
        }

        private void frm_taxAnalaysis_Rpt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { SendKeys.Send("{Tab}"); }
        }

        private void button1_Click(object sender, EventArgs e) { }


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

       
    }
}
