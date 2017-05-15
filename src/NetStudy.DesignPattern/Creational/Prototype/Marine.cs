using NetSutdy.DesignPattern.Behavioral.Strategy;
using NetSutdy.DesignPattern.Shared;

namespace NetSutdy.DesignPattern.Creational.Prototype
{
    public class Marine : AttackableUnit, ICloneable
    {
        public ICloneable Clone()
        {
            var clone = this.MemberwiseClone() as Marine;

            return clone;
        }
    }
}
