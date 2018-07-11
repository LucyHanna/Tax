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
    public partial class suppliers : Form
    {

        public SqlDataAdapter TBLsuppliers_da = new SqlDataAdapter
        (" SELECT     supcd, supnm, taxfileNo , taxcd,taxrecNo , txdep_cd  FROM         TBLsuppliers "
        , Static_class.con);
        public DataTable TBLsuppliers_Table = new DataTable();


        //public SqlDataAdapter TBLsites_da = new SqlDataAdapter
        //(" SELECT     stcd, stnm, stdis FROM         TBLsites "
        //, Static_class.con);


        public DataTable TBLsites_Table = new DataTable();

        public SqlDataAdapter taxkd_da = new SqlDataAdapter("SELECT     taxcd, taxnm  FROM         taxkd", Static_class.con);
        public DataTable taxkd_tbl = new DataTable();

        public SqlDataAdapter txdp_da = new SqlDataAdapter("SELECT     txdep_cd , txdep_nm  FROM        Tbltxdep ", Static_class.con);
        public DataTable txdp_tbl = new DataTable();


        public SqlCommandBuilder cm = new SqlCommandBuilder();

        public SqlCommand cmd = new SqlCommand("",Static_class.con);

        int flag_add_edit = 0; // 1 for add --- 2 for edit

        public suppliers()
        {
            InitializeComponent();
        }

        private void suppliers_Load(object sender, EventArgs e)
        {
            cm = new SqlCommandBuilder(TBLsuppliers_da);
            TBLsuppliers_da.Fill(TBLsuppliers_Table);

            //TBLsites_da.Fill(TBLsites_Table);
            taxkd_da.Fill(taxkd_tbl);
            txdp_da.Fill(txdp_tbl);


            DataColumn[] dpk = new DataColumn[1];
            dpk[0] = TBLsuppliers_Table.Columns[0];
            TBLsuppliers_Table.PrimaryKey = dpk;

            //sts.DataSource = TBLsites_Table;
            //sts.DisplayMember = "stnm";
            //sts.ValueMember = "stcd";


            taxknd.DataSource = taxkd_tbl;
            taxknd.DisplayMember = "taxnm";
            taxknd.ValueMember = "taxcd";

            cbBxtxdp.DataSource = txdp_tbl;
            cbBxtxdp.DisplayMember = "txdep_nm";
            cbBxtxdp.ValueMember = "txdep_cd";
            
            
            supcd.DataBindings.Add("Text", TBLsuppliers_Table, "supcd");
            supnm.DataBindings.Add("Text", TBLsuppliers_Table, "supnm");
            taxfileNo.DataBindings.Add("Text", TBLsuppliers_Table, "taxfileNo");

            taxrecNo.DataBindings.Add("Text", TBLsuppliers_Table, "taxrecNo");
            taxcd.DataBindings.Add("Text", TBLsuppliers_Table, "taxcd");
            cbBxtxdp.DataBindings.Add("selectedvalue", TBLsuppliers_Table, "txdep_cd");


            
        }

       
        private void prv_Click(object sender, EventArgs e)
        {
            this.BindingContext[TBLsuppliers_Table].Position -= 1;
           
        }

        private void nxt_Click(object sender, EventArgs e)
        {
            this.BindingContext[TBLsuppliers_Table].Position += 1;
          


        }

        private void frst_Click(object sender, EventArgs e)
        {
            this.BindingContext[TBLsuppliers_Table].Position = 0;
           

        }

        private void lst_Click(object sender, EventArgs e)
        {
            this.BindingContext[TBLsuppliers_Table].Position = this.BindingContext[TBLsuppliers_Table].Count - 1;
            

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


                else if (gb.GetType().ToString() == "System.Windows.Forms.ComboBox")
                    {
                        System.Windows.Forms.ComboBox tx = (ComboBox)gb;
                        tx.Enabled = boolean;
                    }
                else if (gb.GetType().ToString() == "System.Windows.Forms.MaskedTextBox")
                {
                    System.Windows.Forms.MaskedTextBox tx = (MaskedTextBox)gb;
                    tx.ReadOnly = !boolean;
                }
            }

            panbutt_Nav.Visible = !boolean;
            panSav.Visible = boolean;

        }

        private void useradd_Click(object sender, EventArgs e)
        {
            flag_add_edit = 1;
            BindingContext[TBLsuppliers_Table].AddNew();
            enbControls(true);
            supcd.Focus();

        }

        private void back_Click(object sender, EventArgs e)
        {
            flag_add_edit = 0;
            this.BindingContext[TBLsuppliers_Table].CancelCurrentEdit();
           
            enbControls(false);
        }

       

        private void save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Static_class.con.State == ConnectionState.Closed) Static_class.con.Open();
                Save_fun();
                if (Static_class.con.State == ConnectionState.Open) Static_class.con.Close();
                //this.BindingContext[TBLsuppliers_Table].EndCurrentEdit();
                //DataTable tbEdit = (DataTable)(TBLsuppliers_Table.GetChanges(DataRowState.Modified));
                //DataTable tbAdded = (DataTable)(TBLsuppliers_Table.GetChanges(DataRowState.Added));
                //DataTable tbdelete = (DataTable)(TBLsuppliers_Table.GetChanges(DataRowState.Deleted));
                //TBLsuppliers_Table.AcceptChanges();
                //if (tbAdded != null) { TBLsuppliers_da.Update(tbAdded); }
                //if (tbEdit != null) { TBLsuppliers_da.Update(tbEdit); }
                //if (tbdelete != null) { TBLsuppliers_da.Update(tbdelete); }

                //if (tbAdded != null || tbEdit != null || tbdelete != null)
                //{
                //    MessageBox.Show("تم الحفظ");

                //    this.BindingContext[TBLsuppliers_Table].EndCurrentEdit();

                //    back_Click(null, null);
                //}
                //else { MessageBox.Show("لم يتم الحفظ لوجود خطأ ما !!"); }
            }
            catch 
            {

                MessageBox.Show("لم يتم الحفظ لوجود خطأ ما !!");
            }

        }

        private void supcd_Validated(object sender, EventArgs e)
        {
            if (supcd.ReadOnly == false)
            {
                int pos = TBLsuppliers_Table.Rows.IndexOf(TBLsuppliers_Table.Rows.Find(supcd.Text));
                if (pos != -1)
                {
                    MessageBox.Show("هذا الكود قد سبق استخدامه ");
                    back_Click(null, null);
                    this.BindingContext[TBLsuppliers_Table].Position = pos;


                }
                else
                {
                    MessageBox.Show("برجاء الالتزام ببداية الكود الخاص بكل  نوع ضريبة ");
                }
            }
        }

        private void suppliers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { SendKeys.Send("{Tab}"); }
        }

        private void useredit_Click(object sender, EventArgs e)
        {
            flag_add_edit = 2;
            
            enbControls(true);
            supcd.ReadOnly = true;

            taxfileNo.ReadOnly = false;
        }

        //private void sts_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (!supnm.ReadOnly)
        //    {
        //        stcd.Text = sts.SelectedValue.ToString();
        //    }
        //}

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void userfind_Click(object sender, EventArgs e)
        {

            SearchForm search = new SearchForm(TBLsuppliers_da
                , "supcd", "supnm", 2, 3);
            search.ShowDialog();

            this.BindingContext[TBLsuppliers_Table].Position =
            TBLsuppliers_Table.Rows.IndexOf(TBLsuppliers_Table.Rows.Find(Static_class.search_output[0]));
        }

        private void userdelete_Click(object sender, EventArgs e)
        {
            if (Static_class.con.State == ConnectionState.Closed) Static_class.con.Open();
            string str = "select count(docno) from tblMovment where supcd='" + supcd.Text+"'";

            SqlCommand com = new SqlCommand(str, Static_class.con);

            int cont = Convert.ToInt32(com.ExecuteScalar().ToString());
            if (cont > 0)
            {
                MessageBox.Show("لا يمكن الحذف فقد سبق ادخال مستندات لهذا العميل ");
                return;
            }
            else
            {
                flag_add_edit = 3;
                string message = " هل تريد حذف العميل  "+supnm.Text+"?";
                 
			    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
			    DialogResult result;
                result = MessageBox.Show(message, "رسالة تحذيرية ", buttons, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                   
                    Save_fun();
                    TBLsuppliers_Table.Rows[this.BindingContext[TBLsuppliers_Table].Position].Delete();
                }
 
            }
        }

        private void taxknd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!supnm.ReadOnly)
            {
                taxcd.Text = taxknd.SelectedValue.ToString();
            }
        }

        private void taxcd_TextChanged(object sender, EventArgs e)
        {
            try
            {
                taxknd.SelectedValue = taxcd.Text;
            }
            catch (Exception)
            { taxknd.SelectedIndex = 0; }
        }

        private void rprt_Click(object sender, EventArgs e)
        {

            Static_class.reportdb = 2;
            Static_class.rptlbl5 = "الكــل";
            string tblsql = "";

            tblsql = @" SELECT     dbo.tblMovment.docno, dbo.tblMovment.docsubno, dbo.TBLsuppliers.supnm, dbo.tblMovment.mov_date as   [date] , dbo.tblMovment.prftcred, 
                      dbo.tblMovment.freejbscred, dbo.taxkd.taxnm, dbo.tblMovment.supcd,taxfileNo,taxrecNo
                FROM         dbo.TBLsuppliers INNER JOIN
                      dbo.taxkd ON dbo.TBLsuppliers.taxcd = dbo.taxkd.taxcd RIGHT OUTER JOIN
                      dbo.tblMovment ON dbo.TBLsuppliers.supcd = dbo.tblMovment.supcd where dbo.tblMovment.supcd ='" + supcd.Text + "'    order by dbo.tblMovment.mov_date ";

            Static_class.fillTbl(tblsql);
            Static_class.rptlbl1 = "";

            Static_class.rptlbl2 = "";
            Static_class.rptlbl3 = "";
            Static_class.rptlbl4 = "";


            Static_class.reportname = "rptbscsupdt";


            Static_class.sysprint();

           
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Static_class.reportdb = 2;
            Static_class.rptlbl5 = "الكــل";
            string tblsql = "";

            tblsql = @" SELECT     dbo.TBLsuppliers.supcd, dbo.TBLsuppliers.supnm, dbo.taxkd.taxnm, dbo.taxkd.taxprc
FROM         dbo.taxkd RIGHT OUTER JOIN
                      dbo.TBLsuppliers ON dbo.taxkd.taxcd = dbo.TBLsuppliers.taxcd ";

            Static_class.fillTbl(tblsql);
            Static_class.rptlbl1 = "";

            Static_class.rptlbl2 = "";
            Static_class.rptlbl3 = "";
            Static_class.rptlbl4 = "";


            Static_class.reportname = "RPTSUP";


            Static_class.sysprint();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SearchForm search = new SearchForm(TBLsuppliers_da
              , "supcd", "taxfileNo", 2, 2);
            search.ShowDialog();

            this.BindingContext[TBLsuppliers_Table].Position =
            TBLsuppliers_Table.Rows.IndexOf(TBLsuppliers_Table.Rows.Find(Static_class.search_output[0]));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SearchForm search = new SearchForm(TBLsuppliers_da
              , "supcd", "taxrecNo", 2, 2);
            search.ShowDialog();

            this.BindingContext[TBLsuppliers_Table].Position =
            TBLsuppliers_Table.Rows.IndexOf(TBLsuppliers_Table.Rows.Find(Static_class.search_output[0]));
        }

        private void taxfileNo_Validated(object sender, EventArgs e)
        {
            if (flag_add_edit > 0)
            {
                SqlDataAdapter da = new SqlDataAdapter(@"SELECT [supcd]
            ,[supnm]
            FROM [dbo].[TBLsuppliers]
            where supcd !='"+supcd.Text+"'  and  [taxfileNo]='" + taxfileNo.Text + "'", Static_class.con);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("قد تم استعمال رقم الملف الضريبي من قبل " + "\n" + dt.Rows[0]["supnm"].ToString(), "تحذير");
                    taxfileNo.SelectAll();
                    this.ActiveControl = taxfileNo;

                }
            }
        }

        public void Save_fun()
        {
            string cbBxtxdptxt = (cbBxtxdp.Text.Length > 0) ? cbBxtxdp.SelectedValue.ToString() : "";
            switch (flag_add_edit)
            {
                case 1://add
                 {
                    
                     cmd.CommandText = @"INSERT INTO [dbo].[TBLsuppliers]
                    ([supcd]
                    ,[supnm]
                    ,[taxcd]
                    ,[stcd]
                    ,[taxfileNo]
                    ,[taxrecNo]
                    ,[txdep_cd])
                    VALUES
                    ('"+supcd.Text+@"'
                    ,'"+supnm.Text+@"'
                    ,'"+taxcd.Text+@"'
                    ,"+taxknd.SelectedValue.ToString()+@"
                    ,"+taxfileNo.Text.TOInsertString()+@"
                    ,"+taxrecNo.Text.TOInsertString() + @"
                    ," + cbBxtxdptxt.TOInsertString() + ")";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("تم الحفظ");

                 
                     


                 } break;
                case 2: //edit
                    {
                        cmd.CommandText = @"UPDATE [dbo].[TBLsuppliers]
                        SET
                         [supnm] = '"+supnm.Text+@"'
                        ,[taxcd] = '" + taxcd.Text + @"'
                        ,[stcd] = '" + taxknd.SelectedValue.ToString() + @"'
                        ,[taxfileNo] = "+taxfileNo.Text.TOInsertString()+@"
                        ,[taxrecNo] = " + taxrecNo.Text.TOInsertString() + @"
                        ,[txdep_cd] =" + cbBxtxdptxt.TOInsertString() + @"
                        WHERE  [supcd] = '" +supcd.Text+"'";

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("تم الحفظ");

                    } break;


                case 3:
                    {
                        cmd.CommandText = @"DELETE FROM [dbo].[TBLsuppliers]
                        WHERE supcd='" + supcd.Text + "'";

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("تم الحذف");
                    } break;
            }

            this.BindingContext[TBLsuppliers_Table].EndCurrentEdit();

            back_Click(null, null);
           
        }

        private void taxrecNo_Validated(object sender, EventArgs e)
        {
            if (flag_add_edit > 0)
            {
                SqlDataAdapter da = new SqlDataAdapter(@"SELECT [supcd]
            ,[supnm]
            FROM [dbo].[TBLsuppliers]
            where  supcd !='" + supcd.Text + "' and [taxrecNo]='" + taxrecNo.Text + "'", Static_class.con);
                DataTable dt = new DataTable();

                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("قد تم استعمال رقم التسجيل الضريبي من قبل " + "\n" + dt.Rows[0]["supnm"].ToString(), "تحذير");
                    taxrecNo.SelectAll();
                    this.ActiveControl = taxrecNo;

                }
            }
        }

        private void cbBxtxdp_Leave(object sender, EventArgs e)
        {
            this.ActiveControl = save;
        }

        
    }
}
