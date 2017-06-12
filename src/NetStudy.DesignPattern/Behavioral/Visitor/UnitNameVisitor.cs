using System;
using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Behavioral.Visitor
{
    public class UnitNameVisitor : IVisitor
    {
        public void Visit(Unit unit)
        {
            Console.WriteLine($"{unit.Name}");
        }
    }
}