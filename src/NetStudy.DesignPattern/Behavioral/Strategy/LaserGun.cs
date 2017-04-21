
namespace NetSutdy.DesignPattern.Behavioral.Strategy
{
    public class LaserGun : IWeapon
    {
        public int UpgradeLvl { get; set; } = 0;

        public void Fire(Unit unit)
        {
            int initDamage = 8;

            unit.GotDamage(initDamage);
        }
    }
}
