using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tax
{
    public partial class frmViewTotal : Form
    {

        DataTable mydt = new DataTable();
        int sw = 0;
        public frmViewTotal()
        {
            InitializeComponent();
        }

        public frmViewTotal(DataTable dt , int sw ,string lbltxt)
        {
            InitializeComponent();

            mydt = dt;
            this.sw = sw;

            this.label1.Text = lbltxt;
        }
     

        private void frmViewTotal_Load(object sender, EventArgs e)
        {
            switch (sw)
            {
                case 0:
                    {
                        com.Visible = true;
                        fin.Visible = false;
                        foreach (Control gb in com.Controls)
                        {
                            if (gb.GetType().ToString() == "System.Windows.Forms.TextBox")
                            {
                                System.Windows.Forms.TextBox tx = (TextBox)gb;

                                tx.Text = mydt.Rows[0][tx.Name].ToString();
                                tx.ReadOnly = true;

                            }
                        }

                    } break;
                case 1:
                    {
                        com.Visible = false;
                        fin.Visible = true;


                        foreach (Control gb in fin.Controls)
                        {
                            if (gb.GetType().ToString() == "System.Windows.Forms.TextBox")
                            {
                                System.Windows.Forms.TextBox tx = (TextBox)gb;

                                tx.Text = mydt.Rows[0][tx.Name].ToString();
                                tx.ReadOnly = true;

                            }
                        }
                    }break;

            }

        }
    }
}
