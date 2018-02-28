using System;
using NetStudy.Core;

namespace NetSutdy.DesignPattern.Behavioral.State
{

    public class StatePatternRunner : IRunner
    {
        public void Run()
        {
            StateMarine marine1 = new StateMarine();
            marine1.Name = "Marine 1";
            StateMarine marine2 = new StateMarine();
            marine2.Name = "Marine 2";

            for (int i = 0; i < 7; i++)
            {
                marine1.Attack(marine2);
            }

            Console.WriteLine($"Current {marine2.Name} hp = {marine2.CurrentHp}");

            Arbiter arbiter = new Arbiter();
            arbiter.StasisField(marine2);

            for (int i = 0; i < 7; i++)
            {
                marine1.Attack(marine2);
            }

            marine2.StateChanged(MarineState.Stimpack);

            //4번 공격 했지만 스팀 상태로 8번 공격이 나감.
            marine2.Attack(marine1);
            marine2.Attack(marine1);
            marine2.Attack(marine1);
            marine2.Attack(marine1);
            marine2.Attack(marine1);
        }
    }
}
