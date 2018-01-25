using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Shared.Weapon
{
    public class Flamethrower : IWeapon
    {
        public int Damage { get; } = 15;

        public void Fire(Unit unit)
        {
            unit.GotDamage(Damage);
            unit.GotDamage(Damage);
        }
    }
}
