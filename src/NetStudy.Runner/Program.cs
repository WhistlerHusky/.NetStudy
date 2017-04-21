
using NetStudy.Core;
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
            //IRunner runner = new VariantRunner();
            //IRunner runner = new StrategyPattern();
            //IRunner runner = new ObserverPatternPush();
            IRunner runner = new ObserverPatternPull();
            
            runner.Run();
        }
    }
}