using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;
public partial record DisputeEvidence
{
    [JsonPropertyName("billing_address")]
    public new Address? BillingAddress { get; set; }
    [JsonPropertyName("shipping_address")]
    public new Address? ShippingAddress { get; set; }
    [JsonPropertyName("submitted_by_merchant_on")]
    public DateTimeOffset? SubmittedByMerchantOn { get; set; }
    [JsonPropertyName("fulfillments")]
    public new IEnumerable<FulfillmentShipping>? Fulfillments { get; set; }
    [JsonPropertyName("dispute_evidence_files")]
    public new DisputeEvidenceFiles? DisputeEvidenceFiles { get; set; }
}