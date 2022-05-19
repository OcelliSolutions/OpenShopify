using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// An object representing remote javascript tags that are loaded into the pages of a shop's storefront.
    /// </summary>
    public class ScriptTagBase
    {
        /// <summary>
        /// The date and time when the <see cref="ScriptTag"/> was created.
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// Where the script tag should be included on the store. Known values are 'online_store', 'order_status' or 'all'. Defaults to 'all'.
        /// </summary>
        [JsonPropertyName("display_scope")]
        public string? DisplayScope { get; set; }

        /// <summary>
        /// DOM event which triggers the loading of the script. The only known value is 'onload'.
        /// </summary>
        [JsonPropertyName("event")]
        public string? Event { get; set; }

        /// <summary>
        /// Specifies the location of the ScriptTag.
        /// </summary>
        [JsonPropertyName("src")]
        public string? Src { get; set; }

        /// <summary>
        /// The date and time when the <see cref="ScriptTag"/> was updated.
        /// </summary>
        [JsonPropertyName("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }
    }
}
