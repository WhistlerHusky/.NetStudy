using NetSutdy.DesignPattern.Behavioral.Strategy;
using NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.Bulletproofvest;
using NetSutdy.DesignPattern.Shared;

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
