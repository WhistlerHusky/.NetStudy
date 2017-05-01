using NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern;
using NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.MarineSettingFactory;

namespace NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.Marines
{
    public class UsaFlyingMarine : AttackableUnit
    {
        private IMarineSettingFactory _marineSettingFactory;

        public UsaFlyingMarine(IMarineSettingFactory marineSettingFactory)
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