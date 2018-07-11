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

namespace Tax
{
    class Static_class
    {

      

       public static SqlConnection con;
        public static SqlConnection con_his;


        public static SqlConnection con_rep;

        public static string muser;



        ////search///
        public static string[] search_output;
        public static string search_in = "";
        public static Boolean child_form_opened_flag = false;


       
        public static string rptlbl1;
        public static string rptlbl2;
        public static string rptlbl3;
        public static string rptlbl4;
        public static string rptlbl5;


       
        public static string reportname;
       

        public static int reportdb;

        public static string SQLstr;
        public static string SQLstr1;

        public static string app_path = Directory.GetCurrentDirectory();


        public static string TAX_PATH = "";

        public static DataTable reportDataSrc=new DataTable();

        public static DataTable userjob_dt;

        public static void sysprint()
        {

            if (reportdb != 1) { reportdb = 2; }
          //  SQLstr = Rsql;
            formreport.frmrpt frmrpt = new formreport.frmrpt();
            frmrpt.ShowDialog();

        }
        public static void sysprint(string Rsql, string Rsql_sld)
        {

            if (reportdb != 1) { reportdb = 0; }
            SQLstr = Rsql;
            SQLstr1 = Rsql_sld;
            formreport.frmrpt frmrpt = new formreport.frmrpt();
            frmrpt.ShowDialog();

        }

        public static void fillTbl(String tblsql)
        {
            SqlDataAdapter adreport = new SqlDataAdapter(tblsql, Static_class.con);
            reportDataSrc = new DataTable();
           
            adreport.Fill(reportDataSrc);

        }




        public static string makeDate(decimal dd, decimal mm, decimal yy)
        {
            string out_date = "";
            try
            {
                if (dd.ToString().Length == 1)
                    out_date = '0' + dd.ToString() + "/";
                else
                    out_date = dd.ToString() + "/";

                if (mm.ToString().Length == 1)
                    out_date = out_date + '0' + mm.ToString() + "/";
                else
                    out_date = out_date + mm.ToString() + "/";

                out_date = out_date + yy.ToString();

                return out_date;
            }
            catch (Exception)
            {

                return "";
            }

            
        }



        public static void EditMasterDataTable(DataTable Master,
 DataTable Details,
 int Pk_Number,
 int MaterColumnIndex,
 int detailColumnIndex)
        {


            DataColumn[] dcM = Master.PrimaryKey;

            DataColumn[] dcD = Details.PrimaryKey;


            if (dcM.Length != dcD.Length)
            {

                MessageBox.Show("PrimaryKey Error");
                return;
            }



            if (dcM.Length == 0 | dcD.Length == 0)
            {

                MessageBox.Show("PrimaryKey Error");
                return;
            }



            object[] pk = new object[Pk_Number];


            //if (Details.Rows.Count == 0)
            //{
            //    Master.Columns[MaterColumnIndex].Expression = "0";
            //    return;

            //}


            for (int i = 0; i < Details.Rows.Count; i++)
            {
                for (int x = 0; x < pk.Length; x++)
                {
                    pk[x] = Details.Rows[i][x];

                }


                DataRow dr = Master.Rows.Find(pk);

                if (dr != null)
                {
                    int drIndex = Master.Rows.IndexOf(dr);

                    object Dval = Details.Rows[i][detailColumnIndex];

                    Master.Rows[drIndex][MaterColumnIndex] = Dval;


                }


            }



        }


    }
}
