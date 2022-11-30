using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record PrerequisiteToEntitlementPurchase
{
    /// <summary>
    /// The minimum purchase amount required to be entitled to the discount.
    /// </summary>
    [JsonPropertyName("prerequisite_amount")]
    public decimal? PrerequisiteAmount { get; set; }
}