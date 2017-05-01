using System;
using NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.Marines;
using NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.MarineSettingFactory;

namespace NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern
{
    public class UsaSmartMarine : AttackableUnit
    {
        private IMarineSettingFactory _marineSettingFactory;

        public UsaSmartMarine(IMarineSettingFactory marineSettingFactory)
        {
            _marineSettingFactory = marineSettingFactory;
        }

        public override void GetReadyToFight()
        {
            _weapon = _marineSettingFactory.GetWeapon();
            _bulletProofVest = _marineSettingFactory.GetBulletProofVest();
        }
    }
}
