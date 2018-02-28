
using System;
using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Structural.Decorator
{
    public class Stimpack : Decorator
    {
        public Stimpack() : base()
        {
        }
        public Stimpack(AttackableUnit smartMarine) : base(smartMarine)
        {
            _currentHp = smartMarine.CurrentHp;
            _weapon = smartMarine.GetWeapon();
            Name += "Stimpack " + smartMarine.Name;
            Console.WriteLine($"'{smartMarine.Name} uses stimpack'");
        }

        public override void Attack(Unit unit)
        {
            base.Attack(unit);
            base.Attack(unit);
        }
    }
}
