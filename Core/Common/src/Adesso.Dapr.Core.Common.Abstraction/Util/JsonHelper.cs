using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Adesso.Dapr.Core.Common.Abstraction.Exception;

namespace Adesso.Dapr.Core.Common.Abstraction.Util
{
    public static class JsonHelper
    {
        public static bool ValidateSchema(JArray validatingObj, JObject schema, Formatting format = Formatting.None)
        {
            if (schema is null)
            {
                throw new AdessoException("Schema can not be null !");
            }

            return validatingObj.IsValid(JSchema.Parse(schema.ToString(format)));
        }
        public static bool ValidateSchema(JArray validatingObj, JSchema schema)
        {
            if (schema is null)
            {
                throw new AdessoException("Schema can not be null !");
            }

            return validatingObj.IsValid(schema);
        }

        public static bool IsNullOrEmptyJToken(this JToken token)
        {
            return (token == null) ||
                   (token.Type == JTokenType.Array && !token.HasValues) ||
                   (token.Type == JTokenType.Object && !token.HasValues) ||
                   (token.Type == JTokenType.String && string.IsNullOrEmpty(token.ToString())) ||
                   (token.Type == JTokenType.Null);
        }
    }
}
