using System;
using System.Timers;

namespace CourseEvent01
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Event source: timer is an Event source.
            Timer timer=new Timer();  
            timer.Interval=1500;
            Boy boy=new Boy();

            // 2. Event: Elapsed就是timer这个事件拥有者的事件
            // 5. 事件订阅: boy.Action方法的作为事件处理器，订阅了timer的Elapsed事件。订阅符号是+=。
            timer.Elapsed+=boy.Action;
        }        
    }

    // 3. Event responder: event responder should has an Event handler to Subscribe the Event
    // 事件响应者，事件响应者应该有一个方法叫事件处理器用于订阅事件
    class Boy
    {
        // 4. Event handler: Action是Boy这个事件响应者的事件处理器方法
        internal void Action(object sender, ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
