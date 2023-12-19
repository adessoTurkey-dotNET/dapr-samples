using LinqKit;
using System.Linq.Expressions;

namespace Adesso.Dapr.Core.Common.Abstraction.Extensions
{
    public static class AdessoExpressionBuilder
    {
        public static Expression<Func<T, bool>> New<T>(
       bool defaultExpression)
        {
            return PredicateBuilder.New<T>(defaultExpression);
        }

        public static Expression<Func<T, bool>> New<T>(
            Expression<Func<T, bool>> expression = null)
        {
            return expression == null ? PredicateBuilder.New<T>(true) : PredicateBuilder.New(expression);
        }

        public static Expression<Func<T, bool>> And<T>(
            this Expression<Func<T, bool>> leftExpression,
            Expression<Func<T, bool>> rightExpression)
        {
            return leftExpression.Extend(rightExpression, PredicateOperator.And);
        }

        public static Expression<Func<T, bool>> Or<T>(
            this Expression<Func<T, bool>> leftExpression,
            Expression<Func<T, bool>> rightExpression)
        {
            return leftExpression.Extend(rightExpression, PredicateOperator.Or);
        }
    }
}
