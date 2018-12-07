using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlToExcel
{
    static class LogOut
    {
        static System.Windows.Forms.TextBox logWindow = null;
        static int prompt_limit = 0;
        static int prompt_idx = 0;
        static string[] prompt_list = null;

        public delegate void LogOutInvoke(string str1);

        static public void InitLogOut(System.Windows.Forms.TextBox textBox)
        {
            logWindow = textBox;
            prompt_limit = 200;
            prompt_list = new string[prompt_limit];

            for (int i = 0; i < prompt_list.Length; i++)
                prompt_list[i] = "";
        }

        static public void WriteLine(string prompt_str)
        {
            if (logWindow == null)
                return;

            if (logWindow.InvokeRequired)
            {
                LogOutInvoke invokeFunc = new LogOutInvoke(WriteLine);

                logWindow.BeginInvoke(invokeFunc, prompt_str);

                return;
            }

            prompt_list[prompt_idx] = prompt_str + "\r\n";
            prompt_idx = (prompt_idx + 1) % prompt_list.Length;

            string total_str = "";
            for (int i = 0; i < prompt_list.Length; i++)
            {
                total_str += prompt_list[(prompt_idx + i) % prompt_list.Length];
            }
            logWindow.Text = total_str;

            logWindow.Select(total_str.Length, total_str.Length);
            logWindow.ScrollToCaret();

            logWindow.Invalidate();
            logWindow.Update();

            return;
        }
    }
}
