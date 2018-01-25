
using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Shared.Weapon
{
    public class Gun : IWeapon
    {
        public int Damage { get; } = 5;

        public void Fire(Unit unit)
        {
            unit.GotDamage(Damage);
        }
    }
}
