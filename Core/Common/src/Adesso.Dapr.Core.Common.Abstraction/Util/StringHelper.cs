using System;
using System.Linq;
using System.Text;
using Adesso.Dapr.Core.Common.Abstraction.Enums;


namespace Adesso.Dapr.Core.Common.Abstraction.Util
{
    public static class StringHelper
    {
        private static readonly Random _random = new();
        private static readonly string _alphanumeric = "0123456789";
        private static readonly string _upperCaseCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static readonly string _lowerCaseCharacters = "abcdefghijklmnopqrstuvwxyz";

        public static string Generate(int length, AdessoStringCasing casing = default, bool isAlphanumeric = false)
        {
            var charset = casing switch
            {
                AdessoStringCasing.Lower => _lowerCaseCharacters,
                AdessoStringCasing.Upper => _upperCaseCharacters,
                AdessoStringCasing.Mixed => _lowerCaseCharacters + _upperCaseCharacters,
                _ => _lowerCaseCharacters
            };


            if (isAlphanumeric)
            {
                charset += _alphanumeric;
            }

            return Generate(length, charset);
        }

        public static string Generate(int length, string charset)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(charset);

            return new string(Enumerable.Repeat(stringBuilder.ToString(), length)
                            .Select(s => s[_random.Next(s.Length)])
                            .ToArray());
        }
    }
}
