/*
泛型:
所属命名空间：System.Collections.Generic
public class List<T> : IList<T>, ICollection<T>, IEnumerable<T>, IList, ICollection, IEnumerable
List<T>类是 ArrayList 类的泛型等效类。该类使用大小可按需动态增加的数组实现 IList<T> 泛型接口。

泛型的好处：
关于object类型：
1.object类型可以来引用任何类型的实例；
2.object类型可以存储任何类型的值；
3.可以定义object类型的参数；
4.可以把object作为返回类型。
但是--这样做有很大的问题：
1.会因为程序员没有记住使用的类型而出错，造成类型不兼容；
2.值类型和引用类型的互化即装箱拆箱使系统性能下降。 
泛型为使用c#语言编写面向对象程序增加了极大的效力和灵活性。不会强行对值类型进行装箱和拆箱，或对引用类型进行向下强制类型转换，所以性能得到提高。

性能注意事项：
在决定使用IList<T> 还是使用ArrayList类（两者具有类似的功能）时，记住IList<T> 类在大多数情况下执行得更好并且是类型安全的。
如果对IList<T> 类的类型 T 使用引用类型，则两个类的行为是完全相同的。但是，如果对类型 T 使用值类型，则需要考虑实现和装箱问题。
 “添加到 ArrayList 中的任何引用或值类型都将隐式地向上强制转换为 Object。如果项是值类型，则必须在将其添加到列表中时进行装箱操作，在检索时进行取消装箱操作。强制转换以及装箱和取消装箱操作都会降低性能；
 在必须对大型集合进行循环访问的情况下，装箱和取消装箱的影响非常明显。”
*/

//List的基础、常用方法：
//声明方法一：
List<T> mList = new List<T>();  //T为列表中元素类型，现在以string类型作为例子
//E.g.： 
List<string> mList = new List<string>();

//声明方法二：
List<T> testList =new List<T> (IEnumerable<T> collection);   //以一个集合作为参数创建List
//E.g.：
string[] temArr = { "Ha", "Hunter", "Tom", "Lily", "Jay", "Jim", "Kuku", "Locu" };
List<string> testList = new List<string>(temArr); 

//添加元素:
List. Add(T item)   //添加一个元素
//E.g.：    
mList.Add("John");

List. AddRange(IEnumerable<T> collection)   //添加一组元素
//E.g.：
string[] temArr = { "Ha","Hunter", "Tom", "Lily", "Jay", "Jim", "Kuku",  "Locu" };
mList.AddRange(temArr);

Insert(int index, T item);    //在index位置添加一个元素
//E.g.：    
mList.Insert(1, "Hei"); 

//遍历List中元素:

foreach (T element in mList)  //T的类型与mList声明时一样
    {
        Console.WriteLine(element);
    }
//E.g.：
foreach (string s in mList)
    {
        Console.WriteLine(s);
    }

//删除元素:
List. Remove(T item)       //删除一个值
//E.g.:
mList.Remove("Hunter");

List. RemoveAt(int index);   //删除下标为index的元素
//E.g.：   
mList.RemoveAt(0);

List. RemoveRange(int index, int count); //从下标index开始，删除count个元素
//E.g.：   
mList.RemoveRange(3, 2); 

//判断某个元素是否在该List中：

List. Contains(T item)   //返回true或false，很实用
//E.g.：
if (mList.Contains("Hunter"))
    {
        Console.WriteLine("There is Hunter in the list");
    }
else
    {
        mList.Add("Hunter");
        Console.WriteLine("Add Hunter successfully.");
    }

//给List里面元素排序：
List. Sort ()   //默认是元素第一个字母按升序
//E.g.：   
mList.Sort();

//给List里面元素顺序反转：
List. Reverse ()   //可以与List. Sort ()配合使用，达到想要的效果
//E.g.：   
mList.Reverse();

//List清空：
List. Clear () 
//E.g.：   
mList.Clear();

//获得List中元素数目：
List. Count ()    //返回int值
//E.g.：
int count = mList.Count();
Console.WriteLine("The num of elements in the list: " +count);

//List的进阶、强大方法：
//
//举例用的List：
string[] temArr = { Ha","Hunter", "Tom", "Lily", "Jay", "Jim", "Kuku", " "Locu" };
mList.AddRange(temArr);

List.Find     //搜索与指定谓词所定义的条件相匹配的元素，并返回整个 List 中的第一个匹配元素。 
public T Find(Predicate<T> match); //Predicate是对方法的委托，如果传递给它的对象与委托中定义的条件匹配，则该方法返回 true。当前 List 的元素被逐个传递给Predicate委托，并在 List 中向前移动，从第一个元素开始，到最后一个元素结束。当找到匹配项时处理即停止。Predicate 可以委托给一个函数或者一个拉姆达表达式:

//委托给拉姆达表达式：
//E.g.：
//name是变量，代表的是mList中元素，自己设定
string listFind = mList.Find
(name =>  
    {
        if (name.Length > 3) 
        {
            return true;
        }
            return false;
    }
);
Console.WriteLine(listFind);     //输出是Hunter

//委托给一个函数：
//E.g.：
string listFind1 = mList.Find(ListFind);  //委托给ListFind函数
Console.WriteLine(listFind);           //输出是Hunter

ListFind    //函数 
public bool ListFind(string name)
    {
        if (name.Length > 3)
        {
            return true;
        }
            return false;
    }
//这两种方法的结果是一样的。

List.FindLast    //搜索与指定谓词所定义的条件相匹配的元素，并返回整个 List 中的最后一个匹配元素。 
public T FindLast(Predicate<T> match);  //用法与List.Find相同。

List.TrueForAll   //确定是否 List 中的每个元素都与指定的谓词所定义的条件相匹配。
public bool TrueForAll(Predicate<T> match);

//委托给拉姆达表达式：
//E.g.：
    bool flag = mList.TrueForAll
    (name =>
        {
            if (name.Length > 3)
                {
                    return true;
                }
            else
                {
                    return false;
                }
        }
    );
   Console.WriteLine("True for all:  "+flag);  //flag值为false

//委托给一个函数，这里用到上面的ListFind函数：
//E.g.：
bool flag = mList.TrueForAll(ListFind); //委托给ListFind函数
Console.WriteLine("True for all:  "+flag);  //flag值为false
//这两种方法的结果是一样的。

List.FindAll    //检索与指定谓词所定义的条件相匹配的所有元素。
public List<T> FindAll(Predicate<T> match);
//E.g.：
List<string> subList = mList.FindAll(ListFind); //委托给ListFind函数
    foreach (string s in subList)
        {
            Console.WriteLine("element in subList: "+s);
        }
//这时subList存储的就是所有长度大于3的元素

List.Take(n)    //获得前n行 返回值为IEnumetable<T>，T的类型与List<T>的类型一样
//E.g.：
IEnumerable<string> takeList=  mList.Take(5);
    foreach (string s in takeList)
        {
              Console.WriteLine("element in takeList: " + s);
        }
//这时takeList存放的元素就是mList中的前5个

List.Where  //检索与指定谓词所定义的条件相匹配的所有元素。跟List.FindAll方法类似。
//E.g.：
IEnumerable<string> whereList = mList.Where
(name =>
    {
        if (name.Length > 3)
            {
                return true;
            }
        else
            {
                return false;
            }
    }
);
        foreach (string s in subList)
            {
                Console.WriteLine("element in subList: "+s);
            }
//这时subList存储的就是所有长度大于3的元素

List.RemoveAll      //移除与指定的谓词所定义的条件相匹配的所有元素。
public int RemoveAll(Predicate<T> match);
//E.g.：
mList.RemoveAll
(name =>
    {
        if (name.Length > 3)
            {
                return true;
            }
        else
            {
                return false;
            }
    }
);
    foreach (string s in mList)
        {
            Console.WriteLine("element in mList:     " + s);
        }
//这时mList存储的就是移除长度大于3之后的元素。

//List<T> 是一个泛型链表...T表示节点元素类型
//比如
List<int> intList;  //表示一个元素为int的链表
intList.Add(34); //添加
intList.Remove(34);//删除
intList.RemoveAt(0); //删除位于某处的元素
intList.Count; //链表长度

/*
还有Insert,Find,FindAll,Contains等方法,也有索引方法 intList[0] = 23;
1.减少了装箱拆箱
2.便于编译时检查数据类型
List<Object>就相当于 System.Collections命名空间里面的List
即通过参数化类型来实现在同一份代码上操作多种数据类型。泛型编程是一种编程范式，它利用“参数化类型”将类型抽象化，从而实现更为灵活的复用。

C#泛型的作用概述:
1. C#泛型赋予了代码更强的类型安全，更好的复用，更高的效率，更清晰的约束。
2. 排序

先说1. 类型安全：
在一个方法中，一个变量的值是可以作为参数，但其实这个变量的类型本身也可以作为参数。泛型允许我们在调用的时候再指定这个类型参数是什么。
在.net中，泛型能够给我们带来的两个明显的好处是--类型安全和减少装箱、拆箱。
*/
public class Person  //假设我们现在有一个人员集合：创建Person类型
    {  
        private string name;  
        private int age;  
        
        public Person(string Name, int Age) //构造函数  
        {  
            this.age = Age;  
            this.name = Name;  
        }  

        public string Name  
        {  
            set { this.name = value; }  
            get { return name; }  
        }

        public int Age  
        {  
            set { this.age = value; }  
            get { return age; }  
        }  
    } 

/*
我们在程序的入口点处运行 以下在集合中增加了一个其他类型的对象，但插入数据的时候并没有报错，编译也可以通过。
但把“谁是功夫之王？”这样的字段转换成人员的时候出问题了，这说明ArrayList是类型不安全的。
*/
    static void Main(string[] args)  
    {  
        ArrayList peoples = new ArrayList();  
        peoples.Add(new Person("成龙", 18));  
        peoples.Add(new Person("李小龙", 17));  
        peoples.Add("谁是功夫之王？");  
        foreach (Person person in peoples)  
        {  
            Console.WriteLine(person.Name + "今年" + person.Age + "岁。");  
        }  
    } 

    static void Main(string[] args)  
    {  
        List< Person> peoples = new List< Person>();  //因此在此处中我们创建一个人员的泛型，当要向里面插入其他类型的时候，编译器就会报错
        peoples.Add(new Person("成龙", 18));  
        peoples.Add(new Person("李小龙", 17));  
        peoples.Add("谁是功夫之王？");  
        foreach (Person person in peoples)  
        {  
        Console.WriteLine(person.Name + "今年" + person.Age + "岁。");  
        }  
    } 

/*
再说2. 排序
泛型作为一种集合，排序是不可或缺的。排序基于比较，要排序，首先要比较。一个对象可以有多个比较规则，但只能有一个默认规则，默认规则放在定义该对象的类中。
默认规则在CompareTo方法中定义，该方法属于IComparable< T>泛型接口。
*/
    public class Person :IComparable< Person>   
    {  
        。。。。。。  
        public int CompareTo(Person p) //此处增加一个按年龄排序比较器  
        {  
            return this.Age - p.Age;  
        }  
    }  
        
    static void Main(string[] args)  
    {  
        List< Person> peoples = new List< Person>();  
        
        peoples.Add(new Person("陈小龙", 18));  
        peoples.Add(new Person("李小龙", 17));  
        peoples.Add(new Person("房小龙", 23));  
        peoples.Add(new Person("张小龙", 42));  
        peoples.Sort(); //不带参数的Sort()方法对集合进行排序  
        
        foreach (Person person in peoples)  
        {  
            Console.WriteLine(person.Name + "今年" + person.Age + "岁。");  
        }  
    } 

