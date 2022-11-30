using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record CountItem
{
    [JsonPropertyName("count")] public int Count { get; set; }
}
