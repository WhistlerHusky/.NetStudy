using NetStudy.Core;
using System;
using System.Reactive.Linq;
using System.Threading;

namespace RxNet
{
    public class ReactiveRunner : IRunner
    {
        public void Run()
        {
            Console.WriteLine("Shows use of Start to start on a background thread:");

            try
            {
                var o = Observable.Start(() =>
                {
                    //This starts on a background thread.
                    Console.WriteLine("From background thread. Does not block main thread.");
                    Console.WriteLine("Calculating...");
                    throw new NotImplementedException("test");
                    Thread.Sleep(3000);
                    Console.WriteLine("Background work completed.");
                }).Finally(() => Console.WriteLine("Main thread completed."));
                Console.WriteLine("\r\n\t In Main Thread...\r\n");
                o.Wait(); // Wait for completion of background operation.
            }
            catch (Exception e)
            {

            }
        }
    }
}
