using NetStudy.Core;
using NetStudy.DifficultSubject.Variant;
using NetSutdy.DesignPattern.Behavioral;
using NetSutdy.DesignPattern.Behavioral.Observer.ObserverPull;
using NetSutdy.DesignPattern.Behavioral.Observer.ObserverPush;
using NetSutdy.DesignPattern.Behavioral.Strategy;

namespace NetStudy.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            IRunner runner = new VariantRunner();
            runner.Run();
        }
    }
}