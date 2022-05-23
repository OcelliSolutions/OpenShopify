

using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public record PrerequisiteValueRange
    {
        [JsonPropertyName("less_than_or_equal_to")]
        public decimal? LessThanOrEqualTo { get; set; }

        [JsonPropertyName("greater_than_or_equal_to")]
        public decimal? GreaterThanOrEqualTo { get; set; }
    }
}