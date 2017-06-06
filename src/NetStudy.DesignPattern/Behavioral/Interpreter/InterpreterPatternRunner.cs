using System;
using System.Collections.Generic;
using System.Linq;
using NetStudy.Core;

namespace NetSutdy.DesignPattern.Behavioral.Interpreter
{
    public class InterpreterPatternRunner : IRunner
    {
        public void Run()
        {
            var currentMineral = 650;

            IList<Expression> list = new List<Expression>();
            list.Add(new BattleCruiserExpression());
            list.Add(new DropshipExpression());
            list.Add(new MarinExpression());

            Console.WriteLine($"With {currentMineral} mienrals");
            Console.WriteLine($"If you create only, ");
            foreach (var unit in list)
            {
                var availableUnitCount= unit.Interpret(currentMineral);

                Console.WriteLine($"    {unit.GetType().Name.Replace("Expression", "")}, then {availableUnitCount} can be created");
            }
            Console.WriteLine();

            Console.WriteLine($"If you create as many as possible from {string.Join(" -> ",list.Select(x => x.GetType().Name.Replace("Expression", "")))}");

            foreach (var unit in list)
            {
                Console.WriteLine($"Current mineral: {currentMineral}");

                var createdUnit = unit.CreateUnit(ref currentMineral);

                Console.WriteLine($"    {createdUnit} {unit.GetType().Name.Replace("Expression","")}");
            }

            Console.WriteLine();
            Console.WriteLine($"Current Mineral {currentMineral}");
        }
    }
}
