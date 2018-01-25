using System;
using NetStudy.Core;
using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Structural.Facade
{
    public class FacadePatternRunner : IRunner
    {
      
        public void Run()
        {
            //인구수가 200을 넘던지, Mineral 혹은 Gas가 다 부족하다는 메시지가 출력될때까지 반복
            //Facade 사용하지 않은 경우

            //RunWithoutFacade();

            RunWithFacade();
        }

        private void RunWithFacade()
        {
            StarcraftFacade facade = new StarcraftFacade();

            while (true)
            {
                UnitType unitType = InputUnitNumber();

                Unit unit = facade.CreateUnit(unitType);
                if (unit == null)
                {
                    break;
                }
            }
        }

        private void RunWithoutFacade()
        {
            while (true)
            {
                UnitType unitType = InputUnitNumber();

                var requiredSupplyNumber = UnitHelper.GetSupplyNumber(unitType);

                if (StarcraftResources.CurrentSupplyNumber + requiredSupplyNumber > 200)
                {
                    Console.WriteLine("Supply limmit cannot exceed 200");
                    break;
                }

                var requiredMinerals = UnitHelper.GetRequiredMinerals(unitType);
                if (StarcraftResources.CurrentMinerals < requiredMinerals)
                {
                    Console.WriteLine("Not enough minerals");
                    break;
                }

                var requiredGas = UnitHelper.GetRequiredGas(unitType);
                if (StarcraftResources.CurrentGas < requiredGas)
                {
                    Console.WriteLine("Not enough gas");
                    break;
                }

                var unit = UnitFactory.CreateUnit(unitType);
                Console.WriteLine($"{unit.GetType().Name} is created");

                StarcraftResources.CurrentGas -= requiredGas;
                StarcraftResources.CurrentMinerals -= requiredMinerals;
                StarcraftResources.CurrentSupplyNumber += requiredSupplyNumber;

                Console.WriteLine();
            }
        }

        private static UnitType InputUnitNumber()
        {
            Console.WriteLine($"Current Mineral : {StarcraftResources.CurrentMinerals}");
            Console.WriteLine($"Current Gas : {StarcraftResources.CurrentGas}");
            Console.WriteLine($"Current Supply : {StarcraftResources.CurrentSupplyNumber}");
            Console.WriteLine("Enter 1, 2 or 3 to create a unit");
            Console.WriteLine("1.Marine : 50 Mineral, 1 Supply count");
            Console.WriteLine("2.Firebat : 50 Mineral, 25 Gas, 1 Supply count");
            Console.WriteLine("3.Medic : 50 Mineral, 50 Gas, 1 Supply count");

            var key = Console.ReadLine();
            Enum.TryParse(key, out UnitType unitType);

            return unitType;
        }
    }
}
