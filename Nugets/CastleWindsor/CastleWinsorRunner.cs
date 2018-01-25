using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using NetStudy.Core;

namespace CastleWindsor
{
    public class CastleWinsorRunner : IRunner
    {
        public void Run()
        {
            var container =
                new WindsorContainer().Install(installers: FromAssembly.Containing<CastleWinsorRunner>());

            container.Register(Component.For<IRunner>().ImplementedBy<TestInterfaceRunner>().LifestyleTransient());
            container.Register(Component.For<ITestInterface>().ImplementedBy<TestInterface>().LifestyleTransient());

            var runner = container.Resolve<IRunner>();
            runner.Run();
        }
    }
}