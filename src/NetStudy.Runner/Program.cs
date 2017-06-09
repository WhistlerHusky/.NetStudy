using NetStudy.Core;
using NetStudy.DifficultSubject.Variant;
using NetSutdy.DesignPattern.Behavioral.ChainOfResponsibility;
using NetSutdy.DesignPattern.Behavioral.Command;
using NetSutdy.DesignPattern.Behavioral.Interpreter;
using NetSutdy.DesignPattern.Behavioral.Iterator;
using NetSutdy.DesignPattern.Behavioral.Mediator;
using NetSutdy.DesignPattern.Behavioral.Memento;
using NetSutdy.DesignPattern.Behavioral.Observer.ObserverPull;
using NetSutdy.DesignPattern.Behavioral.Observer.ObserverPush;
using NetSutdy.DesignPattern.Behavioral.Strategy;
using NetSutdy.DesignPattern.Creational.Builder;
using NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern;
using NetSutdy.DesignPattern.Creational.Factory.FactoryMethodPattern;
using NetSutdy.DesignPattern.Creational.Factory.SimpleFactoryPattern;
using NetSutdy.DesignPattern.Creational.Prototype;
using NetSutdy.DesignPattern.Creational.Singleton;
using NetSutdy.DesignPattern.Structural.Adapter;
using NetSutdy.DesignPattern.Structural.Bridge;
using NetSutdy.DesignPattern.Structural.Composite;
using NetSutdy.DesignPattern.Structural.Decorator;
using NetSutdy.DesignPattern.Structural.Facade;
using NetSutdy.DesignPattern.Structural.Flyweight;
using NetSutdy.DesignPattern.Structural.Proxy;

namespace NetStudy.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            IRunner runner;
            //runner = new VariantRunner();
            //runner.Run();
            //runner = new ObserverPatternPullRunner();
            //runner.Run();
            //runner = new ObserverPatternPushRunner();
            //runner.Run();
            //runner = new StrategyPatternRunner();
            //runner.Run();
            //runner = new ChainOfResponsibilityRunner();
            //runner.Run();
            //runner = new DecoratorPatternRunner();
            //runner.Run();
            //runner = new SimpleFactoryPatternRunner();
            //runner.Run();
            //runner = new FactoryMethodPatternRunner();
            //runner.Run();
            //runner = new AbstractFactoryMethodPatternRunner();
            //runner.Run();
            //runner = new BuilderPatternRunner();
            //runner.Run();
            //runner = new SingletonPatternRunner();
            //runner.Run();
            //runner = new PrototypePatternRunner();
            //runner.Run();
            //runner = new AdapterPatternRunner();
            //runner.Run();
            //runner = new BridgePatternRunner();
            //runner.Run();
            //runner = new CompositePatternRunner();
            //runner.Run();
            //runner = new FacadePatternRunner();
            //runner.Run();
            //runner = new FlyweightPatternRunner();
            //runner.Run();
            //runner = new ProxyPatternRunner();
            //runner.Run(); 
            //runner = new CommandPatternRunner();
            //runner.Run();
            //runner = new InterpreterPatternRunner();
            //runner.Run();
            //runner = new IteratorPatternRunner();
            //runner.Run();
            //runner = new MediatorPatternRunner();
            //runner.Run();
            runner = new MementoPatternRunner();
            runner.Run();
        }
    }
}