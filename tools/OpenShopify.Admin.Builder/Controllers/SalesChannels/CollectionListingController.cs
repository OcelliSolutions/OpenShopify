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

    public abstract class CollectionListingControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Retrieve collection listings that are published to your app
        /// </summary>
        /// <param name="limit">Amount of results</param>
        /// <param name="page_info">A unique ID used to access a certain page of results.</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("collection_listings.json")]
        public abstract System.Threading.Tasks.Task GetCollectionListings([Microsoft.AspNetCore.Mvc.FromQuery] int? limit = null, string? page_info = null);

        /// <summary>
        /// Retrieve &lt;code&gt;product_ids&lt;/code&gt; that are published to a &lt;code&gt;collection_id&lt;/code&gt;
        /// </summary>
        /// <param name="limit">Amount of results</param>
        /// <param name="page_info">A unique ID used to access a certain page of results.</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("collection_listings/{collection_listing_id}/product_ids.json")]
        public abstract System.Threading.Tasks.Task GetProductIdsThatArePublishedToCollectionId(long collection_listing_id, [Microsoft.AspNetCore.Mvc.FromQuery] int? limit = null, string? page_info = null);

        /// <summary>
        /// Retrieve a specific collection listing that is published to your app
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("collection_listings/{collection_listing_id}.json")]
        public abstract System.Threading.Tasks.Task GetCollectionListing(long collection_listing_id);

        /// <summary>
        /// Create a collection listing to publish a collection to your app
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("collection_listings/{collection_listing_id}.json")]
        public abstract System.Threading.Tasks.Task CreateCollectionListing([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.CreateCollectionListingRequest request, long collection_listing_id);

        /// <summary>
        /// Delete a collection listing to unpublish a collection from your app
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("collection_listings/{collection_listing_id}.json")]
        public abstract System.Threading.Tasks.Task DeleteCollectionListing(long collection_listing_id);

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial record CollectionListingOrig
    {
        /// <summary>
        /// Identifies which collection this listing is for.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("collection_id")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]   
        public long? CollectionId { get; set; } = default!;

        /// <summary>
        /// The description of the collection, complete with HTML formatting.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("body_html")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]   
        public string? BodyHtml { get; set; } = default!;

        /// <summary>
        /// The default product image for a collection.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("default_product_image")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]   
        public string? DefaultProductImage { get; set; } = default!;

        /// <summary>
        /// The image for a collection.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("image")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]   
        public string? Image { get; set; } = default!;

        /// <summary>
        /// A human-friendly unique string for the Collection automatically generated from its title.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("handle")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]   
        public string? Handle { get; set; } = default!;

        /// <summary>
        /// The date and time when the collection was published. The API returns this in ISO_8601.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("published_at")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]   
        public System.DateTimeOffset? PublishedAt { get; set; } = default!;

        /// <summary>
        /// The name of the collection.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("title")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]   
        public string? Title { get; set; } = default!;

        /// <summary>
        /// The order in which products in the collection appear. Valid values are:
        /// 
        /// *   **alpha-asc**: Alphabetically, in ascending order (A - Z). 
        /// *   **alpha-desc**: Alphabetically, in descending order (Z - A). 
        /// *   **best-selling**: By best-selling products. 
        /// *   **created**: By date created, in ascending order (oldest - newest). 
        /// *   **created-desc**: By date created, in descending order (newest - oldest). 
        /// *   **manual**: Order created by the shop owner. 
        /// *   &lt;strong&gt;price-asc**: By price, in ascending order (lowest - highest). 
        /// *   **price-desc**: By price, in descending order (highest - lowest). &lt;/strong&gt;
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("sort_order")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]   
        public string? SortOrder { get; set; } = default!;

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