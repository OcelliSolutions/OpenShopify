using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record LocationsForMoveBase
{
    [JsonIgnore]
    public new string? LocationsForMove { get; set; } = default!;
    /// <summary>
    /// The location being considered as the fulfillment order's new assigned location
    /// </summary>
    [JsonPropertyName("location")]
    public MoveLocation Location { get; set; } = null!;

    /// <summary>
    /// Whether the fulfillment order can be moved to the location
    /// </summary>
    [JsonPropertyName("movable")]
    public bool Movable { get; set; }

    /// <summary>
    /// A human-readable string with the reason why the fulfillment order, or some of its line items, can't be moved to the location.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }
}