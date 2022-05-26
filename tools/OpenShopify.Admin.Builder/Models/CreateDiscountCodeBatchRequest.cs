using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public class CreateDiscountCodeBatchRequest
{
    [JsonPropertyName("discount_codes"), Required]
    public IEnumerable<CreateDiscountCode> DiscountCodes { get; set; } = null!;
}
