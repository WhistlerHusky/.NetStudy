using NetSutdy.DesignPattern.Shared;
using NetSutdy.DesignPattern.Shared.Weapon;
using AttackableUnit = NetSutdy.DesignPattern.Shared.Units.AttackableUnit;

namespace NetSutdy.DesignPattern.Creational.Factory.FactoryMethodPattern
{
    public class UsaFlyingMarine : AttackableUnit
    {
        public UsaFlyingMarine() : base()
        {
        }

        public UsaFlyingMarine(IWeapon weapon)
        {
            _currentHp = 40;

            _weapon = weapon;
        }
    }
}