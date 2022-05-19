using System.Text.Json.Serialization;
using OpenShopify.Common.Data;

namespace OpenShopify.Common.Models
{
    /// <summary>
    /// An object representing an access scope
    /// </summary>
    public class AccessScope
    {
        /// <summary>
        /// The scope's handle, such as "read_orders", "write_products", etc...
        /// </summary>
        [JsonPropertyName("handle")]
        public AuthorizationScope Handle { get; set; }
    }
}
