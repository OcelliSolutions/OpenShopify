namespace Ocelli.OpenShopify;
public partial class CountItem
{

    [System.Text.Json.Serialization.JsonPropertyName("count")]
    public int? Count { get; set; } = default!;

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties; }
        set { _additionalProperties = value; }
    }

}
