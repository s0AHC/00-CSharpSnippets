            MySqlConnection conn = new MySqlConnection("连接数据库字符串");
            conn.Open();
            MySqlCommand mycmd = new MySqlCommand();
            mycmd.Connection = conn;
            mycmd.CommandType = CommandType.Text;
            mycmd.CommandText = "insert into product(productname) values ("产品名称");";
            mycmd.ExecuteNonQuery();
            //获取插入后的数据ID
            long newid = mycmd.LastInsertedId;
/*
    --------------------- 
    作者：jsonzbc 
    来源：CSDN 
    原文：https://blog.csdn.net/zbc496218/article/details/51082983 
    版权声明：本文为博主原创文章，转载请附上博文链接！
*/