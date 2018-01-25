using System;

namespace NetStudy.InDepth.Task
{
    public class FooBar
    {
        public async void Biz() 
        {
            await Foo();
        }
        public System.Threading.Tasks.Task Foo()
        {
            return System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                System.Threading.Tasks.Task.Delay(2000);
                Console.WriteLine("Done!");
            });
        }
    }
}
