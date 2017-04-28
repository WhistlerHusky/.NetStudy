using System;
using NetSutdy.DesignPattern.Behavioral.Strategy;

namespace NetSutdy.DesignPattern.Creational.Factory
{
    public class MarinFactory
    {
        public static AttackableUnit CreateMarin(string marinName)
        {
            IWeapon gun = new Gun();

            Console.WriteLine("Enter either 1 or 2 to create mainB: 1. SmartMarin 2. SuperMarin");
            var userInput = Console.ReadLine();
            AttackableUnit marin = null;

            switch (userInput)
            {
                case "1":
                    marin = new SmartMarin(gun);
                    marin.Name = "Smart " + marinName;
                    break;
                case "2":
                    marin = new SuperMarin(gun);
                    marin.Name = "Super " + marinName;
                    break;
                case "3":
                    marin = new FlyingMarin(gun);
                    marin.Name = "Flying " + marinName;
                    break;
                default:
                    throw new NotImplementedException("Wrong input entered");
            }

            return marin;
        }
    }
}
