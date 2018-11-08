using System;
using NetStudy.Core;
using NetSutdy.DesignPattern.Shared.Units;
using NetSutdy.DesignPattern.Shared.Weapon;

namespace NetSutdy.DesignPattern.Structural.Bridge
{
    public class BridgePatternRunner : IRunner
    {
        public void Run()
        {
            IWeapon gun = new Gun();

            //이부분이 Bridge 패턴 핵심
            //AttackableUnit 을 이용하여, 여러가지 타입의 마린을 생성(생성 의 중심)
            //멍청한 마린
            AttackableUnit stupidMarine = new StupidMarine();
            stupidMarine.Name = "Stupid Marine";

            //똑똑한 마린
            AttackableUnit smartMarine = new SmartMarine(gun);
            smartMarine.Name = "Smart Marine";

            //멍청한 마린이 똑똑한 마린에게 공격을 시작함.
            stupidMarine.Attack(smartMarine);
            Console.WriteLine();

            //똑똑한 마린도 반격함.
            smartMarine.Attack(stupidMarine);
            Console.WriteLine();

            //둘중 하나체력이 15 이하가 되는동안 반복해서 싸움.
            while (stupidMarine.CurrentHp > 15 && smartMarine.CurrentHp > 15)
            {
                stupidMarine.Attack(smartMarine);
                Console.WriteLine();

                smartMarine.Attack(stupidMarine);
                Console.WriteLine();
            }

        //이상태로 가면 똑똑한 마린이 질꺼같아서 무기를 바꿈.
        //이부분이 Strategy pattern의 핵심!
        //여긴 행동의 중심
        smartMarine.SetWeapon(new LaserGun());

            //다시 죽을때까지 싸움.
            while (stupidMarine.CurrentHp > 0 && smartMarine.CurrentHp > 0)
            {
                stupidMarine.Attack(smartMarine);
                Console.WriteLine();

                smartMarine.Attack(stupidMarine);
                Console.WriteLine();
            }

            var winner = stupidMarine.CurrentHp > 0 ? stupidMarine.Name : smartMarine.Name;

            Console.WriteLine($"The winner is {winner}");
        }
    }
    class Firebat : AttackableUnit
    {
        void Attach(Unit unit)
        {
            if (_weapon.GetType().Name.Contains("Gun"))
            {
                Console.Write($"FireBat cannot use {_weapon.GetType().Name}");
            }
            else if (_weapon.GetType().Name.Contains("Flamethrower "))
            {
                _weapon.Fire(unit);
            }
        }
    }

}
