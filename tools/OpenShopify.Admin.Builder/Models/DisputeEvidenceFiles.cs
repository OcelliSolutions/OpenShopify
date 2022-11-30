using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

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