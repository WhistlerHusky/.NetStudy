using NetSutdy.DesignPattern.Behavioral.Strategy;
using NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.Bulletproofvest;

namespace NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.MarineSettingFactory
{
    public interface IMarineSettingFactory
    {
        IWeapon GetWeapon();
        IBulletProofVest GetBulletProofVest();
    }
}
