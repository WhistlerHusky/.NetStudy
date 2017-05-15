using NetSutdy.DesignPattern.Shared.Bulletproofvest;
using NetSutdy.DesignPattern.Shared.Weapon;

namespace NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.MarineSettingFactory
{
    public interface IMarineSettingFactory
    {
        IWeapon GetWeapon();
        IBulletProofVest GetBulletProofVest();
    }
}
