using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;


public record MarkFulfillmentOrderAsIncompleteRequest
{
    [Required, JsonPropertyName("fulfillment_order")]
    public FulfillmentOrderCancellationRequestDetail FulfillmentOrder { get; set; } = null!;
}