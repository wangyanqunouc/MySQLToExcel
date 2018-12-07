using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySqlToExcel
{
    public partial class Form1 : Form
    {
        private MysqlDB m_mysqlDB = null;
        private string m_strDBUrl = "";//数据库地址
        private string m_strDBPort = "";//数据库端口号
        private string m_strDBName = "";//数据库名称
        private string m_strDBUser = "";//数据库用户名
        private string m_strDBPassword = "";//数据库密码
        private string m_strBDString = "";//所有数据库相关信息
        string m_strTagID;//所查手环编号
        private string m_strDateReal = "";//查询日期
        private string m_strDateFile = "";//数据库表所指示的日期
        private string m_strTime1 = "";
        private string m_strTime2 = "";//查询起始时间和结束时间
        //private string m_strWaveFileName = "";
        //private string m_strSaveWaveName = "";
        public Form1()
        {
            InitializeComponent();
            LogOut.InitLogOut(txt_Log);
        }
        //txt_DBUrlName.Text=m_mysqlDB.DataSource;
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void btn_DataBase_Click(object sender, EventArgs e)
        {
            /*
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "access数据库|*.accdb";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                strDBFileName = (string)dlg.FileName.Clone();

                txt_DBFileName.Text = strDBFileName;

                mysqlDB = new AccessDB(strDBFileName);
            }
             * */

            m_strDBName = txt_DBName.Text;
            m_strDBUrl =txt_DBUrl.Text;
            m_strDBPort = txt_DBPort.Text;
            //m_strDBName = "";
            m_strDBUser =txt_DBUser.Text;
            m_strDBPassword =txt_Password.Text;

            m_strBDString = m_strDBName + ":" + m_strDBUrl + ":" + m_strDBPort + ":" + m_strDBUser + ":" + m_strDBPassword;
            m_mysqlDB = new MysqlDB(m_strBDString);

            /*if (m_mysqlDB != null)
            {
                //m_strDBName = m_mysqlDB.DataSource + ":" + m_mysqlDB.DBport + ":" + m_mysqlDB.DataBase;
            }*/
            txt_Log.Text = "连接数据库：" + m_strDBName;
            return;
        }

        private void txt_DBUrlName_TextChanged(object sender, EventArgs e)
        {
            //txt_DBUrlName.Text="ok";
        }

        private void btn_Go_Click(object sender, EventArgs e)
        {
            dateTimeCopy.Value = dateTime.Value;//格式化日期选择eg 2018-09-02
            m_strDateFile = (int.Parse(dateTime.Text)+1).ToString();//把非格式话的日期选择加一天。eg180920---180921
            m_strDateReal=dateTime.Text;//真实的日期
            m_strTime1=dateTimeCopy.Text+" "+str_Time1.Text;//开始时间
            m_strTime2 = dateTimeCopy.Text + " " + str_Time2.Text;//结束时间
            m_mysqlDB.alter_ibeacon_timetype1(m_strDateFile);//把time类型变成varchar
            m_strTagID = txt_TagID.Text;//手环编号
            m_mysqlDB.Search_user_info(m_strTagID, m_strDateFile);//查找user信息，最终结果不需要
            string result=m_mysqlDB.Search_final_result(m_strTagID,m_strDateFile, m_strTime1, m_strTime2);//结果查询，目前只能查到原始数据
            m_mysqlDB.alter_ibeacon_timetype2(m_strDateFile);//把varchar类型变成time
            ToExcel.wExcel(result);//把结果写到Excel

        }

        private void test_excel_Click(object sender, EventArgs e)
        {
            dateTimeCopy.Value = dateTime.Value;
            string time1 = ToTime.convertTime(dateTimeCopy.Text + " " + str_Time1.Text, 0);
            //ToExcel.wExcel("行1列1\t行1列2\t\r\n行2列1\t行2列2\t\r\n行3列1\t行3列2\t\r\n行4列1\t行4列2\t\r\n行5列1\t行5列2\t\r\n");
            string time2 = ToTime.convertTime(dateTimeCopy.Text + " " + str_Time1.Text,15);
            LogOut.WriteLine(time1.ToString());
            LogOut.WriteLine(time2.ToString());
            LogOut.WriteLine(ToTime.CompareTimes(time2, time1).ToString());
        }

        private void txt_Time1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

