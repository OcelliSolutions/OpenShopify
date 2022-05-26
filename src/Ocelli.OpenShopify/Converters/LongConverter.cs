using System.Text.Json;
using System.Text.Json.Serialization;
using Ocelli.OpenShopify.Extensions;

namespace Ocelli.OpenShopify.Converters;

internal class LongConverter : JsonConverter<long?>
{
    override public long? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            _ = long.TryParse(reader.GetString(), out var dbl);
            return dbl;
        }

        reader.TrySkip();
        return null;
    }

    override public void Write(Utf8JsonWriter writer, long? value, JsonSerializerOptions options) =>
        writer.WriteAsNullable(value);
}