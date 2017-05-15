using NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.Marines;
using NetSutdy.DesignPattern.Shared;

namespace NetSutdy.DesignPattern.Creational.Builder
{
    public abstract class MarinBuilder
    {
        public AttackableUnit Marin { get; protected set; }

        public abstract MarinBuilder SetWeapon();
        public abstract MarinBuilder SetBulletProofVest();
    }
}
