using System;
using System.Threading;

namespace NetSutdy.DesignPattern.Behavioral.Strategy
{
    public abstract class AttackableUnit : Unit
    {
        protected IWeapon _weapon;

        protected AttackableUnit()
        {
            _weapon = new Gun();
        }

        public void Fire(Unit unit)
        {
            _weapon.Fire(unit);
        }

        public virtual void Attack(Unit unit)
        {
            //HP가 0이하로 내려가면 죽은거임.
            if (_hp <= 0)
            {
                return;
            }
            if(unit.HP <= 0)
            {
                //이미 죽음
                return;
            }

            Console.WriteLine($"{Name} attacks {unit.Name}");

            Fire(unit);
        }
    }
}
