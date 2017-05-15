using NetSutdy.DesignPattern.Shared.Weapon;

namespace NetSutdy.DesignPattern.Shared.Units
{
    public class SmartMarine : AttackableUnit
    {
        public SmartMarine() : base()
        {
        }
        public SmartMarine(IWeapon weapon)
        {
            _hp = 40;

            _weapon = weapon;
        }
    }
}
