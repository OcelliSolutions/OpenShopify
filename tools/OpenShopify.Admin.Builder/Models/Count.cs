using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public class CountItem
{
    [JsonPropertyName("count")] public int Count { get; set; }
}
