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
    public partial class SearchForm : Form
    {

       // public DataTable prlbasdat_Table = new DataTable();

        public DataTable tableToSearch = new DataTable();
        public SqlDataAdapter tableToSearch_da;
        public string name_for_search;
        public string code_for_search;
        public int unvisibleFrom = 0;

        public string label1 = " الكود ";
        public string label2 = "الأسم";
        
        //public SqlDataAdapter prlbasdat_da = new SqlDataAdapter("select empcd,empnm from prlbasdat",Static_class.con);


        public SearchForm()
        {
            InitializeComponent();
        }
        public SearchForm(SqlDataAdapter tableToSearch_da, string code_for_search, string name_for_search,int unvisibleFrom , int swNo)
        {
            this.tableToSearch_da = tableToSearch_da;
            this.code_for_search = code_for_search;
            this.name_for_search = name_for_search;
            this.unvisibleFrom = unvisibleFrom;
            
            Static_class.search_output = new string[unvisibleFrom];

            InitializeComponent();

            switch (swNo)
            {
                case 1:
                    this.radioButton1.Select();
                    break;
                case 2:
                    this.radioButton2.Select();
                    break;
                case 3:
                    this.radioButton3.Select();
                    break;
               

            }

            this.ActiveControl = textBox1;

        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            this.radioButton3.Text = "داخل " + label2;
            this.radioButton1.Text = label1;
            this.radioButton2.Text = label2;

            tableToSearch_da.Fill(tableToSearch);

            searchGridview.DataSource = tableToSearch;
            searchGridview.Columns[0].HeaderText = label1;
            searchGridview.Columns[1].HeaderText = label2;

            if (unvisibleFrom <= 2)
            {
                searchGridview.Columns[1].Width = 300;
            }
           
            for (int i = unvisibleFrom; i < searchGridview.Columns.Count; i++)
                    searchGridview.Columns[i].Visible = false;

           // textBox1.Text = Static_class.search_in;

            textBox1.Focus();
            

        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            BindingSource source1 = new BindingSource();
            source1.DataSource = tableToSearch;
            if (this.radioButton1.Checked)
            {
                source1.Filter =code_for_search+" LIKE '" + textBox1.Text + "%'";
               
            }
            else if (this.radioButton2.Checked)
                source1.Filter = name_for_search+" LIKE '" + textBox1.Text + "%'";
            else if (this.radioButton3.Checked)
                source1.Filter = name_for_search + " LIKE '%" + textBox1.Text + "%'";
            searchGridview.DataSource = source1; 
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        public void CloseFrm()
        {
            this.Close();
            Static_class.child_form_opened_flag = false;
        }

        private void SearchForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Static_class.child_form_opened_flag = false;
        }

        private void searchGridview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Static_class.child_form_opened_flag = false;
            for (int i = 0; i < unvisibleFrom;i++ )
                Static_class.search_output [i]= searchGridview[i, e.RowIndex].Value.ToString();
            
            this.Close();
           
        }

        //private void textBox1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyData == Keys.Enter)
        //    {
        //        try
        //        {
        //            Static_class.child_form_opened_flag = false;
        //            for (int i = 0; i < unvisibleFrom;i++ )
        //                Static_class.search_output[i] = searchGridview.Rows[searchGridview.CurrentCell.RowIndex].Cells[i].Value.ToString();

        //            this.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            this.Close();
        //        }
        //    } 
        //}

        private void SearchForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { SendKeys.Send("{Tab}"); }
            if (e.KeyCode == Keys.Escape) { this.Close(); }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Focus();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Focus();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Focus();
        }

        //private void textBox1_KeyUp(object sender, KeyEventArgs e)
        //{
            

        //}

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                try
                {
                    Static_class.child_form_opened_flag = false;
                    for (int i = 0; i < unvisibleFrom; i++)
                        Static_class.search_output[i] = searchGridview.Rows[searchGridview.CurrentCell.RowIndex].Cells[i].Value.ToString();

                    this.Close();
                }
                catch (Exception )
                {
                    this.Close();
                }
            } 
        }

     

      

        

      

       


       
    }
}
