
namespace NetSutdy.DesignPattern.Shared.Weapon
{
    public class LaserGun : IWeapon
    {
        public void Fire(Unit unit)
        {
            int initDamage = 8;

            unit.GotDamage(initDamage);
        }
    }
}
