using NetSutdy.DesignPattern.Shared.Units;
using NetSutdy.DesignPattern.Shared.Weapon;
using System;
using System.Linq.Expressions;

namespace NetSutdy.DesignPattern.Others.Specification
{
    public class DoubleGunSpecification : Specification<AttackableUnit>
    {
        public override bool IsSatisfiedBy(AttackableUnit candidate) => AsExpression().Compile()(candidate);

        public override Expression<Func<AttackableUnit, bool>> AsExpression()
        {
            return unit => unit.GetWeapon().GetType() == typeof(DoubleGun);
        }
    }
}