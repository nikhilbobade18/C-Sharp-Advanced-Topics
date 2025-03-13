using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadDemo.Models
{
    public class BankAccountThread
    {

        public static void BankThreadStart()
        {
            BankAccount account = new BankAccount(new Random().Next(8000,10000));
            Console.WriteLine($"Final Balance: {account.GetBalance()}");
            Thread thread1 = new Thread(() => account.
            Withdraw(new Random().Next(5000, 8000)))
            { Name = "Customer 1" };
            Thread thread2 = new Thread(() => account.
            Withdraw(new Random().Next(5000, 10000)))
            { Name = "Customer 2" };
            thread1.Start();
            thread2.Start();
            thread1.Join();
            thread2.Join();
            Console.WriteLine($"Final Balance: {account.GetBalance()}");
        }
    }
}
