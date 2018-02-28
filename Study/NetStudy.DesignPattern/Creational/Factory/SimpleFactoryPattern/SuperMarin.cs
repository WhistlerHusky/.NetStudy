using NetSutdy.DesignPattern.Shared.Units;
using NetSutdy.DesignPattern.Shared.Weapon;

namespace NetSutdy.DesignPattern.Creational.Factory.SimpleFactoryPattern
{
    public class SuperMarine : AttackableUnit
    {
        public SuperMarine(IWeapon weapon)
        {
            _currentHp = 60;

            _weapon = weapon;
        }
    }
}
