using System.Text.Json.Serialization;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record FulfillmentServiceBase
    {
        /// <inheritdoc cref="FulfillmentServiceOrig.Format"/>
        public new FulfillmentServiceFormat? Format { get; set; }

        /// <inheritdoc cref="FulfillmentServiceOrig.InventoryManagement"/>
        [JsonPropertyName("inventory_management")]
        public new bool? InventoryManagement { get; set; }

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

        /// <inheritdoc cref="FulfillmentServiceOrig.PermitsSkuSharing"/>
        [JsonPropertyName("permits_sku_sharing")]
        public new bool? PermitsSkuSharing { get; set; } = default!;
    }
}