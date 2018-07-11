using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
namespace Tax
{
    public partial class frmpassword : Form
    {
        string msql;
        SqlCommand cmd; 
        public frmpassword()
        {
            InitializeComponent();
        }

        private void frmpassword_Load(object sender, EventArgs e)
        {
            //txtpassword.PasswordChar = '*';
        }
        
        private void cmdok_Click(object sender, EventArgs e)
        {  
            this.Hide();
            if (Static_class.con.State != ConnectionState.Open) Static_class.con.Open();

            //msql = " select SEC from TBLUSR where username='" + txtusrname.Text + "'";
            //cmd = new SqlCommand(msql, Static_class.con);
            //Static_class.sector = cmd.ExecuteScalar().ToString();

            //msql = " select SUF from TBLUSR where username='" + txtusrname.Text + "'";
            //cmd = new SqlCommand(msql, Static_class.con);
            //Static_class.suffix = cmd.ExecuteScalar().ToString();
            //if (Static_class.con.State != ConnectionState.Closed) Static_class.con.Close();
            MainFrm mainfrm = new MainFrm();
            mainfrm.ShowDialog();
        }

        private void txtusrname_Validated(object sender, EventArgs e)
        {
            if (ActiveControl != cmdexit)
            {
                msql = " select username from TBLUSR where username='" + txtusrname.Text + "'";
                cmd = new SqlCommand(msql, Static_class.con);
                if (Static_class.con.State != ConnectionState.Open) Static_class.con.Open();

                object usr = cmd.ExecuteScalar();

                cmdok.Enabled = true;
                if (usr == null)
                {
                    MessageBox.Show("كود مستخدم غيرمعرف من قبل");
                    txtusrname.Focus();

                }
                Static_class.muser = txtusrname.Text;
                if (Static_class.con.State != ConnectionState.Closed) Static_class.con.Close();
            }
        }

        private void txtpassword_Validated(object sender, EventArgs e)
        {

            msql = " select password from TBLUSR  where username='" + txtusrname.Text + "'" +
                "and  password='" + txtpassword.Text + "'";
            cmd = new SqlCommand(msql, Static_class.con);
            if (Static_class.con.State != ConnectionState.Open) Static_class.con.Open();


            object password = cmd.ExecuteScalar();
            cmdok.Enabled = true;
            if (password == null)
            {
                MessageBox.Show("كلمة مرور غيرمعرفة من قبل");
                txtpassword.Focus();
            }
            if (Static_class.con.State != ConnectionState.Closed) Static_class.con.Close();
        }

        private void cmdexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { SendKeys.Send("{Tab}"); }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       

       

        
    }
}
