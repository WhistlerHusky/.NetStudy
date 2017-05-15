using NetSutdy.DesignPattern.Shared;
using NetSutdy.DesignPattern.Shared.Weapon;
using AttackableUnit = NetSutdy.DesignPattern.Shared.AttackableUnit;

namespace NetSutdy.DesignPattern.Creational.Factory.FactoryMethodPattern
{
    public class KoreanSmartMarine : Shared.AttackableUnit
    {
        public KoreanSmartMarine() : base()
        {
            _hp = 40;
        }

        public KoreanSmartMarine(IWeapon weapon) : this()
        {
            _weapon = weapon;
        }
    }
}
