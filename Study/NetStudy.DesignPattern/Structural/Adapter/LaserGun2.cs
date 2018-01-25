using NetSutdy.DesignPattern.Shared.Units;
using System;

namespace NetSutdy.DesignPattern.Structural.Adapter
{
    public class LaserGun2 : IGun
    {
        public void Shoot(Unit unit)
        {
            int initDamage = 8;

            unit.GotDamage(initDamage);
            Console.WriteLine($"{GetType().Name} is used." );
        }
    }
}
