using NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.Marines;
using NetSutdy.DesignPattern.Shared;

namespace NetSutdy.DesignPattern.Creational.Factory.FactoryMethodPattern
{
    public abstract class MarineFactory
    {
        public AttackableUnit CreateNewMarine(string marineType)
        {
            var marine = CreateMarine(marineType);
            marine.HP = 40;

            return marine;
        }
        public abstract AttackableUnit CreateMarine(string marineType);
    }
}
