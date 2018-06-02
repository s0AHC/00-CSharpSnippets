//别忘了导包
using MySql.Data.MySqlClient;
//……
//参考逻辑
string insertSql = "INSERT INTO teacher (teacher.id, teacher.utc8_create, teacher.utc8_modify, teacher.`name`, teacher.office, teacher.other, teacher.contact) VALUES (@ID,@Create,@Modify,@Name,@Office,@Other,@Contact)";
            string Conn = "Database='for_aurora';Data Source='localhost';User Id='root';Password='root';charset='utf8'";
            MySqlConnection mySqlConnection = new MySqlConnection(Conn);//创建连接
            mySqlConnection.Open();//先打开连接
            MySqlTransaction mySqlTransaction = mySqlConnection.BeginTransaction();//后开启事务

            try
            {
                //执行命令>1
                MySqlCommand mSqlCommand_1 = new MySqlCommand();
                mSqlCommand_1.Connection = mySqlConnection;
                mSqlCommand_1.CommandText = insertSql;
                mSqlCommand_1.Parameters.Add(new MySqlParameter("@ID", Guid.NewGuid().ToString("N")));
                mSqlCommand_1.Parameters.Add(new MySqlParameter("@Create", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                mSqlCommand_1.Parameters.Add(new MySqlParameter("@Modify", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                mSqlCommand_1.Parameters.Add(new MySqlParameter("@Name", "name"));
                mSqlCommand_1.Parameters.Add(new MySqlParameter("@Office", "Office"));
                mSqlCommand_1.Parameters.Add(new MySqlParameter("@Other", "Other"));
                mSqlCommand_1.Parameters.Add(new MySqlParameter("@Contact", "Contact"));
                mSqlCommand_1.ExecuteNonQuery();

                //执行命令>1
                //MySqlCommand mSqlCommand_2 = new MySqlCommand();
                mSqlCommand_1.Parameters.Clear();
                mSqlCommand_1.Connection = mySqlConnection;
                mSqlCommand_1.CommandText = insertSql;
                mSqlCommand_1.Parameters.Add(new MySqlParameter("@ID", Guid.NewGuid().ToString("N")));
                mSqlCommand_1.Parameters.Add(new MySqlParameter("@Create", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                mSqlCommand_1.Parameters.Add(new MySqlParameter("@Modify", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")));
                mSqlCommand_1.Parameters.Add(new MySqlParameter("@Name", "name"));
                mSqlCommand_1.Parameters.Add(new MySqlParameter("@Office", "Office"));
                mSqlCommand_1.Parameters.Add(new MySqlParameter("@Other", "Other"));
                mSqlCommand_1.Parameters.Add(new MySqlParameter("@Contact", "Contact"));
                mSqlCommand_1.ExecuteNonQuery();

                //命令若干……
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                mySqlTransaction.Rollback();
                mySqlConnection.Close();
            }
            finally {
                Console.WriteLine("状态：" + mySqlConnection.State);
                if (mySqlConnection.State != ConnectionState.Closed) {
                    mySqlTransaction.Commit();
                    mySqlConnection.Close();
                }
            }