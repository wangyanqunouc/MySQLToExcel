using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MySqlToExcel
{
    class MysqlDB
    {
        private MySql.Data.MySqlClient.MySqlConnection mysqlDb = null;
        public string DataSource = "localhost";
        public string DBport = "3306";
        public string DataBase = "wantongbao1206";
        public string DataPassword = "123456";
        public string DataUser = "root";

        public const int NotFound = -1;

        public MysqlDB()
        {
            CreateConnection();
        }

        public MysqlDB(string DataSourceAddr)
        {
            //m_strBDString = m_strDBName + ":" + m_strDBUrl + ":" + m_strDBPort + ":" + m_strDBUser + ":" + m_strDBPassword;
            
            string[] source = DataSourceAddr.Split(':');
            if (source[0] != "") {
                DataBase = source[0];
            }
            if (source[1] != "")
            {
                DataSource = source[1];
            }
            if (source[2] != "")
            {
                DBport = source[2];
            }
            if (source[3] != "")
            {
                DataUser = source[3];
            }
            if (source[4] != "")
            {
                DataPassword = source[4];
            }
            CreateConnection();
        }

        

        private void CreateConnection()
        {
            string conString = string.Format("Database={2};Data Source={0};User Id={3};Password={4};pooling=false;CharSet=utf8;port={1}", DataSource, DBport, DataBase, DataUser, DataPassword);

            try
            {
                mysqlDb = new MySqlConnection(conString);
                mysqlDb.Open();
                //txt_Log.Text = "连接数据库：" + m_strDBName;
            }
            catch (Exception e)
            {
                //LogOut.WriteLine(string.Format("打开数据库{0}:端口{1}, 失败！", DataSource, DBport));
                //LogOut.WriteLine(string.Format("错误信息：{0}", e.ToString()));

                return;
            }
        }

        public bool ExecuteNonQuery(string sql)
        {
            MySqlCommand mySqlCommand = getSqlCommand(sql);

            int iRet = mySqlCommand.ExecuteNonQuery();
            if (iRet <= 0)
                return false;

            return true;
        }

        public List<Object[]> ExecuteQuery(string sql)
        {
            List<Object[]> lResult = new List<object[]>();

            MySqlCommand mySqlCommand = getSqlCommand(sql);

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            

            try
            {
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        Object[] row = new Object[reader.FieldCount];
                        for (int i = 0; i < row.Length; ++i)
                        {
                            string fieldType = reader.GetDataTypeName(i).ToUpper();
                            switch (fieldType)
                            {
                                case "VARCHAR":
                                    row[i] = reader.GetString(i);
                                    break;
                                case "INT":
                                    row[i] = reader.GetInt32(i);
                                    break;
                                default:
                                    break;
                            }
                        }
                        lResult.Add(row);
                    }
                }
            }
            catch (Exception)
            {
               // LogOut.WriteLine("查询失败了！");
            }
            finally
            {
                reader.Close();
            }

            return lResult;
        }
        public void alter_ibeacon_timetype1(string date)
        {
            string ibeacontable_name = "ibeacon" + date;
            string sql = string.Format("alter table "+ibeacontable_name+" modify column Time varchar(50);");
            ExecuteNonQuery(sql);

        }
        public void alter_ibeacon_timetype2(string date)
        {
            string ibeacontable_name = "ibeacon" + date;
            string sql = string.Format("alter table " + ibeacontable_name + " modify column Time datetime;");
            ExecuteNonQuery(sql);

        }
        public string Search_time1_by_id(int tag_id,string date)
        {
            string usertable_name = "user" + date;

            string sql = string.Format("select * from "+usertable_name+" WHERE TagID='{0}';", tag_id);
            //获取表中的内容
            List<Object[]> retRows = ExecuteQuery(sql);
            //int num = retRows.Count;
            DateTime Time = new DateTime();

            //int cnt = 0;
            if (retRows[0][6] != null)
            {
                Time = Convert.ToDateTime(retRows[0][6].ToString());
            }

            return retRows[0][6].ToString(); 
        }
        public string Search_final_result(string tag_id,string m_strDate,string m_strTime1, string m_strTime2)
        {
            string userTable_Name = "user" + m_strDate;
            string ideaconTable_Name = "ibeacon"+m_strDate;
            string baseStation = "basestation";
            string[] result;
            int k = 0;
            //string sql = string.Format("select * from " + ideaconTable_Name + "," + baseStation + " where " + ideaconTable_Name + ".BSMAC=" + baseStation + ".BSMAC and TagID=" + tag_id + " and Time>='" + m_strTime1 + "' and Time<='" + m_strTime2+ "';");
            //List<Object[]> retRows = ExecuteQuery(sql);
            //查询所得原始表
            for (string time = m_strTime1; ToTime.CompareTimes(time, m_strTime2); time=ToTime.convertTime(time, 90))//每90秒得到一个结果
            {
                for (string time1 = time; ToTime.CompareTimes(time1, ToTime.convertTime(time, 90)); time1 = ToTime.convertTime(time1, 10))//每十秒得到一个结果
                {
                    int k = 0;
                    for (string time2 = time1; ToTime.CompareTimes(time1, ToTime.convertTime(time1, 10)); time2 = ToTime.convertTime(time2, 2))//每两秒得到一个结果
                    {
                        string time2_end = ToTime.convertTime(time2, 2);
                        string sql = string.Format("select * from " + ideaconTable_Name + "," + baseStation + " where " + ideaconTable_Name + ".BSMAC=" + baseStation + ".BSMAC and TagID=" + tag_id + " and Time>='" + m_strTime1 + "' and Time<='" + m_strTime2 + "';");
                        List<Object[]> retRows = ExecuteQuery(sql);
                        
                        foreach (object[] item in retRows)
                        {
                            if (int.Parse(item[3].ToString())>=k)
                            {
                                k = int.Parse(item[3].ToString());
                                result[k] = item[1].ToString();
                            }
                            k++;
                            LogOut.WriteLine(result[k]);
                        }
                    }//result数组被五个基站的Mac地址填满，下一步五选一

                }
            }
            
            /*foreach (object[] item in retRows)
            {
                result += item[2].ToString() + "\t" + item[1].ToString() + "\t" + item[3].ToString() + "\t" + item[7].ToString() + "\t" + item[4].ToString() + "\t\r\n";
                LogOut.WriteLine(item[4].ToString());
                cnt++;
            }*/
            return result;
        }
        public string Search_user_info(string tag_id, string m_strDate)
        {
            string userTable_Name = "user" + m_strDate;
            string sql = string.Format("select * from " + userTable_Name+";");
            //获取表中的内容
            List<Object[]> retRows = ExecuteQuery(sql);
            string result = retRows[0][1].ToString() + "\t" + retRows[0][2].ToString() + "\t" + retRows[0][3].ToString() + "\t" + retRows[0][5].ToString() + "\r\n";
            LogOut.WriteLine(retRows[0][1].ToString() + "\t" + retRows[0][2].ToString() + "\t" + retRows[0][3].ToString() + "\t" + retRows[0][5].ToString()+"\r\n");
            return result;
        }
        public string Search_time2_by_id(string tag_id, string date)
        {
            string usertable_name = "user" + date;

            string sql = string.Format("select * from " + usertable_name + " WHERE TagID='{0}';", tag_id);
            //获取表中的内容
           List<Object[]> retRows = ExecuteQuery(sql);
            //int num = retRows.Count;

            DateTime Time=new DateTime();

            //int cnt = 0;
            if (retRows[0][7] != null)
            {
                Time = Convert.ToDateTime(retRows[0][7].ToString());
            }
            //Time = Convert.ToDateTime(retRows[0][6].ToString());

            return retRows[0][7].ToString();
            //return Time.ToString();
        }

        /// <summary>
        /// 建立执行命令语句对象
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="mysql"></param>
        /// <returns></returns>
        public MySql.Data.MySqlClient.MySqlCommand getSqlCommand(String sql)
        {
            /*
            byte[] sqlbytes = Encoding.Default.GetBytes(sql);
            sqlbytes = Encoding.Convert(Encoding.Default, Encoding.UTF8, sqlbytes);
            sql = Encoding.UTF8.GetString(sqlbytes);
             * */

            MySqlCommand mySqlCommand = new MySqlCommand(sql, mysqlDb);
            // MySqlCommand mySqlCommand = new MySqlCommand(sql);
            // mySqlCommand.Connection = mysql;

            return mySqlCommand;
        }
    }
}
