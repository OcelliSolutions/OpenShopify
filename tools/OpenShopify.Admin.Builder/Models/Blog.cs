
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record Blog
    {
        /// <inheritdoc cref="BlogOrig.Feedburner"/>
        [JsonPropertyName("feedburner")]
        public new object? Feedburner { get; set; }
    }
}
