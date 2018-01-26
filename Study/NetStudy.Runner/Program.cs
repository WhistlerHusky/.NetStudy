using NetStudy.Core;
using Redis;
using System;

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
            //runner = new DecoratorPatternRunner();
            //runner = new SimpleFactoryPatternRunner();
            //runner = new FactoryMethodPatternRunner();
            //runner = new AbstractFactoryMethodPatternRunner();
            //runner = new BuilderPatternRunner();
            //runner = new SingletonPatternRunner();
            //runner = new PrototypePatternRunner();
            //runner = new AdapterPatternRunner();
            //runner = new BridgePatternRunner();
            //runner = new CompositePatternRunner();
            //runner = new FacadePatternRunner();
            //runner = new FlyweightPatternRunner();
            //runner = new ProxyPatternRunner();
            //runner = new CommandPatternRunner();
            //runner = new InterpreterPatternRunner();
            //runner = new IteratorPatternRunner();
            //runner = new MediatorPatternRunner();
            //runner = new MementoPatternRunner();
            //runner = new StatePatternRunner();
            //runner = new TemplateMethodPatternRunner();
            //runner = new VisitorPatternRunner();
            //runner = new SpecificationRunner();
            //runner = new CastleWinsorRunner();
            runner = new RedisRunner();
            runner.Run();

            Console.ReadKey();
        }
    }
}