using System.Text.Json.Serialization;
//using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Models;

public partial record ThemeBase
{
    /// <inheritdoc cref="ThemeOrig.Role"/>
    [JsonPropertyName("role")]
    public new ThemeRole? Role { get; set; }

    [JsonPropertyName("src")]
    public string? Src { get; set; }
}
