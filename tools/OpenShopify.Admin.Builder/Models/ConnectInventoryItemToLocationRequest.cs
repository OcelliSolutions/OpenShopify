using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public class ConnectInventoryItemToLocationRequest
{
    /// <summary>
    /// The ID of the inventory item.
    /// </summary>
    [JsonPropertyName("inventory_item_id"), Required]
    public long InventoryItemId { get; set; }

    /// <summary>
    /// The ID of the location that the inventory level belongs to. To find the ID of the location, use the Location resource.
    /// </summary>
    [JsonPropertyName("location_id"), Required]
    public long LocationId { get; set; }

    /// <summary>
    /// Whether inventory for any previously connected locations will be relocated. This property is ignored when no fulfillment service location is involved. For more information, refer to Inventory levels and fulfillment service locations.
    /// </summary>
    [JsonPropertyName("relocate_if_necessary")]
    public bool? RelocateIfNecessary { get; set; }
}
