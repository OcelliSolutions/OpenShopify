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

    public abstract class ProductImageControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Receive a list of all Product Images
        /// </summary>
        /// <param name="fields">comma-separated list of fields to include in the response</param>
        /// <param name="since_id">Restrict results to after the specified ID</param>
        /// <returns>Receive a list of all Product Images</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("admin/api/{api_version}/products/{product_id}/images.json")]
        public abstract System.Threading.Tasks.Task ReceiveListOfAllProductImages(string product_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? fields = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? since_id = null);

        /// <summary>
        /// Create a new Product Image
        /// </summary>
        /// <returns>Create a new Product Image</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("admin/api/{api_version}/products/{product_id}/images.json")]
        public abstract System.Threading.Tasks.Task CreateNewProductImage(string product_id);

        /// <summary>
        /// Receive a count of all Product Images
        /// </summary>
        /// <param name="since_id">Restrict results to after the specified ID</param>
        /// <returns>Receive a count of all Product Images</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("admin/api/{api_version}/products/{product_id}/images/count.json")]
        public abstract System.Threading.Tasks.Task ReceiveCountOfAllProductImages(string product_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? since_id = null);

        /// <summary>
        /// Receive a single Product Image
        /// </summary>
        /// <param name="fields">comma-separated list of fields to include in the response</param>
        /// <returns>Receive a single Product Image</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("admin/api/{api_version}/products/{product_id}/images/{image_id}.json")]
        public abstract System.Threading.Tasks.Task ReceiveSingleProductImage(string image_id, string product_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? fields = null);

        /// <summary>
        /// Modify an existing Product Image
        /// </summary>
        /// <returns>Modify an existing Product Image</returns>
        [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("admin/api/{api_version}/products/{product_id}/images/{image_id}.json")]
        public abstract System.Threading.Tasks.Task ModifyExistingProductImage(string image_id, string product_id);

        /// <summary>
        /// Remove an existing Product Image
        /// </summary>
        /// <returns>Remove an existing Product Image</returns>
        [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("admin/api/{api_version}/products/{product_id}/images/{image_id}.json")]
        public abstract System.Threading.Tasks.Task RemoveExistingProductImage(string image_id, string product_id);

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class ProductImage
    {
        /// <summary>
        /// The date and time when the product image was created. The API returns this value in ISO 8601 format.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("created_at")]
        public string? Created_at { get; set; } = default!;

        /// <summary>
        /// A unique numeric identifier for the product image.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("id")]
        public string? Id { get; set; } = default!;

        /// <summary>
        /// The order of the product image in the list. The first product image is at position 1 and is the "main" image for the product.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("position")]
        public string? Position { get; set; } = default!;

        /// <summary>
        /// The id of the product associated with the image.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("product_id")]
        public string? Product_id { get; set; } = default!;

        /// <summary>
        /// An array of variant ids associated with the image.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("variant_ids")]
        public string? Variant_ids { get; set; } = default!;

        /// <summary>
        /// Specifies the location of the product image. This parameter supports URL filters that you can use to retrieve modified copies of the image. For example, add &amp;#95;small, to the filename to retrieve a scaled copy of the image at 100 x 100 px (for example, ipod-nano_small.png), or add &amp;#95;2048x2048 to retrieve a copy of the image constrained at 2048 x 2048 px resolution (for example, ipod-nano_2048x2048.png).
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("src")]
        public string? Src { get; set; } = default!;

        /// <summary>
        /// Width dimension of the image which is determined on upload.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("width")]
        public string? Width { get; set; } = default!;

        /// <summary>
        /// Height dimension of the image which is determined on upload.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("height")]
        public string? Height { get; set; } = default!;

        /// <summary>
        /// The date and time when the product image was last modified. The API returns this value in ISO 8601 format.
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