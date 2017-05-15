using System;
using NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.MarineSettingFactory;
using NetSutdy.DesignPattern.Shared;

namespace NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.Marines
{
    public class KoreanMarineFactory : MarineFactory
    {
        public override AttackableUnit CreateMarine(string marineType)
        {
            AttackableUnit marine = null;

            IMarineSettingFactory marineSettingFactory = new KoreanMarineSettingFactory();

            switch (marineType)
            {
                case "1":
                    marine = new KoreanFlyingMarine(marineSettingFactory);
                    break;
                case "2":
                    marine = new KoreanFactorySmartMarine(marineSettingFactory);
                    break;
                default:
                    throw new NotImplementedException("There are only 2 types, 1 and 2");
            }

            return marine;
        }
    }
}
