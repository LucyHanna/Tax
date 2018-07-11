using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
namespace Tax
{
    static class Program
    {
      
        [STAThread]
        static void Main()
        {
            //////////string startPath = Application.StartupPath.ToString();
            //////////Static_class.con = new SqlConnection
            //////////    //(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\Tax\Tax\bin\Debug\TaxDB\taxDB.mdf;Integrated Security=True");  
            //////////    (@"Data Source=.\SQLEXPRESS;AttachDbFilename=" + startPath + @"\TaxDB\taxDB.mdf;Integrated Security=True ;User Instance=True");
            ////////////(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\Tax2\Tax\bin\Debug\TaxDB\taxDB.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            //////////Static_class.con.Open();
            //////////Application.EnableVisualStyles();
            //////////Application.SetCompatibleTextRenderingDefault(false);
            //////////Application.Run(new frmpassword());



            #region  Read_db_info

            string[] lines =
            System.IO.File.ReadAllLines(Application.StartupPath + @"\Server-INFO.dat");

            string server_ip = lines[0].Substring(lines[0].LastIndexOf('#') + 1);

            string user = lines[1].Substring(lines[1].LastIndexOf('#') + 1);

            string pass = lines[2].Substring(lines[2].LastIndexOf('#') + 1);

            string DB_name = lines[3].Substring(lines[3].LastIndexOf('#') + 1);

            Static_class.TAX_PATH = server_ip + ";Initial Catalog=" + DB_name + ";User ID=" + user + ";Password=" + pass + "";

            string DB_Path = @"Data Source=" + server_ip + ";Initial Catalog=" + DB_name + ";User ID=" + user + ";Password=" + pass + ";Connect Timeout=90;";



            #endregion



            Static_class.con = new SqlConnection(DB_Path);
          
            Static_class.con.Open();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new userNm_Pw());
        }
    }
}
