using System.Text.Json;
using System.Text.Json.Serialization;
using Ocelli.OpenShopify.Extensions;

namespace Ocelli.OpenShopify.Converters;

internal class DateTimeConverter : JsonConverter<DateTime?>
{
    override public DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            reader.TryGetDateTime(out var dt);
            return dt;
        }

        reader.TrySkip();
        return null;
    }

    override public void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options) =>
        writer.WriteAsNullable(value);
}