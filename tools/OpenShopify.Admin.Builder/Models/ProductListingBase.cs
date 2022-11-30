using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

/// <inheritdoc cref="ProductListingOrig"/>
public partial record ProductListingBase
{
    [JsonPropertyName("available")]
    public bool Available{ get; set; }

    /// <inheritdoc cref="ProductListingOrig.Variants"/>>
    [JsonPropertyName("variants")]
    public new List<ProductVariant>? Variants { get; set; }


    /// <inheritdoc cref="ProductListingOrig.Images"/>>
    [JsonPropertyName("images")]
    public new List<ProductImage>? Images { get; set; }

    /// <inheritdoc cref="ProductListingOrig.Options"/>>
    [JsonPropertyName("options")]
    public new List<ProductOption>? Options { get; set; }
}
