
namespace NetSutdy.DesignPattern.Behavioral.Strategy
{
    public class Gun : IWeapon
    {
        public int UpgradeLvl { get; set; } = 0;

        public void Fire(Unit unit)
        {
            int initDamage = 5;

            unit.GotDamage(initDamage);
        }
    }
}
