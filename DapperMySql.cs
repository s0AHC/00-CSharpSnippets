using MySql.Data.MySqlClient; //自行网上下载引用MySql.Data.dll
using System.Configuration;
using System.Data;
using Dapper;                //自行网上下载引用Dapper.dll
using System.Collections.Generic;
 
namespace DapperTest
{
    public class DapperHelper
    {
        /// <summary>
        /// 连接MySQL数据库
        /// </summary>
        /// <returns></returns>
        public static MySqlConnection MySqlCon()
        {
            string mysqlConnectionStr = ConfigurationManager.ConnectionStrings["testDB"].ToString();
            var connection = new MySqlConnection(mysqlConnectionStr);
            connection.Open();
            return connection;
        }
 
        /// <summary>
        /// 执行insert与update脚本
        /// </summary>
        public int ExcuteSqlString(string sqlStr)
        {
            using (IDbConnection conn = DapperHelper.MySqlCon())
            {
               return conn.Execute(sqlStr);
            }
        }
 
        /// <summary>
        /// 执行查询脚本
        /// </summary>
        public List<T> QuerySqlString<T>(string sqlStr)
        {
            using (IDbConnection conn = DapperHelper.MySqlCon())
            {
                return conn.Query<T>(sqlStr) as List<T>;
            }
        }
 
 
        //调用测试
        public void Test()
        {
            DapperHelper dh = new DapperHelper();
 
            //查询测试
            List<TestTable> list = dh.QuerySqlString<TestTable>("select * from TestTable limit 10;");
 
            //执行测试
            int result = dh.ExcuteSqlString("update TestTable set name='test' where id=1");
            return;
        }
    }
}