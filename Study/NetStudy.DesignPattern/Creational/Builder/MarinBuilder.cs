using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Creational.Builder
{
    public abstract class MarinBuilder
    {
        public AttackableUnit Marin { get; protected set; }

        public abstract MarinBuilder SetWeapon();
        public abstract MarinBuilder SetBulletProofVest();
    }
}
