using System;
using NetSutdy.DesignPattern.Behavioral.Strategy;
using NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.Bulletproofvest;

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
