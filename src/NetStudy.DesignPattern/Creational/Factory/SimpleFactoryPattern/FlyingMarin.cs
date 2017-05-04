using System;
using NetSutdy.DesignPattern.Behavioral.Strategy;
using NetSutdy.DesignPattern.Shared;

namespace NetSutdy.DesignPattern.Creational.Factory.SimpleFactoryPattern
{
    public class FlyingMarine : AttackableUnit
    {
        public FlyingMarine(IWeapon weapon)
        {
            _hp = 60;

            _weapon = weapon;
        }
    }
}