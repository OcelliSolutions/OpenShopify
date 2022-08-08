using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record ShippingRateOrig
{
    [JsonPropertyName("id"), Required]
    public string Id { get; set; } = null!;

    [JsonPropertyName("price")]
    public decimal? Price { get; set; }
    [JsonPropertyName("title")]
    public string? Title { get; set; }
    [JsonPropertyName("checkout")]
    public ShippingRateCheckout? Checkout { get; set; }
    [JsonPropertyName("phone_required")]
    public bool? PhoneRequired { get; set; }
    [JsonPropertyName("delivery_range")]
    public long? DeliveryRange { get; set; }
    [JsonPropertyName("estimated_time_in_transit")]
    public long? EstimatedTimeInTransit { get; set; }
    [JsonPropertyName("handle")]
    public string? Handle { get; set; }
}

public record ShippingRateCheckout
{
    [JsonPropertyName("total_tax")]
    public decimal? TotalTax { get; set; }
    [JsonPropertyName("total_price")]
    public decimal? TotalPrice { get; set; }
    [JsonPropertyName("subtotal_price")]
    public decimal? SubtotalPrice { get; set; }
}
