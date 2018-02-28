using NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.MarineSettingFactory;
using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.Marines
{
    public class UsaFlyingMarine : AttackableUnit
    {
        private IMarineSettingFactory _marineSettingFactory;

        public UsaFlyingMarine(IMarineSettingFactory marineSettingFactory)
        {
            _marineSettingFactory = marineSettingFactory;

            _weapon = _marineSettingFactory.GetWeapon();
            _bulletProofVest = _marineSettingFactory.GetBulletProofVest();
        }
    }
}