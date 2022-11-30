using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record FulfillmentShipping
{
    [JsonPropertyName("shipping_carrier")]
    public string? ShippingCarrier { get; set; }
    [JsonPropertyName("shipping_tracking_number")]
    public string? ShippingTrackingNumber { get; set; }
    [JsonPropertyName("shipping_date")]
    public DateTime? ShippingDate { get; set; }
}