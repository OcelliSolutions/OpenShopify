using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record AddressItem
{
    [JsonPropertyName("address"), Required]
    public Address Address { get; set; } = null!;
}