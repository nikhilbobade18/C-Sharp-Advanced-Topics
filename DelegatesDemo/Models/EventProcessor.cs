using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo.Models
{
    public delegate void TransactionEventHandler(Transaction transaction);
    public class EventProcessor
    {
        //wrapper for delegate
        public event TransactionEventHandler OnTransactionCompleted;


        public void ProcessTransaction(Transaction transaction)
        {
            Console.WriteLine($"Processing Transaction {transaction.FromAccount} " +
                $"for the amount {transaction.Amount}");
            //event invocation
            OnTransactionCompleted(transaction);
        }

        public static void FraudDetection(Transaction transaction)
        {
            if (transaction.Amount > 10000000)
            {
                Console.WriteLine("Fraud Detected");
            }
            else
            {
                Console.WriteLine("Fraud Not Detected, No Suscpicious Activity");
            }
        }

        public static void SendNotification(Transaction transaction)
        {
            Console.WriteLine($"OTP Generated for {transaction.FromAccount} " +
                $"for the amount {transaction.Amount}={new Random().Next(1000,9999)}");
        }


        public static void ProcessTransactionEvent(Transaction transaction)
        {
            Console.WriteLine($"Processing Transaction {transaction.FromAccount} " +
                $"for the amount {transaction.Amount}");
            EventProcessor eventProcessor = new EventProcessor();
            eventProcessor.OnTransactionCompleted += FraudDetection;    
            eventProcessor.OnTransactionCompleted += SendNotification;
            eventProcessor.ProcessTransaction(transaction);
            Console.WriteLine($"Transaction Completed {transaction.FromAccount} " +
                $"for the amount {transaction.Amount}");
        }
    }



   
}
