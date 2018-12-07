using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace MySqlToExcel
{
    static class ToExcel
    {
        static public void wExcel(string result1) {
            string[] result = Regex.Split(result1, "\r\n", RegexOptions.IgnoreCase);//按行分
            string[] result2 = Regex.Split(result[0], "\t", RegexOptions.IgnoreCase);//每一行按列分
            int row = result.Length;
            int column = result2.Length;
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            
            excel.Application.Workbooks.Add(true);
                //生成字段名称
            /*for (int i = 0; i < DGVCustomer.ColumnCount; i++)
            {
            excel.Cells[1, i + 1] = DGVCustomer.Columns[i].HeaderText;
            }*/
            //填充数据
            for (int i = 0; i < row - 1; i++)
            {
                for (int j = 0; j < column-1; j++)
                {
                    // Regex.Split(result[i], "\t", RegexOptions.IgnoreCase)[j]
                    /*if (typeof(Regex.Split(result[i], "\t", RegexOptions.IgnoreCase)[j])== typeof(string))
                    {
                        excel.Cells[i + 2, j + 1] = "" + Regex.Split(result[i], "\t", RegexOptions.IgnoreCase)[j].ToString();
                    }
                    else
                    {*/
                    excel.Cells[i + 1, j + 1] = Regex.Split(result[i], "\t", RegexOptions.IgnoreCase)[j].ToString();
                    //}
                }
            }
            excel.Visible = true;
        } 
    }
}
