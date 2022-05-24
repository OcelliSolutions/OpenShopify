//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v13.0.0.0)) (http://NSwag.org)
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

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v13.0.0.0))")]

    public abstract class MetafieldControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Retrieve a list of metafields from the resource's endpoint
        /// </summary>
        /// <param name="created_at_max">Show metafields created before date (format: 2022-02-25T16:15:47-04:00)</param>
        /// <param name="created_at_min">Show metafields created after date (format: 2022-02-25T16:15:47-04:00)</param>
        /// <param name="fields">Retrieve only certain fields, specified by a comma-separated list of fields names.</param>
        /// <param name="key">Show metafields with given key</param>
        /// <param name="limit">The maximum number of results to show on a page.</param>
        /// <param name="page_info">A unique ID used to access a certain page of results.</param>
        /// <param name="@namespace">Show metafields with given namespace</param>
        /// <param name="since_id">Show metafields created after the specified ID.</param>
        /// <param name="type">The type of data that the metafield stores in the `value` field.Refer to the list of [supported types](/apps/metafields/types).</param>
        /// <param name="updated_at_max">Show metafields last updated before date (format: 2022-02-25T16:15:47-04:00)</param>
        /// <param name="updated_at_min">Show metafields last updated after date (format: 2022-02-25T16:15:47-04:00)</param>
        /// <param name="value_type">The legacy type information for the stored value. Replaced by `type`</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("metafields.json")]
        public abstract System.Threading.Tasks.Task ListMetafieldsFromResourcesEndpoint(System.DateTimeOffset? created_at_max = null, System.DateTimeOffset? created_at_min = null, string? fields = null, string? key = null, int? limit = null, string? page_info = null, string? @namespace = null, long? since_id = null, string? type = null, System.DateTimeOffset? updated_at_max = null, System.DateTimeOffset? updated_at_min = null, string? value_type = null);

        /// <summary>
        /// Create a metafield
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("metafields.json")]
        public abstract System.Threading.Tasks.Task CreateMetafield([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.CreateMetafieldRequest request);

        /// <summary>
        /// Retrieve a count of a resource's metafields.
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("metafields/count.json")]
        public abstract System.Threading.Tasks.Task CountResourcesMetafields();

        /// <summary>
        /// Retrieve a specific metafield
        /// </summary>
        /// <param name="fields">Retrieve only certain fields, specified by a comma-separated list of fields names.</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("metafields/{metafield_id}.json")]
        public abstract System.Threading.Tasks.Task GetMetafield(long metafield_id, string? fields = null);

        /// <summary>
        /// Updates a metafield
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("metafields/{metafield_id}.json")]
        public abstract System.Threading.Tasks.Task UpdateMetafield([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.UpdateMetafieldRequest request, long metafield_id);

        /// <summary>
        /// Deletes a metafield by its ID
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("metafields/{metafield_id}.json")]
        public abstract System.Threading.Tasks.Task DeleteMetafield(long metafield_id);

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial record MetafieldOrig
    {
        /// <summary>
        /// The date and time ([ISO 8601 format](https://en.wikipedia.org/wiki/ISO_8601)) when the metafield was created.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("created_at")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]   
        public System.DateTimeOffset? CreatedAt { get; set; } = default!;

        /// <summary>
        /// A description of the information that the metafield contains.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("description")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]   
        public string? Description { get; set; } = default!;

        /// <summary>
        /// The key of the metafield. Keys can be up to 30 characters long and can contain alphanumeric characters, hyphens, underscores, and periods.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("key")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]   
        public string? Key { get; set; } = default!;

        /// <summary>
        /// A container for a group of metafields. Grouping metafields within a namespace prevents your metafields from conflicting with other metafields with the same key name. Must have between 3-20 characters.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("namespace")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]   
        public string? Namespace { get; set; } = default!;

        /// <summary>
        /// The unique ID of the resource that the metafield is attached to.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("owner_id")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]   
        public long? OwnerId { get; set; } = default!;

        /// <summary>
        /// The type of resource that the metafield is attached to.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("owner_resource")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]   
        public string? OwnerResource { get; set; } = default!;

        /// <summary>
        /// The date and time ([ISO 8601 format](https://en.wikipedia.org/wiki/ISO_8601)) when the metafield was last updated.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("updated_at")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]   
        public System.DateTimeOffset? UpdatedAt { get; set; } = default!;

        /// <summary>
        /// The data to store in the metafield. The value is always stored as a string, regardless of the metafield's type.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("value")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]   
        public string? Value { get; set; } = default!;

        /// <summary>
        /// The type of data that the metafield stores in the `value` field. Refer to the list of [supported types](/apps/metafields/types).
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("type")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]   
        public string? Type { get; set; } = default!;

        /// <summary>
        /// &lt;aside class="note caution"&gt; 
        /// 
        /// #### Caution
        /// 
        /// `value_type` is deprecated and replaced by `type` in API version 2021-07.
        ///  &lt;/aside&gt; The legacy type information for the stored value. Valid values: `string`, `integer`, `json_string`.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("value_type")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]   
        [System.Obsolete]
        public string? ValueType { get; set; } = default!;

        private System.Collections.Generic.IDictionary<string, object> _additionalProperties = new System.Collections.Generic.Dictionary<string, object>();

        [System.Text.Json.Serialization.JsonExtensionData]
        public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties; }
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