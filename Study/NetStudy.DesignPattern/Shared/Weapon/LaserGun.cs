using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Shared.Weapon
{
    public class LaserGun : IWeapon
    {
        public int Damage { get; } = 8;

        public void Fire(Unit unit)
        {
            unit.GotDamage(Damage);
        }
    }
}
