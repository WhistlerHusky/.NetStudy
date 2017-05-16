using System;
using NetSutdy.DesignPattern.Behavioral.Strategy;
using NetSutdy.DesignPattern.Shared;
using NetSutdy.DesignPattern.Shared.Units;
using NetSutdy.DesignPattern.Shared.Weapon;

namespace NetSutdy.DesignPattern.Creational.Factory.SimpleFactoryPattern
{
    public class FlyingMarine : AttackableUnit
    {
        public FlyingMarine(IWeapon weapon)
        {
            _currentHp = 60;

            _weapon = weapon;
        }
    }
}