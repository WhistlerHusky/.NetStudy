using System;
using NetSutdy.DesignPattern.Behavioral.Strategy;
using NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.Bulletproofvest;

namespace NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.Marines
{
    public abstract class AttackableUnit : Unit
    {
        protected IWeapon _weapon;
        protected IBulletProofVest _bulletProofVest;
        public abstract void GetReadyToFight();

        public virtual void SetInitialHP()
        {
            HP = 40;
        }

        public override void GotDamage(int damage)
        {
            if (_bulletProofVest != null)
            {
                damage = _bulletProofVest.ReduceDamage(damage);
            }

            base.GotDamage(damage);
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
