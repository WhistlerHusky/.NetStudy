using NetSutdy.DesignPattern.Shared.Bulletproofvest;
using NetSutdy.DesignPattern.Shared.Weapon;

namespace NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.MarineSettingFactory
{
    public class UsaMarineSettingFactory : IMarineSettingFactory
    {
        public IWeapon GetWeapon()
        {
            return new LaserGun();
        }
        public IBulletProofVest GetBulletProofVest()
        {
            return new UsaBulletProofVest();
        }
    }
}
