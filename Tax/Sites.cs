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
    public partial class Sites : Form
    {
        public Sites()
        {
            InitializeComponent();
        }

        


        public SqlDataAdapter TBLsites_da = new SqlDataAdapter
        (" SELECT     stcd, stnm, stdis FROM         TBLsites "
        , Static_class.con);

  
        public DataTable TBLsites_Table = new DataTable();


        public SqlCommandBuilder cm = new SqlCommandBuilder();


        private void Sites_Load(object sender, EventArgs e)
        {
            cm = new SqlCommandBuilder(TBLsites_da);
            TBLsites_da.Fill(TBLsites_Table);
            
            DataColumn[] dpk = new DataColumn[1];
            dpk[0] = TBLsites_Table.Columns[0];
            TBLsites_Table.PrimaryKey = dpk;

            stcd.DataBindings.Add("Text", TBLsites_Table, "stcd");
            stnm.DataBindings.Add("Text", TBLsites_Table, "stnm");
            stdis.DataBindings.Add("Text", TBLsites_Table, "stdis");
            


        }

        private void useradd_Click(object sender, EventArgs e)
        {
            BindingContext[TBLsites_Table].AddNew();
            stcd.Focus();
            enbControls(true);
            
        }

        private void useredit_Click(object sender, EventArgs e)
        {
            enbControls(true);
            stcd.ReadOnly = true;
        }

        private void userdelete_Click(object sender, EventArgs e)
        {

        }

        private void userfind_Click(object sender, EventArgs e)
        {
            SearchForm search = new SearchForm(TBLsites_da
              , "stcd", "stnm", 2, 3);
            search.ShowDialog();

            this.BindingContext[TBLsites_Table].Position =
            TBLsites_Table.Rows.IndexOf(TBLsites_Table.Rows.Find(Static_class.search_output[0]));
      
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frst_Click(object sender, EventArgs e)
        {
            this.BindingContext[TBLsites_Table].Position = 0;
        }

        private void prv_Click(object sender, EventArgs e)
        {
            this.BindingContext[TBLsites_Table].Position -= 1;
        }

        private void nxt_Click(object sender, EventArgs e)
        {
            this.BindingContext[TBLsites_Table].Position += 1;
        }

        private void lst_Click(object sender, EventArgs e)
        {
            this.BindingContext[TBLsites_Table].Position = this.BindingContext[TBLsites_Table].Count - 1;
            
        }


        public void enbControls(Boolean boolean) /// true if enabled
        {
            foreach (Control gb in this.Controls)
            {




                if (gb.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    System.Windows.Forms.TextBox tx = (TextBox)gb;
                    tx.ReadOnly = !boolean;


                }


              

            }

            panbutt_Nav.Visible = !boolean;
            panSav.Visible = boolean;

        }

        private void save_Click(object sender, EventArgs e)
        {
            this.BindingContext[TBLsites_Table].EndCurrentEdit();
            DataTable tbEdit = (DataTable)(TBLsites_Table.GetChanges(DataRowState.Modified));
            DataTable tbAdded = (DataTable)(TBLsites_Table.GetChanges(DataRowState.Added));
            DataTable tbdelete = (DataTable)(TBLsites_Table.GetChanges(DataRowState.Deleted));
            TBLsites_Table.AcceptChanges();
            if (tbAdded != null) { TBLsites_da.Update(tbAdded); }
            if (tbEdit != null) { TBLsites_da.Update(tbEdit); }
            if (tbdelete != null) { TBLsites_da.Update(tbdelete); }

            if (tbAdded != null || tbEdit != null || tbdelete != null)
            {
                MessageBox.Show("تم الحفظ");

                this.BindingContext[TBLsites_Table].EndCurrentEdit();

                back_Click(null, null);
            }
            else { MessageBox.Show("لم يتم الحفظ لوجود خطأ ما !!"); }
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.BindingContext[TBLsites_Table].CancelCurrentEdit();

            enbControls(false);
        }

        private void stcd_Validated(object sender, EventArgs e)
        {
            if (stcd.ReadOnly == false)
            {
                int pos = TBLsites_Table.Rows.IndexOf(TBLsites_Table.Rows.Find(stcd.Text));
                if (pos != -1)
                {
                    MessageBox.Show("هذا الكود قد سبق استخدامه ");
                    back_Click(null, null);
                    this.BindingContext[TBLsites_Table].Position = pos;


                }
            }
        }

        private void Sites_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { SendKeys.Send("{Tab}"); }
        }
    }
}
