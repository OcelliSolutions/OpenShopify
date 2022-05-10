

using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public class AppliedDiscount 
    {
        /// <summary>
        /// Title of the discount.
        /// </summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        /// <summary>
        /// Reason for the discount.
        /// </summary>
        [JsonPropertyName("description")]
        public string? Description { get; set; }

        /// <summary>
        /// he value of the discount. If the type of the discount is fixed_amount, then this is a fixed dollar amount. If the type is percentage, then this is the percentage.
        /// </summary>
        [JsonPropertyName("value")]
        public string? Value { get; set; }

        /// <summary>
        /// The type of discount. Known values are "percentage" and "fixed_amount".
        /// </summary>
        [JsonPropertyName("value_type")]
        public string? ValueType { get; set; }

        /// <summary>
        /// The applied amount of the discount, based on the setting of value_type. 
        /// When ValueType is set to fixed_amount discount amount = quantity * value
        /// When ValueType is set to percentage discount amount = floor(price * quantity * value) / 100
        /// </summary>      
        [JsonPropertyName("amount")]
        public decimal? Amount { get; set; }
    }
}