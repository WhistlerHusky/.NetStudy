using NetSutdy.DesignPattern.Behavioral.Strategy;
using NetSutdy.DesignPattern.Shared;
using NetSutdy.DesignPattern.Shared.Bulletproofvest;
using NetSutdy.DesignPattern.Shared.Weapon;

namespace NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.MarineSettingFactory
{
    public class KoreanMarineSettingFactory : IMarineSettingFactory
    {
        public IWeapon GetWeapon()
        {
            return new DoubleGun();
        }

        public IBulletProofVest GetBulletProofVest()
        {
            return new KoreanBulletProofVest();
        }
    }
}
