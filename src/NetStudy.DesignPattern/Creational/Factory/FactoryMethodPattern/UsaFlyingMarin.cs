using NetSutdy.DesignPattern.Shared;
using NetSutdy.DesignPattern.Shared.Weapon;
using AttackableUnit = NetSutdy.DesignPattern.Shared.Units.AttackableUnit;

namespace NetSutdy.DesignPattern.Creational.Factory.FactoryMethodPattern
{
    public class UsaFlyingMarine : Shared.Units.AttackableUnit
    {
        public UsaFlyingMarine() : base()
        {
        }

        public UsaFlyingMarine(IWeapon weapon)
        {
            _hp = 40;

            _weapon = weapon;
        }
    }
}