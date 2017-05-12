using System;
using NetStudy.Core;

namespace NetSutdy.DesignPattern.Creational.Prototype
{
    public class PrototypePatternRunner : IRunner
    {
        public void Run()
        {
            var marine = new Marine { Name = "Core Marine" };

            var cloneMarine = marine.Clone() as Marine;

            //The original instance's Name property has changed.
            marine.Name = "Net Marine";

            Console.WriteLine(marine.Name); //Net Marine
            Console.WriteLine(cloneMarine?.Name); // Core Marine
        }
    }
}
