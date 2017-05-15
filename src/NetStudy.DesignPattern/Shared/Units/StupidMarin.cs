using NetSutdy.DesignPattern.Shared.Weapon;
using System;

namespace NetSutdy.DesignPattern.Shared.Units
{
    public class StupidMarine : AttackableUnit
    {
        public StupidMarine()
        {
            _hp = 40;
            _weapon = new Gun();
        }
        
        public void Fire(Unit unit)
        {
            int initDamage = 5;

            unit.GotDamage(initDamage);
        }

        public override void Attack(Unit unit)
        {
            //HP가 0이하로 내려가면 죽은거임.
            if (_hp <= 0)
            {
                return;
            }

            Console.WriteLine($"{Name} attacks {unit.Name}");

            Fire(unit);
        }
    }
}
