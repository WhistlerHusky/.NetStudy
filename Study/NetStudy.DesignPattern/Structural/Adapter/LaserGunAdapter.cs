using NetSutdy.DesignPattern.Shared.Units;
using NetSutdy.DesignPattern.Shared.Weapon;

namespace NetSutdy.DesignPattern.Structural.Adapter
{
    public class LaserGunAdapter : IWeapon
    {
        public int Damage { get; } = 0;

        private IGun _gun;

        public LaserGunAdapter(IGun gun)
        {
            _gun = gun;
        }

        public void Fire(Unit unit)
        {
            _gun.Shoot(unit);
        }
    }
}
