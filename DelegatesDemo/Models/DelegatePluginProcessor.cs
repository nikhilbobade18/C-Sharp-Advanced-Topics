using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo.Models
{
    public delegate bool TransactionDelegatePlugin(Transaction transactions, Account account);
    public class DelegatePluginProcessor
    {
        public static void ProcessDelegatePlugin(List<Transaction> transactions, Account account)
        {

            InvokeMethodPlugin(transactions, account, ValidateTransaction).ToList().ForEach(t => {
                if (t)
                {
                    Console.WriteLine($"Transaction is valid {t}");
                   
                }
            });

            InvokeMethodPlugin(transactions, account, CheckBalance).ToList().ForEach(t => {
                if (t)
                {
                    Console.WriteLine($"Transaction is valid{t}");
                    return;
                }
            });

        }
        public static bool ValidateTransaction(Transaction transaction, Account account)
        {
            Console.WriteLine($"Validating Accounts {transaction.FromAccount}=> {transaction.ToAccount}");
            bool valid = (string.IsNullOrEmpty(transaction.FromAccount) && string.IsNullOrEmpty(transaction.ToAccount)) ? false : true;
            if (!valid)
            {
                Console.WriteLine("Transaction is invalid");
            }
            return valid;
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


        public static bool[] InvokeMethodPlugin(List<Transaction> transactions,
            Account account, TransactionDelegatePlugin transactionDelegatePlugin)
        {

            bool[] results = new bool[transactions.Count];
            for (int i = 0; i < transactions.Count; i++)
            {
                results[i] = transactionDelegatePlugin(transactions[i], account);
            }
            return results;
        }

    }
    
    }
