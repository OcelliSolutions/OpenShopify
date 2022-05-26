using System.Text.Json.Serialization;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Models;

public partial record MetafieldBase
{
    /// <inheritdoc cref="MetafieldOrig.Value"/>
    [JsonPropertyName("value")]
    public new object? Value { get; set; }
    /// <inheritdoc cref="MetafieldOrig.Type" />
    [JsonPropertyName("type")]
    public new MetafieldType? Type { get; set; }
}