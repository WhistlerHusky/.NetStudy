using System;
using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Behavioral.State
{
    public class StimpackStateMarine : IState
    {
        public AttackableUnit Unit { get; set; }

        public StimpackStateMarine(AttackableUnit unit)
        {
            Unit = unit;
        }

        public void Attack(Unit unit)
        {
            //두번공격
            Unit.Fire(unit);
            Unit.Fire(unit);
        }

        public void GotDamaged(int damage)
        {
            Console.WriteLine($"{Unit.Name} got attacked! {Unit.CurrentHp} -> {((Unit.CurrentHp - damage) > 0 ? (Unit.CurrentHp - damage) : 0)}");
            Unit.CurrentHp -= damage;
        }
    }
}
