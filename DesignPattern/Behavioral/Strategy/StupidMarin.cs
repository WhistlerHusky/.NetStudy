using System;

namespace NetSutdy.DesignPattern.Behavioral.Strategy
{
    public class StupidMarin : Unit, IWeapon
    {
        public StupidMarin()
        {
            _hp = 40;
        }

        public int UpgradeLvl { get; set; } = 0;

        public void Fire(Unit unit)
        {
            int initDamage = 5;

            unit.GotDamage(initDamage);
        }

        public void Attach(Unit unit)
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
