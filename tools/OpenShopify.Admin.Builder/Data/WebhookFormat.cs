using System.Runtime.Serialization;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Data;

/// <inheritdoc cref="WebhookOrig.Format"/>
public enum WebhookFormat
{
    [EnumMember(Value = "json")]
    Json,
    [Obsolete("`xml` is no longer a valid value."), EnumMember(Value = "xml")]
    Xml,
}
