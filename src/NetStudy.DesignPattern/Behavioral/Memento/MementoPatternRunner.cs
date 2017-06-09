using System;
using NetStudy.Core;
using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Behavioral.Memento
{

    public class MementoPatternRunner : IRunner
    {
        public void Run()
        {
            AttackableUnit stupidMarine = new StupidMarine();
            stupidMarine.Name = "Stupid Marine";

            AttackableUnit smartMarin = new SmartMarine();
            smartMarin.Name = "Smart Marine";

            //Create memento obj before fighting.
            var ct = new CareTaker();
            ct.Memento = smartMarin.CreateMemento();

            for (int i = 0; i < 7; i++)
            {
                stupidMarine.Fire(smartMarin);
            }

            Console.WriteLine($"Current smart marine hp = {smartMarin.CurrentHp}");
            Console.WriteLine();

            smartMarin.RestoreMemento(ct.Memento);
            Console.WriteLine($"smart marine hp after restoring memento = {smartMarin.CurrentHp}");
        }
    }
}
