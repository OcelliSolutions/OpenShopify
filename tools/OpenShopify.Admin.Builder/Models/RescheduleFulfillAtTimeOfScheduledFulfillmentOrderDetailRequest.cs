using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public record RescheduleFulfillAtTimeOfScheduledFulfillmentOrderDetailRequest
{

    [JsonPropertyName("new_fulfill_at"), Required]
    public DateTimeOffset NewFulfillAt { get; set; }
}