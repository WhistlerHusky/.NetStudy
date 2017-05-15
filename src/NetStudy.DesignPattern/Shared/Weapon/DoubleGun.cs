using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Shared.Weapon
{
    public class DoubleGun : IWeapon
    {
        public void Fire(Unit unit)
        {
            int initDamage = 6;

            unit.GotDamage(initDamage);
            unit.GotDamage(initDamage);
        }
    }
}
