using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo.Models
{
    public delegate bool TransactionDelegate(Transaction transaction,Account account);
    public class MulticastDelegateProcessor
    {
        public static bool ValidateTransaction(Transaction transaction,Account account)
        {
         Console.WriteLine($"Validating Accounts {transaction.FromAccount}=> {transaction.ToAccount}" );
         bool valid= (string.IsNullOrEmpty(transaction.FromAccount) && string.IsNullOrEmpty(transaction.ToAccount)) ? false : true;
           if(!valid)
            {
                Console.WriteLine("Transaction is invalid");
            }
           return valid;
        }

        public static bool CheckBalance(Transaction transaction, Account account)
        {
            Console.WriteLine($"Checking balance for {transaction.FromAccount}");
            if(transaction.Amount > account.Balance)
            {
                Console.WriteLine("Insufficient balance");
                return false;
            }
            return true;
        }

        public static bool DeductAmount(Transaction transaction, Account account)
        {
            Console.WriteLine($"Deducting amount from {transaction.FromAccount}");
            account.Balance -= transaction.Amount;
            return true;
        }
        public static bool SendNotification(Transaction transaction, Account account)
        {
            Console.WriteLine($"Sending notification to {transaction.FromAccount}");
            Console.WriteLine($"Available balance is {account.Balance}");
            return true;
        }
        public static bool WatchTransaction(Transaction transaction, Account account, TransactionDelegate transactionDelegate)
        {
            bool allSuccessful = true;
            foreach (TransactionDelegate transactionDelegateItem in transactionDelegate.GetInvocationList())
            {
                try
                {
                    bool result = transactionDelegateItem(transaction, account);
                    if (!result)
                    {
                        allSuccessful = false;
                        Console.WriteLine($"{transactionDelegateItem.Method.Name} failed");
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{transactionDelegateItem.Method.Name} failed with exception {ex.Message}");
                    allSuccessful = false;
                    break;
                }
            }
            return allSuccessful;
        }

        public static void ProcessTransaction(Transaction transaction, Account account)
        {
           
            TransactionDelegate transactionDelegate = null;
            transactionDelegate += ValidateTransaction;
            transactionDelegate += CheckBalance;
            transactionDelegate += DeductAmount;
            transactionDelegate += SendNotification;
           
            //invocation
            WatchTransaction(transaction, account, transactionDelegate);

        }

    }
}
