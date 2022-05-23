using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models;

public partial record DeprecatedApiCall
{
    /// <summary>
    /// The type of API that the call was made to. Valid values: REST, Webhook, GraphQL
    /// </summary>
    [JsonPropertyName("api_type")]
    public string? ApiType { get; set; }
    /// <summary>
    /// A description of the deprecation and any required migration steps.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    /// <summary>
    /// The documentation URL to the deprecated change.
    /// </summary>
    [JsonPropertyName("documentation_url")]
    public string? DocumentationUrl { get; set; }
    /// <summary>
    ///  description of the REST endpoint, webhook topic, or GraphQL field called.
    /// </summary>
    [JsonPropertyName("endpoint")]
    public string? Endpoint { get; set; }
    /// <summary>
    /// The timestamp (ISO 4217 format) when the last deprecated API call was made.
    /// </summary>
    [JsonPropertyName("last_call_at")]
    public DateTime LastCallAt { get; set; }
    /// <summary>
    /// The time (ISO 4217 format) when the deprecated API call will be removed.
    /// </summary>
    [JsonPropertyName("migration_deadline")]
    public DateTime MigrationDeadline { get; set; }
    /// <summary>
    /// The name of the GraphQL schema. If the call wasn't made to a GraphQL API, then this value is null.
    /// </summary>
    [JsonPropertyName("graphql_schema_name")]
    public string? GraphQlSchemaName { get; set; }
    /// <summary>
    /// The earliest API version to migrate to in order to avoid making the deprecated API calls.
    /// </summary>
    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
