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

    public abstract class PriceRuleControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Creates a price rule
        /// </summary>
        /// <returns>Creates a price rule</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("price_rules.json")]
        public abstract System.Threading.Tasks.Task CreatePriceRule([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.CreatePriceRuleRequest request);

        /// <summary>
        /// Retrieves a list of price rules
        /// </summary>
        /// <param name="created_at_max">Show price rules created before date (format 2017-03-25T16:15:47-04:00).</param>
        /// <param name="created_at_min">Show price rules created after date (format 2017-03-25T16:15:47-04:00).</param>
        /// <param name="ends_at_max">Show price rules ending before date (format 2017-03-25T16:15:47-04:00).</param>
        /// <param name="ends_at_min">Show price rules ending after date (format 2017-03-25T16:15:47-04:00).</param>
        /// <param name="limit">The maximum number of results to retrieve.</param>
        /// <param name="since_id">Restrict results to after the specified ID.</param>
        /// <param name="starts_at_max">Show price rules starting before date (format 2017-03-25T16:15:47-04:00).</param>
        /// <param name="starts_at_min">Show price rules starting after date (format 2017-03-25T16:15:47-04:00).</param>
        /// <param name="times_used">Show price rules with times used.</param>
        /// <param name="updated_at_max">Show price rules last updated before date (format 2017-03-25T16:15:47-04:00).</param>
        /// <param name="updated_at_min">Show price rules last updated after date (format 2017-03-25T16:15:47-04:00).</param>
        /// <returns>Retrieves a list of price rules</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("price_rules.json")]
        public abstract System.Threading.Tasks.Task ListPriceRules([Microsoft.AspNetCore.Mvc.FromQuery] DateTime? created_at_max, [Microsoft.AspNetCore.Mvc.FromQuery] DateTime? created_at_min, [Microsoft.AspNetCore.Mvc.FromQuery] DateTime? ends_at_max, [Microsoft.AspNetCore.Mvc.FromQuery] DateTime? ends_at_min, [Microsoft.AspNetCore.Mvc.FromQuery] int? limit, string? page_info, [Microsoft.AspNetCore.Mvc.FromQuery] int? since_id, [Microsoft.AspNetCore.Mvc.FromQuery] DateTime? starts_at_max, [Microsoft.AspNetCore.Mvc.FromQuery] DateTime? starts_at_min, [Microsoft.AspNetCore.Mvc.FromQuery] string? times_used, [Microsoft.AspNetCore.Mvc.FromQuery] DateTime? updated_at_max, [Microsoft.AspNetCore.Mvc.FromQuery] DateTime? updated_at_min);

        /// <summary>
        /// Updates an existing a price rule
        /// </summary>
        /// <returns>Updates an existing a price rule</returns>
        [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("price_rules/{price_rule_id}.json")]
        public abstract System.Threading.Tasks.Task UpdatePriceRule([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.UpdatePriceRuleRequest request, long price_rule_id);

        /// <summary>
        /// Retrieves a single price rule
        /// </summary>
        /// <returns>Retrieves a single price rule</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("price_rules/{price_rule_id}.json")]
        public abstract System.Threading.Tasks.Task GetPriceRule(long price_rule_id);

        /// <summary>
        /// Remove an existing PriceRule
        /// </summary>
        /// <returns>Remove an existing PriceRule</returns>
        [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("price_rules/{price_rule_id}.json")]
        public abstract System.Threading.Tasks.Task DeleteExistingPriceRule(long price_rule_id);

        /// <summary>
        /// Retrieves a count of all price rules
        /// </summary>
        /// <returns>Retrieves a count of all price rules</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("price_rules/count.json")]
        public abstract System.Threading.Tasks.Task GetCountOfAllPriceRules();

    }

    


}

#pragma warning restore 1591
#pragma warning restore 1573
#pragma warning restore  472
#pragma warning restore  114
#pragma warning restore  108
#pragma warning restore 3016
#pragma warning restore 8603