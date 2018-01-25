using System;
using NetStudy.Core;

namespace NetSutdy.DesignPattern.Creational.Builder
{
    public class BuilderPatternRunner : IRunner
    {
        public void Run()
        {
            //Director 이용
            MarineDirector marinDirector = new MarineDirector();
            MarinBuilder marinBuilder = new KoreanMarinBuilder();

            marinDirector.CreateMarine(marinBuilder);
            var marin = marinBuilder.Marin;
            Console.WriteLine($"{marin.GetType().Name} has {marin.GetWeapon().GetType().Name} and wears {marin.GetBulletProofVest().GetType().Name}");
            Console.WriteLine();

            marinBuilder = new UsaMarinBuilder();;
            marinDirector.CreateMarine(marinBuilder);
            marin = marinBuilder.Marin;
            Console.WriteLine($"{marin.GetType().Name} has {marin.GetWeapon().GetType().Name} and wears {marin.GetBulletProofVest().GetType().Name}");
            Console.WriteLine();

            //Director 이용하지 않을경우 아래와같이 바로 해줘도 상관없다.
            marinBuilder = new KoreanMarinBuilder();
            marinBuilder
                .SetWeapon()
                .SetBulletProofVest();
            marin = marinBuilder.Marin;

            Console.WriteLine($"{marin.GetType().Name} has {marin.GetWeapon().GetType().Name} and wears {marin.GetBulletProofVest().GetType().Name}");
        }
    }
}
