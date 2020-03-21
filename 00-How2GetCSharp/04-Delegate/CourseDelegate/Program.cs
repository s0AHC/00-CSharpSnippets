using System;

namespace CourseDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Use system defined delegate class: Action and Func      
            使用公司定义的delegate类型: Action and Func 
            */
            
            //Example: Action, for subroutine. 
            //本例: Action，用于无法返回的函数
            Action<int, int> multiplication=new Action<int, int>(MyMath.Multiplication); //Attention: just put method's name in Action invoke, don't need()
            Action<int, int> subtraction=new Action<int, int>(MyMath.Subtraction);
            multiplication(100,200);
            subtraction(300,50);

            //Example: Func, for function
            //本例: Func, 用于有返回值得的函数
            Func<int, int, int> add =new Func<int,int,int>(MyMath.Add);
            System.Console.WriteLine($"Func delegate, add return: {add(100,32)}");;
            Func<double,double,double> divide=new Func<double,double,double>(MyMath.Divide);
            System.Console.WriteLine($"Func delegate, divide return: {divide(400,2)}");;
        }
        
        class MyMath
        {
            //Function
            //返回函数
            public static int Add(int OperandA, int OperandB) => OperandA + OperandB;

            public static double Divide(double OperandA, double OperandB) => OperandA / OperandB;

            //Subroutine
            //功能方法
            public static void Multiplication(int OperandA, int OperandB) => Console.WriteLine($"Action delegation,Multiplication: {OperandA * OperandB}");
            public static void Subtraction(int OperandA, int OperandB) => Console.WriteLine($"Action delegation,Subtraction: {OperandA - OperandB}");
        }
    }
}