using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Data;



public class ManageControls
{

   public void ManageKeyDown(System.Windows.Forms.Control _target)
   {
       try
       {
           if (
               _target is TextBox || _target is Button
               || _target is CheckBox || _target is RadioButton
               || _target is ComboBox || _target is MaskedTextBox
               )
           {
               _target.KeyDown += new KeyEventHandler(_control_KeyDown);
           }
           else
           {
               foreach (Control _ChildControl in _target.Controls)
               {
                   ManageKeyDown(_ChildControl);
               }
           }
       }
       catch (Exception ex)
       {
           throw ex;
       }
   }

   void _control_KeyDown(object sender, KeyEventArgs e)
   {
      
       if (e.KeyCode == Keys.Enter) { SendKeys.Send("{Tab}"); }
   }

   public void AllowNumbersOnly(TextBox  _textBox)
   {
       
       _textBox.KeyPress += new KeyPressEventHandler(_textBox_KeyPress);
   }

   void _textBox_KeyPress(object sender, KeyPressEventArgs e)
   {
       AllowNumbersOnly(sender, e);
   }


   private bool IsNumber(string text)
   {
       bool res = true;
       try
       {
           if (!string.IsNullOrEmpty(text) && ((text.Length != 1) || (text != "-")))
           {
               Decimal d = decimal.Parse(text, CultureInfo.CurrentCulture);
           }
       }
       catch
       {
           res = false;
       }
       return res;
   }

   public void AllowDecimalNumbersOnly(TextBox _textBox)
   { 
        _textBox.KeyPress +=new KeyPressEventHandler(_textBoxDecimal_KeyPress);
   }

   void _SignedtextBox_KeyPress(object sender, KeyPressEventArgs e)
   {
       if (!char.IsControl(e.KeyChar)
              && !char.IsDigit(e.KeyChar)
              && e.KeyChar != '.' && e.KeyChar != '-')
       {
           e.Handled = true;
       }

       // only allow one decimal point
       if (e.KeyChar == '.'
           && (sender as TextBox).Text.ToString().IndexOf('.') > -1)
       {
           e.Handled = true;
       }
   }
   public void AllowSignedDecimalNumbersOnly(TextBox _SignedtextBox)
   {
       _SignedtextBox.KeyPress += new KeyPressEventHandler(_SignedtextBox_KeyPress);
       
   }

   

   void _textBoxDecimal_KeyPress(object sender, KeyPressEventArgs e)
   {
       AllowDecimalNumbersOnly(sender, e);
   }

   public  void AllowDecimalNumbersOnly(object sender, KeyPressEventArgs e)
   {

       if (!char.IsControl(e.KeyChar)
               && !char.IsDigit(e.KeyChar)
               && e.KeyChar != '.')
       {
           e.Handled = true;
       }

       // only allow one decimal point
        if (e.KeyChar == '.'
            && (sender as TextBox).Text.ToString().IndexOf('.') > -1)
        {
            e.Handled = true;
        }
   }

   private void AllowNumbersOnly(object sender, KeyPressEventArgs e)
   {
       if (!char.IsControl(e.KeyChar)
              && !char.IsDigit(e.KeyChar))
       {
           e.Handled = true;
       }
   }

   public bool IsMaskedTextHasValue(MaskedTextBox _target)
   {
       bool _result = false;

       string[] _value = _target.Text.Split('/');
       foreach (string str in _value)
       {
           if (str.Trim().Length > 0)
           {
               _result = true;
               break;
           }
       }

       return _result;
   }

   public void ShowErrorMessage(Exception ex)
   {
       MessageBox.Show(ex.Message, "خطأ ", MessageBoxButtons.OK, MessageBoxIcon.Error);
   }

   public void ShowErrorMessage(string pMessage)
   {
       MessageBox.Show(pMessage, "خطأ ", MessageBoxButtons.OK, MessageBoxIcon.Error);
   }

   public void ManageEnterKey(Form pForm)
   {
       pForm.KeyPreview = true;
       pForm.KeyDown += new KeyEventHandler(pForm_KeyDown);

   }

   void pForm_KeyDown(object sender, KeyEventArgs e)
   {
       if (e.KeyCode == Keys.Enter) { SendKeys.Send("{Tab}"); }
   }



   public bool IsEmptyString(string pText)
   {
       if (pText == null || pText.Trim() == string.Empty)
           return true;
       return false;
   }

   public int GetMonthFromDate(object pValue)
   {
       try
       {
           return Convert.ToDateTime(pValue).Month;
       }
       catch (Exception ex)
       {

           new ManageControls().ShowErrorMessage(ex);
           return 0;
       }
   }

   public int GetYearFromDate(object pValue)
   {
       try
       {
           string year = Convert.ToDateTime(pValue).Year.ToString();
           return Convert.ToInt32(year.Substring(2, 2));
       }
       catch (Exception ex)
       {

           new ManageControls().ShowErrorMessage(ex);
           return 0;
       }
   }

   public string GetMaxStringAllowed(string pValue, string pKey)
   {
       try
       {
           int KeyValue = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings[pKey]);
           pValue = pValue.Trim();
           if (pValue.Length > KeyValue)
               return pValue.Substring(0, KeyValue);
           return pValue.ToString().Trim();
       }
       catch (Exception ex)
       {
           new ManageControls().ShowErrorMessage(ex);
           return string.Empty;
       }
   }

   public string GetPound(object pValue)
   {
       if (Convert.IsDBNull(pValue) || pValue == null || pValue.ToString().Trim() == "")
           return string.Empty;

       if (pValue.ToString().Contains("."))
       {
           return ConvertZeroToEmptyString(pValue.ToString().Split('.')[0]);
       }
       return ConvertZeroToEmptyString(pValue);
   }

   public string GetPiaster(object pValue)
   {
       if (Convert.IsDBNull(pValue) || pValue == null || pValue.ToString().Trim() == "")
           return string.Empty;

       if (pValue.ToString().Contains("."))
       {
           string result = pValue.ToString().Split('.')[1];
           if (result == null) result = string.Empty;
           if (result.Length > 2)
           {
               result = result.Substring(0, 2);
           }
           result = ConvertZeroToEmptyString(result);
          
           if (result != string.Empty)
               result = Convert.ToInt32(result).ToString("00");
           return result;
       }

       return string.Empty;
   }

   public string ConvertZeroToEmptyString(object pValue)
   {
       if (Convert.IsDBNull(pValue) || pValue == null)
           return string.Empty;

       int val = 0;
       int.TryParse(pValue.ToString(), out val);
       if (val == 0)
           return string.Empty;

       return pValue.ToString();
   }

   public string RemoveSpecialCharacters(string pValue)
   {
       try
       {
           List<string> lstSpecial = new List<string>() { "/", "*" , "&" , 
                "~" , "@" , "#" , "$" , "%" , "^" , "&" , "*"
            , "(" , ")" , "-" , "_" , "=" , "+" , @"\" , "|" , "'" 
            , "]" , "[" , "{" , "}" , ":" , "،" , "," , "؟",".", "?" , "ـ" , "،"
            };
           foreach (string str in lstSpecial)
           {
               pValue = pValue.Replace(str, "");
           }
           return pValue;
       }
       catch (Exception ex)
       {
           throw ex;
       }

   }

   public string ManageBoardNo(object pValue)
   {
      string board_no = string.Empty;
      if (!Convert.IsDBNull(pValue))
          board_no = pValue.ToString().Trim();
       if (board_no.Length > 9)
           board_no = "000000000";
       return board_no.Trim();
   }

   public bool ShowMenu(string pKey)
   {
       try
       {
           int KeyValue = Convert.ToInt32(System.Configuration.ConfigurationSettings.AppSettings[pKey]);
           if (KeyValue == 1)
               return true;
           return false;
       }
       catch (Exception ex)
       {

           ShowErrorMessage(ex);
           return false;
           
       }
   }

   

   public string GetCurrentFatoraPaperName()
   {
       try
       {
           return System.Configuration.ConfigurationSettings.AppSettings["CurrentFatpraPaperName"];
         
       }
       catch (Exception ex)
       {

           ShowErrorMessage(ex);
           return string.Empty;
       }
   }

   public float GetCurrentFatoraPaperHeightINCM()
   {
       try
       {
           return Convert.ToSingle(System.Configuration.ConfigurationSettings.AppSettings["CurrentFatpraPaperHeightINCM"]);
       }
       catch (Exception ex)
       {

           ShowErrorMessage(ex);
           return -1;

       }
   }

   public float GetCurrentFatoraPaperWidthINCM()
   {
       try
       {
           return Convert.ToSingle(System.Configuration.ConfigurationSettings.AppSettings["CurrentFatpraPaperWidthINCM"]);
       }
       catch (Exception ex)
       {

           ShowErrorMessage(ex);
           return -1;

       }
   }



   public string CreateReferenceKey_Old(DataRow pDataRow)
   {
       try
       {
           return string.Format("00", pDataRow["hndsa_code"]) + string.Format("00", pDataRow["mntka_code"]) + string.Format("00", pDataRow["day_code"]) + string.Format("0000", pDataRow["main_code"]) + string.Format("00", pDataRow["fary_code"]);
       }
       catch (Exception ex)
       {

           throw ex;
       }
   }

   public string CreateReferenceKey_old(DataRow pDataRow)
   {
       try
       {
           return Convert.ToString( pDataRow["hndsa_code"]).PadLeft(2) + Convert.ToString ( pDataRow["mntka_code"]).PadLeft(2) +  Convert.ToString( pDataRow["day_code"]).PadLeft(2) + Convert.ToString( pDataRow["main_code"]).PadLeft(4) + Convert.ToString( pDataRow["fary_code"]).PadLeft(2);
       }
       catch (Exception ex)
       {

           throw ex;
       }
   }

   public string CreateReferenceKey(DataRow pDataRow)
   {
       try
       {
           return Convert.ToInt32( pDataRow["hndsa_code"]).ToString("00") + Convert.ToInt32(pDataRow["mntka_code"]).ToString("00") + Convert.ToInt32(pDataRow["day_code"]).ToString("00") + Convert.ToInt32(pDataRow["main_code"]).ToString("0000") + Convert.ToInt32(pDataRow["fary_code"]).ToString("00");

           // return Convert.ToInt32(pDataRow["fary_code"]).ToString("00") + Convert.ToInt32(pDataRow["main_code"]).ToString("0000") + Convert.ToInt32(pDataRow["day_code"]).ToString("00") + Convert.ToInt32(pDataRow["mntka_code"]).ToString("00") + Convert.ToInt32(pDataRow["hndsa_code"]).ToString("00");
       }
       catch (Exception ex)
       {

           throw ex;
       }
   }

   public string CreateReferenceKey(params object[] pDataRow)
   {
       try
       {
           return string.Format("00", pDataRow[0]) + string.Format("00", pDataRow[1]) + string.Format("00", pDataRow[2]) + string.Format("0000", pDataRow[3]) + string.Format("00", pDataRow[4]);
       }
       catch (Exception ex)
       {

           throw ex;
       }
   }

    //To Call CreateReferenceKey(2,1,5,4,8);
   
}

public enum enDataLoading
{
    QueryExecution,
    DataPreparation,
    DataCompleted
}

