using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public record ShippingRateCheckout
{
    [JsonPropertyName("total_tax")]
    public decimal? TotalTax { get; set; }
    [JsonPropertyName("total_price")]
    public decimal? TotalPrice { get; set; }
    [JsonPropertyName("subtotal_price")]
    public decimal? SubtotalPrice { get; set; }
}