using System.Linq.Expressions;

namespace GamingCornerAPI.Domain.Main
{
    public abstract class Specification<T>
    {
        public abstract Expression<Func<T, bool>> SatisfiedBy();

        public static Specification<T> operator &(Specification<T> left, Specification<T> right)
        {
            return new AndSpecification<T>(left, right);
        }

        public static Specification<T> operator |(Specification<T> left, Specification<T> right)
        {
            return new OrSpecification<T>(left, right);
        }
    }

    public class AndSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _left;
        private readonly Specification<T> _right;

        public AndSpecification(Specification<T> left, Specification<T> right)
        {
            _left = left;
            _right = right;
        }

        public override Expression<Func<T, bool>> SatisfiedBy()
        {
            var leftExpr = _left.SatisfiedBy();
            var rightExpr = _right.SatisfiedBy();

            var parameter = Expression.Parameter(typeof(T));
            var body = Expression.AndAlso(
                Expression.Invoke(leftExpr, parameter),
                Expression.Invoke(rightExpr, parameter)
            );

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
    }

    public class OrSpecification<T> : Specification<T>
    {
        private readonly Specification<T> _left;
        private readonly Specification<T> _right;

        public OrSpecification(Specification<T> left, Specification<T> right)
        {
            _left = left;
            _right = right;
        }

        public override Expression<Func<T, bool>> SatisfiedBy()
        {
            var leftExpr = _left.SatisfiedBy();
            var rightExpr = _right.SatisfiedBy();

            var parameter = Expression.Parameter(typeof(T));
            var body = Expression.OrElse(
                Expression.Invoke(leftExpr, parameter),
                Expression.Invoke(rightExpr, parameter)
            );

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
    }
}
