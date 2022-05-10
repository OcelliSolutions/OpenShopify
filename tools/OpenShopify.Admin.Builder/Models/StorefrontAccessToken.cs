using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public class StorefrontAccessToken : ShopifyObject
    {
        /// <summary>
        /// The issued public access token.
        /// </summary>
        [JsonPropertyName("access_token")]
        public string? AccessToken { get; set; }
        
        /// <summary>
        /// An application-dependant, comma separated list of permissions associated with the token.
        /// </summary>
        [JsonPropertyName("access_scope")]
        public string? AccessScope { get; set; }
        
        /// <summary>
        /// The date and time when the public access token was created. The API returns this value in ISO 8601 format.
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }
        
        /// <summary>
        /// An arbitrary title for each token determined by the developer/application, used for reference purposes.
        /// No constraint on uniqueness.
        /// </summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }
    }
}