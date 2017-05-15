using NetSutdy.DesignPattern.Shared;
using NetSutdy.DesignPattern.Shared.Units;
using NetSutdy.DesignPattern.Shared.Weapon;

namespace NetSutdy.DesignPattern.Behavioral.Strategy
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
