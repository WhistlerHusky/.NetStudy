using System.Collections.Generic;
using System.Linq;
using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Behavioral.Mediator
{
    public class Mediator
    {
        //private IList<Terran> _terranUnits;
        //private IList<Zerg> _zergUnits;

        private IList<SpeakableUnit> _units;

        public Mediator()
        {
            _units = new List<SpeakableUnit>();
        }

        public void Register(SpeakableUnit unit)
        {
            if (_units.IndexOf(unit) < 0)
            {
                _units.Add(unit);

                unit.Mediator = this;
            }
        }

        public void Speak(Unit unit, string message)
        {
            foreach (var unitInUnits in _units)
            {
                if (unitInUnits == unit)
                {
                    continue;
                }

                if (unit.GetType() == unitInUnits.GetType())
                {
                    unitInUnits.Hear(unit, message);
                }
                else
                {
                    unitInUnits.Hear(unit, new string(message.ToCharArray().Reverse().ToArray()));
                }
            }
        }
    }
}
