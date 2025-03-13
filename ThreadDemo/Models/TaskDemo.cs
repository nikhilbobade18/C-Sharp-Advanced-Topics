using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadDemo.Models
{
   public class TaskDemo
    {
        private static decimal balance = 10000;


        public async Task Entry()
        {
            Task<decimal>[] tasks = new Task<decimal>[3];
            long customerId = 0;
            decimal amount = 0;
            for (int i = 0; i < tasks.Length; i++)
            {
                customerId = new Random().Next(1000, 10000);
                amount = new Random().Next(1000, 5000);
                tasks[i] = WithdrawMoneyAsync(customerId, amount);
                //sub task for receipt and history
                Task receiptTask = tasks[i].ContinueWith(previousTask =>
                {
                    decimal balance = previousTask.Result;
                    GenerateReceipt(customerId, 1000, balance);
                });
                Task historyTask = tasks[i].ContinueWith(previousTask =>
                {
                    decimal balance = previousTask.Result;
                    UpdateHistory(customerId, 1000, balance);
                });
            }

            decimal[] balances = await Task.WhenAll(tasks);
            Console.WriteLine("Banking System Closed....");
            balances.ToList().ForEach(b => Console.WriteLine($"Final Balance {b}"));
        }

        public async Task<decimal> WithdrawMoneyAsync(long customerId, decimal amount)
        {
            Console.WriteLine($"Available balance {balance} for Customer {customerId}");
            await Task.Delay(new Random().Next(1000, 5000));
            if (balance >= amount)
            {
                balance -= amount;
                Console.WriteLine($"Amount {amount} withdrawn successfully for Customer {customerId}");
                return balance;
            }
            else
            {
                Console.WriteLine($"Insufficient balance for Customer {customerId}");
                return balance;
            }

        }

        public static void GenerateReceipt(long customerId,decimal amount, decimal balance)
        {
            Console.WriteLine($"Receipt for Customer {customerId} withdrawn {amount}" +
                $" and having balance{balance}");
        }
        public static void UpdateHistory(long customerId, decimal amount, decimal balance)
        {
            Console.WriteLine($"Updating Transaction History for Customer {customerId} withdrawn {amount}" +
                $" and having balance{balance}");
        }
    }
}
