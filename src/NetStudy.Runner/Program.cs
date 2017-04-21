
using NetStudy.Core;
using NetSutdy.DesignPattern.Behavioral.Strategy;

namespace NetStudy.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            //IRunner runner = new VariantRunner();
            IRunner runner = new StrategyPattern();

            runner.Run();
        }
    }
}