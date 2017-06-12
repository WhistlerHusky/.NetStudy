using System;

namespace NetSutdy.DesignPattern.Behavioral.TemplateMethod
{

    public abstract class TerranBuild
    {
        protected int _currentUnitCount  = 4;
        protected int _currentSupplyBlock = 10;

        public void PrepareWar()
        {
            Console.WriteLine($"Current unit {_currentUnitCount}/{_currentSupplyBlock}");

            CreateWorkers();

            //Abstract
            CreateBarracks();

            IncreaseAvailableUnitCount();
        }

        private void CreateWorkers()
        {
            for (int i = _currentUnitCount; i < 8; i++)
            {
                CreateSCV();
            }
        }

        private void IncreaseAvailableUnitCount()
        {
            Console.WriteLine("A supply depot is just created");
            _currentSupplyBlock += 8;
            Console.WriteLine($"Current Unit Count = {_currentUnitCount} / {_currentSupplyBlock}");
            Console.WriteLine();
        }

        private void CreateSCV()
        {
            Console.WriteLine("SCV is created");

            _currentUnitCount++;
            Console.WriteLine($"Current Unit Count = {_currentUnitCount} / {_currentSupplyBlock}");
            Console.WriteLine();
        }

        public abstract void CreateBarracks();
    }
}
