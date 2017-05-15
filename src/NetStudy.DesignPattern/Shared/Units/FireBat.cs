using NetSutdy.DesignPattern.Shared.Weapon;

namespace NetSutdy.DesignPattern.Shared.Units
{
    public class FireBat : AttackableUnit
    {
        public FireBat() : base()
        {
        }
        public FireBat(IWeapon weapon)
        {
            _hp = 40;

            _weapon = weapon;
        }
    }
}
