using System.Text.Json.Serialization;
//using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Models;

public partial record ScriptTagBase
{
    /// <inheritdoc cref="ScriptTagOrig.Event"/>
    [JsonPropertyName("event")] 
    public new ScriptTagEvent? Event { get; set; }

    /// <inheritdoc cref="ScriptTagOrig.DisplayScope"/>
    [JsonPropertyName("display_scope")]
    public new ScriptTagDisplayScope? DisplayScope { get; set; }
}
