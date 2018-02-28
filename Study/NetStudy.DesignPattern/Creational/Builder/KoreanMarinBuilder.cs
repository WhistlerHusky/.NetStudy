using NetSutdy.DesignPattern.Shared.Bulletproofvest;
using NetSutdy.DesignPattern.Shared.Weapon;

namespace NetSutdy.DesignPattern.Creational.Builder
{
    public class KoreanMarinBuilder : MarinBuilder
    {
        public KoreanMarinBuilder()
        {
            Marin = new KoreanSmartMarine();
        }
        public override MarinBuilder SetWeapon()
        {
            Marin.SetWeapon(new DoubleGun());
            return this;
        }

        public override MarinBuilder SetBulletProofVest()
        {
            Marin.SetBulletProofVest(new KoreanBulletProofVest());
            return this;
        }
    }
}
