using System;
using NetStudy.Core;
using NetSutdy.DesignPattern.Behavioral.Strategy;

namespace NetSutdy.DesignPattern.Creational.Factory
{
    public class FactoryPatternRunner : IRunner
    {
        //Before method
        //public void Run()
        //{
        //    IWeapon gun = new Gun();

        //    Console.WriteLine("Enter either 1 or 2 to create mainA: 1. SmartMarin 2. SuperMarin");
        //    var userInput = Console.ReadLine();

        //    AttackableUnit marinA = CreateMarin("Marin A");

        //    switch (userInput)
        //    {
        //        case "1":
        //            marinA = new SmartMarin(gun);
        //            marinA.Name = "Smart Marin A";
        //            break;
        //        case "2":
        //            marinA = new SuperMarin(gun);
        //            marinA.Name = "Super Marin A";
        //            break;
        //        default:
        //            throw new NotImplementedException("Wrong input entered");
        //    }

        //    Console.WriteLine("Enter either 1 or 2 to create mainB: 1. SmartMarin 2. SuperMarin");
        //    userInput = Console.ReadLine();
        //    AttackableUnit marinB = null;

        //    switch (userInput)
        //    {
        //        case "1":
        //            marinB = new SmartMarin(gun);
        //            marinA.Name = "Smart Marin B";
        //            break;
        //        case "2":
        //            marinB = new SuperMarin(gun);
        //            marinA.Name = "Super Marin B";
        //            break;
        //        default:
        //            throw new NotImplementedException("Wrong input entered");
        //    }

        //    marinA.Attack(marinB);
        //    Console.WriteLine();

        //    marinB.Attack(marinA);
        //    Console.WriteLine();
        //    //죽을때까지 싸움.
        //    while (marinA.HP > 0 && marinB.HP > 0)
        //    {
        //        marinA.Attack(marinB);
        //        Console.WriteLine();

        //        marinB.Attack(marinA);
        //        Console.WriteLine();
        //    }

        //    var winner = marinA.HP > 0 ? marinB.Name : marinA.Name;

        //    Console.WriteLine($"The winner is {winner}");
        //}

        //Before factory pattern 
        //public void Run()
        //{
        //    AttackableUnit marinA = CreateMarin("Marin A");
        //    AttackableUnit marinB = CreateMarin("Marin B");

        //    while (marinA.HP > 0 && marinB.HP > 0)
        //    {
        //        marinA.Attack(marinB);
        //        Console.WriteLine();

        //        marinB.Attack(marinA);
        //        Console.WriteLine();
        //    }

        //    var winner = marinA.HP > 0 ? marinA.Name : marinB.Name;

        //    Console.WriteLine($"The winner is {winner}");
        //}
        
        public void Run()
        {
            AttackableUnit marinA = MarinFactory.CreateMarin("Marin A");
            AttackableUnit marinB = MarinFactory.CreateMarin("Marin B");

            while (marinA.HP > 0 && marinB.HP > 0)
            {
                marinA.Attack(marinB);
                Console.WriteLine();

                marinB.Attack(marinA);
                Console.WriteLine();
            }

            var winner = marinA.HP > 0 ? marinA.Name : marinB.Name;

            Console.WriteLine($"The winner is {winner}");
        }

        //MarinFactory.cs 클래스로 이동
        //private AttackableUnit CreateMarin(string marinName)
        //{
        //    IWeapon gun = new Gun();

        //    Console.WriteLine("Enter either 1 or 2 to create mainB: 1. SmartMarin 2. SuperMarin");
        //    var userInput = Console.ReadLine();
        //    AttackableUnit marin = null;

        //    switch (userInput)
        //    {
        //        case "1":
        //            marin = new SmartMarin(gun);
        //            marin.Name = "Smart " + marinName;
        //            break;
        //        case "2":
        //            marin = new SuperMarin(gun);
        //            marin.Name = "Super" + marinName;
        //            break;
        //        default:
        //            throw new NotImplementedException("Wrong input entered");
        //    }

        //    return marin;
        //}
    }
}
