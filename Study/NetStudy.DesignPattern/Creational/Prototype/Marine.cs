using NetSutdy.DesignPattern.Behavioral.Strategy;
using NetSutdy.DesignPattern.Shared;
using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Creational.Prototype
{
    public class Marine : AttackableUnit, ICloneable
    {
        public ICloneable Clone()
        {
            var clone = MemberwiseClone() as Marine;

            return clone;
        }
    }
}
