using System.Text.Json.Serialization;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Models;

public record PaymentsRefundAttributes
{

    /// <summary>
    /// The current status of the refund. Valid values: pending, failure, success, and error.
    /// </summary>
    [JsonPropertyName("status")]
    public PaymentsRefundAttributeStatus? Status { get; set; }

    /// <summary>
    /// A unique number associated with the transaction that can be used to track the refund. This property has a value only for transactions completed with Visa or Mastercard.
    /// </summary>
    [JsonPropertyName("acquirer_reference_number")]
    public string? AcquirerReferenceNumber { get; set; }
}