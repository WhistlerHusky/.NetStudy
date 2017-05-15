using NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.MarineSettingFactory;
using System;
using NetSutdy.DesignPattern.Shared;

namespace NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.Marines
{
    public class UsaMarineFactory : MarineFactory
    {
        public override AttackableUnit CreateMarine(string marineType)
        {
            AttackableUnit marine = null;
            IMarineSettingFactory marineSettingFactory = new UsaMarineSettingFactory();

            switch (marineType)
            {
                case "1":
                    marine = new UsaFlyingMarine(marineSettingFactory);
                    break;
                case "2":
                    marine = new UsaSmartMarine(marineSettingFactory);
                    break;
                default:
                    throw new NotImplementedException("There are only 2 types, 1 and 2");
            }

            return marine;
        }
    }
}
