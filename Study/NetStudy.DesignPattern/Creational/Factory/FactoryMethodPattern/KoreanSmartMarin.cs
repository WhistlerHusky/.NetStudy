﻿using NetSutdy.DesignPattern.Shared.Weapon;
using AttackableUnit = NetSutdy.DesignPattern.Shared.Units.AttackableUnit;

namespace NetSutdy.DesignPattern.Creational.Factory.FactoryMethodPattern
{
    public class KoreanSmartMarine : AttackableUnit
    {
        public KoreanSmartMarine() : base()
        {
            _currentHp = 40;
        }

        public KoreanSmartMarine(IWeapon weapon) : this()
        {
            _weapon = weapon;
        }
    }
}
