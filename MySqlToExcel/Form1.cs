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
        int m_strTagID;//所查手环编号
        private string m_strDate = "";//查询日期
        private string m_strTime1 = "";
        private string m_strTime2 = "";//查询起始时间和结束时间
        //private string m_strWaveFileName = "";
        //private string m_strSaveWaveName = "";
        public Form1()
        {
            InitializeComponent();
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
            try
            {
                m_strTagID = int.Parse(txt_TagID.Text);

            }
            catch (Exception ee)
            {
                throw ee;
            }
            //m_strTagID = txt_TagID.Text;
            m_strDate = txt_Date.Text;
            //m_strTime1 = txt_Time1.Text;
           // m_strTime2 = txt_Time2.Text;

            string time1 = m_mysqlDB.Search_time1_by_id(m_strTagID, m_strDate);
            string time2 = m_mysqlDB.Search_time2_by_id(m_strTagID, m_strDate);
            txt_Log.Text = time1 + time2 + dateTimePicker1.Text;
            //txt_Log.Text = time1;


        }

        private void txt_Time1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

