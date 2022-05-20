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

    public abstract class MarketingEventControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Retrieves a list of all marketing events
        /// </summary>
        /// <param name="limit">The amount of results to return.</param>
        /// <param name="offset">The number of marketing events to skip.</param>
        /// <returns>Retrieves a list of all marketing events</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("marketing_events.json")]
        public abstract System.Threading.Tasks.Task ListMarketingEvents([Microsoft.AspNetCore.Mvc.FromQuery] int? limit, string? page_info, [Microsoft.AspNetCore.Mvc.FromQuery] string? offset);

        /// <summary>
        /// Creates a marketing event
        /// </summary>
        /// <returns>Creates a marketing event</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("marketing_events.json")]
        public abstract System.Threading.Tasks.Task CreateMarketingEvent([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.CreateMarketingEventRequest request);

        /// <summary>
        /// Retrieves a count of all marketing events
        /// </summary>
        /// <returns>Retrieves a count of all marketing events</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("marketing_events/count.json")]
        public abstract System.Threading.Tasks.Task GetCountOfAllMarketingEvents();

        /// <summary>
        /// Retrieves a single marketing event
        /// </summary>
        /// <returns>Retrieves a single marketing event</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("marketing_events/{marketing_event_id}.json")]
        public abstract System.Threading.Tasks.Task GetMarketingEvent(long marketing_event_id);

        /// <summary>
        /// Updates a marketing event
        /// </summary>
        /// <returns>Updates a marketing event</returns>
        [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("marketing_events/{marketing_event_id}.json")]
        public abstract System.Threading.Tasks.Task UpdateMarketingEvent([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.UpdateMarketingEventRequest request, long marketing_event_id);

        /// <summary>
        /// Deletes a marketing event
        /// </summary>
        /// <returns>Deletes a marketing event</returns>
        [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("marketing_events/{marketing_event_id}.json")]
        public abstract System.Threading.Tasks.Task DeleteMarketingEvent(long marketing_event_id);

        /// <summary>
        /// Creates marketing engagements on a marketing event
        /// </summary>
        /// <param name="occurred_on">The date that these engagements occurred on, in the format “YYYY-MM-DD”.</param>
        /// <param name="ad_spend">The total ad spend for the day, if the marketing event is a paid ad with a daily spend.</param>
        /// <param name="clicks_count">The total number of clicks on the marketing event for the day.</param>
        /// <param name="comments_count">The total number of comments for the day.</param>
        /// <param name="favorites_count">The total number of favorites for the day.</param>
        /// <param name="impressions_count">The total number of impressions for the day. An impression occurs when the marketing event is served to a customer, either as a email or through a marketing channel.</param>
        /// <param name="is_cumulative">Whether the engagements are reported as lifetime values rather than daily totals.</param>
        /// <param name="shares_count">The total number of shares for the day.</param>
        /// <param name="views_count">The total number of views for the day. A view occurs when a customer reads the marketing event that was served to them, for example, if the customer opens the email or spends time looking at a Facebook post.</param>
        /// <returns>Creates marketing engagements on a marketing event</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("marketing_events/{marketing_event_id}/engagements.json")]
        public abstract System.Threading.Tasks.Task CreateMarketingEngagementsOnMarketingEvent([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.CreateMarketingEventRequest request, long marketing_event_id, [Microsoft.AspNetCore.Mvc.FromQuery] string occurred_on, [Microsoft.AspNetCore.Mvc.FromQuery] string? ad_spend, [Microsoft.AspNetCore.Mvc.FromQuery] string? clicks_count, [Microsoft.AspNetCore.Mvc.FromQuery] string? comments_count, [Microsoft.AspNetCore.Mvc.FromQuery] string? favorites_count, [Microsoft.AspNetCore.Mvc.FromQuery] string? impressions_count, [Microsoft.AspNetCore.Mvc.FromQuery] string? is_cumulative, [Microsoft.AspNetCore.Mvc.FromQuery] string? shares_count, [Microsoft.AspNetCore.Mvc.FromQuery] string? views_count);

    }

    


}

#pragma warning restore 1591
#pragma warning restore 1573
#pragma warning restore  472
#pragma warning restore  114
#pragma warning restore  108
#pragma warning restore 3016
#pragma warning restore 8603