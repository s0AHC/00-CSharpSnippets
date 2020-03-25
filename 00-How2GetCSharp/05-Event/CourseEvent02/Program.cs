using System;

namespace CourseEvent02
{
    
    /*
        4. Event handler: remeber we use delegate to subscribe the Event.
            a. In the arguments list the HereIsEventSource specified the event source, 
            b. the EventArgs specified which information should be send to event responder 
    */
    public delegate void MyEventHandler(HereIsEventSource eventSource, EventNameEventArgs e);
    class Program
    {
        static void Main(string[] args)
        {
             
        }
    }

    // Define details arguments, this class should derived from EventArgs
    public class EventNameEventArgs:EventArgs
    {
        public string FirstArgs{get;set;}
        public string SecondArgs{get;set;}
    }

    // 1. Event source: This class define a event source
    public class HereIsEventSource
    {
        
    }
}
