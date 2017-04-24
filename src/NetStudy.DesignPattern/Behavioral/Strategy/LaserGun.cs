
namespace NetSutdy.DesignPattern.Behavioral.Strategy
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
