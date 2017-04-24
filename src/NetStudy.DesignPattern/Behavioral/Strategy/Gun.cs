
namespace NetSutdy.DesignPattern.Behavioral.Strategy
{
    public class Gun : IWeapon
    {
        public void Fire(Unit unit)
        {
            int initDamage = 5;

            unit.GotDamage(initDamage);
        }
    }
}
