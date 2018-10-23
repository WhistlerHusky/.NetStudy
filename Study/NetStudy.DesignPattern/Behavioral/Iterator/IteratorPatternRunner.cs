using System;
using System.Collections.Generic;
using NetStudy.Core;
using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Behavioral.Iterator
{
    public class IteratorPatternRunner : IRunner
    {
        public void Run()
        {
            Unit[] marins = new Unit[3];
            marins[0] = new StupidMarine{ Name = "StupidMarine1" };
            marins[1] = new StupidMarine{ Name = "StupidMarine2" };
            marins[2] = new StupidMarine{ Name = "StupidMarine3" };

            ITerator iterator = new UnitArrayIterator(marins);
            Display(iterator);

            IList<Unit> firebats = new List<Unit>
            {
                new FireBat{Name = "FireBat1"},
                new FireBat{Name = "FireBat2"},
                new FireBat{Name = "FireBat3"},
            };

            iterator = new UnitListIterator(firebats);
            Display(iterator);


            IDictionary<int, Unit> medics = new Dictionary<int, Unit>
            {
                {0 , new Medic{Name = "Medic1"}},
                {1 , new Medic{Name = "Medic2"}},
                {2 , new Medic{Name = "Medic3"}},
            };

            iterator = new UnitDictionaryIterator(medics);
            Display(iterator);
        }

        private static void Display(ITerator iterator)
        {
            for (Unit unit = iterator.First(); !iterator.IsDone(); unit = iterator.Next())
            {
                Console.WriteLine(unit.Name);
            }
        }
    }
}
