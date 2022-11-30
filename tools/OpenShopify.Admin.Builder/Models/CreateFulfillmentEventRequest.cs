using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial class CreateFulfillmentEventRequest
{

    [JsonPropertyName("event"), Required]
    public CreateFulfillmentEvent FulfillmentEvent { get; set; } = null!;
}