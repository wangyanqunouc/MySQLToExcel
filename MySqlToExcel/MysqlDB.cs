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

            //string create_table_song_hash_list_sql
               // = "CREATE TABLE IF NOT EXISTS `song_hash_list` ( `ID` int(20) unsigned NOT NULL AUTO_INCREMENT,  `HashID` int(20) DEFAULT NULL,  `SongID` int(20) DEFAULT NULL,  `TimeStamp` int(20) DEFAULT NULL,  PRIMARY KEY (`ID`)) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;";
            //ExecuteNonQuery(create_table_song_hash_list_sql);

            //string create_table_song_list_sql
                //= "CREATE TABLE IF NOT EXISTS `song_list` (  `SongID` int(20) unsigned NOT NULL AUTO_INCREMENT COMMENT 'song id, autoincrement',  `SongName` longtext,  `SongLength` int(20) DEFAULT NULL,  PRIMARY KEY (`SongID`)) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;";
           // ExecuteNonQuery(create_table_song_list_sql);

            //LogOut.WriteLine(string.Format("打开数据库{0}:端口{1}:库名{2},成功！", DataSource, DBport, DataBase));
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

            //DateTime startTime = DateTime.Now;
            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            //double last_time = (DateTime.Now - startTime).TotalMilliseconds;
            //LogOut.WriteLine(string.Format("MySQL ExecuteReader for {0:000.0}ms", last_time));

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
        public string Search_time1_by_id(int tag_id,string date)
        {
            string usertable_name = "user" + date;

            string sql = string.Format("select EntryTime from "+usertable_name+" WHERE TagID='{0}';", tag_id);
            //获取表中的内容
            List<Object[]> retRows = ExecuteQuery(sql);
            //int num = retRows.Count;
            DateTime Time = new DateTime();

            //int cnt = 0;
            if (retRows[0][0] != null)
            {
                Time = Convert.ToDateTime(retRows[0][0].ToString());
            }
            
            return Time.ToString();

            

            //return num;
        }
        public string Search_time2_by_id(int tag_id, string date)
        {
            string usertable_name = "user" + date;

            string sql = string.Format("select * from " + usertable_name + " WHERE TagID='{0}';", tag_id);
            //获取表中的内容
           List<Object[]> retRows = ExecuteQuery(sql);
            //int num = retRows.Count;

            DateTime Time=new DateTime();

            //int cnt = 0;
            if (retRows[0][6] != null)
            {
                Time = Convert.ToDateTime(retRows[0][7].ToString());
            }
            //Time = Convert.ToDateTime(retRows[0][6].ToString());


            return Time.ToString();
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
