using System;
using NetSutdy.DesignPattern.Behavioral.Strategy;

namespace NetSutdy.DesignPattern.Creational.Factory.FactoryMethodPattern
{
    public abstract class MarineFactory
    {
        public AttackableUnit CreateNewMarin(string marineType)
        {
            var marine = CreateMarine(marineType);
            marine.HP = 40;

            return marine;
        }
        public abstract AttackableUnit CreateMarine(string marineType);
    }
}
