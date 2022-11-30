using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record CreateAddressForCustomerRequest
{
    [JsonPropertyName("customer_address"), Required]
    public CreateCustomerAddress CustomerAddress { get; set; } = null!;
}