using System;
using NetStudy.Core;
using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Behavioral.Visitor
{
    public class VisitorPatternRunner : IRunner
    {
        public void Run()
        {
            AttackableUnit stupidMarine1 = new StupidMarine();
            stupidMarine1.Name = "StupidMarine1";
            AttackableUnit stupidMarine2 = new StupidMarine();
            stupidMarine2.Name = "StupidMarine2";
            AttackableUnit smartMarine1 = new SmartMarine();
            smartMarine1.Name = "SmartMarine1";
            AttackableUnit smartMarine2 = new SmartMarine();
            smartMarine2.Name = "SmartMarine2";

            stupidMarine1.Attack(stupidMarine2);
            stupidMarine1.Attack(stupidMarine2);
            smartMarine1.Attack(smartMarine2);
            smartMarine1.Attack(smartMarine2);
            smartMarine1.Attack(smartMarine2);

            Units units = new Units();
            units.Attach(stupidMarine1);
            units.Attach(stupidMarine2);
            units.Attach(smartMarine1);
            units.Attach(smartMarine2);

            Console.WriteLine("");
            IVisitor visitor = new UnitNameAndHpVisitor();
            units.Accept(visitor);

            Console.WriteLine("");

            visitor = new UnitNameVisitor();
            units.Accept(visitor);
        }
    }
}
