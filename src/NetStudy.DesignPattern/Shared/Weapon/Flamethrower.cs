using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Shared.Weapon
{
    public class Flamethrower : IWeapon
    {
        public void Fire(Unit unit)
        {
            int initDamage = 15;

            unit.GotDamage(initDamage);
            unit.GotDamage(initDamage);
        }
    }
}
