using System.Text.Json;
using System.Text.Json.Serialization;
using Ocelli.OpenShopify.Converters;

namespace Ocelli.OpenShopify;

internal class ShopifyClientBase
{
    protected static void UpdateJsonSerializerSettings(JsonSerializerOptions settings)
    {
        settings.Converters.Add(new JsonStringEnumMemberConverter(new JsonStringEnumMemberConverterOptions(deserializationFailureFallbackValue: null)));
        //settings.Converters.Add(new JsonNullableStringEnumConverter());
        //settings.Converters.Add(new NullableConverterFactory());
        settings.NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString;
        settings.PropertyNameCaseInsensitive = true;
        settings.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    }
}
