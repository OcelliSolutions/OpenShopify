using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record InventoryLevelBase
    {
        /// <inheritdoc cref="InventoryLevelOrig.Available"/>
        [JsonPropertyName("available")]
        public new long? Available { get; set; }

        /// <inheritdoc cref="InventoryLevelOrig.InventoryItemId"/>
        [JsonPropertyName("inventory_item_id"), Required]
        public new long InventoryItemId { get; set; }
    }
}
