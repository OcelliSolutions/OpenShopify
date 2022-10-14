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

    public abstract class AssetControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Retrieves a list of assets for a theme
        /// </summary>
        /// <remarks>
        /// Retrieves a list of assets for a theme.
        /// 
        /// **Note:** Retrieving a list of assets returns only metadata about each asset. To retrieve an asset's content, you need to retrieve the asset individually.
        /// </remarks>
        /// <param name="fields">Specify which fields to show using a comma-separated list of field names.</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("themes/{theme_id}/assets.json")]
        public abstract System.Threading.Tasks.Task ListAssetsForTheme(long theme_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? fields = null);

        /// <summary>
        /// Creates or updates an asset for a theme
        /// </summary>
        /// <remarks>
        /// Creates or updates an asset for a theme.
        /// 
        /// In the PUT request, you can include the `src` or `source_key` property to create the asset from an existing file.
        /// </remarks>
        [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("themes/{theme_id}/assets.json")]
        public abstract System.Threading.Tasks.Task CreateOrUpdatesAssetForTheme([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.CreateOrUpdatesAssetForThemeRequest request, long theme_id);

        /// <summary>
        /// Deletes an asset from a theme
        /// </summary>
        /// <param name="assetkey">Deletes a single asset from a theme by specifying the asset's key.</param>
        [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("themes/{theme_id}/assets.json")]
        public abstract System.Threading.Tasks.Task DeleteAssetFromTheme([Microsoft.AspNetCore.Mvc.FromQuery(Name = "asset[key]")] string? assetkey = null, long? theme_id = null);

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial record AssetOrig
    {
        /// <summary>
        /// A base64-encoded image.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("attachment")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Attachment { get; set; } = default!;

        /// <summary>
        /// The [MD5](https://en.wikipedia.org/wiki/MD5) representation of the content, consisting of a string of 32 hexadecimal digits. May be null if an asset has not been updated recently.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("checksum")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Checksum { get; set; } = default!;

        /// <summary>
        /// The [MIME](https://en.wikipedia.org/wiki/Media_type) representation of the content, consisting of the type and subtype of the asset.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("content_type")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? ContentType { get; set; } = default!;

        /// <summary>
        /// The path to the asset within a theme. It consists of the file's directory and filename. For example, the asset `assets/bg-body-green.gif` is in the **assets** directory, so its key is `assets/bg-body-green.gif`.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("key")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Key { get; set; } = default!;

        /// <summary>
        /// The public-facing URL of the asset.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("public_url")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? PublicUrl { get; set; } = default!;

        /// <summary>
        /// The asset size in bytes.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("size")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public decimal? Size { get; set; } = default!;

        /// <summary>
        /// The ID for the theme that an asset belongs to.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("theme_id")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public long? ThemeId { get; set; } = default!;

        /// <summary>
        /// The text content of the asset, such as the HTML and Liquid markup of a template file.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("value")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Value { get; set; } = default!;

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