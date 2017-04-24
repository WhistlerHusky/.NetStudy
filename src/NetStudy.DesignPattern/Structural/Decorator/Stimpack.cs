
using System;
using NetSutdy.DesignPattern.Behavioral.Strategy;

namespace NetSutdy.DesignPattern.Structural.Decorator
{
    public class Stimpack : Decorator
    {
        public Stimpack(AttackableUnit smartMarin) : base(smartMarin)
        {
            _hp = smartMarin.HP;
            Name += "Stimpack " + smartMarin.Name;
            Console.WriteLine($"'{smartMarin.Name} uses stimpack'");
        }

        public override void Attack(Unit unit)
        {
            base.Attack(unit);
            base.Attack(unit);
        }
    }
}
