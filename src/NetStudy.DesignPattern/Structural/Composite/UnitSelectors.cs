using System;
using System.Collections.Generic;
using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Structural.Composite
{
    public class UnitSelectors : AttackableUnit
    {
        readonly IList<AttackableUnit> _attackableUnits = new List<AttackableUnit>();

        public override void Attack(Unit unit)
        {
            Console.WriteLine($"Group Attack started");

            foreach (var attackAbleUnit in _attackableUnits)
            {
                attackAbleUnit.Attack(unit);
                Console.WriteLine();
            }

            Console.WriteLine($"Group Attack ended");
        }

        public void AddAttackAbleUnit(AttackableUnit unit)
        {
            _attackableUnits.Add(unit);
        }
        public void RemoveAttackAbleUnit(AttackableUnit unit)
        {
            _attackableUnits.Remove(unit);
        }
    }   
}
