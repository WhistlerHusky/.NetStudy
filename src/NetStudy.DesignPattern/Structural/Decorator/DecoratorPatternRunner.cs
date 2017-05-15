using System;
using NetStudy.Core;
using NetSutdy.DesignPattern.Shared.Units;
using NetSutdy.DesignPattern.Shared.Weapon;

namespace NetSutdy.DesignPattern.Structural.Decorator
{
    public class DecoratorPatternRunner : IRunner
    {
        public void Run()
        {
            IWeapon gun = new Gun();

            //멍청한 마린
            StupidMarine stupidMarine = new StupidMarine();
            stupidMarine.Name = "Stupid Marine A";

            //똑똑한 마린
            SmartMarine smartMarine = new SmartMarine(gun);
            smartMarine.Name = "Smart Marine B";

            //멍청한 마린이 똑똑한 마린에게 공격을 시작함.
            stupidMarine.Attack(smartMarine);
            Console.WriteLine();

            //똑똑한 마린도 반격함.
            smartMarine.Attack(stupidMarine);
            Console.WriteLine();

            //둘중 하나체력이 15 이하가 되는동안 반복해서 싸움.
            while (stupidMarine.HP > 15 && smartMarine.HP > 15)
            {
                stupidMarine.Attack(smartMarine);
                Console.WriteLine();

                smartMarine.Attack(stupidMarine);
                Console.WriteLine();
            }

            // 여기서 Strategy pattern 에서는 무기를 바꿨지만
            // 이번엔 Decorator pattern을 이용해서 스팀팩을 구현, 두번씩 공격을 함
            Decorator stimpackMarine = new Stimpack(smartMarine);

            //다시 죽을때까지 싸움.
            while (stupidMarine.HP > 0 && stimpackMarine.HP > 0)
            {
                stupidMarine.Attack(stimpackMarine);
                Console.WriteLine();

                stimpackMarine.Attack(stupidMarine);
                Console.WriteLine();
            }

            var winner = stupidMarine.HP > 0 ? stupidMarine.Name : stimpackMarine.Name;

            Console.WriteLine($"The winner is {winner}");
        }
    }   
}
