using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Tax.movement
{
    public partial class FrmMovement : Form
    {
        public FrmMovement()
        {
            InitializeComponent();
        }

        public SqlDataAdapter TBLMovTyp_da = new SqlDataAdapter("SELECT     movcd, movnm  FROM         TBLMovTyp", Static_class.con);
        public DataTable TBLMovTyp_tbl = new DataTable();

        public SqlDataAdapter TBLdocTyp_da = new SqlDataAdapter("SELECT  doccd,docnm   FROM tbldoctyp", Static_class.con);
        public DataTable TBLdocTyp_tbl = new DataTable();

        public SqlDataAdapter TBLTyp_da = new SqlDataAdapter(" SELECT [typcd],[typnm] FROM [TAXDB].[dbo].[TBLtyp]", Static_class.con);
        public DataTable TBLTyp_tbl = new DataTable();




        public SqlDataAdapter TBLLabel_da = new SqlDataAdapter("SELECT     lblcd, lblnm  FROM         TBLLabel", Static_class.con);
        public DataTable TBlLabel_tbl = new DataTable();



        public SqlDataAdapter TBLsuppliers_da = new SqlDataAdapter("SELECT     supcd, supnm, stcd,taxcd   FROM         TBLsuppliers", Static_class.con);
        public DataTable TBLsuppliers_tbl = new DataTable();


        //

        public SqlDataAdapter TBLsites_da = new SqlDataAdapter("SELECT     stcd, stnm, stdis  FROM   TBLsites", Static_class.con);
        public DataTable TBLsites_tbl = new DataTable();



        public SqlDataAdapter TBLmovement_da = new SqlDataAdapter(@"SELECT  cast(docno as int) as docno,[docsubno],[supcd],[movcd],[doccd],[typcd]
      ,[mov_date] ,[yr],[lblcd],[stmpdep],[earndep],[prftdep],[freejbsdep]
      ,[fincombdep],[stmpdmnddep],[stmpknddep],[stmpndusdep],[stmpcheckdep]
      ,[stmpconsdep],[stmpsupdep],[stmpcontdep],[suppcomdep] ,[internalTaxdep],[depsum],[depdiff]
      ,[stmpcred],[earncred],[prftcred],[freejbscred],[fincombcred],[stmpdmndcred],[stmpkndcred]
      ,[stmpnduscred],[stmpcheckcred],[stmpconscred],[stmpsupcred],[stmpcontcred],[suppcomcred] ,[internalTaxcred]
      ,[credsum],[creddiff],[notes] FROM [TAXDB].[dbo].[tblMovment]", Static_class.con);
        public DataTable TBLmovement_tbl = new DataTable();

        public DataTable mov_datatyp = new DataTable();
        public SqlDataAdapter mov_datatyp_da = new SqlDataAdapter("SELECT COLUMN_NAME,DATA_TYPE  FROM INFORMATION_SCHEMA.COLUMNS  WHERE TABLE_NAME = 'tblMovment'", Static_class.con);


        //

        public SqlDataAdapter taxkd_da = new SqlDataAdapter("SELECT     taxcd, taxnm  FROM         taxkd", Static_class.con);
        public DataTable taxkd_tbl = new DataTable();

        string[] mov_pk = new string[4];

        int movementPos = -1;

        DataSet ds = new DataSet();
        ErrorProvider erPrv = new ErrorProvider();


        int add_edt= 0; // 0 add 1 edt


        private void FrmMovement_Load(object sender, EventArgs e)
        {
            if (Static_class.muser == "Administrator")
            {
                useredit.Visible = true;
                userdelete.Visible = true;
            }
            TBLmovement_da.Fill(TBLmovement_tbl);


            TBLmovement_tbl.PrimaryKey = new DataColumn[4] { TBLmovement_tbl.Columns["docno"], TBLmovement_tbl.Columns["docsubno"], TBLmovement_tbl.Columns["yr"], TBLmovement_tbl.Columns["doccd"] };

            mov_datatyp_da.Fill(mov_datatyp);
            mov_datatyp.PrimaryKey = new DataColumn[1] { mov_datatyp.Columns["COLUMN_NAME"] };



            TBLMovTyp_da.Fill(TBLMovTyp_tbl);
            TBLdocTyp_da.Fill(TBLdocTyp_tbl);
            TBLTyp_da.Fill(TBLTyp_tbl);
            TBLLabel_da.Fill(TBlLabel_tbl);
            taxkd_da.Fill(taxkd_tbl);
            TBLsuppliers_da.Fill(TBLsuppliers_tbl);

            TBLsuppliers_tbl.PrimaryKey = new DataColumn[1] { TBLsuppliers_tbl.Columns[0]};
            taxkd_tbl.PrimaryKey = new DataColumn[1] { taxkd_tbl.Columns[0]};

            movcd.DataSource = TBLMovTyp_tbl;
            movcd.DisplayMember = "movnm";
            movcd.ValueMember = "movcd";


            doccd.DataSource = TBLdocTyp_tbl;
            doccd.DisplayMember = "docnm";
            doccd.ValueMember = "doccd";



            typcd.DataSource = TBLTyp_tbl;
            typcd.DisplayMember = "typnm";
            typcd.ValueMember = "typcd";

            lblcd.DataSource = TBlLabel_tbl;
            lblcd.DisplayMember = "lblnm";
            lblcd.ValueMember = "lblcd";

            //taxknd.DataSource = taxkd_tbl;
            //taxknd.DisplayMember = "taxnm";
            //taxknd.ValueMember = "taxcd";

            this.ActiveControl = movcd;

            //foreach (Control gb in fin.Controls)
            //{
            //    if (gb.GetType().ToString() == "System.Windows.Forms.TextBox")
            //    {
            //        System.Windows.Forms.TextBox tx = (TextBox)gb;

            //        new ManageControls().AllowDecimalNumbersOnly(tx);

            //    }
            //}

            //foreach (Control gb in com.Controls)
            //{
            //    if (gb.GetType().ToString() == "System.Windows.Forms.TextBox")
            //    {
            //        System.Windows.Forms.TextBox tx = (TextBox)gb;

            //        new ManageControls().AllowDecimalNumbersOnly(tx);


            //    }
            //}

            foreach (Control gb in fin.Controls)
            {
                if (gb.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    System.Windows.Forms.TextBox tx = (TextBox)gb;

                    new ManageControls().AllowSignedDecimalNumbersOnly(tx);

                }
            }

            foreach (Control gb in com.Controls)
            {
                if (gb.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    System.Windows.Forms.TextBox tx = (TextBox)gb;

                    new ManageControls().AllowSignedDecimalNumbersOnly(tx);


                }
            }
            new ManageControls().AllowSignedDecimalNumbersOnly(depsum);
            new ManageControls().AllowSignedDecimalNumbersOnly(credsum);

            new ManageControls().AllowSignedDecimalNumbersOnly(depdiff);
            new ManageControls().AllowSignedDecimalNumbersOnly(creddiff);

            //new ManageControls().AllowDecimalNumbersOnly(depsum);
            //new ManageControls().AllowDecimalNumbersOnly(credsum);

            //new ManageControls().AllowDecimalNumbersOnly(depdiff);
            //new ManageControls().AllowDecimalNumbersOnly(creddiff);
            string curyr = System.DateTime.Now.Year.ToString();

            try
            {
                object maxdocno = TBLmovement_tbl.Compute("max( docno )", "yr='" + curyr + "'");
                docno.Text = (Convert.ToInt32(maxdocno) + 1).ToString();
            }
            catch {
                docno.Text = "";
            }

        }

        public void clearScr()
        {

            foreach (Control gb in this.Controls)
            {

                if (gb is Panel )
                {
                    foreach (Control tb in gb.Controls)
                    {
                       
                        if (tb.GetType().ToString() == "System.Windows.Forms.TextBox")
                        {
                            System.Windows.Forms.TextBox tx = (TextBox)tb;
                           
                                tx.Text = "";

                        }

                        //else if (tb.GetType().ToString() == "System.Windows.Forms.MaskedTextBox")
                        //{
                        //    System.Windows.Forms.MaskedTextBox tx = (MaskedTextBox)tb;
                        //    tx.Text = "";

                        //}

                      
                    }
                }
                else if (gb.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    System.Windows.Forms.TextBox tx = (TextBox)gb;

                    tx.Text = "";

                }

            }
            foreach (Control gb in fin.Controls)
            {
                if (gb.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    System.Windows.Forms.TextBox tx = (TextBox)gb;

                    tx.Text = "0.0";


                }
            }

            foreach (Control gb in com.Controls)
            {
                if (gb.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    System.Windows.Forms.TextBox tx = (TextBox)gb;

                    tx.Text = "0.0";


                }
            }
            supcd.Text = "";
            notes.Text = "";

            taxcd.Text = "";
            taxnm.Text = "";
          
        }

        public void enbControls(Boolean boolean) /// true if enabled
        {
            foreach (Control gb in this.Controls)
            {

                if (gb is Panel)
                {
                    foreach (Control tb in gb.Controls)
                    {


                        if (tb.GetType().ToString() == "System.Windows.Forms.TextBox")
                        {
                            System.Windows.Forms.TextBox tx = (TextBox)tb;
                            tx.ReadOnly = !boolean;
                            //if (!docno.ReadOnly)
                            //    if (gb.Name.ToString() == "fin" || gb.Name.ToString() == "com")
                            //    {
                            //        tx.Text = "0.0";
                            //    }

                        }

                        else if (tb.GetType().ToString() == "System.Windows.Forms.ComboBox")
                        {
                            System.Windows.Forms.ComboBox tx = (ComboBox)tb;
                            tx.Enabled = boolean;
                        }

                        else if (tb.GetType().ToString() == "System.Windows.Forms.MaskedTextBox")
                        {
                            System.Windows.Forms.MaskedTextBox tx = (MaskedTextBox)tb;
                            tx.ReadOnly = !boolean;

                        }


                    }



                }
                else if (gb is ComboBox)
                {

                    gb.Enabled = boolean;
                }
                else if (gb is TextBox)
                {
                    System.Windows.Forms.TextBox tx = (TextBox)gb;
                    tx.ReadOnly = !boolean;


                }

                foreach (Control c in otherPan.Controls)
                {
                    if (c.GetType().ToString() == "System.Windows.Forms.TextBox")
                    {
                        System.Windows.Forms.TextBox tx = (TextBox)c;
                        tx.ReadOnly = !boolean;

                    }
                }


            }
            notes.ReadOnly = !boolean;

            //if (!docno.ReadOnly)
            //{
            //    credsum.Text = "0.0";
            //    depsum.Text = "0.0";

            //    depdiff.Text = "0.0";
            //    creddiff.Text = "0.0";
            //}

            //if (movcd.Text == "تجاري")
            //{
            //    doccd.SelectedText = "تسوية";
            //    doccd.Enabled = false;
            //}


            //panbutt_Nav.Visible = !boolean;
            //panSav.Visible = boolean;


        }

        private void FrmMovement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { SendKeys.Send("{Tab}"); }
            if (e.KeyCode == Keys.ShiftKey) { SendKeys.Send("{Tab}"); }
            if (e.KeyCode == Keys.Escape) { this.ActiveControl = docno; }
        }

        private void Lbl_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (lblcd.Text .Contains( "اجور و ما في حكمها"))
            {
                prftcred.Enabled = false;
                prftdep.Enabled = false;
                freejbscred.Enabled = false;
                freejbsdep.Enabled = false;
                otherPan.Visible = false;

                earncred.Enabled = true;
                earndep.Enabled = true;
            }
            else if (lblcd.Text == "أخري")
            {
                otherPan.Visible = true;
                prftcred.Enabled = true;
                prftdep.Enabled = true;
                freejbscred.Enabled = true;
                freejbsdep.Enabled = true;

                earncred.Enabled = false;
                earndep.Enabled = false;
            }

            else
            {
                earncred.Enabled = true;
                earndep.Enabled = true;
                otherPan.Visible = true;
                prftcred.Enabled = true;
                prftdep.Enabled = true;
                freejbscred.Enabled = true;
                freejbsdep.Enabled = true;
            }

           
        }

        private void supcd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                SearchForm search = new SearchForm(TBLsuppliers_da
                              , "supcd", "supnm", 2, 3);
                search.ShowDialog();

                supcd.Text =
                 Static_class.search_output[0];

              

            }
        }

        private void depsum_Validated(object sender, EventArgs e)
        {
            

            if (depsum.Text == "")
            {
                depsum.Text = "0.0";
            }
            //if (taxknd.Text == "أ.ت.ص" && depprft.Enabled)
            //{
            //    depprft.Text = depsum.Text;
            //    // depprft.Focus();
            //}
        }

        private void credsum_Validated(object sender, EventArgs e)
        {
            //if (taxknd.Text == "أ.ت.ص" && credprft.Enabled)
            //{
            //    credprft.Text = credsum.Text;
            //    credprft.Focus();
            //}

            if (credsum.Text == "")
            {
                credsum.Text = "0.0";
            }
        }

        private void depprft_Validated(object sender, EventArgs e)
        {
            //if (taxknd.Text == "أ.ت.ص")
            //{

            //    depdiff.Focus();
            //}
        }

        private void credprft_Validated(object sender, EventArgs e)
        {
        //    if (taxknd.Text == "أ.ت.ص")
        //    {
        //        creddiff.Focus();
        //    }
        }

        private void depfincomb_Validated(object sender, EventArgs e)
        {
            try
            {
                double sum = 0, diff = 0;

                sum = double.Parse(earndep.Text) +
                    double.Parse(fincombdep.Text) +
                    double.Parse(freejbsdep.Text) +
                    double.Parse(prftdep.Text) +
                    double.Parse(stmpdep.Text) + double.Parse(internalTaxdep.Text); ;

                sum = Convert.ToDouble(Math.Round(Convert.ToDecimal(sum), 3));




                diff = sum - double.Parse(depsum.Text);
                depdiff.Text = diff.ToString();
                if (diff != 0)
                {
                    MessageBox.Show("خطا برجاء تصحيح البيان", "خطأ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                    erPrv.SetError(depsum, "خطا برجاء تصحيح البيان");
                    depsum.Focus();
                }
            }
            catch { }
        }

        private void credfincomb_Validated(object sender, EventArgs e)
        {
            double sum = 0, diff = 0;
            //if (mov.Text == "مالي")
            //{
            try
            {
                sum =  double.Parse(earncred.Text) +
                    double.Parse(fincombcred.Text) +
                    double.Parse(freejbscred.Text) +
                    double.Parse(prftcred.Text) +
                    double.Parse(stmpcred.Text)+double.Parse(internalTaxcred.Text);
                sum = Convert.ToDouble( Math.Round(Convert.ToDecimal(sum), 3));
            }
            catch { sum = 0; }


            //}
            // else if (mov.Text == "تجاري")
            //{
            //sum = double.Parse(stmpcheckcred.Text) +
            //double.Parse(stmpconscred.Text) +
            //double.Parse(stmpcontcred.Text) +
            //double.Parse(stmpdmndcred.Text) +
            //double.Parse(stmpkndcred.Text) +
            //double.Parse(stmpnduscred.Text) +
            //double.Parse(stmpsupcred.Text) +
            //double.Parse(suppcomcred.Text);

            // }


            diff = sum - double.Parse(credsum.Text);
            creddiff.Text = diff.ToString();
            if (diff != 0)
            {
                MessageBox.Show("خطا برجاء تصحيح البيان", "خطأ",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                erPrv.SetError(credsum, "خطا برجاء تصحيح البيان");
                credsum.Focus();
            }
        }

        private void suppcomdep_Validated(object sender, EventArgs e)
        {
            double sum = 0, diff = 0;

            try
            {
                sum = double.Parse(stmpcheckdep.Text) +
                   double.Parse(stmpconsdep.Text) +
                   double.Parse(stmpcontdep.Text) +
                   double.Parse(stmpdmnddep.Text) +
                   double.Parse(stmpknddep.Text) +
                   double.Parse(stmpndusdep.Text) +
                   double.Parse(stmpsupdep.Text) +
                   double.Parse(suppcomdep.Text);

                sum = Convert.ToDouble(Math.Round(Convert.ToDecimal(sum), 3));
            }
            catch { sum = 0; }
                diff = sum - double.Parse(depsum.Text);
            
            depdiff.Text = diff.ToString();
            if (diff != 0)
            {
                MessageBox.Show("خطا برجاء تصحيح البيان", "خطأ",
                MessageBoxButtons.OK, MessageBoxIcon.Error);

                erPrv.SetError(depsum, "خطا برجاء تصحيح البيان");
                depsum.Focus();
            }
        }

        private void suppcomcred_Validated(object sender, EventArgs e)
        {
            double sum = 0, diff = 0;
            try
            {
                sum = double.Parse(stmpcheckcred.Text) +
                    double.Parse(stmpconscred.Text) +
                    double.Parse(stmpcontcred.Text) +
                    double.Parse(stmpdmndcred.Text) +
                    double.Parse(stmpkndcred.Text) +
                    double.Parse(stmpnduscred.Text) +
                    double.Parse(stmpsupcred.Text) +
                    double.Parse(suppcomcred.Text);
                sum = Convert.ToDouble(Math.Round(Convert.ToDecimal(sum), 3));

                diff = sum - double.Parse(credsum.Text);
                creddiff.Text = diff.ToString();
            }
            catch { }
            if (diff != 0)
            {
                MessageBox.Show("خطا برجاء تصحيح البيان", "خطأ",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                erPrv.SetError(credsum, "خطا برجاء تصحيح البيان");
                credsum.Focus();
            }
        }

        private void creddiff_Validated(object sender, EventArgs e)
        {
            this.ActiveControl = save;
        }

        private void supcd_TextChanged(object sender, EventArgs e)
        {
            prftdep.Enabled = true;
            prftcred.Enabled = true;
            TBLsuppliers_tbl.Clear();
            TBLsuppliers_da.Fill(TBLsuppliers_tbl);
            int pos = TBLsuppliers_tbl.Rows.IndexOf(TBLsuppliers_tbl.Rows.Find(supcd.Text));
            if (pos > -1)
            {
               
                supnm.Text = TBLsuppliers_tbl.Rows[
                  TBLsuppliers_tbl.Rows.IndexOf(TBLsuppliers_tbl.Rows.Find(supcd.Text))
                  ]["supnm"].ToString();
                taxcd.Text = TBLsuppliers_tbl.Rows[
                    TBLsuppliers_tbl.Rows.IndexOf(TBLsuppliers_tbl.Rows.Find(supcd.Text))
                    ]["taxcd"].ToString();
                try
                {

                    taxnm.Text = taxkd_tbl.Rows[
                        taxkd_tbl.Rows.IndexOf(taxkd_tbl.Rows.Find(taxcd.Text))
                        ]["taxnm"].ToString();

                    if (taxcd.Text == "01")
                    {
                        prftdep.Enabled = false;
                        prftcred.Enabled = false;
                    }
                    
                }
                catch
                {
                    taxnm.Text = "";
                }

            }
            else
            { supnm.Text = ""; }
        }

        private void date_Validated(object sender, EventArgs e)
        {
            try
            {
                yr.Text = mov_date.Text.Substring(6, 4);

                mov_pk[0] = docno.Text; mov_pk[1] = docsubno.Text; mov_pk[2] = mov_date.Text.Substring(6, 4); mov_pk[3] = doccd.SelectedValue.ToString();
                movementPos = TBLmovement_tbl.Rows.IndexOf(TBLmovement_tbl.Rows.Find(mov_pk));

                if (movementPos != -1)
                {
                    add_edt = -1;
                    MessageBox.Show("هذا الملف قد سبق إدخالة من قبل");
                    fillScr();
                    enbControls(false);

                    pansrch.Visible = false;
                    panedt.Visible = true;
                }
            }
            catch {
                MessageBox.Show(" برجاء إدخال التاريخ بطريقة صحيحة ");
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            switch (add_edt)
            {
                case 0:// add
                    {
                        SqlCommand cmd1 = new SqlCommand();
                        cmd1.Connection = Static_class.con;

                        if (Static_class.con.State != ConnectionState.Open) Static_class.con.Open();
                        try
                        {
                            int olddocno = Convert.ToInt32(docno.Text);
                            string qr_hdr = "INSERT INTO [TAXDB].[dbo].[tblMovment]( ";
                            string qr_val = "  VALUES(";

                            foreach (DataColumn dc in TBLmovement_tbl.Columns)
                            {
                                qr_hdr += dc.ColumnName + " , ";

                                 string datatyp = mov_datatyp.Rows[mov_datatyp.Rows.IndexOf(mov_datatyp.Rows.Find(dc.ColumnName))]["DATA_TYPE"].ToString();

                                 Control[] c= this.Controls.Find(dc.ColumnName,true);
                                 if (datatyp == "nvarchar")
                                 {
                                     if (c[0].GetType().ToString() == "System.Windows.Forms.ComboBox")
                                     {
                                         System.Windows.Forms.ComboBox cb = (ComboBox)c[0];


                                         qr_val += " '" + cb.SelectedValue.ToString() + "' , ";
                                     }
                                     else
                                         qr_val += " '" + c[0].Text.Trim() + "' , ";

                                 }
                                 else
                                 {
                                     if (c[0].GetType().ToString() == "System.Windows.Forms.ComboBox")
                                     {
                                         System.Windows.Forms.ComboBox cb = (ComboBox)c[0];


                                         qr_val += cb.SelectedValue.ToString() + " , ";
                                     }
                                     else
                                     qr_val += c[0].Text.Trim() + " , ";
                                 }
                            

                            }

                            qr_hdr = qr_hdr.Substring(0, qr_hdr.Length - 2);
                            qr_hdr += ") ";
                            qr_val=qr_val.Substring(0, qr_val.Length - 2);
                            qr_val += ") ";
                            cmd1.CommandText = qr_hdr + qr_val;
                       
                            cmd1.ExecuteNonQuery();
                         
                            supcd.Text = "";

                            TBLmovement_tbl.Clear();
                            TBLmovement_da.Fill(TBLmovement_tbl);



                            clearScr();

                            docno.Text= (olddocno + 1).ToString();
                            this.ActiveControl = docno;
                        }
                        catch
                        {
                            MessageBox.Show("عذرا:هناك خطأ في الحفظ برجاءالمحاولة مرة اخرى");
                        
                            return;

                        }
                    } break;

                case 1://edt
                    {
                         string message =" تأكيد حفظ التعديل علي الملف رقم   " ;
                         message += docno.Text;
                        
                        message += "؟";

                        MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                        DialogResult result;
                        result = MessageBox.Show(message, "رسالة تحذيرية ", buttons, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {

                            SqlCommand cmd1 = new SqlCommand();
                            cmd1.Connection = Static_class.con;

                            if (Static_class.con.State != ConnectionState.Open) Static_class.con.Open();
                            try
                            {
                                string qr_hdr = " update [TAXDB].[dbo].[tblMovment] set  ";
                                string qr_val = "  where  ";

                                foreach (DataColumn dc in TBLmovement_tbl.Columns)
                                {
                                    qr_hdr += dc.ColumnName + " =  ";

                                    string datatyp = mov_datatyp.Rows[mov_datatyp.Rows.IndexOf(mov_datatyp.Rows.Find(dc.ColumnName))]["DATA_TYPE"].ToString();

                                    Control[] c = this.Controls.Find(dc.ColumnName, true);
                                    if (datatyp == "nvarchar")
                                    {
                                        if (c[0].GetType().ToString() == "System.Windows.Forms.ComboBox")
                                        {
                                            System.Windows.Forms.ComboBox cb = (ComboBox)c[0];


                                            qr_hdr += " '" + cb.SelectedValue.ToString() + "' , ";
                                        }
                                        else
                                            qr_hdr += " '" + c[0].Text + "' , ";

                                    }
                                    else
                                    {
                                        if (c[0].GetType().ToString() == "System.Windows.Forms.ComboBox")
                                        {
                                            System.Windows.Forms.ComboBox cb = (ComboBox)c[0];


                                            qr_hdr += cb.SelectedValue.ToString() + " , ";
                                        }
                                        else
                                            qr_hdr += c[0].Text + " , ";
                                    }


                                }

                                qr_hdr = qr_hdr.Substring(0, qr_hdr.Length - 2);

                                qr_val += " docno= '" + docno.Text + "' and  yr=" + yr.Text + "  and docsubno='" + docsubno.Text + "' and doccd='" + doccd .SelectedValue .ToString () + "'";


                                cmd1.CommandText = qr_hdr + qr_val;

                                cmd1.ExecuteNonQuery();

                                supcd.Text = "";

                                TBLmovement_tbl.Clear();
                                TBLmovement_da.Fill(TBLmovement_tbl);




                                back_Click(null, null);
                            }
                            catch
                            {
                                MessageBox.Show("عذرا:هناك خطأ في الحفظ برجاءالمحاولة مرة اخرى");

                                return;

                            }

                        }
                      
                    } break;
            }
        }

        private void credprft_TextChanged(object sender, EventArgs e)
        {

        }

        public void fillScr()
        {
            foreach (Control gb in this.Controls)
            {
                if (gb.GetType().ToString() == "System.Windows.Forms.ComboBox")
                {
                    System.Windows.Forms.ComboBox cb = (ComboBox)gb;

                    cb.SelectedValue = TBLmovement_tbl.Rows[movementPos][cb.Name].ToString();

                }
                else if (gb.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    System.Windows.Forms.TextBox tx = (TextBox)gb;

                    tx.Text = TBLmovement_tbl.Rows[movementPos][tx.Name].ToString();


                }


            }

            foreach (Control gb in Fin_doc.Controls)
            {
                if (gb.GetType().ToString() == "System.Windows.Forms.ComboBox")
                {
                    System.Windows.Forms.ComboBox cb = (ComboBox)gb;

                    cb.SelectedValue = TBLmovement_tbl.Rows[movementPos][cb.Name].ToString();

                }
                else if (gb.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    System.Windows.Forms.TextBox tx = (TextBox)gb;

                    tx.Text = TBLmovement_tbl.Rows[movementPos][tx.Name].ToString();


                }
                else if (gb.GetType().ToString() == "System.Windows.Forms.MaskedTextBox")
                {
                    System.Windows.Forms.MaskedTextBox tx = (MaskedTextBox)gb;

                    tx.Text = TBLmovement_tbl.Rows[movementPos][tx.Name].ToString();


                }

            }



            foreach (Control gb in fin.Controls)
            {
                if (gb.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    System.Windows.Forms.TextBox tx = (TextBox)gb;

                    tx.Text = TBLmovement_tbl.Rows[movementPos][tx.Name].ToString();


                }
            }

            foreach (Control gb in com.Controls)
            {
                if (gb.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    System.Windows.Forms.TextBox tx = (TextBox)gb;

                    tx.Text = TBLmovement_tbl.Rows[movementPos][tx.Name].ToString();


                }
            }
                
           supcd.Text = TBLmovement_tbl.Rows[movementPos]["supcd"].ToString();

           notes.Text = TBLmovement_tbl.Rows[movementPos]["notes"].ToString();
                




             
        }

        private void useredit_Click(object sender, EventArgs e)
        {
            add_edt = 1;
            enbControls(true);


            docno.ReadOnly = true;
            docsubno.ReadOnly = true;
            mov_date.ReadOnly = true;
            

        }

        private void userdelete_Click(object sender, EventArgs e)
        {
            string message =" تأكيد حذف الملف رقم   " ;
            message += docno.Text;
            
            message += "؟";

            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, "رسالة تحذيرية ", buttons, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                 SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = Static_class.con;

                    if (Static_class.con.State != ConnectionState.Open) Static_class.con.Open();
                    try
                    {
                        cmd1.CommandText = " delete from  [TAXDB].[dbo].[tblMovment] where docno='" + docno.Text + "' and  [docsubno]='" + docsubno.Text + "'  and yr=" + yr.Text + " and doccd='"+doccd.SelectedValue.ToString()+"'";
                        cmd1.ExecuteNonQuery();

                        
                        supcd.Text = "";

                        TBLmovement_tbl.Clear();
                        TBLmovement_da.Fill(TBLmovement_tbl);


                        MessageBox.Show("قد تم الحذف بنجاح");
                        back_Click(null, null);

                        this.ActiveControl = docno;
                    }
                    catch 
                    {
                        MessageBox.Show("عذرا:هناك خطأ في الحذف برجاءالمحاولة مرة اخرى");

                                return;

                    }
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            movementPos = -1;
            add_edt = 0;
            clearScr(); 
            enbControls(true);

            pansrch.Visible = true;
            panedt.Visible = false;

            this.ActiveControl = docno;


        }

        private void userfind_Click(object sender, EventArgs e)
        {
            string qr = "";



            foreach (Control gb in this.Controls)
            {
                if (gb.GetType().ToString() == "System.Windows.Forms.ComboBox")
                {
                    System.Windows.Forms.ComboBox cb = (ComboBox)gb;

                    qr = qr + "dbo.tblMovment." + cb.Name + " =  " + cb.SelectedValue.ToString() + " and ";

                }
                else if (gb.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    System.Windows.Forms.TextBox tx = (TextBox)gb;
                    if (tx.Text!="" && tx.Text!="0.0")
                        qr = qr + "dbo.tblMovment." + tx.Name + " = " + tx.Text + " and ";


                }

            }

            foreach (Control gb in Fin_doc.Controls)
            {
                if (gb.GetType().ToString() == "System.Windows.Forms.ComboBox")
                {
                    System.Windows.Forms.ComboBox cb = (ComboBox)gb;

                    qr = qr + "dbo.tblMovment." + cb.Name + " =  " + cb.SelectedValue.ToString() + " and ";

                }
                else if (gb.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    System.Windows.Forms.TextBox tx = (TextBox)gb;

                    if (tx.Text != "" )
                        qr = qr + "dbo.tblMovment." + tx.Name + " = '" + tx.Text + "'" + " and "; 

                }
                else if (gb.GetType().ToString() == "System.Windows.Forms.MaskedTextBox")
                {
                    System.Windows.Forms.MaskedTextBox tx = (MaskedTextBox)gb;

                    if (tx.Text != "  /  /")
                        qr = qr + "dbo.tblMovment." + tx.Name + " = '" + tx.Text + "'" + " and ";



                }

            }



            foreach (Control gb in fin.Controls)
            {
                if (gb.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    System.Windows.Forms.TextBox tx = (TextBox)gb;

                    if (tx.Text != "" && tx.Text != "0.0")
                        qr = qr + "dbo.tblMovment." + tx.Name + " = " + tx.Text + " and ";



                }
            }

            foreach (Control gb in com.Controls)
            {
                if (gb.GetType().ToString() == "System.Windows.Forms.TextBox")
                {
                    System.Windows.Forms.TextBox tx = (TextBox)gb;

                    if (tx.Text != "" && tx.Text != "0.0")
                        qr = qr + "dbo.tblMovment." + tx.Name + " = " + tx.Text + " and ";



                }
            }

            if(supcd.Text!="")
                qr =qr+ " dbo.tblMovment.supcd = " + supcd.Text+" and ";


            qr = qr.Substring(0, qr.Length - 4);



            SqlDataAdapter da_srch = new SqlDataAdapter(
            @" SELECT        dbo.tblMovment.docno, dbo.tblMovment.docsubno, dbo.tblMovment.yr, dbo.TBLmovtyp.movnm AS movcd, dbo.tblMovment.doccd, dbo.TBLdoctyp.docnm, dbo.tblMovment.mov_date, dbo.tblMovment.credsum, 
            dbo.TBLsuppliers.supnm
            FROM            dbo.tblMovment LEFT OUTER JOIN
            dbo.TBLsuppliers ON dbo.tblMovment.supcd = dbo.TBLsuppliers.supcd LEFT OUTER JOIN
            dbo.TBLmovtyp ON dbo.tblMovment.movcd = dbo.TBLmovtyp.movcd LEFT OUTER JOIN
            dbo.TBLdoctyp ON dbo.tblMovment.doccd = dbo.TBLdoctyp.doccd 

            where " + qr, Static_class.con);
            DataTable dt_srch = new DataTable();
            da_srch.Fill(dt_srch);

            frmMovSrch srch = new frmMovSrch(dt_srch);
            srch.ShowDialog();
            try
            {
                movementPos = TBLmovement_tbl.Rows.IndexOf(TBLmovement_tbl.Rows.Find(srch.pk));
                if (movementPos != -1)
                {
                    add_edt = -1;

                    fillScr();
                    enbControls(false);

                    pansrch.Visible = false;
                    panedt.Visible = true;
                }
            }
            catch { }

        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void movcd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (movcd.Text == "مالي")
            {
                fin.Visible = true;
                com.Visible = false;

                supcd.Visible = true;
                supcdlbl.Visible = true;
                supnm.Visible = true;
                taxnm.Visible = true;
                //supnmlbl.Visible = true;
                taxcd.Visible = true;
                label14.Visible = true;
            }
            else if (movcd.Text == "تجاري")
            {

                //  doctyp.SelectedText = "تسوية";
                fin.Visible = false;
                com.Visible = true;

                supcd.Visible = false;
                supcdlbl.Visible = false;
                supnm.Visible = false;
                taxcd.Visible = false;
                taxnm.Visible = false;
                label14.Visible = false;
                lblcd.SelectedValue = '2';
                lblcd.Enabled = false;
            }

            if (!docno.ReadOnly)
                enbControls(true);
        }

        private void credsum_Enter(object sender, EventArgs e)
        {
            credsum.SelectAll();
        }

        private void depsum_Enter(object sender, EventArgs e)
        {
            depsum.SelectAll();
        }

        private void stmpcred_Enter(object sender, EventArgs e)
        {
            stmpcred.SelectAll();
        }

        private void earncred_Enter(object sender, EventArgs e)
        {
            earncred.SelectAll();
        }

        private void prftcred_Enter(object sender, EventArgs e)
        {
            prftcred.SelectAll();

        }

        private void freejbscred_Enter(object sender, EventArgs e)
        {
            freejbscred.SelectAll();
        }

        private void fincombcred_Enter(object sender, EventArgs e)
        {
            fincombcred.SelectAll();
        }

        private void stmpdep_Enter(object sender, EventArgs e)
        {
            stmpdep.SelectAll();
        }

        private void earndep_Enter(object sender, EventArgs e)
        {
            earndep.SelectAll();
        }

        private void prftdep_Enter(object sender, EventArgs e)
        {
            prftdep.SelectAll();
        }

        private void freejbsdep_Enter(object sender, EventArgs e)
        {
            freejbsdep.SelectAll();
        }

        private void fincombdep_Enter(object sender, EventArgs e)
        {
            fincombdep.SelectAll();
        }

        private void prftdep_TextChanged(object sender, EventArgs e)
        {

        }

        private void suppcomcred_TextChanged(object sender, EventArgs e)
        {

        }

        private void movcd_Validated(object sender, EventArgs e)
        {

        }

        private void btn_viewTotal_Click(object sender, EventArgs e)
        {
            if (mov_date.Text == "  /  /")
            {
                MessageBox.Show("تارخ خاطئ");
                return;
            }
            DateTime  cur_date = Convert.ToDateTime(mov_date.Text);
            string mn = mov_date.Text.Substring(3,2);
            int yr = cur_date.Year;

            string qry = @"SELECT        yr,MONTH(move_date) as mn, SUM(stmpknddep) AS stmpknddep, SUM(stmpndusdep) AS stmpndusdep, SUM(stmpcheckdep) AS stmpcheckdep, SUM(stmpconsdep) AS stmpconsdep, SUM(stmpsupdep) AS stmpsupdep, SUM(stmpcontdep) 
            AS stmpcontdep, SUM(suppcomdep) AS suppcomdep, SUM(internalTaxdep) AS internalTaxdep, SUM(depsum) AS depsum, SUM(depdiff) AS depdiff, SUM(stmpcred) AS stmpcred, SUM(earncred) AS earncred, SUM(prftcred) 
            AS prftcred, SUM(freejbscred) AS freejbscred, SUM(fincombcred) AS fincombcred, SUM(stmpdmndcred) AS stmpdmndcred, SUM(stmpkndcred) AS stmpkndcred, SUM(stmpnduscred) AS stmpnduscred, SUM(stmpcheckcred) 
            AS stmpcheckcred, SUM(stmpconscred) AS stmpconscred, SUM(stmpsupcred) AS stmpsupcred, SUM(stmpcontcred) AS stmpcontcred, SUM(suppcomcred) AS suppcomcred, SUM(internalTaxcred) AS internalTaxcred, 
            SUM(credsum) AS credsum, SUM(creddiff) AS creddiff, MONTH(move_date) AS month, SUM(stmpdep) AS stmpdep, SUM(earndep) AS earndep, SUM(prftdep) AS prftdep, SUM(freejbsdep) AS freejbsdep, SUM(fincombdep) 
            AS fincombdep, SUM(stmpdmnddep) AS stmpdmnddep
            FROM            dbo.tblMovment
            GROUP BY yr, MONTH(move_date)
            HAVING        (yr = "+yr.ToString()+@") AND (MONTH(move_date) = "+mn.ToString()+")";


            SqlDataAdapter da = new SqlDataAdapter(qry, Static_class.con);


            DataTable dt = new DataTable();

            da.Fill(dt);

            DataTable dt_res = new DataTable();

            if (movcd.Text == "مالي")
            {
              //fin
                foreach (Control gb in fin.Controls)
                {
                    if (gb.GetType().ToString() == "System.Windows.Forms.TextBox")
                    {
                        System.Windows.Forms.TextBox tx = (TextBox)gb;

                        dt_res.Columns.Add(tx.Name, typeof(decimal));

                    }
                }
                DataRow dr = dt_res.NewRow(); 
                foreach (DataColumn dc in dt_res.Columns)
                {
                    dr[dc.ColumnName] = dt.Rows[0][dc.ColumnName];

                }
                dt_res.Rows.Add(dr);

                frmViewTotal frm = new frmViewTotal(dt_res,1,"  إجمالي  "+ mov_date.Text);
                frm.ShowDialog();
            }
            else if (movcd.Text == "تجاري")
            {
               
              // com


                foreach (Control gb in com.Controls)
                {
                    if (gb.GetType().ToString() == "System.Windows.Forms.TextBox")
                    {
                        System.Windows.Forms.TextBox tx = (TextBox)gb;

                        dt_res.Columns.Add(tx.Name, typeof(decimal));

                    }
                }
                DataRow dr = dt_res.NewRow();
                foreach (DataColumn dc in dt_res.Columns)
                {
                    dr[dc.ColumnName] = dt.Rows[0][dc.ColumnName];

                }
                dt_res.Rows.Add(dr);

                frmViewTotal frm = new frmViewTotal(dt_res, 0, "  إجمالي  " + mov_date.Text);
                frm.ShowDialog();
            }
        }

        private void lblcd_Leave(object sender, EventArgs e)
        {
            if(supcd.Visible==true)
                this.ActiveControl = supcd;
        }

        private void taxnm_Leave(object sender, EventArgs e)
        {
            
        }

        private void supcd_Leave(object sender, EventArgs e)
        {
            this.ActiveControl = notes;
        }

        
    }
}
