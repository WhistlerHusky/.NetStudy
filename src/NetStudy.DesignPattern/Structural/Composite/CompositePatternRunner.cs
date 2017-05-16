using System;
using NetStudy.Core;
using NetSutdy.DesignPattern.Shared.Units;
using NetSutdy.DesignPattern.Shared.Weapon;
using NetSutdy.DesignPattern.Structural.Decorator;

namespace NetSutdy.DesignPattern.Structural.Composite
{
    public class CompositePatternRunner : IRunner
    {
        public void Run()
        {
            IWeapon gun = new Gun();

            //멍청한 마린
            StupidMarine stupidMarine = new StupidMarine();
            stupidMarine.Name = "Stupid Marine A";

            //똑똑한 마린
            SmartMarine smartMarineB = new SmartMarine(gun);
            smartMarineB.Name = "Smart Marine B";
            //둘중 하나체력이 15 이하가 되는동안 반복해서 싸움.
            while (stupidMarine.CurrentHp > 15 && smartMarineB.CurrentHp > 15)
            {
                stupidMarine.Attack(smartMarineB);
                Console.WriteLine();

                smartMarineB.Attack(stupidMarine);
                Console.WriteLine();
            }

            stupidMarine.Attack(smartMarineB);
            Console.WriteLine();

            //이 상태로 가다간 smart마린이 질꺼같아서 옆에있던 C,D도 그룹으로 묶어서 공격
            SmartMarine smartMarineC = new SmartMarine(gun);
            smartMarineC.Name = "Smart Marine C";

            SmartMarine smartMarineD = new SmartMarine(gun);
            smartMarineD.Name = "Smart Marine D";

            var unitSelectors = new UnitSelectors();
            unitSelectors.AddAttackAbleUnit(smartMarineB);
            unitSelectors.AddAttackAbleUnit(smartMarineC);
            unitSelectors.AddAttackAbleUnit(smartMarineD);

            unitSelectors.Attack(stupidMarine);
        }
    }   
}
