using System;
using System.Collections.Generic;

namespace NetSutdy.DesignPattern.Shared.Units
{
    public class Troopship : Unit
    {
        protected IList<Unit> _units = new List<Unit>();

        public bool TryLoadUnit(Unit unit)
        {
            if (_units.Count < 8)
            {
                _units.Add(unit);
                Console.WriteLine($"{unit.Name} get on the {GetType().Name}");
                return true;
            }

            return false;
        }
    }
}
