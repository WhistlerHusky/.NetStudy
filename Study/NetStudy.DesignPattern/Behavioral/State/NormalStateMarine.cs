using System;
using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Behavioral.State
{
    public class NormalStateMarine : IState
    {
        public AttackableUnit Unit { get; set; }

        public NormalStateMarine(AttackableUnit unit)
        {
            Unit = unit;
        }

        public void Attack(Unit unit)
        {
            Unit.Fire(unit);
        }

        public void GotDamaged(int damage)
        {
            Console.WriteLine($"{Unit.Name} got attacked! {Unit.CurrentHp} -> {((Unit.CurrentHp - damage) > 0 ? (Unit.CurrentHp - damage) : 0)}");
            Unit.CurrentHp -= damage;
        }
    }
}
