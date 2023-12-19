using System;
using System.Linq;

namespace Adesso.Dapr.Core.Common.Abstraction.Extensions
{
    public static class AdessoTypeExtentions
    {
        public static bool IsSubclassOfRawGeneric(this Type generic, Type toCheck)
        {
            while (toCheck != null && toCheck != typeof(object))
            {
                var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (generic == cur)
                {
                    return true;
                }

                toCheck = toCheck.BaseType;
            }

            return false;
        }

        public static bool IsAssignableToGenericType(this Type givenType, Type genericType)
        {
            var interfaceTypes = givenType.GetInterfaces();
            foreach (var interfaceType in interfaceTypes)
            {
                if (interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == genericType)
                {
                    return true;
                }
            }

            if (givenType.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
            {
                return true;
            }

            var baseType = givenType.BaseType;
            if (baseType == null)
            {
                return false;
            }

            return IsAssignableToGenericType(baseType, genericType);
        }

        public static bool IsPrimitiveType(this Type givenType)
        {
            return givenType.IsPrimitive ||
                   givenType.IsEnum ||
                   new Type[] {
                        typeof(string),
                        typeof(bool),
                        typeof(short),
                        typeof(int),
                        typeof(long),
                        typeof(double),
                        typeof(decimal),
                        typeof(DateTime),
                        typeof(DateTimeOffset),
                        typeof(TimeSpan),
                        typeof(Guid),
                   }.Contains(givenType);
        }
    }
}
