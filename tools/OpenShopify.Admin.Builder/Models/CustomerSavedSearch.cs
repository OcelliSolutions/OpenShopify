using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public class CustomerSavedSearch : ShopifyObject
    {
        /// <summary>
        /// The name given by the shop owner to the customer saved search
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        
        /// <summary>
        /// The set of conditions that determines which customers will be returned by the saved search
        /// </summary>
        [JsonPropertyName("query")]
        public string? Query { get; set; }
        
        /// <summary>
        /// The date and time when the customer saved search was created. 
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }
        
        /// <summary>
        /// The date and time when the customer saved search was updated. 
        /// </summary>
        [JsonPropertyName("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}