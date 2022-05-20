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

    public abstract class BlogControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Retrieve a list of all blogs
        /// </summary>
        /// <param name="fields">comma-separated list of fields to include in the response</param>
        /// <param name="handle">Filter by blog handle</param>
        /// <param name="limit">The maximum number of results to retrieve.</param>
        /// <param name="since_id">Restrict results to after the specified ID</param>
        /// <returns>Retrieve a list of all blogs</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("blogs.json")]
        public abstract System.Threading.Tasks.Task ListBlogs([Microsoft.AspNetCore.Mvc.FromQuery] string? fields, [Microsoft.AspNetCore.Mvc.FromQuery] string? handle, [Microsoft.AspNetCore.Mvc.FromQuery] int? limit, string? page_info, [Microsoft.AspNetCore.Mvc.FromQuery] int? since_id);

        /// <summary>
        /// Create a new Blog
        /// </summary>
        /// <param name="title">The title of the blog. Maximum length: 255 characters.</param>
        /// <returns>Create a new Blog</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("blogs.json")]
        public abstract System.Threading.Tasks.Task CreateBlog([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.CreateBlogRequest request, [Microsoft.AspNetCore.Mvc.FromQuery] string title);

        /// <summary>
        /// Receive a count of all Blogs
        /// </summary>
        /// <returns>Receive a count of all Blogs</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("blogs/count.json")]
        public abstract System.Threading.Tasks.Task CountBlogs();

        /// <summary>
        /// Receive a single Blog
        /// </summary>
        /// <param name="fields">comma-separated list of fields to include in the response</param>
        /// <returns>Receive a single Blog</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("blogs/{blog_id}.json")]
        public abstract System.Threading.Tasks.Task GetBlog([System.ComponentModel.DataAnnotations.Required] long blog_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? fields);

        /// <summary>
        /// Modify an existing Blog
        /// </summary>
        /// <returns>Modify an existing Blog</returns>
        [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("blogs/{blog_id}.json")]
        public abstract System.Threading.Tasks.Task UpdateBlog([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.UpdateBlogRequest request, [System.ComponentModel.DataAnnotations.Required] long blog_id);

        /// <summary>
        /// Remove an existing Blog
        /// </summary>
        /// <returns>Remove an existing Blog</returns>
        [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("blogs/{blog_id}.json")]
        public abstract System.Threading.Tasks.Task DeleteBlog([System.ComponentModel.DataAnnotations.Required] long blog_id);

    }

    


}

#pragma warning restore 1591
#pragma warning restore 1573
#pragma warning restore  472
#pragma warning restore  114
#pragma warning restore  108
#pragma warning restore 3016
#pragma warning restore 8603