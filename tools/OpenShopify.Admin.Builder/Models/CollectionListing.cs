namespace OpenShopify.Admin.Builder.Models;
public partial record CollectionListing
{
    /// <inheritdoc cref="CollectionListingOrig.DefaultProductImage" />
    [System.Text.Json.Serialization.JsonPropertyName("default_product_image")]
    public new ProductImage? DefaultProductImage { get; set; }

    /// <inheritdoc cref="CollectionListingOrig.Image" />
    [System.Text.Json.Serialization.JsonPropertyName("image")]
    public new CollectionImage? Image { get; set; }
}
