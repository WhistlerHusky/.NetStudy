using System;
using System.Collections.Generic;
using System.Text;
using NetSutdy.DesignPattern.Creational.Prototype;
using NetSutdy.DesignPattern.Shared.Units;
using NetSutdy.DesignPattern.Structural.Bridge;

namespace NetSutdy.DesignPattern.Structural.Facade
{
    public static class UnitFactory
    {
        public static Unit CreateUnit(UnitType unitType)
        {
            Unit unit;

            switch (unitType)
            {
                case UnitType.Marine:
                        unit = new Marine();
                        break;
                case UnitType.Firebat:
                    unit = new Firebat();
                    break;
                case UnitType.Medic:
                        unit = new Medic();
                    break;
                default:
                    unit = new Marine();
                    break;
            }

            return unit;
        }
    }
}
