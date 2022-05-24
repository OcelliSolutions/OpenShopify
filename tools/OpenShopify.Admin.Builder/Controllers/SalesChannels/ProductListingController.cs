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

    public abstract class ProductListingControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Retrieve product listings that are published to your app
        /// </summary>
        /// <param name="collection_id">Filter by products belonging to a particular collection</param>
        /// <param name="handle">Filter by product handle</param>
        /// <param name="limit">Amount of results</param>
        /// <param name="page_info">A unique ID used to access a certain page of results.</param>
        /// <param name="product_ids">A comma-separated list of product ids</param>
        /// <param name="updated_at_min">Filter by product listings last updated after a certain date and time (formatted in ISO 8601)</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("product_listings.json")]
        public abstract System.Threading.Tasks.Task GetProductListingsThatArePublishedToYourApp(long collection_id, string? handle = null, int? limit = null, string? page_info = null, string? product_ids = null, System.DateTimeOffset? updated_at_min = null);

        /// <summary>
        /// Retrieve &lt;code&gt;product_ids&lt;/code&gt; that are published to your app
        /// </summary>
        /// <param name="limit">Amount of results</param>
        /// <param name="page_info">A unique ID used to access a certain page of results.</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("product_listings/product_ids.json")]
        public abstract System.Threading.Tasks.Task GetProductIdsThatArePublishedToYourApp(int? limit = null, string? page_info = null);

        /// <summary>
        /// Retrieve a count of products that are published to your app
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("product_listings/count.json")]
        public abstract System.Threading.Tasks.Task CountProductsThatArePublishedToYourApp();

        /// <summary>
        /// Retrieve a specific product listing that is published to your app
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("product_listings/{product_listing_id}.json")]
        public abstract System.Threading.Tasks.Task GetProductListingThatIsPublishedToYourApp(long product_listing_id);

        /// <summary>
        /// Create a product listing to publish a product to your app
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("product_listings/{product_listing_id}.json")]
        public abstract System.Threading.Tasks.Task CreateProductListingToPublishProductToYourApp([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.CreateProductListingRequest request, long product_listing_id);

        /// <summary>
        /// Delete a product listing to unpublish a product from your app
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("product_listings/{product_listing_id}.json")]
        public abstract System.Threading.Tasks.Task DeleteProductListingToUnpublishProductFromYourApp(long product_listing_id);

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.16.0.0 (NJsonSchema v10.7.1.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial record ProductListingOrig
    {
        /// <summary>
        /// The unique identifer of the product this listing is for. The primary key for this resource.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("product_id")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]   
        public long? ProductId { get; set; } = default!;

        /// <summary>
        /// The description of the product, complete with HTML formatting.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("body_html")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]   
        public string? BodyHtml { get; set; } = default!;

        /// <summary>
        /// The date and time when the product was created. The API returns this in ISO 8601.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("created_at")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]   
        public System.DateTimeOffset? CreatedAt { get; set; } = default!;

        /// <summary>
        /// A human-friendly unique string for the Product automatically generated from its title.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("handle")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]   
        public string? Handle { get; set; } = default!;

        /// <summary>
        /// A list of image objects, each one representing an image associated with the product.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("images")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]   
        public string? Images { get; set; } = default!;

        /// <summary>
        /// Custom product property names like "Size", "Color", and "Material".
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("options")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]   
        public string? Options { get; set; } = default!;

        /// <summary>
        /// A categorization that a product can be tagged with, commonly used for filtering.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("product_type")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]   
        public string? ProductType { get; set; } = default!;

        /// <summary>
        /// The date and time when the product was published. The API returns this in ISO 8601.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("published_at")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]   
        public System.DateTimeOffset? PublishedAt { get; set; } = default!;

        /// <summary>
        /// A categorization that a product can be tagged with, commonly used for filtering.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("tags")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]   
        public string? Tags { get; set; } = default!;

        /// <summary>
        /// The name of the product.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("title")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]   
        public string? Title { get; set; } = default!;

        /// <summary>
        /// The date and time when the product was last modified. The API returns this in ISO 8601.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("updated_at")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]   
        public System.DateTimeOffset? UpdatedAt { get; set; } = default!;

        /// <summary>
        /// A list of variant objects, each one representing a slightly different version of the product. For example, if a product comes in different sizes and colors, each size and color permutation (such as "small black", "medium black", "large blue"), would be a variant. 
        /// 
        /// To reorder variants, update the product with the variants in the desired order. The position attribute on the variant will be ignored.
        /// 
        /// *   **barcode**: The barcode, UPC or ISBN number for the product. 
        /// *   **compare_at_price**: The competitor's price for the same item. 
        /// *   **created_at**: The date and time when the product variant was created. The API returns this in ISO 8601. 
        /// *   &lt;strong&gt;fulfillment_service&lt;/strong&gt;: Service which is handling fulfillment. Valid values are: `manual`, `gift_card`, or the handle of a [FulfillmentService](/docs/admin-api/rest/reference/shipping-and-fulfillment/fulfillmentservice). 
        /// *   **grams**: The weight of the product variant in grams. 
        /// *   **weight**: The weight of the product variant in the unit system specified with **weight_unit**. 
        /// *   **weight_unit**: The unit system that the product variant's weight is measure in. The weight_unit can be either "g", "kg, "oz", or "lb". 
        /// *   **id**: The unique numeric identifier for the product variant. 
        /// *   **inventory_management**: Specifies whether or not Shopify tracks the number of items in stock for this product variant. 
        /// *   **inventory_policy**: Specifies whether or not customers are allowed to place an order for a product variant when it's out of stock. 
        /// *   **inventory_quantity**: The number of items in stock for this product variant. 
        /// *   **metafield**: Attaches additional information to a shop's resources. 
        /// *   **option**: Custom properties that a shop owner can use to define product variants. Multiple options can exist. Options are represented as: `option1`, `option2`, `option3`, etc. 
        /// *   **position**: The order of the product variant in the list of product variants. 1 is the first position. To reorder variants, update the product with the variants in the desired order. The position attribute on the variant will be ignored. 
        /// *   **price**: The price of the product variant. 
        /// *   **product_id**: The unique numeric identifier for the product. 
        /// *   **requires_shipping**: Specifies whether or not a customer needs to provide a shipping address when placing an order for this product variant. 
        /// *   **sku**: A unique identifier for the product in the shop. 
        /// *   **taxable**: Specifies whether or not a tax is charged when the product variant is sold. 
        /// *   **title**: The title of the product variant. 
        /// *   **updated_at**: The date and time when the product variant was last modified. The API returns this in ISO 8601. 
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("variants")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]   
        public string? Variants { get; set; } = default!;

        /// <summary>
        /// The name of the vendor of the product.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("vendor")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull)]   
        public string? Vendor { get; set; } = default!;

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