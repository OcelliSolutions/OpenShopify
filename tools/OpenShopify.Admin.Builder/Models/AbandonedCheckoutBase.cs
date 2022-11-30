using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record AbandonedCheckoutBase
{

    /// <summary>
    /// Undocumented
    /// </summary>
    [JsonPropertyName("note_attributes")]
    public new IEnumerable<NoteAttribute>? NoteAttributes { get; set; }

}
