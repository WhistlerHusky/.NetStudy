using System;

namespace NetSutdy.DesignPattern.Behavioral.Strategy
{
    public class StupidMarine : Unit, IWeapon
    {
        public StupidMarine()
        {
            _hp = 40;
        }

        public void Fire(Unit unit)
        {
            int initDamage = 5;

            unit.GotDamage(initDamage);
        }

        public void Attack(Unit unit)
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
