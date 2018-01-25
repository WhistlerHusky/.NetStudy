using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NetStudy.Core;
using NetSutdy.DesignPattern.Behavioral.TemplateMethod;
using NetSutdy.DesignPattern.Shared.Units;

namespace NetSutdy.DesignPattern.Behavioral.Visitor
{
    public class Units 
    {
        private IList<Unit> _units = new List<Unit>();

        public void Attach(Unit unit)
        {
            _units.Add(unit);
        }
        public void Detach(Unit unit)
        {
            _units.Remove(unit);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (Unit u in _units)
            {
                visitor.Visit(u);
            }
        }
    }
}
