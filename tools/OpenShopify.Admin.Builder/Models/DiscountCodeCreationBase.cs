using System.Text.Json.Serialization;
//using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Models;
//TODO: create DiscountCodeCreation
public partial record DiscountCodeCreationBase
{
    [JsonPropertyName("id")]
    public long? Id { get; set; }
    [JsonPropertyName("price_rule_id")]
    public long PriceRuleId { get; set; }
    [JsonPropertyName("started_at")]
    public DateTimeOffset? StartedAt { get; set; }
    [JsonPropertyName("completed_at")]
    public DateTimeOffset? CompletedAt { get; set; }
    [JsonPropertyName("created_at")]
    public DateTimeOffset? CreatedAt { get; set; }
    [JsonPropertyName("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }

    /// <summary>
    /// The state of the discount code creation job
    /// </summary>
    [JsonPropertyName("status")]
    public Data.DiscountCodeCreationStatus? Status { get; set; }

    /// <summary>
    /// The number of discount codes to create
    /// </summary>
    [JsonPropertyName("codes_count")]
    public int? CodesCount { get; set; }

    /// <summary>
    /// The number of discount codes created successfully.
    /// </summary>
    [JsonPropertyName("imported_count")]
    public int? ImportedCount { get; set; }

    /// <summary>
    /// The number of discount codes that were not created successfully. Unsuccessful attempts will retry up to three times.
    /// </summary>
    [JsonPropertyName("failed_count")]
    public int? FailedCount { get; set; }

    /// <summary>
    /// A report that specifies when no discount codes were created because the provided data was invalid.
    /// </summary>
    [JsonPropertyName("logs")]
    public IEnumerable<string>? Logs { get; set; }

    [JsonPropertyName("errors")] 
    public DiscountCodeCreationErrors? Errors { get; set; }
}