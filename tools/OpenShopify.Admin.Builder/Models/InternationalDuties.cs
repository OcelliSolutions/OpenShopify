using System.Text.Json.Serialization;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Models;

public class InternationalDuties
{
    [JsonPropertyName("incoterm")] public IncoTerm? IncoTerm { get; set; }
}
