using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tax
{
    public static class Converter
    {
                public static decimal IfNullThenZero (this object value)
                {
                    if (value == DBNull.Value)
                    {
                        return 0;
                    }
                    else
                    {
                        return Convert.ToDecimal(value);
                    }
                }




                public static String TOInsertString(this object value)
                {
                    if (value == DBNull.Value || value.ToString().Length==0 )
                    {
                        return "NULL";
                    }

                    else
                    {
                        return  "'"+value.ToString()+"'";
                    }
                }


    
    }
}
