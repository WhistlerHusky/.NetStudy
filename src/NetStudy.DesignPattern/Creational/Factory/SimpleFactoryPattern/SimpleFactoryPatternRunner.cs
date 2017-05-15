using System;
using NetStudy.Core;
using NetSutdy.DesignPattern.Shared;

namespace NetSutdy.DesignPattern.Creational.Factory.SimpleFactoryPattern
{
    public class SimpleFactoryPatternRunner : IRunner
    {
        //Before method
        //public void Run()
        //{
        //    IWeapon gun = new Gun();

        //    Console.WriteLine("Enter either 1 or 2 to create mainA: 1. SmartMarine 2. SuperMarine");
        //    var userInput = Console.ReadLine();

        //    AttackableUnit marineA = CreateMarine("Marine A");

        //    switch (userInput)
        //    {
        //        case "1":
        //            marineA = new SmartMarine(gun);
        //            marineA.Name = "Smart Marine A";
        //            break;
        //        case "2":
        //            marineA = new SuperMarine(gun);
        //            marineA.Name = "Super Marine A";
        //            break;
        //        default:
        //            throw new NotImplementedException("Wrong input entered");
        //    }

        //    Console.WriteLine("Enter either 1 or 2 to create mainB: 1. SmartMarine 2. SuperMarine");
        //    userInput = Console.ReadLine();
        //    AttackableUnit marineB = null;

        //    switch (userInput)
        //    {
        //        case "1":
        //            marineB = new SmartMarine(gun);
        //            marineA.Name = "Smart Marine B";
        //            break;
        //        case "2":
        //            marineB = new SuperMarine(gun);
        //            marineA.Name = "Super Marine B";
        //            break;
        //        default:
        //            throw new NotImplementedException("Wrong input entered");
        //    }

        //    marineA.Attack(marineB);
        //    Console.WriteLine();

        //    marineB.Attack(marineA);
        //    Console.WriteLine();
        //    //죽을때까지 싸움.
        //    while (marineA.HP > 0 && marineB.HP > 0)
        //    {
        //        marineA.Attack(marineB);
        //        Console.WriteLine();

        //        marineB.Attack(marineA);
        //        Console.WriteLine();
        //    }

        //    var winner = marineA.HP > 0 ? marineB.Name : marineA.Name;

        //    Console.WriteLine($"The winner is {winner}");
        //}

        //Before factory pattern 
        //public void Run()
        //{
        //    AttackableUnit marineA = CreateMarine("Marine A");
        //    AttackableUnit marineB = CreateMarine("Marine B");

        //    while (marineA.HP > 0 && marineB.HP > 0)
        //    {
        //        marineA.Attack(marineB);
        //        Console.WriteLine();

        //        marineB.Attack(marineA);
        //        Console.WriteLine();
        //    }

        //    var winner = marineA.HP > 0 ? marineA.Name : marineB.Name;

        //    Console.WriteLine($"The winner is {winner}");
        //}
        
        public void Run()
        {
            AttackableUnit marineA = MarineFactory.CreateMarine("Marine A");
            AttackableUnit marineB = MarineFactory.CreateMarine("Marine B");

            while (marineA.HP > 0 && marineB.HP > 0)
            {
                marineA.Attack(marineB);
                Console.WriteLine();

                marineB.Attack(marineA);
                Console.WriteLine();
            }

            var winner = marineA.HP > 0 ? marineA.Name : marineB.Name;

            Console.WriteLine($"The winner is {winner}");
        }

        //MarineFactory.cs 클래스로 이동
        //private AttackableUnit CreateMarine(string marineName)
        //{
        //    IWeapon gun = new Gun();

        //    Console.WriteLine("Enter either 1 or 2 to create mainB: 1. SmartMarine 2. SuperMarine");
        //    var userInput = Console.ReadLine();
        //    AttackableUnit marine = null;

        //    switch (userInput)
        //    {
        //        case "1":
        //            marine = new SmartMarine(gun);
        //            marine.Name = "Smart " + marineName;
        //            break;
        //        case "2":
        //            marine = new SuperMarine(gun);
        //            marine.Name = "Super" + marineName;
        //            break;
        //        default:
        //            throw new NotImplementedException("Wrong input entered");
        //    }

        //    return marine;
        //}
    }
}
