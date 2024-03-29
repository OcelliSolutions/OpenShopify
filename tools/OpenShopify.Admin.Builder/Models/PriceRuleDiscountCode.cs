﻿
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record PriceRuleDiscountCode : ShopifyObject
    {        
        /// <summary>
        /// The discount code.
        /// </summary>
        [JsonPropertyName("code")]
        public string? Code { get; set; }

        /// <summary>
        /// Unique numeric identifier for the price rule.
        /// </summary>
        [JsonPropertyName("price_rule_id")]
        public long? PriceRuleId { get; set; }

        /// <summary>
        /// Number of times the discount code has been redeemed.
        /// </summary>
        [JsonPropertyName("usage_count")]
        public int? UsageCount { get; set; }

        /// <summary>
        /// The date and time when the discount code was created. The API returns this value in ISO 8601 format.
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// The date and time when the discount code was last modified. The API returns this value in ISO 8601 format.
        /// </summary>
        [JsonPropertyName("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }

    }
}
