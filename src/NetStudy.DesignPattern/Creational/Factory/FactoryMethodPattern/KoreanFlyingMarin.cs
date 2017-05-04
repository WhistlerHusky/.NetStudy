using System;
using NetSutdy.DesignPattern.Behavioral.Strategy;
using NetSutdy.DesignPattern.Shared;

namespace NetSutdy.DesignPattern.Creational.Factory.FactoryMethodPattern
{
    public class KoreanFlyingMarine : AttackableUnit
    {
        public KoreanFlyingMarine() : base()
        {
        }

        public KoreanFlyingMarine(IWeapon weapon)
        {
            _hp = 30;

            _weapon = weapon;
        }
    }
}