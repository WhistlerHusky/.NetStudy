using System;
using NetSutdy.DesignPattern.Behavioral.Strategy;
using NetSutdy.DesignPattern.Shared;

namespace NetSutdy.DesignPattern.Creational.Factory.FactoryMethodPattern
{
    public class KoreanSmartMarine : AttackableUnit
    {
        public KoreanSmartMarine() : base()
        {
            _hp = 40;
        }

        public KoreanSmartMarine(IWeapon weapon) : this()
        {
            _weapon = weapon;
        }
    }
}
