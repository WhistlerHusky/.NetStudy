using System;
using System.Collections.Generic;
using NetStudy.Core;
using NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern.Marines;
using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Creational.Factory.AbstractMethodFactoryPattern
{
    public class AbstractFactoryMethodPatternRunner : IRunner
    {
        public void Run()
        {
            //아래 부분을 유저 input을 통해 한국 혹은 미국 MarineFactory를 만들수도있다.

            MarineFactory koreanMarineFactory = new KoreanMarineFactory();
            MarineFactory usaMarineFactory = new UsaMarineFactory();
            
            var koreanMarine1 = koreanMarineFactory.CreateNewMarine("1");
            koreanMarine1.Name = "Marine_K";
            var usaMarine = usaMarineFactory.CreateNewMarine("1");
            usaMarine.Name = "Marine_U";

            Console.WriteLine(koreanMarine1.GetType().Name);
            Console.WriteLine(usaMarine.GetType().Name);

            while (koreanMarine1.CurrentHp > 0 && usaMarine.CurrentHp > 0)
            {
                koreanMarine1.Attack(usaMarine);
                Console.WriteLine();

                usaMarine.Attack(koreanMarine1);
                Console.WriteLine();
            }

            var winner = koreanMarine1.CurrentHp > 0 ? koreanMarine1.Name : usaMarine.Name;

            Console.WriteLine($"The winner is {winner}");

            //이렇게 같은 리스트에 담을수도 있다.
            IList<AttackableUnit> marineList = new List<AttackableUnit>();
            marineList.Add(koreanMarine1);
            marineList.Add(usaMarine);
        }
    }
}
