using NetStudy.Core;
using NetSutdy.DesignPattern.Shared.Units;
using NetSutdy.DesignPattern.Shared.Weapon;
using System;
using System.Collections.Generic;

namespace NetSutdy.DesignPattern.Others.Specification
{
    public class SpecificationRunner : IRunner
    {
        public void Run()
        {
            //Director 이용
            var units = new List<AttackableUnit>();

            AttackableUnit unit1 = new SmartMarine();
            unit1.Name = "SmartMarine with DoubleGun";
            unit1.SetWeapon(new DoubleGun());
            units.Add(unit1);

            AttackableUnit unit2 = new SmartMarine();
            unit2.Name = "SmartMarine with LaserGun";
            unit2.SetWeapon(new LaserGun());
            units.Add(unit2);

            AttackableUnit unit3 = new FireBat();
            unit3.Name = "FireBat with Flamethrower";
            unit3.SetWeapon(new Flamethrower());
            units.Add(unit3);

            Console.WriteLine();
            Console.WriteLine("After using SmartMarin with DoubleGun specifications");
            var specs = new SmartMarinSpecification().And(new DoubleGunSpecification());
            PrintUnitFoundAfterUsingFilter(units, specs);

            Console.WriteLine();
            Console.WriteLine("After using SmartMarinspecifications only ");
            specs = new SmartMarinSpecification();
            PrintUnitFoundAfterUsingFilter(units, specs);

            Console.WriteLine();
            Console.WriteLine("After using FireBatSpecifications only");
            specs = new FireBatSpecification();
            PrintUnitFoundAfterUsingFilter(units, specs);
        }

        private static void PrintUnitFoundAfterUsingFilter(List<AttackableUnit> units, ISpecification<AttackableUnit> specs)
        {
            var unitsFound = units.FindAll(specs.IsSatisfiedBy);

            foreach (var unit in unitsFound)
            {
                Console.WriteLine($"{unit.Name} found");
            }
        }
    }
}
