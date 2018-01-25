using NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.Marines;
using NetSutdy.DesignPattern.Shared;
using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Creational.Factory.FactoryMethodPattern
{
    public abstract class MarineFactory
    {
        public AttackableUnit CreateNewMarine(string marineType)
        {
            var marine = CreateMarine(marineType);
            marine.CurrentHp = 40;

            return marine;
        }
        public abstract AttackableUnit CreateMarine(string marineType);
    }
}
