using System;
using NetStudy.Core;

namespace NetSutdy.DesignPattern.Behavioral.Strategy
{
    public class StrategyPattern : IRunner
    {
        public void Run()
        {
            IWeapon Gun = new Gun();
 
            //멍청한 마린
            StupidMarin stupidMarin = new StupidMarin();
            stupidMarin.Name = "Marin A";

            //똑똑한 마린
            SmartMarin smartMarin = new SmartMarin(Gun);
            smartMarin.Name = "Marin B";

            //멍청한 마린이 똑똑한 마린에게 공격을 시작함.
            stupidMarin.Attach(smartMarin);
            Console.WriteLine();

            //똑똑한 마린도 반격함.
            smartMarin.Attach(stupidMarin);
            Console.WriteLine();

            //둘중 하나체력이 15 이하가 되는동안 반복해서 싸움.
            while (stupidMarin.HP > 15 && smartMarin.HP > 15)
            {
                stupidMarin.Attach(smartMarin);
                Console.WriteLine();

                smartMarin.Attach(stupidMarin);
                Console.WriteLine();
            }

            //이상태로 가면 똑똑한 마린이 질꺼같아서 무기를 바꿈.
            //이부분이 Strategy pattern의 핵심!
            smartMarin.ChangeWeapon(new LaserGun());

            //다시 죽을때까지 싸움.
            while (stupidMarin.HP > 0 && smartMarin.HP > 0)
            {
                stupidMarin.Attach(smartMarin);
                Console.WriteLine();

                smartMarin.Attach(stupidMarin);
                Console.WriteLine();
            }

            var winner = stupidMarin.HP > 0 ? stupidMarin.Name : smartMarin.Name;

            Console.WriteLine($"The winner is {winner}");
        }
    }
}
