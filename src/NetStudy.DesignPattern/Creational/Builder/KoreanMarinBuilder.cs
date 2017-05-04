using NetSutdy.DesignPattern.Behavioral.Strategy;
using NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.Bulletproofvest;

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
