using NetSutdy.DesignPattern.Behavioral.Strategy;
using NetSutdy.DesignPattern.Shared;

namespace NetSutdy.DesignPattern.Structural.Decorator
{
    public abstract class Decorator : AttackableUnit
    {
        protected AttackableUnit _attackableUnit;

        protected Decorator() : base()
        {
            
        }
        protected Decorator(AttackableUnit attackableUnit)
        {
            _attackableUnit = attackableUnit;
        }
    }
}
