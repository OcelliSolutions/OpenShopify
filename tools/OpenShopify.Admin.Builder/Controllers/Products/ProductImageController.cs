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

    public abstract class ProductImageControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Receive a list of all Product Images
        /// </summary>
        /// <remarks>
        /// Get all product images
        /// </remarks>
        /// <param name="fields">comma-separated list of fields to include in the response</param>
        /// <param name="since_id">Restrict results to after the specified ID</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("products/{product_id}/images.json")]
        public abstract System.Threading.Tasks.Task ListProductImages(long product_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? fields = null, [Microsoft.AspNetCore.Mvc.FromQuery] long? since_id = null);

        /// <summary>
        /// Create a new Product Image
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("products/{product_id}/images.json")]
        public abstract System.Threading.Tasks.Task CreateProductImage([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.CreateProductImageRequest request, long product_id);

        /// <summary>
        /// Receive a count of all Product Images
        /// </summary>
        /// <remarks>
        /// Get a count of all product images
        /// </remarks>
        /// <param name="since_id">Restrict results to after the specified ID</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("products/{product_id}/images/count.json")]
        public abstract System.Threading.Tasks.Task CountProductImages(long? product_id = null, [Microsoft.AspNetCore.Mvc.FromQuery] long? since_id = null);

        /// <summary>
        /// Receive a single Product Image
        /// </summary>
        /// <remarks>
        /// Get a single product image by id
        /// </remarks>
        /// <param name="fields">comma-separated list of fields to include in the response</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("products/{product_id}/images/{image_id}.json")]
        public abstract System.Threading.Tasks.Task GetProductImage(long image_id, long product_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? fields = null);

        /// <summary>
        /// Modify an existing Product Image
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("products/{product_id}/images/{image_id}.json")]
        public abstract System.Threading.Tasks.Task UpdateProductImage([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.UpdateProductImageRequest request, long image_id, long product_id);

        /// <summary>
        /// Remove an existing Product Image
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("products/{product_id}/images/{image_id}.json")]
        public abstract System.Threading.Tasks.Task DeleteProductImage(long image_id, long product_id);

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial record ProductImageOrig
    {
        /// <summary>
        /// The order of the product image in the list. The first product image is at position 1 and is the "main" image for the product.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("position")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public int? Position { get; set; } = default!;

        /// <summary>
        /// The id of the product associated with the image.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("product_id")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public long? ProductId { get; set; } = default!;

        /// <summary>
        /// An array of variant ids associated with the image.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("variant_ids")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public System.Collections.Generic.List<long>? VariantIds { get; set; } = default!;

        /// <summary>
        /// Specifies the location of the product image. This parameter supports [URL filters](/docs/liquid/reference/filters/url-filters#img_url) that you can use to retrieve modified copies of the image. For example, add `_small`, to the filename to retrieve a scaled copy of the image at 100 x 100 px (for example, `ipod-nano_small.png`), or add `_2048x2048` to retrieve a copy of the image constrained at 2048 x 2048 px resolution (for example, `ipod-nano_2048x2048.png`).
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("src")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Src { get; set; } = default!;

        /// <summary>
        /// Width dimension of the image which is determined on upload.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("width")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public decimal? Width { get; set; } = default!;

        /// <summary>
        /// Height dimension of the image which is determined on upload.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("height")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public decimal? Height { get; set; } = default!;

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