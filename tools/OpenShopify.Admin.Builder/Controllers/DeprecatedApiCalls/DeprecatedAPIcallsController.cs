//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

#nullable enable

using System.Text.Json;

#pragma warning disable 108 // Disable "CS0108 '{derivedDto}.ToJson()' hides inherited member '{dtoBase}.ToJson()'. Use the new keyword if hiding was intended."
#pragma warning disable 114 // Disable "CS0114 '{derivedDto}.RaisePropertyChanged(String)' hides inherited member 'dtoBase.RaisePropertyChanged(String)'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword."
#pragma warning disable 472 // Disable "CS0472 The result of the expression is always 'false' since a value of type 'Int32' is never equal to 'null' of type 'Int32?'
#pragma warning disable 1573 // Disable "CS1573 Parameter '...' has no matching param tag in the XML comment for ...
#pragma warning disable 1591 // Disable "CS1591 Missing XML comment for publicly visible type or member ..."
#pragma warning disable 8073 // Disable "CS8073 The result of the expression is always 'false' since a value of type 'T' is never equal to 'null' of type 'T?'"
#pragma warning disable 3016 // Disable "CS3016 Arrays as attribute arguments is not CLS-compliant"
#pragma warning disable 8603 // Disable "CS8603 Possible null reference return"

namespace OpenShopify.Admin.Builder.Models
{
    using System = global::System;

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]

    public abstract class DeprecatedAPICallsControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Retrieves a list of deprecated API calls
        /// </summary>
        /// <remarks>
        /// Retrieves a list of deprecated API calls made by your private apps in the past 30 days.
        /// </remarks>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("deprecated_api_calls.json")]
        public abstract System.Threading.Tasks.Task ListDeprecatedAPICalls();

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial record DeprecatedAPIcallsOrig
    {
        /// <summary>
        /// The date and time ([ISO 8601 format](https://en.wikipedia.org/wiki/ISO_8601)) when the data was last updated.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("data_updated_at")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? DataUpdatedAt { get; set; } = default!;

        /// <summary>
        /// A list of deprecated API calls made by the authenticated app in the past 30 days. Each object has the following properties:
        /// 
        /// *   `api_type`: The type of API that the call was made to. Valid values: `REST`, `Webhook`, `GraphQL`. 
        /// *   `description`: A description of the deprecation and any required migration steps. 
        /// *   `documentation_url`: The documentation URL to the deprecated change. 
        /// *   `endpoint`: A description of the REST endpoint, webhook topic, or GraphQL field called. 
        /// *   `last_call_at`: The timestamp ([ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) format) when the last deprecated API call was made. 
        /// *   `migration_deadline`: The time ([ISO 4217](https://en.wikipedia.org/wiki/ISO_4217) format) when the deprecated API call will be removed. 
        /// *   `graphql_schema_name`: The name of the GraphQL schema. If the call wasn't made to a GraphQL API, then this value is `null`. 
        /// *   `version`: The earliest API version to migrate to in order to avoid making the deprecated API calls.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("deprecated_api_calls")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? DeprecatedApiCalls { get; set; } = default!;

        private System.Collections.Generic.IDictionary<string, object>? _additionalProperties;

        [System.Text.Json.Serialization.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }


}

#pragma warning restore 1591
#pragma warning restore 1573
#pragma warning restore  472
#pragma warning restore  114
#pragma warning restore  108
#pragma warning restore 3016
#pragma warning restore 8603