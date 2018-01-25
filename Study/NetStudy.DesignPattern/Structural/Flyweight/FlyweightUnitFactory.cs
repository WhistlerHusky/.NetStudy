using System;
using NetSutdy.DesignPattern.Shared.Units;
using System.Collections.Generic;

namespace NetSutdy.DesignPattern.Structural.Flyweight
{
    public class FlyweightUnitFactory 
    {
        private IDictionary<Type, Unit> Flyweights = new Dictionary<Type, Unit>();

        public FlyweightUnitFactory()
        {
            var marine = new SmartMarine();
            var firebat = new FireBat();

            Flyweights.Add(marine.GetType(), marine);
            Flyweights.Add(firebat.GetType(), firebat);
        }
        public Unit GetFlyweight(Type unitType)
        {
            return Flyweights[unitType];
        }
    }
}
