using System.Runtime.Serialization;

namespace OpenShopify.Admin.Builder.Data;

public enum ApiType
{
    [EnumMember(Value = "REST")]
    REST,
    [EnumMember(Value = "Webhook")]
    Webhook,
    [EnumMember(Value = "GraphQL")]
    GraphQL,
}