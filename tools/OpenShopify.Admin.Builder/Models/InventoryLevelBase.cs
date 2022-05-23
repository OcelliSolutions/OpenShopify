using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    public partial record InventoryLevelBase
    {
        /// <inheritdoc cref="InventoryLevelOrig.Available"/>
        [JsonPropertyName("available")]
        public new long? Available { get; set; }
    }
}
