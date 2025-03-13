using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadDemo.Models
{
   public class AnimationThread
    {

        public static void ThreadStart()
        {
            Thread currentThread=Thread.CurrentThread;
            if(currentThread.Name== null)
            {
                currentThread.Name = "Main Thread";
            }
            Console.WriteLine($"Thread Name={Thread.CurrentThread.Name}");
            Thread thread = new Thread(new ParameterizedThreadStart(AnimateName));
            thread.Start("Parameswari");     
            thread.Join();
        }

        public static void AnimateName(object name)
        {

            
            name.ToString().ToCharArray().ToList().ForEach(c =>
            {
                Console.Write(c);
                Thread.Sleep(500);
            });
        }
    }
}
