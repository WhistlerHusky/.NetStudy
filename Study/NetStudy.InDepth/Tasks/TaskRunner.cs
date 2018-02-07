using NetStudy.Core;

namespace NetStudy.InDepth.Tasks
{
    public class TaskRunner : IRunner
    {
        public void Run()
        {
            FooBar bar = new FooBar();

            bar.Biz();
        }
    }
}
