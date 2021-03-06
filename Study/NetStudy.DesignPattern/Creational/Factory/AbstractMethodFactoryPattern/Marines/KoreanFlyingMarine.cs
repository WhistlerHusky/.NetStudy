﻿using NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.MarineSettingFactory;
using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.Marines
{
    public class KoreanFlyingMarine : AttackableUnit
    {
        private IMarineSettingFactory _marineSettingFactory;

        public KoreanFlyingMarine(IMarineSettingFactory marineSettingFactory)
        {
            _marineSettingFactory = marineSettingFactory;
            _weapon = _marineSettingFactory.GetWeapon();
            _bulletProofVest = _marineSettingFactory.GetBulletProofVest();
        }
    }
}