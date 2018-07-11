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
    public partial class frm_SalaryTax_Rpt : Form
    {
        public frm_SalaryTax_Rpt()
        {
            InitializeComponent();
        }


        public SqlDataAdapter TBLdocTyp_da = new SqlDataAdapter("SELECT  doccd,docnm   FROM tbldoctyp", Static_class.con);
        public DataTable TBLdocTyp_tbl = new DataTable();


        private void frm_SalaryTax_Rpt_Load(object sender, EventArgs e)
        {
           

            TBLdocTyp_da.Fill(TBLdocTyp_tbl);

            doccd.DataSource = TBLdocTyp_tbl;
            doccd.DisplayMember = "docnm";
            doccd.ValueMember = "doccd";
        }

        private void frm_taxAnalaysis_Rpt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { SendKeys.Send("{Tab}"); }
        }

        private void button1_Click(object sender, EventArgs e)
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

    }
}
