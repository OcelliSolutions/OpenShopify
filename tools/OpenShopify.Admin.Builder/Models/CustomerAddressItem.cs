using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record CustomerAddressItem
{
    [JsonPropertyName("customer_address"), Required]
    public CustomerAddress CustomerAddress { get; set; } = null!;
}