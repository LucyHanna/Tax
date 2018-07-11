using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Tax
{
    public partial class userNm_Pw : Form
    {
        public userNm_Pw()
        {
            InitializeComponent();
        }


        public static DataTable dt_Engs;
        SqlDataAdapter da_Engs;


        public SqlDataAdapter TBLUSR_da = new SqlDataAdapter("SELECT *  FROM  TBLUSR  ", Static_class.con);


        public DataTable TBLUSR_Table = new DataTable();








     


      

        DataTable dt = new DataTable();



    




        private void userNm_Pw_Load(object sender, EventArgs e)
        {



         









            try
            {



                Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\International", "sShortDate", "yyyy/MM/dd");

                Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\International", "sLongDate", "yyyy/MM/dd");

                Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\International", "sDate", "/");

                Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\International", "sCountry", "Egypt");

                Microsoft.Win32.Registry.SetValue(@"HKEY_CURRENT_USER\Control Panel\International", "LocaleName", "ar-EG");


            }
            catch (Exception ex)
            {

                
            }




            TBLUSR_da.Fill(TBLUSR_Table);

            DataColumn[] dpk = new DataColumn[1];
            dpk[0] = TBLUSR_Table.Columns["username"];
            TBLUSR_Table.PrimaryKey = dpk;


            nm.DataSource = TBLUSR_Table;
            nm.DisplayMember = "username";
            nm.ValueMember = "username";


          
        }

        private void txtpassword_Validated(object sender, EventArgs e)
        {
            
        }

        private void cmdok_Click(object sender, EventArgs e)
        {
            int pos=TBLUSR_Table.Rows.IndexOf(TBLUSR_Table.Rows.Find(nm.Text));
            string pw = TBLUSR_Table.Rows[pos]["password"].ToString();

            if (pw != txtpassword.Text)
            {
                MessageBox.Show("كلمة مرور غيرمعرفة من قبل", "دخول خطا",
                MessageBoxButtons.OK, MessageBoxIcon.Hand);
                this.ActiveControl = txtpassword;
                txtpassword.SelectAll();
            }

            else
            {
                Static_class.muser = nm.Text;

                MainFrm mainfrm = new MainFrm();
                mainfrm.ShowDialog();
            }


             




               
               
            
        }

        private void cmdexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void userNm_Pw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { SendKeys.Send("{Tab}"); }
        }

       

      

    

        
      
        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter)
            {

                cmdok_Click(sender, e);

            }
        }

       

      
    }
}
