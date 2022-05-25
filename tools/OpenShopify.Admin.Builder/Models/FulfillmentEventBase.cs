using System.Text.Json.Serialization;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Models;

public partial record FulfillmentEventBase
{
    [JsonPropertyName("status")]
    public new FulfillmentEventStatus? Status { get; set; }
}
