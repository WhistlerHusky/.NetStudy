using System;
using NetSutdy.DesignPattern.Shared.Units;
using NetSutdy.DesignPattern.Shared.Weapon;

namespace NetSutdy.DesignPattern.Behavioral.Mediator
{
    public class SpeakableStupidMarine : SpeakableUnit
    {
        public SpeakableStupidMarine()
        {
            _currentHp = 40;
            _weapon = new Gun();
        }
        
        public void Fire(Unit unit)
        {
            int initDamage = 5;

            unit.GotDamage(initDamage);
        }

        public override void Attack(Unit unit)
        {
            //CurrentHp가 0이하로 내려가면 죽은거임.
            if (_currentHp <= 0)
            {
                return;
            }

            Console.WriteLine($"{Name} attacks {unit.Name}");

            Fire(unit);
        }
    }
}
