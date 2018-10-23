using System;
using System.Collections.Generic;

namespace NetSutdy.DesignPattern.Shared.Units
{
    public class Troopship : Unit
    {
        protected IList<Unit> Units = new List<Unit>();

        public bool TryLoadUnit(Unit unit)
        {
            if (Units.Count < 8)
            {
                Units.Add(unit);
                Console.WriteLine($"{unit.Name} get on the {GetType().Name}");
                return true;
            }

            return false;
        }
    }
}
