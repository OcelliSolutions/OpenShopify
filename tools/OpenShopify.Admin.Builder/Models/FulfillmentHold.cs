using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public record FulfillmentHold
{
    /// <summary>
    /// The reason for the fulfillment hold.
    /// </summary>
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }
    /// <summary>
    /// Additional information about the fulfillment hold reason.
    /// </summary>
    [JsonPropertyName("reason_notes")]
    public string? ReasonNotes { get; set; }
}