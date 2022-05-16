namespace Ocelli.OpenShopify;
public partial class ErrorResponse
{

    [System.Text.Json.Serialization.JsonPropertyName("errors")]
    public string? Errors { get; set; } = default!;

}
