using System;
using NetStudy.Core;
using NetSutdy.DesignPattern.Behavioral.Strategy;

namespace NetSutdy.DesignPattern.Structural.Decorator
{
    public class DecoratorRunner : IRunner
    {
        public void Run()
        {
            IWeapon gun = new Gun();

            //멍청한 마린
            StupidMarin stupidMarin = new StupidMarin();
            stupidMarin.Name = "Stupid Marin A";

            //똑똑한 마린
            SmartMarin smartMarin = new SmartMarin(gun);
            smartMarin.Name = "Smart Marin B";

            //멍청한 마린이 똑똑한 마린에게 공격을 시작함.
            stupidMarin.Attack(smartMarin);
            Console.WriteLine();

            //똑똑한 마린도 반격함.
            smartMarin.Attack(stupidMarin);
            Console.WriteLine();

            //둘중 하나체력이 15 이하가 되는동안 반복해서 싸움.
            while (stupidMarin.HP > 15 && smartMarin.HP > 15)
            {
                stupidMarin.Attack(smartMarin);
                Console.WriteLine();

                smartMarin.Attack(stupidMarin);
                Console.WriteLine();
            }

            // 여기서 Strategy pattern 에서는 무기를 바꿨지만
            // 이번엔 Decorator pattern을 이용해서 스팀팩을 구현, 두번씩 공격을 함
            Decorator stimpackMarin = new Stimpack(smartMarin);

            //다시 죽을때까지 싸움.
            while (stupidMarin.HP > 0 && smartMarin.HP > 0)
            {
                stupidMarin.Attack(smartMarin);
                Console.WriteLine();

                stimpackMarin.Attack(stupidMarin);
                Console.WriteLine();
            }

            var winner = stupidMarin.HP > 0 ? stupidMarin.Name : smartMarin.Name;

            Console.WriteLine($"The winner is {winner}");
        }
    }   
}
