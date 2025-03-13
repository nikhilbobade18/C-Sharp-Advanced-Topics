using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ThreadDemo.Models
{
    public class BankAccount
    {
        private int balance;
        //private readonly object balanceLock = new object();
        private static Mutex balanceLock = new Mutex();
        public BankAccount(int initialBalance)
        {
            balance = initialBalance;
        }
        public void Deposit(int amount)
        {
            balance += amount;
        }
        public void Withdraw(int amount)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} tries to withdraw {amount}");
             balanceLock.WaitOne();
            //lock (balanceLock)
            // {
            try
            {
                if (balance >= amount)
                {
                    Console.WriteLine($"Balance before Withdrawal: {GetBalance()}");
                    balance -= amount;
                    Console.WriteLine($"After Withdrawal {amount} Balance: {GetBalance()}");
                }
                else
                {
                    Console.WriteLine($"Insufficient Balance: {GetBalance()}");

                }
            }
            finally
            {
                balanceLock.ReleaseMutex();
            }
            //}


        }
        public int GetBalance()
        {
            return balance;
        }
    }
}
