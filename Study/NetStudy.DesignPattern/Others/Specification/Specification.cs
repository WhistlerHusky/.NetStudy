using System;
using System.Linq.Expressions;

namespace NetSutdy.DesignPattern.Others.Specification
{
    public abstract class Specification<T> : CompositeSpecification<T>
    {
        public abstract Expression<Func<T, bool>> AsExpression();
    }
}