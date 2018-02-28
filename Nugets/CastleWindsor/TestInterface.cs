using Castle.Core.Logging;

namespace CastleWindsor
{
    public class TestInterface : ITestInterface
    {
        public ILogger Logger { get; set; }

        public string GetClassName()
        {
            Logger.Info("TestInterface Run Called");

            return nameof(TestInterface);
        }
    }
}