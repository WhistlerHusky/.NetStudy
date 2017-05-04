using System;
using NetSutdy.DesignPattern.Behavioral.Strategy;
using NetSutdy.DesignPattern.Shared;

namespace NetSutdy.DesignPattern.Creational.Factory.FactoryMethodPattern
{
    public class UsaSmartMarine : AttackableUnit
    {
        public UsaSmartMarine() 
        {
            _weapon = new LaserGun();
        }

        public UsaSmartMarine(IWeapon weapon)
        {
            _hp = 40;

            _weapon = weapon;
        }
    }
}
