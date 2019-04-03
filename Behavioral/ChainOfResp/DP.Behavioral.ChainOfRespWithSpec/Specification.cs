using System;

namespace DP.Behavioral.ChainOfRespWithSpec
{
    public class Specification<T> : ISpecification<T>
    {
        private readonly Func<T, bool> expression;

        public Specification(Func<T, bool> expression)
        {
            this.expression = expression ?? throw new ArgumentNullException();
        }

        public bool IsSatisfiedBy(T o)
        {
            return this.expression(o);
        }
    }
}
