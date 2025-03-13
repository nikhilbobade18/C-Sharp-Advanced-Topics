using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadDemo.Models
{
    public class ManualResetEventDemo
    {
        public static ManualResetEvent manualResetEvent = new ManualResetEvent(false);

        //consumer
        public static void UseFlapDoor(object employee)
        {
            Console.WriteLine("Employee {0} is waiting for the door to open", employee);
            //wait()
            manualResetEvent.WaitOne();//wait for the door to open
            Console.WriteLine("Employee {0} has passed through the door", employee);
        }

        //producer
        public static void OpenFlapDoor()
        {
            Thread.Sleep(2000);
            Console.WriteLine("The door is now open");
            //notify()
            manualResetEvent.Set(); //allow all waiting threads to pass
        }

        public static void ControlDoor()
        {
            for (int i = 0; i < 10; i++)
            {
                new Thread(UseFlapDoor).Start($"employee{i}");
            }
            Thread.Sleep(1000);
            new Thread(OpenFlapDoor).Start();
        }

    }
}
