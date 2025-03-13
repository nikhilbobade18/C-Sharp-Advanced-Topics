using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesDemo.Models
{
    public delegate void OTPDelegate(int value);
    public class SimpleEvent
    {
        public event OTPDelegate OTPEvent;

        public void RaiseOTPEvent(int max)
        {
            Random random = new Random();
            OTPEvent(random.Next(max));
        }

        public void SendNotification(int otp)
        {
            Console.WriteLine($"OTP is generated={otp}");
        }

        public static void ProcessEvent( int max)
        {
            SimpleEvent simpleEvent = new SimpleEvent();
            simpleEvent.OTPEvent += simpleEvent.SendNotification;
            simpleEvent.RaiseOTPEvent(max);
        }
    }
}
