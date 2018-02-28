using System;
using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Behavioral.State
{
    public class FrozenStateMarine : IState
    {
        public AttackableUnit Unit { get; set; }

        public FrozenStateMarine(AttackableUnit unit)
        {
            Unit = unit;
        }

        public void Attack(Unit target)
        {
            //공격안됨
            Console.WriteLine($"Frozen {Unit.Name} cannot attack {target.Name}.");
        }

        public void GotDamaged(int damage)
        {
            //데미지를 입지않음
            Console.WriteLine($"Frozen {Unit.Name} cannot get damanged");
        }
    }
}
