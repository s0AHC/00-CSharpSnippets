using System;
using System.Collections.Generic;

namespace CourseDelegate
{
    class Program
    {
        // Define some customized delegates
        // 自定义一些代理
        public delegate int CustomizedIntDelegate(int OperandA,int OperandB);  
        public delegate double CustomizedDblDelegate(Double OperandA,double OperandB); 

        // Define a customized generic delegate
        // 自定义一个泛型代理
        public delegate void CustomedGenericDelegate<T>(T OperandA,T OperandB);
        static void Main(string[] args)
        {
            /*
            Use system defined delegate class: Action and Func      
            使用公司定义的delegate类型: Action and Func 
            */
            
            //Example: Action, for subroutine. 
            //本例: Action，用于无法返回的函数
            Action<int, int> multiplication=new Action<int, int>(MyMath.Multiplication); //Attention: just put method's name in Action invoke, suffix no more ()"
            Action<int, int> subtraction=new Action<int, int>(MyMath.Subtraction);
            multiplication(100,200);  //invoke used, but as you see at below it can be omitted!
            subtraction(300,50);  //invoke was omitted!

            //Example: Func, for function
            //本例: Func, 用于有返回值得的函数
            Func<int, int, int> add =new Func<int,int,int>(MyMath.Add);
            System.Console.WriteLine($"Func delegate, add return: {add(100,32)}");;
            Func<double,double,double> divide=new Func<double,double,double>(MyMath.Divide);
            System.Console.WriteLine($"Func delegate, divide return: {divide(400,2)}");;

            CustomizedIntDelegate cdAdd=new CustomizedIntDelegate(MyMath.Add);
            var v= cdAdd(300, 500);
            
            System.Console.WriteLine( value: $"Customed delegate Add method: {v}");
            CustomizedDblDelegate cdDiv=new CustomizedDblDelegate(MyMath.Divide);
            var v1 = cdDiv(1000.00,200.00);
            System.Console.WriteLine(value: $"Customed delegate Divide method: {v1}");

            CustomedGenericDelegate<int> cgdIntMul=new CustomedGenericDelegate<int>(MyMath.Multiplication);
            CustomedGenericDelegate<double> cgdDblSub=new CustomedGenericDelegate<double>(MyMath.DblSubtraction);

            cgdIntMul(20,300);
            cgdDblSub(999,333);

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
            public static void DblSubtraction(double OperandA,double OperandB)=>System.Console.WriteLine($"Generic delegate, Double Subtraction: {OperandA-OperandB}");
        }
    }
}