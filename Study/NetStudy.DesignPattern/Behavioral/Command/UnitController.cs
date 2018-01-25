using System;
using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Behavioral.Command
{
    public class UnitController : IUnitController
    {
        public void CreateUnit(Unit unit, int x, int y)
        {
            Console.WriteLine($"{unit.GetType().Name} is careated at x:{x} , y:{y}");
        }

        public void DeleteUnit(Unit unit, int x, int y)
        {
            Console.WriteLine($"{unit.GetType().Name} at x:{x} , y:{y} is deleted");
        }
    }
}