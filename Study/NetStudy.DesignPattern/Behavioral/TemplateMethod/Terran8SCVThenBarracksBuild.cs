using System;

namespace NetSutdy.DesignPattern.Behavioral.TemplateMethod
{
    public class Terran8SCVThenBarracksBuild : TerranBuild
    {
        public override void CreateBarracks()
        {
            Console.WriteLine("A barracks is just created");
            Console.WriteLine($"Current Unit Count = {_currentUnitCount} / {_currentSupplyBlock}");
            Console.WriteLine();
        }
    }
}
