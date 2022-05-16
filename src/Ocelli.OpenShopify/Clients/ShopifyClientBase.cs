using System.Text.Json;
using System.Text.Json.Serialization;
using Ocelli.OpenShopify.Converters;

namespace Ocelli.OpenShopify;

internal class ShopifyClientBase
{
    protected static void UpdateJsonSerializerSettings(JsonSerializerOptions settings)
    {
        settings.Converters.Add(new BooleanConverter());
        settings.Converters.Add(new DateTimeConverter());
        settings.Converters.Add(new DateTimeOffsetConverter());
        settings.Converters.Add(new DecimalConverter());
        settings.Converters.Add(new DoubleConverter());
        settings.Converters.Add(new IntConverter());
        settings.Converters.Add(new StringConverter());

        settings.NumberHandling = JsonNumberHandling.AllowReadingFromString;
        settings.PropertyNameCaseInsensitive = true;
    }
}
