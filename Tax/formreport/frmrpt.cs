using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;


using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;

namespace Tax.formreport
{
    public partial class frmrpt : Form
    {
        public frmrpt()
        {
            InitializeComponent();
        }

        private void frmrpt_Load(object sender, EventArgs e)
        {
           

            ReportClass rpreadern = new ReportClass();


            rpreadern.FileName = Static_class.app_path + "\\report\\" + Static_class.reportname + ".rpt";

            rpreadern.SetDataSource(Static_class.reportDataSrc);

          
            /// rpreadern.DataDefinition.FormulaFields["lblbrname"].Text = "'" + clsGeneral.engname + "'";
            crystalReportViewer1.ReportSource = rpreadern;
            crystalReportViewer1.Refresh();
            


        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
