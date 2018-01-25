using NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.Marines;
using NetSutdy.DesignPattern.Shared;
using NetSutdy.DesignPattern.Shared.Bulletproofvest;
using NetSutdy.DesignPattern.Shared.Weapon;

namespace NetSutdy.DesignPattern.Creational.Builder
{
    public class UsaMarinBuilder : MarinBuilder
    {
        public UsaMarinBuilder()
        {
            Marin = new UsaSmartMarine();
        }
        public override MarinBuilder SetWeapon()
        {
            Marin.SetWeapon(new LaserGun());
            return this;
        }

        public override MarinBuilder SetBulletProofVest()
        {
            Marin.SetBulletProofVest(new UsaBulletProofVest());
            return this;
        }
    }
}
