using System;
using NetStudy.Core;
using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Structural.Flyweight
{
    public class FlyweightPatternRunner : IRunner
    {
        public void Run()
        {
            var flyweightUnitFactory = new FlyweightUnitFactory();
            Unit unit = null;

            while (true)
            {
                Console.WriteLine("Enter 1 or 2");
                Console.WriteLine("1. SmartMarine");
                Console.WriteLine("2. Firebat");
                var key = Console.ReadLine();
                unit = flyweightUnitFactory.GetFlyweight(key == "1" ? typeof(SmartMarine) : typeof(FireBat));
                Console.WriteLine($"Unit type : { unit.GetType().Name}");
                Console.WriteLine($"Unit Max HP : { unit.MaxHp }");

                Console.WriteLine($"Would you like to change unit? [Y/N]");

                key = Console.ReadLine();
                if (key.ToLower() == "n")
                    break;
            }

            Console.WriteLine($"You select unit : { unit.GetType().Name}");
        }
    }
}
