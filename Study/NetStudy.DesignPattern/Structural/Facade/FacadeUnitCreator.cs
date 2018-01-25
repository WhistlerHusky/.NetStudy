using System;
using NetStudy.Core;
using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Structural.Facade
{
    public class StarcraftFacade
    {
        public Unit CreateUnit(UnitType unitType)
        {
            var requiredSupplyNumber = UnitHelper.GetSupplyNumber(unitType);

            if (StarcraftResources.CurrentSupplyNumber + requiredSupplyNumber > 200)
            {
                Console.WriteLine("Supply limmit cannot exceed 200");
                return null;
            }

            var requiredMinerals = UnitHelper.GetRequiredMinerals(unitType);
            if (StarcraftResources.CurrentMinerals < requiredMinerals)
            {
                Console.WriteLine("Not enough minerals");
                return null;
            }

            var requiredGas = UnitHelper.GetRequiredGas(unitType);
            if (StarcraftResources.CurrentGas < requiredGas)
            {
                Console.WriteLine("Not enough gas");
                return null;
            }

            var unit = UnitFactory.CreateUnit(unitType);
            Console.WriteLine($"{unit.GetType().Name} is created");

            StarcraftResources.CurrentGas -= requiredGas;
            StarcraftResources.CurrentMinerals -= requiredMinerals;
            StarcraftResources.CurrentSupplyNumber += requiredSupplyNumber;

            Console.WriteLine();
            return unit;
        }
    }
}
