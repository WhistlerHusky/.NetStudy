using NetSutdy.DesignPattern.Shared.Weapon;
using AttackableUnit = NetSutdy.DesignPattern.Shared.Units.AttackableUnit;

namespace NetSutdy.DesignPattern.Creational.Factory.FactoryMethodPattern
{
    public class UsaSmartMarine : AttackableUnit
    {
        public UsaSmartMarine() 
        {
            _weapon = new LaserGun();
        }

        public UsaSmartMarine(IWeapon weapon)
        {
            _currentHp = 40;

            _weapon = weapon;
        }
    }
}
