using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record CreateProduct
{
    /// <inheritdoc cref="ProductOrig.Images"/>
    [JsonPropertyName("images")]
    public new IEnumerable<CreateProductImage>? Images { get; set; }

    /// <inheritdoc cref="ProductBase.Image"/>
    [JsonPropertyName("image")]
    public new CreateProductImage? Image { get; set; }
}
