using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public record ProductVariantError
{
    [JsonPropertyName("errors"), Required]
    public ProductVariantErrorDetails Errors { get; set; } = null!;
}