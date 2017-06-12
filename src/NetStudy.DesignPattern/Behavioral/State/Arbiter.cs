using System;
using NetSutdy.DesignPattern.Shared.Units;
using NetSutdy.DesignPattern.Shared.Weapon;

namespace NetSutdy.DesignPattern.Behavioral.State
{
    public class Arbiter : AttackableUnit
    {
        public Arbiter()
        {
            _currentHp = 80;
            _weapon = new LaserGun();
        }

        public void StasisField(StateMarine marine)
        {
            marine.StateChanged(MarineState.Frozen);
        }
    }
}
