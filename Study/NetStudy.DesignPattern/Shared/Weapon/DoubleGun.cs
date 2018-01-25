using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Shared.Weapon
{
    public class DoubleGun : IWeapon
    {
        public int Damage { get; } = 6;

        public void Fire(Unit unit)
        {
            unit.GotDamage(Damage);
            unit.GotDamage(Damage);
        }
    }
}
