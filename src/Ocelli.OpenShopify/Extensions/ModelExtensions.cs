using System.Text.Json;

namespace Ocelli.OpenShopify.Extensions;

internal static class ModelExtensions
{
    internal static void WriteAsNullable(this Utf8JsonWriter writer, dynamic? value)
    {
        if (value == null)
        {
            writer.WriteStartObject();
            writer.WriteString("@nil", "true");
            writer.WriteEndObject();
        }
        else
            writer.WriteStringValue(value.ToString());
    }

    internal static string GetBaseUrl(this string store, string version) => $@"https://{store}.myshopify.com/admin/api/{version}";
    internal static string GetAccessBaseUrl(this string store, string version) => $@"https://{store}.myshopify.com";
}