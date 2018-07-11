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
    public partial class frm_taxStamp_Rpt : Form
    {
        public frm_taxStamp_Rpt()
        {
            InitializeComponent();
        }

        public SqlDataAdapter TBLMovTyp_da = new SqlDataAdapter("SELECT     movcd, movnm  FROM         TBLMovTyp", Static_class.con);
        public DataTable TBLMovTyp_tbl = new DataTable();
        
        private void frm_taxStamp_Rpt_Load(object sender, EventArgs e)
        {
            TBLMovTyp_da.Fill(TBLMovTyp_tbl);



            movcd.DataSource = TBLMovTyp_tbl;
            movcd.DisplayMember = "movnm";
            movcd.ValueMember = "movcd";

        }

        private void frm_taxAnalaysis_Rpt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { SendKeys.Send("{Tab}"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkEmptyComp(panel2) == 0)
            {
                Static_class.reportdb = 2;
                Static_class.rptlbl5 = "الكــل";
                string tblsql;
                string mov = movcd.Text;

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
