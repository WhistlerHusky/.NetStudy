using System;
using NetSutdy.DesignPattern.Shared.Units;
using NetSutdy.DesignPattern.Shared.Weapon;

namespace NetSutdy.DesignPattern.Creational.Factory.SimpleFactoryPattern
{
    public class MarineFactory
    {
        public static AttackableUnit CreateMarine(string marineName)
        {
            IWeapon gun = new Gun();

            Console.WriteLine($"Enter either 1 or 2 to create {marineName} type: 1. SmartMarine 2. SuperMarine");
            var userInput = Console.ReadLine();
            AttackableUnit marine = null;

            switch (userInput)
            {
                case "1":
                    marine = new SmartMarine(gun);
                    marine.Name = "Smart " + marineName;
                    break;
                case "2":
                    marine = new SuperMarine(gun);
                    marine.Name = "Super " + marineName;
                    break;
                case "3":
                    marine = new FlyingMarine(gun);
                    marine.Name = "Flying " + marineName;
                    break;
                default:
                    throw new NotImplementedException("Wrong input entered");
            }

            return marine;
        }
    }
}
