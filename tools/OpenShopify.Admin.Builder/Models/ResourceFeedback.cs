using System.Text.Json.Serialization;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Models;

public partial record ResourceFeedbackBase
{
    /// <inheritdoc cref="ResourceFeedbackOrig.State"/>
    [JsonPropertyName("state")] 
    public new ResourceFeedbackState? State { get; set; }
}
