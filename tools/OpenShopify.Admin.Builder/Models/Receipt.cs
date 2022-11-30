using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial class Receipt
{
    [JsonPropertyName("testcase")]
    public bool? TestCase { get; set; }

    [JsonPropertyName("authorization")]
    public string? Authorization { get; set; }
}