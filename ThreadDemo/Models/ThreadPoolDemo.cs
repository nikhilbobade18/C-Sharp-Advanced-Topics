using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadDemo.Models
{
    public class ThreadPoolDemo
    {
        public static void Entry()
        {
            ThreadPool.SetMinThreads(2, 2);
            ThreadPool.SetMaxThreads(4, 4);
            ThreadPool.GetMinThreads(out int minWorkerThreads, out int minCompletionPortThreads);
            ThreadPool.GetMaxThreads(out int maxWorkerThreads, out int maxCompletionPortThreads);
            Console.WriteLine("Min Worker Threads: {0}, Min Completion Port Threads: {1}", minWorkerThreads, minCompletionPortThreads);
            Console.WriteLine($"Thread Count{ThreadPool.ThreadCount}");
            ThreadPool.GetAvailableThreads(out int availableWorkerThreads, out int availableCompletionPortThreads);
            Console.WriteLine("Available Worker Threads: {0}, Available Completion Port Threads: {1}", availableWorkerThreads, availableCompletionPortThreads);
            long customerId = 0;
            Console.WriteLine("Banking System Started\n");
            for(int i = 0; i < 100; i++)
            {
                customerId = new Random().NextInt64(10000,10000000);
                ThreadPool.QueueUserWorkItem(ProcessTransactions, customerId);
            }
            Thread.Sleep(5000);
            Console.WriteLine("Banking System Started\n");
        }



        public static void ProcessTransactions(object customerIdInstance)
        {
            long customerId = (long)customerIdInstance;

            Console.WriteLine("Processing transactions for customer {0}", customerId);
            Thread.Sleep(2000);
            Console.WriteLine("Transactions processed for customer {0}", customerId);

        }
    }
}
