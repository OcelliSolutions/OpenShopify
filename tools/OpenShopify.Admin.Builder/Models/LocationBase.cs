using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record LocationBase
{

    [JsonPropertyName("country_name")] public string? CountryName { get; set; }
}
