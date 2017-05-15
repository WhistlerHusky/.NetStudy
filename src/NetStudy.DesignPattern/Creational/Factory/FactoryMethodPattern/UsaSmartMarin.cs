using NetSutdy.DesignPattern.Shared;
using NetSutdy.DesignPattern.Shared.Weapon;
using AttackableUnit = NetSutdy.DesignPattern.Shared.AttackableUnit;

namespace NetSutdy.DesignPattern.Creational.Factory.FactoryMethodPattern
{
    public class UsaSmartMarine : Shared.AttackableUnit
    {
        public UsaSmartMarine() 
        {
            _weapon = new LaserGun();
        }

        public UsaSmartMarine(IWeapon weapon)
        {
            _hp = 40;

            _weapon = weapon;
        }
    }
}
