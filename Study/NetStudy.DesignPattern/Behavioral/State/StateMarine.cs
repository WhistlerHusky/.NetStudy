using NetSutdy.DesignPattern.Shared.Units;
using NetSutdy.DesignPattern.Shared.Weapon;

namespace NetSutdy.DesignPattern.Behavioral.State
{
    public class StateMarine : AttackableUnit
    {
        private IState State;

        public StateMarine()
        {
            _currentHp = 40;
            _weapon = new Gun();
            State = new NormalStateMarine(this);
        }

        public override void Attack(Unit unit)
        {
            if (CurrentHp <= 0)
            {
                return;
            }

            State.Attack(unit);
        }
        public override void GotDamage(int damage)
        {
            if (CurrentHp <= 0)
            {
                return;
            }

            State.GotDamaged(damage);
        }

        public void StateChanged(MarineState marineState)
        {
            switch (marineState)
            {
                case MarineState.Frozen:
                    State = new FrozenStateMarine(this);
                    break;
                case MarineState.Normal:
                    State = new NormalStateMarine(this);
                    break;
                case MarineState.Stimpack:
                    State = new StimpackStateMarine(this);
                    break;
            }
        }
    }
}
