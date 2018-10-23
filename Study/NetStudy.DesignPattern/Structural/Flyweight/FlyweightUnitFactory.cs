using System;
using NetSutdy.DesignPattern.Shared.Units;
using System.Collections.Generic;

namespace NetSutdy.DesignPattern.Structural.Flyweight
{
    public class FlyweightUnitFactory 
    {
        private IDictionary<Type, Unit> _flyweights = new Dictionary<Type, Unit>();

        public FlyweightUnitFactory()
        {
            var marine = new SmartMarine();
            var firebat = new FireBat();

            _flyweights.Add(marine.GetType(), marine);
            _flyweights.Add(firebat.GetType(), firebat);
        }
        public Unit GetFlyweight(Type unitType)
        {
            return _flyweights[unitType];
        }
    }
}
