﻿//using System;
//using NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.Bulletproofvest;
//using NetSutdy.DesignPattern.Shared;

//namespace NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.Marines
//{
//    public abstract class AttackableUnit : Unit
//    {
//        protected IWeapon _weapon;
//        protected IBulletProofVest _bulletProofVest;

//        public virtual void SetInitialCurrentHp()
//        {
//            CurrentHp = 40;
//        }

//        public override void GotDamage(int damage)
//        {
//            if (_bulletProofVest != null)
//            {
//                damage = _bulletProofVest.ReduceDamage(damage);
//            }

//            base.GotDamage(damage);
//        }

//        public void Fire(Unit unit)
//        {
//            _weapon.Fire(unit);
//        }

//        public virtual void Attack(Unit unit)
//        {
//            //CurrentHp가 0이하로 내려가면 죽은거임.
//            if (_currentHp <= 0)
//            {
//                return;
//            }
//            if(unit.CurrentHp <= 0)
//            {
//                //이미 죽음
//                return;
//            }

//            Console.WriteLine($"{Name} attacks {unit.Name}");

//            Fire(unit);
//        }
        
//        public void SetWeapon(IWeapon weapon)
//        {
//            Console.WriteLine($"{Name} changed weapon - {weapon.GetType().Name}");
//            _weapon = weapon;
//        }

//        public IWeapon GetWeapon()
//        {
//            return _weapon;
//        }

//        public IBulletProofVest GetBulletProofVest()
//        {
//            return _bulletProofVest;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="bulletProofVest"></param>
//        public void SetBulletProofVest(IBulletProofVest bulletProofVest)
//        {
//            Console.WriteLine($"{Name} changed bullet proof vest - {bulletProofVest.GetType().Name}");
//            _bulletProofVest = bulletProofVest;
//        }
//    }
//}
