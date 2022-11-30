using System.Text.Json.Serialization;
//using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Models;

//TODO: create Comment
public partial record Comment
{
    /// <inheritdoc cref="CommentOrig.Status"/>
    [JsonPropertyName("status")]
    public new CommentStatus? Status { get; set; } = default!;
}
