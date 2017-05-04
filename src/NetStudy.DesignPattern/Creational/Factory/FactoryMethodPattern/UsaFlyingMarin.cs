using System;
using NetSutdy.DesignPattern.Behavioral.Strategy;
using NetSutdy.DesignPattern.Shared;

namespace NetSutdy.DesignPattern.Creational.Factory.FactoryMethodPattern
{
    public class UsaFlyingMarine : AttackableUnit
    {
        public UsaFlyingMarine() : base()
        {
        }

        public UsaFlyingMarine(IWeapon weapon)
        {
            _hp = 40;

            _weapon = weapon;
        }
    }
}