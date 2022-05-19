
using System.Text.Json.Serialization;

namespace OpenShopify.Admin.Builder.Models
{
    /// <summary>
    /// An object representing a Shopify blog article.
    /// </summary>
    public class ArticleBase
    {
        /// <summary>
        /// The name of the author of this article
        /// </summary>
        [JsonPropertyName("author")]
        public string? Author { get; set; }

        /// <summary>
        /// A unique numeric identifier for the blog containing the article.
        /// </summary>
        [JsonPropertyName("blog_id")]
        public long? BlogId { get; set; }

        /// <summary>
        /// The text of the body of the article, complete with HTML markup.
        /// </summary>
        [JsonPropertyName("body_html")]
        public string? BodyHtml { get; set; }

        /// <summary>
        /// The date and time when the article was created.
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTimeOffset? CreatedAt { get; set; }

        /// <summary>
        /// A human-friendly unique string for an article automatically generated from its title. It is used in the article's URL.
        /// </summary>
        [JsonPropertyName("handle")]
        public string? Handle { get; set; }

        /// <summary>
        /// The article image.
        /// </summary>
        [JsonPropertyName("image")]
        public ArticleImage Image { get; set; }

        /// <summary>
        /// States whether or not the article is visible. 
        /// </summary>
        [JsonPropertyName("published")]
        public bool? Published { get; set; }

        /// <summary>
        /// The date and time when the article was published. 
        /// </summary>
        [JsonPropertyName("published_at")]
        public DateTimeOffset? PublishedAt { get; set; }

        /// <summary>
        /// The text of the summary of the article, complete with HTML markup.
        /// </summary>
        [JsonPropertyName("summary_html")]
        public string? SummaryHtml { get; set; }

        /// <summary>
        /// Tags are additional short descriptors formatted as a string of comma-separated values. For example, if an article has three tags: tag1, tag2, tag3.
        /// </summary>
        [JsonPropertyName("tags")]
        public string? Tags { get; set; }

        /// <summary>
        /// States the name of the template an article is using if it is using an alternate template. If an article is using the default article.liquid template, the value returned is null.
        /// </summary>
        [JsonPropertyName("template_suffix")]
        public string? TemplateSuffix { get; set; }

        /// <summary>
        /// The title of the article.
        /// </summary>
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        /// <summary>
        /// The date and time when the article was last updated.
        /// </summary>
        [JsonPropertyName("updated_at")]
        public DateTimeOffset? UpdatedAt { get; set; }

        /// <summary>
        /// A unique numeric identifier for the author of the article.
        /// </summary>
        [JsonPropertyName("user_id")]
        public long? UserId { get; set; }
    }
}
