using System.Linq;
using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Behavioral.Iterator
{
    public class UnitArrayIterator : ITerator
    {
        int _current = 0;
        private Unit[] _units;

        public UnitArrayIterator(Unit[] units)
        {
            _units = units;
        }

        public Unit First()
        {
            if (_units != null && _units.Any())
            {
                _current = 0;
                return _units[_current];
            }

            return null;
        }

        public Unit Next()
        {
            ++_current;

            if (_units != null & IsDone() == false)
            {
                var current = _units[_current];

                return current;
            }

            return null;
        }

        public bool IsDone()
        {
            return _current >= _units.Length ;
        }

        public Unit CurrentItem()
        {
            return _units[_current];
        }
    }
}
