using Adesso.Dapr.Core.Common.Abstraction.Attributes;
using Adesso.Dapr.Core.Common.Abstraction.Exception;
using System.Reflection;
using System.Text;
using System.Security.Cryptography;

namespace Adesso.Dapr.Core.Common.Abstraction.Extensions
{
    public static class AdessoLineExtension
    {
        public static string ToAdessoLineString(
        this object data)
        {
            var properties = data.GetType()
                .GetProperties()
                .Where(a => a.CustomAttributes.Any(ca => ca.AttributeType == typeof(AdessoLinePropertyAttribute)))
                .OrderBy(a => a.GetCustomAttribute<AdessoLinePropertyAttribute>()?.Order)
                .ToList();

            var stringBuilder = new StringBuilder();

            foreach (var property in properties)
            {
                var capacity = property.GetCustomAttribute<AdessoLinePropertyAttribute>()?.Capacity;
                var text = property.GetValue(data)?.ToString() ?? string.Empty;
                var spaceCount = capacity - text.Length;

                if (spaceCount < 0)
                {
                    throw new AdessoException(
                        $"Out or the maximum capacity property {property.Name}.");
                }

                stringBuilder.Append(text);
                stringBuilder.Append("".PadRight(spaceCount.GetValueOrDefault()));
            }

            return stringBuilder.ToString();
        }
        public static T ToAdessoLineObject<T>(
            this string line) where T : new()
        {
            var pegasusLine = Activator.CreateInstance<T>();
            var properties = pegasusLine.GetType()
                .GetProperties()
                .Where(a => a.CustomAttributes.Any(ca => ca.AttributeType == typeof(AdessoLinePropertyAttribute)))
                .OrderBy(a => a.GetCustomAttribute<AdessoLinePropertyAttribute>()?.Order)
                .ToList();

            var startIndex = 0;
            foreach (var property in properties)
            {
                var capacity = property.GetCustomAttribute<AdessoLinePropertyAttribute>()?.Capacity;
                var text = line.Substring(
                    startIndex,
                    capacity.GetValueOrDefault());

                if (property.PropertyType == typeof(string))
                {
                    property.SetValue(
                        pegasusLine,
                        text.TrimEnd());
                }
                else if (property.PropertyType == typeof(int))
                {
                    property.SetValue(
                        pegasusLine,
                        Convert.ToInt32(text.TrimEnd()));
                }
                else
                {
                    throw new AdessoException($"{property.PropertyType.Assembly} property type not supported by Adesso line serializer.");
                }

                startIndex += capacity.GetValueOrDefault();
            }


            return pegasusLine;
        }

        public static string ToAdessoHashLine(this string line)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(line));
                line = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
            return line;
        }
    }
}
