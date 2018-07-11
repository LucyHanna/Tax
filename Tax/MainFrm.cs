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
    public partial class MainFrm : Form
    {
        string msql;
        object obj;
        public MainFrm()
        {
            InitializeComponent();
        }


        Form form = new Form();


        public SqlDataAdapter tblusr_da = new SqlDataAdapter("SELECT   useradd, useredit, userdelete, userfind, userprint FROM TBLUSR  WHERE (username = '"+Static_class.muser +"') ", 
            Static_class.con);
        public DataTable tblusr_Table = new DataTable();
        DataRow dr;

        private void MainFrm_Load(object sender, EventArgs e)
        {
            if (Static_class.con.State != ConnectionState.Open) Static_class.con.Open();
         
            //Static_class.con.Open();
            msql = "select username,jobmnu_site,jobmnu_ndx,state,jobname,job_form" +
                  " from qryuserjob where username='" + Static_class.muser + "' and jobmnu_ndx=-1  " +
                  "and state=1 order by jobmnu_site,jobmnu_ndx";

            SqlDataAdapter adusr = new SqlDataAdapter(msql, Static_class.con);
            DataTable dt_usr = new DataTable();

            adusr.Fill(dt_usr);


            string menu_site;
            int jobmnu_ndx;
            int state;
            string jobname;
            string job_ord;





            foreach (DataRow row in dt_usr.Rows)
            {
                menu_site = row[1].ToString();
                jobmnu_ndx = Convert.ToInt16(row[2].ToString());
                state = Convert.ToInt16(row[3].ToString());
                jobname = row[4].ToString();
                job_ord = row[5].ToString();


                ToolStripMenuItem xx = new ToolStripMenuItem();
                xx.Text = jobname;
                xx.Tag = job_ord;
                xx.Name = menu_site;
                xx.ForeColor = Color.DarkBlue;

                usrmenu.Items.Add(xx);
                AddSubMenu(menu_site, xx);
            }

            ///            druser.Close();

            ToolStripMenuItem gg = new ToolStripMenuItem();
            gg.Text = "إعــادة دخــول";
            gg.Tag = "frmrenter";
            usrmenu.Items.Add(gg);
            gg.Click += new EventHandler(gg_Click);


            ToolStripMenuItem zz = new ToolStripMenuItem();
            zz.Text = "خــــروج";
            zz.Tag = "frmexit";
            usrmenu.Items.Add(zz);
            zz.Click += new EventHandler(zz_Click);
           Static_class.con.Close();



           tblusr_da.Fill(tblusr_Table);
            dr = tblusr_Table.Rows[0];

           

           

        }

        private void AddSubMenu(string sId, ToolStripMenuItem main)
        {

            msql = "select jobname,job_form" +
              " from qryuserjob where username='" + Static_class.muser + "'" +
              "and jobmnu_ndx>-1  and state=1 and jobmnu_site='" + sId + "' order by jobmnu_site,jobmnu_ndx";

            SqlCommand cmdsubmnu = new SqlCommand(msql, Static_class.con);
            ////   SqlDataReader  dtsubmnu = cmdsubmnu.ExecuteReader();

            DataTable dt_submnu = new DataTable();
            SqlDataAdapter admnu = new SqlDataAdapter(msql, Static_class.con);
            admnu.Fill(dt_submnu);

            string jobname;
            string job_ord;

            foreach (DataRow row in dt_submnu.Rows)
            //// while (dtsubmnu.Read() == true)
            {

                jobname = row[0].ToString();
                job_ord = row[1].ToString();

                ToolStripMenuItem yy = new ToolStripMenuItem();
                yy.Text = jobname;
                yy.Tag = job_ord;
                yy.Click += new EventHandler(yy_Click);

                main.DropDownItems.Add(yy);

                AddSubMenu(jobname, yy);

            }

            //// dtsubmnu.Close();
        }
        void yy_Click(object sender, EventArgs e)
        {
           
          

           // form.Close();
            string frmname;
            string frmcaption;
            frmname = ((ToolStripMenuItem)sender).Tag.ToString();
            frmcaption = ((ToolStripMenuItem)sender).Text.ToString();
            //try
            //{
                frmname = "Tax." + frmname;
                Type type = Type.GetType(frmname);
            

                obj = Activator.CreateInstance(type);

                //(obj as Form).BackColor = Color.LightSkyBlue;
                (obj as Form).Text = frmcaption;
                form = (obj as Form);
                form.MdiParent = this;

            //    PayrollPro.BasicData.EmpBsDt pp = new PayrollPro.BasicData.EmpBsDt();
            //pp.MdiParent=this;    
            //pp.Show();
                form.Show();


              
            ////}
            ////catch (Exception)
            ////{
            ////    MessageBox.Show("لم تصمم بعد ");
            ////    //Application.Exit();
            ////}

        }

        void zz_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد إنهـاء النظام فعلا ؟", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
           // this.Close();
        }

        void gg_Click(object sender, EventArgs e)
        {
            this.Dispose();
            // this.Close();

            userNm_Pw frmpassword = new userNm_Pw();
            
            frmpassword.ShowDialog();
        }

        private void MainFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

      



       
    }


}
