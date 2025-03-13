using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadDemo.Models
{
    public class SemaphoreDemo
    {
        public static Semaphore semaphore = new Semaphore(4, 4);
        public static void UseFlapDoor(object employee)
        {
            Console.WriteLine(employee + " is waiting to use the flap door");
            semaphore.WaitOne();
            try
            {
                Console.WriteLine(employee + " is using the flap door");
                Thread.Sleep(2000);
                Console.WriteLine(employee + " has finished using the flap door");
            }
            finally
            {
                semaphore.Release();
                //Console.WriteLine(employee + " has left the flap door");
            }
        }
    }
}
