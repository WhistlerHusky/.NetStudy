using Greeter;
using NetStudy.Core;
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
            //runner = new VisitorPatternRunn   er();
            //runner = new SpecificationRunner();
            //runner = new CastleWinsorRunner();
            //runner = new RedisRunner();
            //runner = new SpanRunner();
            //runner = new LinqRunner();
            //runner = new CSharpScriptingRunner();
            //Task.Run(async () => await CSharpScript.EvaluateAsync("Debug.WriteLine(\"Hello world!\")")).Wait();
            //runner = new DataStructureRunner();
            //runner = new ElasticsearchLowLevelRunner();
            //runner = new ElasticsearchHighLevelRunner();
            //runner = new ParallelRunner();
            //runner = new ResharperRunner();
            //runner = new NewLanguageFeaturesRunner();
            //runner = new AutoMapperRunner();
            //runner = new BTreeRunner();
            //runner = new XmlDtdRunner();
            runner = new GrpcServerRunner();
            runner.Run();

            runner = new GrpcClientRunner();
            runner.Run();

            //runner = new ReactiveRunner();
            //runner.Run();

            //runner = new ChannelRunner();
            //runner.Run();

            Console.ReadKey();
        }
    }
}