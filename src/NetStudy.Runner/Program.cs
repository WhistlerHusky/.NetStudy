using NetStudy.Core;
using NetStudy.DifficultSubject.Variant;
using NetSutdy.DesignPattern.Behavioral.ChainOfResponsibility;
using NetSutdy.DesignPattern.Behavioral.Observer.ObserverPull;
using NetSutdy.DesignPattern.Behavioral.Observer.ObserverPush;
using NetSutdy.DesignPattern.Behavioral.Strategy;
using NetSutdy.DesignPattern.Creational.Factory;
using NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern;
using NetSutdy.DesignPattern.Creational.Factory.FactoryMethodPattern;
using NetSutdy.DesignPattern.Structural.Decorator;

namespace NetStudy.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            IRunner runner;
            //runner = new VariantRunner();
            //runner = new ObserverPatternPullRunner();
            //runner = new ObserverPatternPushRunner();
            //runner = new StrategyPatternRunner();
            //runner = new ChainOfResponsibilityRunner();
            //runner = new DecoratorRunner();
            //runner = new SimpleFactoryPatternRunner();
            //runner = new FactoryMethodPatternRunner();
            runner = new AbstractFactoryMethodPatternRunner();
            
            runner.Run();
        }
    }
}