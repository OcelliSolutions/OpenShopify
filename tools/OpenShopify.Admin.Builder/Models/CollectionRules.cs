using System.Text.Json.Serialization;
//using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// An entity representing a Shopify Collection Rule.
    /// </summary>
    public partial record CollectionRules
    {
        /// <summary>
        /// The relationship between the column choice, and the condition.
        /// </summary>
        [JsonPropertyName("relation")]
        public Data.RuleRelation? Relation { get; set; }

        /// <summary>
        /// Select products for a collection using a condition. Conditions are either strings or numbers, depending on the relation.
        /// </summary>
        [JsonPropertyName("condition")]
        public string? Condition { get; set; }

        /// <summary>
        /// The properties of a product that can be used to to populate a collection.
        /// </summary>
        [JsonPropertyName("column")]
        public Data.RuleColumn? Column { get; set; }
    }
}
