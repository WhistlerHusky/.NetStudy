using NetSutdy.DesignPattern.Shared.Weapon;

namespace NetSutdy.DesignPattern.Shared.Units
{
    public class SmartMarine : AttackableUnit
    {
        public SmartMarine() : base()
        {
        }
        public SmartMarine(string name) : base()
        {
            Name = name;
        }
        public SmartMarine(IWeapon weapon)
        {
            _hp = 40;

            _weapon = weapon;
        }
    }
}
