using System;
using NetSutdy.DesignPattern.Behavioral.Strategy;

namespace NetSutdy.DesignPattern.Creational.Factory.FactoryMethodPattern
{
    public class KoreanMarineFactory : MarineFactory
    {
        public override AttackableUnit CreateMarine(string marineType)
        {
            AttackableUnit marine = null;

            switch (marineType)
            {
                case "1":
                    marine = new KoreanFlyingMarine();
                    break;
                case "2":
                    marine = new KoreanSmartMarine();
                    break;
                default:
                    throw new NotImplementedException("There are only 2 types, 1 and 2");
            }

            return marine;
        }
    }
}
