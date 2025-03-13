// See https://aka.ms/new-console-template for more information
using ThreadDemo.Models;

//AnimationThread.ThreadStart();
//BankAccountThread.BankThreadStart();
//Thread[] threads = new Thread[50];
//for (int i = 0; i < 50; i++)
//{
//   threads[i]= new Thread(() => SemaphoreDemo.UseFlapDoor("Employee " + i));
//    if (i % 2 == 0)

//        threads[i].Priority = ThreadPriority.Highest;
//    else
//        threads[i].Priority = ThreadPriority.Lowest;
//    threads[i].Start();
//    //threads[i].Join();

//}

//LocalStateDemo.Run();

//ManualResetEventDemo.ControlDoor();
//ThreadPoolDemo.Entry();
new TaskDemo().Entry().Wait();