using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadDemo.Models
{
    public class LocalStateDemo
    {
        static ThreadLocal<int>threadLocalData = new ThreadLocal<int>(() => 0);


        public static void Run()
        {
            Thread t1 = new Thread(Counter);
            Thread t2 = new Thread(Counter);
            Thread t3 = new Thread(Counter);
            t1.Start();
            t2.Start();
            t3.Start();

        }

        public static void Counter()
        {
            if (!threadLocalData.IsValueCreated)
            {
                Console.WriteLine("Thread Local Data is not created");
            }
            Console.WriteLine("Thread Local Data Value: {0}", threadLocalData.Value);
            threadLocalData.Value++;
            Console.WriteLine("Thread Local Data Value: {0}", threadLocalData.Value);
        }
       
    }


}
