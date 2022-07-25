using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;
public partial record DisputeEvidence
{
    [JsonPropertyName("billing_address")]
    public new Address? BillingAddress { get; set; }
    [JsonPropertyName("shipping_address")]
    public Address? ShippingAddress { get; set; }
    [JsonPropertyName("submitted_by_merchant_on")]
    public DateTimeOffset? SubmittedByMerchantOn { get; set; }
    [JsonPropertyName("fulfillments")]
    public new IEnumerable<FulfillmentShipping>? Fulfillments { get; set; }
    [JsonPropertyName("dispute_evidence_files")]
    public new DisputeEvidenceFiles? DisputeEvidenceFiles { get; set; }
}

public partial record DisputeEvidenceFiles
{
    [JsonPropertyName("cancellation_policy_file_id")]
    public long? CancellationPolicyFileId { get; set; }
    [JsonPropertyName("customer_communication_file_id")]
    public long? CustomerCommunicationFileId { get; set; }
    [JsonPropertyName("customer_signature_file_id")]
    public long? CustomerSignatureFileId { get; set; }
    [JsonPropertyName("refund_policy_file_id")]
    public long? RefundPolicyFileId { get; set; }
    [JsonPropertyName("service_documentation_file_id")]
    public long? ServiceDocumentationFileId { get; set; }
    [JsonPropertyName("shipping_documentation_file_id")]
    public long? ShippingDocumentationFileId { get; set; }
    [JsonPropertyName("uncategorized_file_id")]
    public long? UncategorizedFileId { get; set; }
}

public partial record FulfillmentShipping
{
    [JsonPropertyName("shipping_carrier")]
    public string? ShippingCarrier { get; set; }
    [JsonPropertyName("shipping_tracking_number")]
    public string? ShippingTrackingNumber { get; set; }
    [JsonPropertyName("shipping_date")]
    public DateTime? ShippingDate { get; set; }
}
