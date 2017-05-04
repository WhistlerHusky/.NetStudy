using System;
using System.Collections.Generic;
using NetStudy.Core;
using NetSutdy.DesignPattern.Behavioral.Strategy;

namespace NetSutdy.DesignPattern.Creational.Factory.FactoryMethodPattern
{
    public class FactoryMethodPatternRunner : IRunner
    {
        public void Run()
        {
            //아래 부분을 유저 input을 통해 한국 혹은 미국 MarineFactory를 만들수도있다.
            MarineFactory koreanMarineFactory = new KoreanMarineFactory();
            var koreanMarine1 = koreanMarineFactory.CreateNewMarine("1");
            Console.WriteLine(koreanMarine1.GetType().Name);

            MarineFactory usaMarineFactory = new UsaMarineFactory();
            var usaMarine = usaMarineFactory.CreateNewMarine("1");
            Console.WriteLine(usaMarine.GetType().Name);
            
            //이렇게 같은 리스트에 담을수도 있다.
            IList<AttackableUnit> marineList = new List<AttackableUnit>();
            marineList.Add(koreanMarine1);
            marineList.Add(usaMarine);
        }
    }
}
