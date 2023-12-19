namespace Adesso.Dapr.Core.Common.Extension;

public static class StringExtentions
{
    public static string ToLowerFirstChar(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return string.Empty;
        }

        return char.ToLower(str[0]) + str.Substring(1);
    }
    
    public static string ToUpperFirstChar(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return string.Empty;
        }

        return char.ToUpper(str[0]) + str.Substring(1);
    }
}