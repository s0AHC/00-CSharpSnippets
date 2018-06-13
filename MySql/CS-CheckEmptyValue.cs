/*
C#中往数据库插入空值的问题：
在用C#往数据库里面插入记录的时候,可能有的字段未赋值,那么这个字段的值就为null,如果按一般想法的话,这个值会被数据库接受,然后在数据表里面显示为NUll,
实际上这就牵扯到一个类型的问题,C#中的NUll与SQL中的null是不一样的,SQL中的null用C#表示出来就是DBNull.Value,所以在进行Insert的时候要注意的地方.

Example:
       SqlCommand cmd=new  SqlCommand("Insert into Student values(@StuName,@StuAge)" ,con);
       cmd.parameters.add("@StuName" ,stuname);
       cmd.parameters.add("@StuAge" ,stuage);
       cmd.ExecuteNonQuery();

这些代码看似没有问题,其实当stuname于stuage中的任何一个值为null的时候,这代码就会报错!

解决办法:
其实最简单的办法就是进行判断, 当stuname或stuage为空时, 插入DBNull.Value.
但是这样当一个数据库有很多字段时或者是有很多张表时, 代码就会很多了,我也没有找到特别方便的方法,
我的方法是：写一个静态的方法来对变量的值进行判断:
*/

static  public  object  SqlNull(object  obj)
{
   if  (obj == null )
		return  DBNull.Value;
		return  obj;
}

//用上面的方法对参数进行了判断 
cmd.parameters.add("@StuName" ,SqlNull(stuname));
cmd.parameters.add("@StuAge" ,SqlNull(stuage));
cmd.ExecuteNonQuery();