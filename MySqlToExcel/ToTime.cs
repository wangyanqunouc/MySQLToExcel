using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlToExcel
{
    static class ToTime
    {
        static public  string convertTime(string str_time,int n)
        {

            return Convert.ToDateTime(str_time).AddSeconds(n).ToString("yyyy-MM-dd HH:mm:ss");
            //DateTime.ToString("yyyy-MM-dd HH:mm:ss")
            /*
            方法一：Convert.ToDateTime(string)
            string格式有要求，必须是yyyy-MM-dd hh:mm:ss
            */
        }
        static public bool CompareTimes(string time1,string time2) {
            DateTime t1=Convert.ToDateTime(time1);
            DateTime t2= Convert.ToDateTime(time2);
            
            if (DateTime.Compare(t1, t2) == 0)
            {
                return true;
            }
                
            else if (DateTime.Compare(t1, t2) < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
                
        }
        
    }
}
