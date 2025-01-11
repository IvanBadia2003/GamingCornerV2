//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace GamingCornerAPI.Domain.Main
//{
//    public interface IOrderByExpression<T>
//    {
//        IOrderedQueryable<T> ApplyOrderBy(IQueryable<T> query);
//    }

//    public class OrderByExpression<T, TKey> : IOrderByExpression<T>
//    {
//        private readonly Specification<T> _specification;
//        private readonly bool _ascending;

//        public OrderByExpression(Specification<T> specification, bool ascending = true)
//        {
//            _specification = specification;
//            _ascending = ascending;
//        }

//        public IOrderedQueryable<T> ApplyOrderBy(IQueryable<T> query)
//        {
//            var orderExpr = _specification.SatisfiedBy();
//            return _ascending ? query.OrderBy(orderExpr) : query.OrderByDescending(orderExpr);
//        }
//    }
//}
