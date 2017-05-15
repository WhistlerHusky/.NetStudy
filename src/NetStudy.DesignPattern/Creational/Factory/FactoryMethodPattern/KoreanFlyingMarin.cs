using NetSutdy.DesignPattern.Shared;
using NetSutdy.DesignPattern.Shared.Units;
using NetSutdy.DesignPattern.Shared.Weapon;

namespace NetSutdy.DesignPattern.Creational.Factory.FactoryMethodPattern
{
    public class KoreanFlyingMarine : AttackableUnit
    {
        public KoreanFlyingMarine() : base()
        {
        }

        public KoreanFlyingMarine(IWeapon weapon)
        {
            _hp = 30;

            _weapon = weapon;
        }
    }
}