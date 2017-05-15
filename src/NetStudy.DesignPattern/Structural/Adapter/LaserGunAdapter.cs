using System.CodeDom;
using System.Net;
using NetSutdy.DesignPattern.Shared;
using NetSutdy.DesignPattern.Shared.Weapon;

namespace NetSutdy.DesignPattern.Structural.Adapter
{
    public class LaserGunAdapter : IWeapon
    {
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
