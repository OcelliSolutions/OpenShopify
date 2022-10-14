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

    public abstract class ArticleControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Retrieves a list of all articles from a blog
        /// </summary>
        /// <remarks>
        /// Retrieves a list of all articles from a blog. **Note:** As of version 2019-10, this endpoint implements pagination by using links that are provided in the response header. Sending the `page` parameter will return an error. To learn more, see [*Make paginated requests to the REST Admin API*](/api/usage/pagination-rest).
        /// </remarks>
        /// <param name="author">Filter articles by article author.</param>
        /// <param name="created_at_max">Show articles created before date (format: 2014-04-25T16:15:47-04:00).</param>
        /// <param name="created_at_min">Show articles created after date (format: 2014-04-25T16:15:47-04:00).</param>
        /// <param name="fields">Show only certain fields, specified by a comma-separated list of field names.</param>
        /// <param name="handle">Retrieve an article with a specific handle.</param>
        /// <param name="limit">The maximum number of results to retrieve.</param>
        /// <param name="page_info">A unique ID used to access a certain page of results.</param>
        /// <param name="published_at_max">Show articles published before date (format: 2014-04-25T16:15:47-04:00).</param>
        /// <param name="published_at_min">Show articles published after date (format: 2014-04-25T16:15:47-04:00).</param>
        /// <param name="published_status">Retrieve results based on their published status.</param>
        /// <param name="since_id">Restrict results to after the specified ID.</param>
        /// <param name="tag">Filter articles with a specific tag.</param>
        /// <param name="updated_at_max">Show articles last updated before date (format: 2014-04-25T16:15:47-04:00).</param>
        /// <param name="updated_at_min">Show articles last updated after date (format: 2014-04-25T16:15:47-04:00).</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("blogs/{blog_id}/articles.json")]
        public abstract System.Threading.Tasks.Task ListArticlesFromBlog(long blog_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? author = null, [Microsoft.AspNetCore.Mvc.FromQuery] System.DateTimeOffset? created_at_max = null, [Microsoft.AspNetCore.Mvc.FromQuery] System.DateTimeOffset? created_at_min = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? fields = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? handle = null, [Microsoft.AspNetCore.Mvc.FromQuery] int? limit = null, string? page_info = null, [Microsoft.AspNetCore.Mvc.FromQuery] System.DateTimeOffset? published_at_max = null, [Microsoft.AspNetCore.Mvc.FromQuery] System.DateTimeOffset? published_at_min = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? published_status = null, [Microsoft.AspNetCore.Mvc.FromQuery] long? since_id = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? tag = null, [Microsoft.AspNetCore.Mvc.FromQuery] System.DateTimeOffset? updated_at_max = null, [Microsoft.AspNetCore.Mvc.FromQuery] System.DateTimeOffset? updated_at_min = null);

        /// <summary>
        /// Creates an article for a blog
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("blogs/{blog_id}/articles.json")]
        public abstract System.Threading.Tasks.Task CreateArticleForBlog([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.CreateArticleForBlogRequest request, long blog_id);

        /// <summary>
        /// Retrieves a count of all articles from a blog
        /// </summary>
        /// <param name="created_at_max">Count articles created before date (format: 2014-04-25T16:15:47-04:00).</param>
        /// <param name="created_at_min">Count articles created after date (format: 2014-04-25T16:15:47-04:00).</param>
        /// <param name="published_at_max">Count articles published before date (format: 2014-04-25T16:15:47-04:00).</param>
        /// <param name="published_at_min">Count articles published after date (format: 2014-04-25T16:15:47-04:00).</param>
        /// <param name="published_status">Count articles with a given published status.</param>
        /// <param name="updated_at_max">Count articles last updated before date (format: 2014-04-25T16:15:47-04:00).</param>
        /// <param name="updated_at_min">Count articles last updated after date (format: 2014-04-25T16:15:47-04:00).</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("blogs/{blog_id}/articles/count.json")]
        public abstract System.Threading.Tasks.Task CountArticlesFromBlog(long? blog_id = null, [Microsoft.AspNetCore.Mvc.FromQuery] System.DateTimeOffset? created_at_max = null, [Microsoft.AspNetCore.Mvc.FromQuery] System.DateTimeOffset? created_at_min = null, [Microsoft.AspNetCore.Mvc.FromQuery] System.DateTimeOffset? published_at_max = null, [Microsoft.AspNetCore.Mvc.FromQuery] System.DateTimeOffset? published_at_min = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? published_status = null, [Microsoft.AspNetCore.Mvc.FromQuery] System.DateTimeOffset? updated_at_max = null, [Microsoft.AspNetCore.Mvc.FromQuery] System.DateTimeOffset? updated_at_min = null);

        /// <summary>
        /// Receive a single Article
        /// </summary>
        /// <remarks>
        /// Retrieves a single article
        /// </remarks>
        /// <param name="fields">Show only certain fields, specifed by a comma-separated list of field names.</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("blogs/{blog_id}/articles/{article_id}.json")]
        public abstract System.Threading.Tasks.Task GetArticle(long article_id, long blog_id, [Microsoft.AspNetCore.Mvc.FromQuery] string? fields = null);

        /// <summary>
        /// Updates an article
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("blogs/{blog_id}/articles/{article_id}.json")]
        public abstract System.Threading.Tasks.Task UpdateArticle([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.UpdateArticleRequest request, long article_id, long blog_id);

        /// <summary>
        /// Deletes an article
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("blogs/{blog_id}/articles/{article_id}.json")]
        public abstract System.Threading.Tasks.Task DeleteArticle(long article_id, long blog_id);

        /// <summary>
        /// Retrieves a list of all article authors
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("articles/authors.json")]
        public abstract System.Threading.Tasks.Task ListArticleAuthors();

        /// <summary>
        /// Retrieves a list of all article tags
        /// </summary>
        /// <param name="limit">The maximum number of tags to retrieve.</param>
        /// <param name="page_info">A unique ID used to access a certain page of results.</param>
        /// <param name="popular">A flag for ordering retrieved tags. If present in the request, then the results will be ordered by popularity, starting with the most popular tag.</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("articles/tags.json")]
        public abstract System.Threading.Tasks.Task ListArticleTags([Microsoft.AspNetCore.Mvc.FromQuery] int? limit = null, string? page_info = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? popular = null);

        /// <summary>
        /// Retrieves a list of all article tags from a specific blog
        /// </summary>
        /// <param name="limit">The maximum number of tags to retrieve.</param>
        /// <param name="page_info">A unique ID used to access a certain page of results.</param>
        /// <param name="popular">A flag for ordering retrieved tags. If present in the request, then the results will be ordered by popularity, starting with the most popular tag.</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("blogs/{blog_id}/articles/tags.json")]
        public abstract System.Threading.Tasks.Task ListArticleTagsFromSpecificBlog(long blog_id, [Microsoft.AspNetCore.Mvc.FromQuery] int? limit = null, string? page_info = null, [Microsoft.AspNetCore.Mvc.FromQuery] string? popular = null);

        /// <summary>
        /// Remove the image from an article
        /// </summary>
        [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("articles/{article_id}.json")]
        public abstract System.Threading.Tasks.Task DeleteImageFromArticle(long article_id);

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.17.0.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial record ArticleOrig
    {
        /// <summary>
        /// The name of the author of the article.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("author")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Author { get; set; } = default!;

        /// <summary>
        /// The ID of the blog containing the article.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("blog_id")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public long? BlogId { get; set; } = default!;

        /// <summary>
        /// The text of the body of the article, complete with HTML markup.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("body_html")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? BodyHtml { get; set; } = default!;

        /// <summary>
        /// A human-friendly unique string for the article that's automatically generated from the article's title.The handle is used in the article's URL.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("handle")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Handle { get; set; } = default!;

        /// <summary>
        /// An image associated with the article. It can have the following properties:
        /// 
        /// *   **attachment**: An image attached to article returned as Base64-encoded binary data. 
        /// *   **src**: A source URL that specifies the location of the image. 
        /// *   **alt**: Alternative text that describes the image.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("image")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Image { get; set; } = default!;

        /// <summary>
        /// The additional information attached to an Article object. It has the following properties: 
        /// 
        /// *   **key**: An identifier for the metafield. (maximum: 30 characters) 
        /// *   **namespace**: A container for a set of metadata. Namespaces help distinguish between metadata created by different apps. (maximum: 20 characters) 
        /// *   **value**: The information to be stored as metadata. 
        /// *   **type**: The metafield's information type. Refer to the [full list of types](/apps/metafields/types). 
        /// *   **description (optional)**: Additional information about the metafield. 
        /// 
        /// For more information on attaching metadata to Shopify resources, see the [Metafield](/api/admin-rest/latest/resources/metafield) resource.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("metafields")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Metafields { get; set; } = default!;

        /// <summary>
        /// Whether the article is visible.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("published")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public bool? Published { get; set; } = default!;

        /// <summary>
        /// The date and time ([ISO 8601](https://en.wikipedia.org/wiki/ISO_8601) format) when the article was published.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("published_at")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public System.DateTimeOffset? PublishedAt { get; set; } = default!;

        /// <summary>
        /// A summary of the article, which can include HTML markup. The summary is used by the online store theme to display the article on other pages, such as the home page or the main blog page.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("summary_html")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? SummaryHtml { get; set; } = default!;

        /// <summary>
        /// A comma-separated list of tags. Tags are additional short descriptors formatted as a string of comma-separated values.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("tags")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Tags { get; set; } = default!;

        /// <summary>
        /// The name of the template an article is using if it's using an alternate template. If an article is using the default `article.liquid` template, then the value returned is `null`.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("template_suffix")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? TemplateSuffix { get; set; } = default!;

        /// <summary>
        /// The title of the article.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("title")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public string? Title { get; set; } = default!;

        /// <summary>
        /// A unique numeric identifier for the author of the article.
        /// </summary>

        [System.Text.Json.Serialization.JsonPropertyName("user_id")]

        [System.Text.Json.Serialization.JsonIgnore(Condition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault)]   
        public long? UserId { get; set; } = default!;

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