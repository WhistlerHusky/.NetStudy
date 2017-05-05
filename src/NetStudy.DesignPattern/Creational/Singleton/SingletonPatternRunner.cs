using System;
using NetStudy.Core;

namespace NetSutdy.DesignPattern.Creational.Singleton
{
    public class SingletonPatternRunner : IRunner
    {
        public void Run()
        {
            //Director 이용
            Singleton first = Singleton.Instance;
            first.Name = "I'm the first";
            Console.WriteLine(first.Name);

            Singleton second = Singleton.Instance;
            second.Name = "I'm the second";

            Console.WriteLine(second.Name);

            Console.WriteLine(first.Name); //I'm the second이 출력된다.
        }
    }
}
