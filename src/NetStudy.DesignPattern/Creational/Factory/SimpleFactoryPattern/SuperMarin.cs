using System;
using NetSutdy.DesignPattern.Behavioral.Strategy;
using NetSutdy.DesignPattern.Shared;
using NetSutdy.DesignPattern.Shared.Weapon;

namespace NetSutdy.DesignPattern.Creational.Factory.SimpleFactoryPattern
{
    public class SuperMarine : AttackableUnit
    {
        public SuperMarine(IWeapon weapon)
        {
            _hp = 60;

            _weapon = weapon;
        }
    }
}
