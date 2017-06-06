using System.Collections.Generic;
using System.Linq;
using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Behavioral.Iterator
{
    public class UnitListIterator : Iterator
    {
        int _current = 0;
        private IList<Unit> _units;

        public UnitListIterator(IList<Unit> units)
        {
            this._units = units;
        }

        public Unit First()
        {
            if (_units != null && _units.Any())
            {
                return _units[0];
            }

            return null;
        }

        public Unit Next()
        {
            _current++;

            if (_units != null && IsDone() == false)
            {
                 var current = _units[_current];

                return current;
            }

            return null;
        }

        public bool IsDone()
        {
            return _current >= _units.Count;
        }

        public Unit CurrentItem()
        {
            return _units[_current];
        }
    }
}
