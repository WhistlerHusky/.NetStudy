using NetSutdy.DesignPattern.Behavioral.Strategy;

namespace NetSutdy.DesignPattern.Structural.Decorator
{
    public abstract class Decorator : AttackableUnit
    {
        protected AttackableUnit _attackableUnit;

        protected Decorator(AttackableUnit attackableUnit)
        {
            _attackableUnit = attackableUnit;
        }
    }
}
