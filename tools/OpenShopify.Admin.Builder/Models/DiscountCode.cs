

using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record DiscountCode
    {
        /// <summary>
        /// The amount of the discount.
        /// </summary>
        [JsonPropertyName("amount")]
        public string? Amount { get; set; }

        /// <summary>
        /// The type of discount. Known values are 'percentage', 'shipping', 'fixed_amount' and 'none'.
        /// </summary>
        [JsonPropertyName("type")]
        public string? Type { get; set; }


        /// <summary>
        /// This property is undocumented by Shopify.
        /// </summary>
        [JsonPropertyName("errors")]
        public DiscountCodeErrors? Errors { get; set; }
    }

    public record DiscountCodeErrors
    {
        [JsonPropertyName("code")]
        public IEnumerable<string>? Code { get; set; }
    }
}
