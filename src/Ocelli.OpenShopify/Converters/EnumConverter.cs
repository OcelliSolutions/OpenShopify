using System.Text.Json;
using System.Text.Json.Serialization;
using Ocelli.OpenShopify.Extensions;

namespace Ocelli.OpenShopify.Converters;

internal class EnumConverter<T> : JsonConverter<T?> where T : Enum
{
    override public T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
            return reader.GetString().GetEnumFromString<T>();
        reader.TrySkip();
        return default;
    }

    override public void Write(Utf8JsonWriter writer, T? value, JsonSerializerOptions options) =>
        writer.WriteAsNullable(value);
}