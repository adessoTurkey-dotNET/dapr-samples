using System.Reflection;

namespace Adesso.Dapr.Core.InfoAccessor.Extensions;

internal static class TypeConverter
{
    public static object ConvertToPropertyType(
        this PropertyInfo property,
        object value)
    {
        if (property.PropertyType == typeof(string))
        {
            return value;
        }
        else if (property.PropertyType.IsEnum)
        {
            return Enum.Parse(property.PropertyType, value.ToString());
        }
        else if (property.PropertyType == typeof(int))
        {
            return Convert.ToInt32(value);
        }
        else if (property.PropertyType == typeof(long))
        {
            return Convert.ToInt64(value);
        }
        else if (property.PropertyType == typeof(short))
        {
            return Convert.ToInt16(value);
        }
        else if (property.PropertyType == typeof(DateTime))
        {
            return Convert.ToDateTime(value);
        }
        else if (property.PropertyType == typeof(DateTimeOffset))
        {
            return DateTimeOffset.Parse(value.ToString());
        }
        else
        {
            throw new ArgumentException(
                $"{property.PropertyType.FullName} in property {property.Name} is not supported.");
        }
    }
}