using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record PrerequisiteToEntitlementQuantityRatio
{
    /// <summary>
    /// The necessary 'buy' quantity.
    /// </summary>
    [JsonPropertyName("prerequisite_quantity")]
    public int PrerequisiteQuantity { get; set; }

    /// <summary>
    /// The offered 'get' quantity.
    /// </summary>
    [JsonPropertyName("entitled_quantity ")]
    public int EntitledQuantity { get; set; }
}