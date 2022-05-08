//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v13.0.0.0)) (http://NSwag.org)
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

namespace OpenShopify.Admin.Builder
{
    using System = global::System;

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v13.0.0.0))")]

    public abstract class CollectionControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Retrieves a single collection
        /// </summary>
        /// <param name="fields">Show only certain fields, specified by a comma-separated list of field names.</param>
        /// <returns>Retrieves a single collection</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("admin/api/{api_version}/collections/{collection_id}.json")]
        public abstract System.Threading.Tasks.Task RetrieveSingleCollection(string collection_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? fields = null);

        /// <summary>
        /// Retrieve a list of products belonging to a collection
        /// </summary>
        /// <param name="limit">The number of products to retrieve.</param>
        /// <returns>Retrieve a list of products belonging to a collection</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("admin/api/{api_version}/collections/{collection_id}/products.json")]
        public abstract System.Threading.Tasks.Task RetrieveListOfProductsBelongingToCollection(string collection_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? limit = "50");

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class Collection
    {
        /// <summary>
        /// A description of the collection, complete with HTML markup. Many templates display this on their collection pages.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("body_html")]
        public string? Body_html { get; set; } = default!;

        /// <summary>
        /// A unique, human-readable string for the collection automatically generated from its title. This is used in themes by the Liquid templating language to refer to the collection. (limit: 255 characters)
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("handle")]
        public string? Handle { get; set; } = default!;

        /// <summary>
        /// Image associated with the collection. Valid values are:
        /// <br/> 
        /// <br/> attachment: An image attached to a collection returned as Base64-encoded binary data.
        /// <br/> src: The source URL that specifies the location of the image.
        /// <br/> alt: The alternative text that describes the collection image.
        /// <br/> created_at: The time and date (ISO 8601 format) when the image was added to the collection.
        /// <br/> width: The width of the image in pixels.
        /// <br/> height: The height of the image in pixels.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("image")]
        public string? Image { get; set; } = default!;

        /// <summary>
        /// The ID for the collection.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public string? Id { get; set; } = default!;

        /// <summary>
        /// The time and date (ISO 8601 format) when the collection was made visible. Returns null for a hidden collection.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("published_at")]
        public string? Published_at { get; set; } = default!;

        /// <summary>
        /// Whether the collection is published to the Point of Sale channel. Valid values:
        /// <br/> 
        /// <br/> web: The collection is published to the Online Store channel but not published to
        /// <br/> the Point of Sale channel.
        /// <br/> global: The collection is published to both the Online Store channel and the Point
        /// <br/> of Sale channel.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("published_scope")]
        public string? Published_scope { get; set; } = default!;

        /// <summary>
        /// The order in which products in the collection appear. Valid values:
        /// <br/> 
        /// <br/> alpha-asc: Alphabetically, in ascending order (A - Z).
        /// <br/> alpha-desc: Alphabetically, in descending order (Z - A).
        /// <br/> best-selling: By best-selling products.
        /// <br/> created: By date created, in ascending order (oldest - newest).
        /// <br/> created-desc: By date created, in descending order (newest - oldest).
        /// <br/> manual: In the order set manually by the shop owner.
        /// <br/> price-asc: By price, in ascending order (lowest - highest).
        /// <br/> price-desc: By price, in descending order (highest - lowest).
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("sort_order")]
        public string? Sort_order { get; set; } = default!;

        /// <summary>
        /// The suffix of the liquid template being used. For example, if the value is custom, then the collection is using the collection.custom.liquid template. If the value is null, then the collection is using the default collection.liquid.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("template_suffix")]
        public string? Template_suffix { get; set; } = default!;

        /// <summary>
        /// The name of the collection. (limit: 255 characters)
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("title")]
        public string? Title { get; set; } = default!;

        /// <summary>
        /// The date and time (ISO 8601 format) when the collection was last modified.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("updated_at")]
        public string? Updated_at { get; set; } = default!;

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