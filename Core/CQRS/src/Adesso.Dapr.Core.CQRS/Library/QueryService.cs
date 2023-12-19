using System.Linq.Expressions;
using LinqKit;
using Adesso.Dapr.Core.Common.Extension;

namespace Adesso.Dapr.Core.CQRS.Library;

public static class QueryService<T>
{
    public static Expression<Func<T, bool>> ApplyFilters(T entity, IEnumerable<Filter> filters)
    {
        filters.ForEach(x => x.PropertyName = x.PropertyName.ToUpperFirstChar());
        Expression<Func<T, bool>> result = arg => 1 == 1;
        foreach (var filter in filters)
        {
            var value = typeof(T).GetProperty(filter.PropertyName).GetValue(entity);
            result.Or(ApplyFilter(filter.PropertyName, value, filter.FilterType));
        }

        return result;
    }

    private static Expression<Func<T, bool>> ApplyFilter(string propertyName, object value, FilterType filterType)
    {
        ParameterExpression param = Expression.Parameter(typeof(T), "x");
        MemberExpression member = Expression.Property(param, propertyName);
        ConstantExpression constant = Expression.Constant(value);

        Expression condition = BuildCondition(member, constant, filterType);
        Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(condition, param);

        return lambda;
    }

    private static Expression BuildCondition(MemberExpression member, ConstantExpression constant,
        FilterType filterType)
    {
        switch (filterType)
        {
            case FilterType.Equal:
                return Expression.Equal(member, constant);

            case FilterType.NotEqual:
                return Expression.NotEqual(member, constant);

            case FilterType.GreaterThan:
                return Expression.GreaterThan(member, constant);

            case FilterType.GreaterThanOrEqual:
                return Expression.GreaterThanOrEqual(member, constant);

            case FilterType.LessThan:
                return Expression.LessThan(member, constant);

            case FilterType.LessThanOrEqual:
                return Expression.LessThanOrEqual(member, constant);

            case FilterType.Contains:
                return Expression.Call(member, typeof(string).GetMethod("Contains", new[] {typeof(string)}), constant);

            case FilterType.StartsWith:
                return Expression.Call(member, typeof(string).GetMethod("StartsWith", new[] {typeof(string)}),
                    constant);

            case FilterType.EndsWith:
                return Expression.Call(member, typeof(string).GetMethod("EndsWith", new[] {typeof(string)}), constant);

            default:
                throw new NotSupportedException("Filter type is not supported.");
        }
    }
}