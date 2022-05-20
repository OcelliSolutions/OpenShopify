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

namespace OpenShopify.Admin.Builder.Controllers
{
    using System = global::System;

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.15.10.0 (NJsonSchema v10.6.10.0 (Newtonsoft.Json v13.0.0.0))")]

    public abstract class ScriptTagControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Retrieves a list of all script tags
        /// </summary>
        /// <param name="created_at_max">Show script tags created before this date. (format: 2014-04-25T16:15:47-04:00)</param>
        /// <param name="created_at_min">Show script tags created after this date. (format: 2014-04-25T16:15:47-04:00)</param>
        /// <param name="fields">A comma-separated list of fields to include in the response.</param>
        /// <param name="limit">The number of results to return.</param>
        /// <param name="since_id">Restrict results to after the specified ID.</param>
        /// <param name="src">Show script tags with this URL.</param>
        /// <param name="updated_at_max">Show script tags last updated before this date. (format: 2014-04-25T16:15:47-04:00)</param>
        /// <param name="updated_at_min">Show script tags last updated after this date. (format: 2014-04-25T16:15:47-04:00)</param>
        /// <returns>Retrieves a list of all script tags</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("script_tags.json")]
        public abstract System.Threading.Tasks.Task ListScriptTags([Microsoft.AspNetCore.Mvc.FromQuery] DateTime? created_at_max, [Microsoft.AspNetCore.Mvc.FromQuery] DateTime? created_at_min, [Microsoft.AspNetCore.Mvc.FromQuery] string? fields, [Microsoft.AspNetCore.Mvc.FromQuery] int? limit, string? page_info, [Microsoft.AspNetCore.Mvc.FromQuery] int? since_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? src, [Microsoft.AspNetCore.Mvc.FromQuery] DateTime? updated_at_max, [Microsoft.AspNetCore.Mvc.FromQuery] DateTime? updated_at_min);

        /// <summary>
        /// Creates a new script tag
        /// </summary>
        /// <returns>Creates a new script tag</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("script_tags.json")]
        public abstract System.Threading.Tasks.Task CreateScriptTag([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.CreateScriptTagRequest request);

        /// <summary>
        /// Retrieves a count of all script tags
        /// </summary>
        /// <param name="src">Count only script tags with a given URL.</param>
        /// <returns>Retrieves a count of all script tags</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("script_tags/count.json")]
        public abstract System.Threading.Tasks.Task CountScriptTags([Microsoft.AspNetCore.Mvc.FromQuery] string? src);

        /// <summary>
        /// Retrieves a single script tag
        /// </summary>
        /// <param name="fields">A comma-separated list of fields to include in the response.</param>
        /// <returns>Retrieves a single script tag</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("script_tags/{script_tag_id}.json")]
        public abstract System.Threading.Tasks.Task GetScriptTag([System.ComponentModel.DataAnnotations.Required] long script_tag_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? fields);

        /// <summary>
        /// Updates a script tag
        /// </summary>
        /// <returns>Updates a script tag</returns>
        [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("script_tags/{script_tag_id}.json")]
        public abstract System.Threading.Tasks.Task UpdateScriptTag([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.UpdateScriptTagRequest request, [System.ComponentModel.DataAnnotations.Required] long script_tag_id);

        /// <summary>
        /// Deletes a script tag
        /// </summary>
        /// <returns>Deletes a script tag</returns>
        [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("script_tags/{script_tag_id}.json")]
        public abstract System.Threading.Tasks.Task DeleteScriptTag([System.ComponentModel.DataAnnotations.Required] long script_tag_id);

    }

    


}

#pragma warning restore 1591
#pragma warning restore 1573
#pragma warning restore  472
#pragma warning restore  114
#pragma warning restore  108
#pragma warning restore 3016
#pragma warning restore 8603