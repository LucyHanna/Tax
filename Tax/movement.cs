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
    public partial class movement : Form
    {
        public movement()
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

        public SqlDataAdapter TBLmovdet_da = new SqlDataAdapter(" SELECT     docno, docsubno, supcd, stdis, movcd, doccd, date, lblcd, stmpdep, earndep, prftdep, freejbsdep, fincombdep, stmpdmnddep, stmpknddep,"+ 
                      " stmpndusdep, stmpcheckdep, stmpconsdep, stmpsupdep, stmpcontdep, suppcomdep, depsum, depdiff, stmpcred, earncred, prftcred, freejbscred, "+
                      " fincombcred, stmpdmndcred, stmpkndcred, stmpnduscred,stmpcheckcred, stmpconscred, stmpsupcred, stmpcontcred, suppcomcred, credsum, creddiff  FROM         TBLmovdet", Static_class.con);
        public DataTable TBLmovdet_tbl = new DataTable();

        public SqlDataAdapter TBLmovheader_da = new SqlDataAdapter("select   docno, docsubno, supcd,docno, movcd, doccd, typcd, date, lblcd, depsum, depdiff, credsum, creddiff from TBLmovheader", Static_class.con);
        public DataTable TBLmovheader_tbl = new DataTable();

    //
 
        public SqlDataAdapter taxkd_da = new SqlDataAdapter("SELECT     taxcd, taxnm  FROM         taxkd", Static_class.con);
        public DataTable taxkd_tbl = new DataTable();
        
        string [] hdPk=new string[2];

        DataSet ds = new DataSet();
        ErrorProvider erPrv = new ErrorProvider();
        //public SqlCommandBuilder  CB_hed;
        //public SqlCommandBuilder CB_det;
        int add_ed_del = 0;//1=add  2=ed  3=del

        int position = -1;

        private void movement_Load(object sender, EventArgs e)
        {
            
            
            TBLdocTyp_da.Fill(ds,"TBLdocTyp_tbl");
            TBLLabel_da.Fill(ds,"TBlLabel_tbl");
            TBLmovdet_da.Fill(ds, "TBLmovdet_tbl");
            TBLmovheader_da.Fill(ds, "TBLmovheader_tbl");
            TBLMovTyp_da.Fill(ds, "TBLMovTyp_tbl");
            TBLsuppliers_da.Fill(TBLsuppliers_tbl);
            TBLsites_da.Fill(TBLsites_tbl);
            taxkd_da.Fill(taxkd_tbl);

            TBLTyp_da.Fill(ds, "TBLTyp_tbl");


            DataColumn[] dpk = new DataColumn[1];
            dpk[0] = TBLsuppliers_tbl.Columns[0];
             TBLsuppliers_tbl.PrimaryKey = dpk;



             DataColumn[] dpkst = new DataColumn[1];
             dpkst[0] = TBLsites_tbl.Columns[0];
             TBLsites_tbl.PrimaryKey = dpkst;


            DataColumn[] dpkmov = new DataColumn[2];
            dpkmov[0] = ds.Tables["TBLmovdet_tbl"].Columns[0];
            dpkmov[1] = ds.Tables["TBLmovdet_tbl"].Columns[1];
            ds.Tables["TBLmovdet_tbl"].PrimaryKey = dpkmov;

            DataColumn[] dpkmov2 = new DataColumn[2];
            dpkmov2[0] = ds.Tables["TBLmovheader_tbl"].Columns[0];
            dpkmov2[1] = ds.Tables["TBLmovheader_tbl"].Columns[1];
            ds.Tables["TBLmovheader_tbl"].PrimaryKey = dpkmov2;


            sts.DataSource = TBLsites_tbl;
            sts.DisplayMember = "stnm";
            sts.ValueMember = "stcd";


            taxknd.DataSource = taxkd_tbl;
            taxknd.DisplayMember = "taxnm";
            taxknd.ValueMember = "taxcd";


            doctyp.DataBindings.Add("selectedvalue", ds, "TBLmovheader_tbl.doccd");
            doctyp.DataSource = ds;
            doctyp.DisplayMember = "TBLdocTyp_tbl.docnm";
            doctyp.ValueMember = "TBLdocTyp_tbl.doccd";


            typ.DataBindings.Add("selectedvalue", ds, "TBLmovheader_tbl.typcd");
            typ.DataSource = ds;
            typ.DisplayMember = "TBLTyp_tbl.typnm";
            typ.ValueMember = "TBLTyp_tbl.typcd";


            mov.DataBindings.Add("selectedvalue", ds, "TBLmovheader_tbl.movcd");
            mov.DataSource = ds;
            mov.DisplayMember = "TBLMovTyp_tbl.movnm";
            mov.ValueMember = "TBLMovTyp_tbl.movcd";



            Lbl.DataBindings.Add("selectedvalue", ds, "TBLmovdet_tbl.lblcd");
            Lbl.DataSource = ds;
            Lbl.DisplayMember = "TBlLabel_tbl.lblnm";
            Lbl.ValueMember = "TBlLabel_tbl.lblcd";


            docno.DataBindings.Add("Text", ds, "TBLmovheader_tbl.docno");
            subdocno.DataBindings.Add("Text", ds, "TBLmovdet_tbl.docsubno");

            date.DataBindings.Add("Text",ds , "TBLmovdet_tbl.date");

         

            depearn.DataBindings.Add("Text", ds, "TBLmovdet_tbl.earndep");
                
            depfincomb.DataBindings.Add("Text", ds, "TBLmovdet_tbl.fincombdep");
             
            depfreejbs.DataBindings.Add("Text", ds, "TBLmovdet_tbl.freejbsdep");
              
            depprft.DataBindings.Add("Text", ds, "TBLmovdet_tbl.prftdep");
            depstmp.DataBindings.Add("Text", ds, "TBLmovdet_tbl.stmpdep");
            depsum.DataBindings.Add("Text", ds, "TBLmovdet_tbl.depsum");
               



            credearn.DataBindings.Add("Text", ds, "TBLmovdet_tbl.earncred");

            credfincomb.DataBindings.Add("Text", ds, "TBLmovdet_tbl.fincombcred");

            credfreejbs.DataBindings.Add("Text", ds, "TBLmovdet_tbl.freejbscred");
            credprft.DataBindings.Add("Text", ds, "TBLmovdet_tbl.prftcred");
            credstmp.DataBindings.Add("Text", ds, "TBLmovdet_tbl.stmpcred");
            credsum.DataBindings.Add("Text", ds, "TBLmovdet_tbl.credsum");

            depdiff.DataBindings.Add("Text", ds, "TBLmovdet_tbl.depdiff");
            creddiff.DataBindings.Add("Text", ds, "TBLmovdet_tbl.creddiff");

            supcd.DataBindings.Add("Text", ds, "TBLmovdet_tbl.supcd");


            suppcomcred.DataBindings.Add("Text", ds, "TBLmovdet_tbl.suppcomcred");
            suppcomdep.DataBindings.Add("Text", ds, "TBLmovdet_tbl.suppcomdep");

            stmpcheckcred.DataBindings.Add("Text", ds, "TBLmovdet_tbl.stmpcheckcred");
            stmpcheckdep.DataBindings.Add("Text", ds, "TBLmovdet_tbl.stmpcheckdep");


            stmpconscred.DataBindings.Add("Text", ds, "TBLmovdet_tbl.stmpconscred");
            stmpconsdep.DataBindings.Add("Text", ds, "TBLmovdet_tbl.stmpconsdep");

            stmpcontcred.DataBindings.Add("Text", ds, "TBLmovdet_tbl.stmpcontcred");
            stmpcontdep.DataBindings.Add("Text", ds, "TBLmovdet_tbl.stmpcontdep");



            stmpdmndcred.DataBindings.Add("Text", ds, "TBLmovdet_tbl.stmpdmndcred");
            stmpdmnddep.DataBindings.Add("Text", ds, "TBLmovdet_tbl.stmpdmnddep");

            stmpkndcred.DataBindings.Add("Text", ds, "TBLmovdet_tbl.stmpkndcred");
            stmpknddep.DataBindings.Add("Text", ds, "TBLmovdet_tbl.stmpknddep");


            stmpnduscred.DataBindings.Add("Text", ds, "TBLmovdet_tbl.stmpnduscred");
            stmpndusdep.DataBindings.Add("Text", ds, "TBLmovdet_tbl.stmpndusdep");

            stmpsupcred.DataBindings.Add("Text", ds, "TBLmovdet_tbl.stmpsupcred");
            stmpsupdep.DataBindings.Add("Text", ds, "TBLmovdet_tbl.stmpsupdep");



            if (Lbl.Text == "اجور و ما في احكمها")
            {
                credprft.Enabled = false;
                depprft.Enabled = false;
                credfreejbs.Enabled = false;
                depfreejbs.Enabled = false;
            }

            else 
            {
                credprft.Enabled = true;
                depprft.Enabled = true;
                credfreejbs.Enabled = true;
                depfreejbs.Enabled = true;
            }


            

        }

     

        public void designPanel(String x)
        {
            if (x == "1")
            {
 
            }
        }

        private void docno_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Lbl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Lbl.Text == "اجور و ما في احكمها")
            {
                credprft.Enabled = false;
                depprft.Enabled = false;
                credfreejbs.Enabled = false;
                depfreejbs.Enabled = false;
                otherPan.Visible = false;
            }

            else
            {
                otherPan.Visible = true;
                credprft.Enabled = true;
                depprft.Enabled = true;
                credfreejbs.Enabled = true;
                depfreejbs.Enabled = true;
            }
        }

        public void setDetPos()
        {
            int pos = TBLmovdet_tbl.Rows.IndexOf(TBLmovdet_tbl.Rows.Find(hdPk));
            if (pos !=-1)
            {
                depearn.Text = TBLmovdet_tbl.Rows[pos]["earndep"].ToString();
                depfincomb.Text = TBLmovdet_tbl.Rows[pos]["fincombdep"].ToString();
                depfreejbs.Text = TBLmovdet_tbl.Rows[pos]["freejbsdep"].ToString();
                depprft.Text = TBLmovdet_tbl.Rows[pos]["prftdep"].ToString();
                depstmp.Text = TBLmovdet_tbl.Rows[pos]["stmpdep"].ToString();
                depsum.Text = TBLmovdet_tbl.Rows[pos]["depsum"].ToString();



                credearn.Text = TBLmovdet_tbl.Rows[pos]["earncred"].ToString();
                credfincomb.Text = TBLmovdet_tbl.Rows[pos]["fincombcred"].ToString();
                credfreejbs.Text = TBLmovdet_tbl.Rows[pos]["freejbscred"].ToString();
                credprft.Text = TBLmovdet_tbl.Rows[pos]["prftcred"].ToString();
                credstmp.Text = TBLmovdet_tbl.Rows[pos]["stmpcred"].ToString();
                credsum.Text = TBLmovdet_tbl.Rows[pos]["credsum"].ToString();
            }
            else
            {
                depearn.Text = " ";
                depfincomb.Text = " ";
                depfreejbs.Text = " ";
                depprft.Text = " ";
                depstmp.Text = " ";
                depsum.Text = " ";



                credearn.Text = " ";
                credfincomb.Text = " ";
                credfreejbs.Text = " ";
                credprft.Text = " ";
                credstmp.Text = " ";
                credsum.Text = " ";
            }

        }


        public void enbControls(Boolean boolean) /// true if enabled
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
                            tx.ReadOnly = !boolean;
                            if(!docno.ReadOnly)
                            if (gb.Name.ToString() == "fin" || gb.Name.ToString() == "com")
                            {
                                tx.Text = "0.0";
                            }

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
                else   if (gb is ComboBox) 
                {

                    gb.Enabled = boolean;
                }
                else if (gb is TextBox)
                {
                    System.Windows.Forms.TextBox tx = (TextBox)gb;
                    tx.ReadOnly = !boolean;


                }

            }

            if (!docno.ReadOnly)
            {
                credsum.Text = "0.0";
                depsum.Text = "0.0";
                    
                depdiff.Text = "0.0";
                creddiff.Text = "0.0";
            }

            if (mov.Text == "تجاري")
            {
                doctyp.SelectedText = "تسوية";
                doctyp.Enabled = false;
            }


            panbutt_Nav.Visible = !boolean;
            panSav.Visible = boolean;

            
        }

        private void useradd_Click(object sender, EventArgs e)
        {
            add_ed_del = 1;
           
            this.BindingContext[ds, "TBLmovheader_tbl"].AddNew();
            this.BindingContext[ds, "TBLmovdet_tbl"].AddNew();
            enbControls(true);
            taxknd.Enabled = false;
            mov.SelectedIndex = 0;
            mov.Focus();
        }

        private void useredit_Click(object sender, EventArgs e)
        {
            add_ed_del = 2;
            enbControls(true);
            taxknd.Enabled = false;
            docno.ReadOnly = true;
            subdocno.ReadOnly = true;
          
            depsum.Focus();
        }

        private void userdelete_Click(object sender, EventArgs e)
        {
            string message = " هل تريد حذف المستند  "+docno.Text+"?";
                 
			MessageBoxButtons buttons = MessageBoxButtons.YesNo;
			DialogResult result;

			// Displays the MessageBox.

            result = MessageBox.Show(message, "رسالة تحذيرية ", buttons, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = Static_class.con;
                
                if (Static_class.con.State != ConnectionState.Open) Static_class.con.Open();
                cmd1.CommandText = "delete from  TBLmovheader where  docno=" + docno.Text + " and  docsubno=" + subdocno.Text;
                int x=cmd1.ExecuteNonQuery();
                if (x > 0)
                {
                   
                    cmd1.CommandText = "delete from  TBLmovdet where  docno=" + docno.Text + " and  docsubno=" + subdocno.Text;
                   x= cmd1.ExecuteNonQuery();
                }
                if (x > 0)
                {
                    MessageBox.Show("لقد تم الحذف ");
                    ds.Tables["TBLmovheader_tbl"].Rows.RemoveAt(position);
                    ds.Tables["TBLmovdet_tbl"].Rows.RemoveAt(position);
                    ds.Tables["TBLmovheader_tbl"].AcceptChanges();
                    ds.Tables["TBLmovdet_tbl"].AcceptChanges();
                    //TBLmovdet_da.Fill(ds, "TBLmovdet_tbl");
                    //TBLmovheader_da.Fill(ds, "TBLmovheader_tbl");

                }
                else
                    MessageBox.Show("هناك خطأ : لم يتم الحذف  ");



            }

        }

        private void userfind_Click(object sender, EventArgs e)
        {


        //    SearchForm search = new SearchForm(TBLmovheader_tbl
        //        , "supcd", "supnm", 2, 3);
        //    search.ShowDialog();

        //    this.BindingContext[TBLsuppliers_Table].Position =
        //    TBLsuppliers_Table.Rows.IndexOf(TBLsuppliers_Table.Rows.Find(Static_class.search_output[0]));
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void prv_Click(object sender, EventArgs e)
        {
            this.BindingContext[ds,"TBLmovheader_tbl"].Position -= 1;
            this.BindingContext[ds, "TBLmovdet_tbl"].Position -= 1;
            position = this.BindingContext[ds, "TBLmovdet_tbl"].Position;
           
        }

        private void nxt_Click(object sender, EventArgs e)
        {
            this.BindingContext[ds, "TBLmovheader_tbl"].Position += 1;
            this.BindingContext[ds, "TBLmovdet_tbl"].Position += 1;

            position = this.BindingContext[ds, "TBLmovdet_tbl"].Position;

           
        }

        private void frst_Click(object sender, EventArgs e)
        {
            this.BindingContext[ds, "TBLmovheader_tbl"].Position = 0;
            this.BindingContext[ds, "TBLmovdet_tbl"].Position = 0;
            position = 0;

        }

        private void lst_Click(object sender, EventArgs e)
        {
            this.BindingContext[ds, "TBLmovheader_tbl"].Position = this.BindingContext[ds,"TBLmovheader_tbl"].Count - 1;
            this.BindingContext[ds, "TBLmovdet_tbl"].Position = this.BindingContext[ds,"TBLmovdet_tbl"].Count - 1;
            position = this.BindingContext[ds, "TBLmovdet_tbl"].Count - 1;
        }

        private void movement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { SendKeys.Send("{Tab}");  }
            if (e.KeyCode == Keys.ShiftKey) { SendKeys.Send("{Tab}"); }
           
        }

        private void back_Click(object sender, EventArgs e)
        {
            add_ed_del = 0;
            this.BindingContext[ds, "TBLmovdet_tbl"].CancelCurrentEdit();
            this.BindingContext[ds, "TBLmovheader_tbl"].CancelCurrentEdit();
        
            enbControls(false);
        }

        private void save_Click(object sender, EventArgs e)
        {
           


            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = Static_class.con;
            string dt = date.Text;
            if (Static_class.con.State != ConnectionState.Open) Static_class.con.Open();

            cmd1.Transaction = Static_class.con.BeginTransaction();
            switch (add_ed_del)
            {
                case 1://adding
                    {
                        
                        cmd1.CommandText = "INSERT INTO TBLmovheader (docno, docsubno, supcd, movcd, " +
                            "doccd, typcd,date, lblcd, depsum, depdiff, credsum, creddiff)" +
                       "VALUES (" + docno.Text + ",'" + subdocno.Text + "','" + supcd.Text +
                       "', " + mov.SelectedValue.ToString() + "," +
                       doctyp.SelectedValue.ToString() +","+
                        typ.SelectedValue.ToString() +
                       ",'" + date.Text + "'" +
                       "," + Lbl.SelectedValue.ToString() +
                       "," + depsum.Text +
                        "," + depdiff.Text +
                       "," + credsum.Text +
                       "," + creddiff.Text +
                      ")";
                        cmd1.ExecuteNonQuery();

                        //string stcd = TBLsuppliers_tbl.Rows[TBLsuppliers_tbl.Rows.IndexOf(TBLsuppliers_tbl.Rows.Find(supcd.Text))]["stcd"].ToString();
                        //.Rows.IndexOf(TBLsuppliers_tbl.Rows.Find(supcd.Text));
                        
                        //string stdis ;
                        //try
                        //{
                        //    stdis = TBLsites_tbl.Rows[TBLsites_tbl.Rows.IndexOf(TBLsites_tbl.Rows.Find(stcd))]["stdis"].ToString();
                        //}
                        //catch (Exception) { stdis = "0"; }
                        cmd1.CommandText = " INSERT INTO TBLmovdet(docno, docsubno, supcd,  movcd, doccd," +
                            " date, lblcd, stmpdep, earndep, prftdep, freejbsdep, fincombdep," +
                            " stmpdmnddep, stmpknddep," +

                      " stmpndusdep, stmpcheckdep, stmpconsdep, stmpsupdep, stmpcontdep," +
                      " suppcomdep, depsum, depdiff, stmpcred, earncred, prftcred," +
                      " freejbscred, " +
                      " fincombcred, stmpdmndcred, stmpkndcred, stmpnduscred,stmpcheckcred," +
                      " stmpconscred, stmpsupcred, stmpcontcred, suppcomcred, credsum" +
                      ", creddiff ) " +
                       "VALUES (" + docno.Text + ",'" + subdocno.Text + "','" + supcd.Text + 
                       "', " + mov.SelectedValue.ToString() + "," +
                       doctyp.SelectedValue.ToString() +
                       ",'" + date.Text + "'" +
                       "," + Lbl.SelectedValue.ToString() +
                       "," + depstmp.Text +
                       "," + depearn.Text +
                       "," + depprft.Text +
                        "," + depfreejbs.Text +
                       "," + depfincomb.Text +
                       "," + stmpdmnddep.Text +

                        "," + stmpknddep.Text +
                       "," + stmpndusdep.Text +
                       "," + stmpcheckdep.Text +
                        "," + stmpconsdep.Text +
                       "," + stmpsupdep.Text +
                       "," + stmpcontdep.Text +

                       "," + suppcomdep.Text +
                       "," + depsum.Text +
                       "," + depdiff.Text +
                        "," + credstmp.Text +
                       "," + credearn.Text +
                       "," + credprft.Text +

                       "," + credfreejbs.Text +
                       "," + credfincomb.Text +
                       "," + stmpdmndcred.Text +

                        "," + stmpkndcred.Text +
                       "," + stmpnduscred.Text +
                       "," + stmpcheckcred.Text +
                        "," + stmpconscred.Text +
                       "," + stmpsupcred.Text +
                       "," + stmpcontcred.Text +

                       "," + suppcomcred.Text +
                       "," + credsum.Text +
                       "," + creddiff.Text +

                      ")";
                        cmd1.ExecuteNonQuery();


                    } break;

                case 2://ed
                    {
                        cmd1.CommandText = "update TBLmovheader  set supcd="+supcd.Text
                            +" , movcd="+mov.SelectedValue.ToString() +
                            " , doccd="+doctyp.SelectedValue.ToString()
                            +" , date='"+date.Text+"', lblcd="+Lbl.SelectedValue.ToString()
                            +" , depsum="+depsum.Text+", depdiff="+depdiff.Text
                            +" , credsum="+credsum.Text+" , creddiff= "+ creddiff.Text
                            + " where  docno="+docno.Text+" and  docsubno=" +subdocno.Text;
                        cmd1.ExecuteNonQuery();

                         string stcd = TBLsuppliers_tbl.Rows[TBLsuppliers_tbl.Rows.IndexOf(TBLsuppliers_tbl.Rows.Find(supcd.Text))]["stcd"].ToString();
                        //.Rows.IndexOf(TBLsuppliers_tbl.Rows.Find(supcd.Text));
                        string stdis ;
                        try
                        {
                            stdis = TBLsites_tbl.Rows[TBLsites_tbl.Rows.IndexOf(TBLsites_tbl.Rows.Find(stcd))]["stdis"].ToString();
                        }
                        catch (Exception) { stdis="0";}
                        cmd1.CommandText = " update  TBLmovdet set "+
                            " supcd="+supcd.Text+
                            " , stdis="+stdis+
                            " , movcd="+mov.SelectedValue.ToString()+
                            " , doccd="+doctyp.SelectedValue.ToString()+
                            " , date='"+date.Text+
                            "', lblcd="+Lbl.SelectedValue.ToString()+
                            " , stmpdep="+depstmp.Text+
                            " , earndep="+depearn.Text+
                            " , prftdep="+depprft.Text+
                            " , freejbsdep="+depfreejbs.Text+
                            " , fincombdep="+depfincomb.Text+
                            " , stmpdmnddep="+stmpdmnddep.Text+
                            " , stmpknddep="+stmpknddep.Text+
                            " , stmpndusdep="+stmpndusdep.Text+
                            " , stmpcheckdep="+stmpcheckdep.Text+
                            " , stmpconsdep="+stmpconsdep.Text+
                            " , stmpsupdep="+stmpsupdep.Text+
                            " , stmpcontdep="+stmpcontdep.Text+
                            " , suppcomdep="+suppcomdep.Text+
                            " , depsum="+depsum.Text+
                            " , depdiff="+depdiff.Text+
                            " , stmpcred="+credstmp.Text+
                            " , earncred="+credearn.Text+
                            " , prftcred="+credprft.Text+
                            " , freejbscred="+credfreejbs.Text+
                            " , fincombcred="+credfincomb.Text+
                            " , stmpdmndcred="+stmpdmndcred.Text+
                            " , stmpkndcred="+stmpkndcred.Text+
                            " , stmpnduscred="+stmpnduscred.Text+
                            " , stmpcheckcred="+stmpcheckcred.Text+
                            " , stmpconscred="+stmpconscred.Text+
                            " , stmpsupcred="+stmpsupcred.Text+
                            " , stmpcontcred="+stmpcontcred.Text+
                            " , suppcomcred="+suppcomcred.Text+
                            " , credsum="+credsum.Text+
                            " , creddiff="+creddiff.Text+
                            " where  docno=" + docno.Text + " and  docsubno=" + subdocno.Text;
                        cmd1.ExecuteNonQuery();
 
                    } break; //ed
              


            }

            try
            {
                cmd1.Transaction.Commit();

                MessageBox.Show("تم  الحفظ ");
                date.Text = dt.ToString();
                //if (add_ed_del == 2)
                    back_Click(null, null);
                //else
                //    if (add_ed_del == 1)
                //    {
                //        string movndx = mov.Text;
                //        string docndx = doctyp.Text;
                //        int docnum = int.Parse(docno.Text);
                //        this.BindingContext[ds, "TBLmovdet_tbl"].EndCurrentEdit();
                //        this.BindingContext[ds, "TBLmovheader_tbl"].EndCurrentEdit();
                //        this.BindingContext[ds, "TBLmovdet_tbl"].AddNew();
                //        this.BindingContext[ds, "TBLmovheader_tbl"].AddNew();
                //        mov.Text = movndx;
                //        doctyp.Text=docndx;
                //        docno.Text = (docnum + 1).ToString();
                //         mov.Refresh();
                //        doctyp.Refresh();
                //        docno.Refresh();
                //        docno.Focus();


                //    }

            }

            catch (Exception)
            {
                MessageBox.Show("عذرا:هناك خطأ في الحفظ برجاءالمحاولة مرة اخرى");
                cmd1.Transaction.Rollback();
                return;
            }

            TBLmovdet_da.Fill(ds, "TBLmovdet_tbl");
            TBLmovheader_da.Fill(ds, "TBLmovheader_tbl");
        }

        private void supcd_TextChanged(object sender, EventArgs e)
        {
            int pos = TBLsuppliers_tbl.Rows.IndexOf(TBLsuppliers_tbl.Rows.Find(supcd.Text));
            if (pos > -1)
            {
                supnm.Text = TBLsuppliers_tbl.Rows[TBLsuppliers_tbl.Rows.IndexOf(TBLsuppliers_tbl.Rows.Find(supcd.Text))]["supnm"].ToString();
                taxknd.SelectedValue = TBLsuppliers_tbl.Rows[TBLsuppliers_tbl.Rows.IndexOf(TBLsuppliers_tbl.Rows.Find(supcd.Text))]["taxcd"].ToString();
            }
            else
            { supnm.Text = ""; }
        }

        private void mov_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (mov.SelectedValue.ToString() == "1")
            {
                fin.Visible = true;
                com.Visible=false;

                supcd.Visible = true;
                supcdlbl.Visible = true;
                supnm.Visible = true;
                supnmlbl.Visible = true;
                taxknd.Visible = true;
                label14.Visible = true;
            }
            else if (mov.SelectedValue.ToString() == "2")
            {

              //  doctyp.SelectedText = "تسوية";
                fin.Visible = false;
                com.Visible = true;

                supcd.Visible = false;
                supcdlbl.Visible = false;
                supnm.Visible = false;
                taxknd.Visible = false;
                supnmlbl.Visible = false;
                label14.Visible = false;
            }

            if(!docno.ReadOnly)
            enbControls(true);
        }

        private void credfincomb_Validated(object sender, EventArgs e)
        {
            double sum =0 , diff=0;
            //if (mov.Text == "مالي")
            //{
                sum = double.Parse(credearn.Text) +
                    double.Parse(credfincomb.Text) +
                    double.Parse(credfreejbs.Text) +
                    double.Parse(credprft.Text) +
                    double.Parse(credstmp.Text);
               
               
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

        private void depfincomb_Validated(object sender, EventArgs e)
        {
            double sum = 0, diff = 0;
           
                sum = double.Parse(depearn.Text) +
                    double.Parse(depfincomb.Text) +
                    double.Parse(depfreejbs.Text) +
                    double.Parse(depprft.Text) +
                    double.Parse(depstmp.Text);
                
                
           
              


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

        private void credsum_Leave(object sender, EventArgs e)
        {
            string dt = date.Text;
            erPrv.Clear();
            date.Text = dt.ToString();
        }

        private void docno_Validated(object sender, EventArgs e)
        {
            
        }

        private void suppcomcred_Validated(object sender, EventArgs e)
        {
            double sum = 0, diff = 0;
            sum = double.Parse(stmpcheckcred.Text) +
                double.Parse(stmpconscred.Text) +
                double.Parse(stmpcontcred.Text) +
                double.Parse(stmpdmndcred.Text) +
                double.Parse(stmpkndcred.Text) +
                double.Parse(stmpnduscred.Text) +
                double.Parse(stmpsupcred.Text) +
                double.Parse(suppcomcred.Text);

       
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
            sum = double.Parse(stmpcheckdep.Text) +
               double.Parse(stmpconsdep.Text) +
               double.Parse(stmpcontdep.Text) +
               double.Parse(stmpdmnddep.Text) +
               double.Parse(stmpknddep.Text) +
               double.Parse(stmpndusdep.Text) +
               double.Parse(stmpsupdep.Text) +
               double.Parse(suppcomdep.Text);



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

        private void supcd_DoubleClick(object sender, EventArgs e)
        {
            
            
        }

        private void subdocno_Validated(object sender, EventArgs e)
        {
            if (!docno.ReadOnly)
            {
                hdPk[0] = docno.Text;
                hdPk[1] = subdocno.Text;

                //int posdet =ds.Tables["TBLmovdet_tbl"].Rows.IndexOf(TBLmovdet_tbl.Rows.Find(hdPk));
                int poshed = ds.Tables["TBLmovdet_tbl"].Rows.IndexOf(ds.Tables["TBLmovdet_tbl"].Rows.Find(hdPk));
               
                if (poshed != -1)
                {
                    back_Click(null, null);
                    this.BindingContext[ds, "TBLmovheader_tbl"].Position = poshed;

                    this.BindingContext[ds, "TBLmovdet_tbl"].Position = poshed;
                    position = poshed;
                }
            }
        }

        private void supcd_Validated(object sender, EventArgs e)
        {
            int pos = TBLsuppliers_tbl.Rows.IndexOf(TBLsuppliers_tbl.Rows.Find(supcd.Text));
            if (pos == -1)
            {
                MessageBox.Show("هذا العميل غير موجود برجاء إدخاله");

                sts.Visible = true;
                stslb.Visible = true;
                if (supcd.Text == "")
                    supcd.Focus();
            }
            else
            {
                sts.Visible = false;
                stslb.Visible = false;
            }


           
        }

        private void taxknd_Validated(object sender, EventArgs e)
        {
            
        }

        private void credsum_Validated(object sender, EventArgs e)
        {
            if (taxknd.Text == "أ.ت.ص"&& credprft.Enabled)
            {
                credprft.Text = credsum.Text;
                credprft.Focus();
            }
        }

        private void credprft_Validated(object sender, EventArgs e)
        {
            if (taxknd.Text == "أ.ت.ص")
            {
                creddiff.Focus();
            }
        }

        private void creddiff_Validated(object sender, EventArgs e)
        {
           
        }

        private void sts_Validated(object sender, EventArgs e)
        {
           string message = " هل تريد حفظ العميل  "+supnm.Text+"?";
                 
			MessageBoxButtons buttons = MessageBoxButtons.YesNo;
			DialogResult result;

			// Displays the MessageBox.

            result = MessageBox.Show(message, "رسالة تحذيرية ", buttons, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                SqlCommand cmd1 = new SqlCommand();
                cmd1.Connection = Static_class.con;

                if (Static_class.con.State != ConnectionState.Open) Static_class.con.Open();
                cmd1.CommandText = "insert into    TBLsuppliers values ('" + supcd.Text + "', CONVERT(NVARCHAR(250),'" + supnm.Text + "') ,'" + sts.SelectedValue.ToString() + "' ,'" + taxknd.SelectedValue.ToString() + "' )";
                int x = cmd1.ExecuteNonQuery();
                if (x > 0)
                {
                    MessageBox.Show("قد تم الحفظ");
                    TBLsuppliers_da.Fill(TBLsuppliers_tbl);
                }
            }
        }

        private void depsum_Validated(object sender, EventArgs e)
        {
            if (taxknd.Text == "أ.ت.ص" && depprft.Enabled)
            {
                depprft.Text = depsum.Text;
               // depprft.Focus();
            }

        }

        private void depprft_Validated(object sender, EventArgs e)
        {
            if (taxknd.Text == "أ.ت.ص")
            {
               
                depdiff.Focus();
            }
        }

        private void supcd_KeyDown(object sender, KeyEventArgs e)
        {

           // string s = e.KeyCode.ToString();
            if (e.KeyCode == Keys.ControlKey)
            {
                SearchForm search = new SearchForm(TBLsuppliers_da
                               , "supcd", "supnm", 2, 3);
                search.ShowDialog();

                supcd.Text =
                 Static_class.search_output[0];
            }
        }

        private void creddiff_TextChanged(object sender, EventArgs e)
        {

        }

        private void docno_TextChanged(object sender, EventArgs e)
        {

        }

        private void mov_Validated(object sender, EventArgs e)
        {
            if (mov.SelectedValue.ToString () == "1")
            {
                fin.Visible = true;
                com.Visible = false;

                supcd.Visible = true;
                supcdlbl.Visible = true;
                supnm.Visible = true;
                supnmlbl.Visible = true;
                taxknd.Visible = true;
                label14.Visible = true;
            }
            else if (mov.SelectedValue.ToString() == "2")
            {

                //  doctyp.SelectedText = "تسوية";
                fin.Visible = false;
                com.Visible = true;

                supcd.Visible = false;
                supcdlbl.Visible = false;
                supnm.Visible = false;
                taxknd.Visible = false;
                supnmlbl.Visible = false;
                label14.Visible = false;
            }

            if (!docno.ReadOnly)
                enbControls(true);
        }


       
       

       

        

     

       
       

     

     
       
        
    }
}
