using NetSutdy.DesignPattern.Shared.Weapon;

namespace NetSutdy.DesignPattern.Shared.Units
{
    public class SmartMarine : AttackableUnit
    {
        public SmartMarine() : base()
        {
            _currentHp = 40;
            MaxHp = 50;
            _weapon = new Gun();

        }
        public SmartMarine(string name) 
            : this()
        {
            Name = name;
        }
        public SmartMarine(IWeapon weapon)
            : this()
        {
            _weapon = weapon;
        }
    }
}
