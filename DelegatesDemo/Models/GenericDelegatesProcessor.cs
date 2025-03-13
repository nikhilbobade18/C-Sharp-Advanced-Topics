using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo.Models
{
   public class GenericDelegatesProcessor
    {
        public static void ProcessGenericDelegate(List<Transaction> transactions,Account account)
        {
            Func<Transaction, Account, bool> validateTransaction = new
                Func<Transaction, Account, bool>(CheckBalance);

            Console.WriteLine($"Transaction is valid {validateTransaction(transactions[0], account)}");
            
            Action<List<Transaction>> action = new 
                Action<List<Transaction>>(SumTransactionAmount);
            action(transactions);

            Predicate<Transaction> predicate = 
                new Predicate<Transaction>(ValidateTransaction);
            predicate(transactions[0]);

        }

        public static bool CheckBalance(Transaction transaction, Account account)
        {
            Console.WriteLine($"Checking balance for {transaction.FromAccount}");
            if (transaction.Amount > account.Balance)
            {
                Console.WriteLine("Insufficient balance");
                return false;
            }
            return true;
        }
        public static bool ValidateTransaction(Transaction transaction)
        {
            Console.WriteLine($"Validating Accounts {transaction.FromAccount}=> {transaction.ToAccount}");
            bool valid = (string.IsNullOrEmpty(transaction.FromAccount) && string.IsNullOrEmpty(transaction.ToAccount)) ? false : true;
            if (!valid)
            {
                Console.WriteLine("Transaction is invalid");
            }
            return valid;
        }
        public static void SumTransactionAmount(List<Transaction> transactions)
        {
           Console.WriteLine($"Total Transaction Amount={transactions.Sum(t => t.Amount)}");
        }

    }


}
