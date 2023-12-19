using System.Linq.Expressions;
using System.Reflection;
using Adesso.Dapr.Core.Common.Abstraction.Exception;
using Adesso.Dapr.Core.Common.Abstraction.Util;


namespace Adesso.Dapr.Core.Common.Abstraction.Util
{
    public static class AdessoGlobalFilterHelper
    {
        public static Expression GenerateExpression(
            ParameterExpression parameter,
            PropertyInfo propertyInfo,
            AdessoGlobalFilterExpressionType expressionType,
            object value)
        {
            return expressionType switch
            {
                AdessoGlobalFilterExpressionType.Equal => Expression.Equal(Expression.Property(parameter, propertyInfo),
                    Expression.Constant(value)),
                AdessoGlobalFilterExpressionType.GreaterThan => Expression.GreaterThan(Expression.Property(parameter, propertyInfo),
                    Expression.Constant(value)),
                _ => throw new AdessoException($"GlobalExpressionBuilder is invalid. ExpressionType: { nameof(expressionType) }")
            };
        }
    }
}
