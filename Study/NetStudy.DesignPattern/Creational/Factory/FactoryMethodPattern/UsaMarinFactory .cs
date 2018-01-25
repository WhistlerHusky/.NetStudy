using System;
using NetSutdy.DesignPattern.Behavioral.Strategy;
using NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.Marines;
using NetSutdy.DesignPattern.Shared;
using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Creational.Factory.FactoryMethodPattern
{
    public class UsaMarineFactory : MarineFactory
    {
        public override AttackableUnit CreateMarine(string marineType)
        {
            AttackableUnit marine = null;

            switch (marineType)
            {
                case "1":
                    marine = new UsaFlyingMarine();
                    break;
                case "2":
                    marine = new UsaSmartMarine();
                    break;
                default:
                    throw new NotImplementedException("There are only 2 types, 1 and 2");
            }

            return marine;
        }
    }
}
