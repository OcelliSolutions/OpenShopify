using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record CustomerAddress : CustomerAddressBase
{
    [JsonPropertyName("id"), Required]
    public long Id { get; set; }
}

public partial record CustomerAddressBase : Models.CustomerAddressOrig { }