using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Models;

public class ApplicationCharge
{
    [JsonPropertyName("id")]
    public long Id { get; set; }
    [JsonPropertyName("name"), MaxLength(255)]
    public string? Name { get; set; }
    [JsonPropertyName("api_client_id")]
    public int ApiClientId { get; set; }
    [JsonPropertyName("price"), Range(.50, 10000)]
    public decimal? Price { get; set; }
    [JsonPropertyName("status")]
    public ApplicationChargeStatus? Status { get; set; }
    [JsonPropertyName("return_url")]
    public string? ReturnUrl { get; set; }
    [JsonPropertyName("test")]
    public bool? Test { get; set; }
    [JsonPropertyName("created_at")]
    public DateTimeOffset? CreatedAt { get; set; }
    [JsonPropertyName("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }
    [JsonPropertyName("charge_type")]
    public string? ChargeType { get; set; }
    [JsonPropertyName("decorated_return_url")]
    public string? DecoratedReturnUrl { get; set; }
}