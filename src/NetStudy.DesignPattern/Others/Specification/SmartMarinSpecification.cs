using NetSutdy.DesignPattern.Shared.Units;
using System;
using System.Linq.Expressions;

namespace NetSutdy.DesignPattern.Others.Specification
{
    public class SmartMarinSpecification : Specification<AttackableUnit>
    {
        public override bool IsSatisfiedBy(AttackableUnit candidate) => AsExpression().Compile()(candidate);

        public override Expression<Func<AttackableUnit, bool>> AsExpression()
        {
            return unit => unit.GetType() == typeof(SmartMarine);
        }
    }
}