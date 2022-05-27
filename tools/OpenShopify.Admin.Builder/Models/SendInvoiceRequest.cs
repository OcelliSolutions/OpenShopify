using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;


public partial record SendInvoiceRequest
{
    [JsonPropertyName("draft_order_invoice"), Required]
    public DraftOrderInvoice DraftOrderInvoice { get; set; } = null!;
}