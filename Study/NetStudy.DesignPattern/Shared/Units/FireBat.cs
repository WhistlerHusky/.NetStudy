using NetSutdy.DesignPattern.Shared.Weapon;

namespace NetSutdy.DesignPattern.Shared.Units
{
    public class FireBat : AttackableUnit
    {
        public FireBat() : base()
        {
            MaxHp = 60;
        }
        public FireBat(IWeapon weapon)
        {
            _currentHp = 40;

            _weapon = weapon;
        }
    }
}
