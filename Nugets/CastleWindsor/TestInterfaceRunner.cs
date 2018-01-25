using System;
using NetStudy.Core;

namespace CastleWindsor
{
    public class TestInterfaceRunner : IRunner
    {
        /// <summary>
        /// Property Injection
        /// </summary>
        public ITestInterface TestInterface { get; set; }
        public void Run()
        {
            Console.WriteLine(TestInterface.GetClassName());
        }
    }
}