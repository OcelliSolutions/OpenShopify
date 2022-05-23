using System.Text.Json.Serialization;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record FulfillmentServiceBase
    {
        /// <inheritdoc cref="FulfillmentServiceOrig.Format"/>
        public new FulfillmentServiceFormat? Format { get; set; }

        /// <summary>
        /// This property is undocumented by Shopify.
        /// </summary>
        [JsonPropertyName("include_pending_stock")]
        public bool? IncludePendingStock { get; set; }

        /// <summary>
        /// This property is undocumented by Shopify.
        /// </summary>
        [JsonPropertyName("service_name")]
        public string? ServiceName { get; set; }

        /// <summary>
        /// This property is undocumented by Shopify.
        /// </summary>
        [JsonPropertyName("email")]
        public string? Email { get; set; }
    }
}