using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo.Models
{
    public enum PaymentType
    {
        CreditCard,
        UPI,
        Wallet,
        NetBanking
    }
    public class DelegateProcessor
    {

        public delegate void PaymentProcessor(decimal amount);

        public static void CreditCardPayment(decimal amount)
        {
            Console.WriteLine($"Credit Card Payment of {amount} is processed");
        }

        public static void UPIPayment(decimal amount)
        {
            Console.WriteLine($"UPI Payment of {amount} is processed");
        }

        public static void WalletPayment(decimal amount)
        {
            Console.WriteLine($"Wallet Payment of {amount} is processed");
        }
        public static void NetBankingPayment(decimal amount)
        {
            Console.WriteLine($"NetBanking Payment of {amount} is processed");
        }

        public static void PerformDelegation()
        {
            PaymentProcessor paymentProcessor = null;
            PaymentType paymentType = GetRandomEnumValue<PaymentType>();
            Console.WriteLine($"Payment Type: {paymentType}");
            //deletegate pointing to the method
            switch (paymentType)
            {
                case PaymentType.CreditCard:
                    paymentProcessor = CreditCardPayment;
                    break;
                case PaymentType.UPI:
                    paymentProcessor = UPIPayment;
                    break;
                case PaymentType.Wallet:
                    paymentProcessor = WalletPayment;
                    break;
                case PaymentType.NetBanking:
                    paymentProcessor = NetBankingPayment;
                    break;
            }
            //deletgate invocation
            paymentProcessor(new Random().Next(1000000));


        }

        public static T GetRandomEnumValue<T>() where T : Enum
        {
            var v = Enum.GetValues(typeof(T));
            Random random = new Random();
            return (T)v.GetValue(new Random().Next(v.Length));
        }
    }
}
