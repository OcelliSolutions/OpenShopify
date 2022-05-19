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

    public abstract class DiscountCodeControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
    {
        /// <summary>
        /// Creates a discount code
        /// </summary>
        /// <returns>Creates a discount code</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("price_rules/{price_rule_id}/discount_codes.json")]
        public abstract System.Threading.Tasks.Task CreateDiscountCode([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.CreateDiscountCodeRequest request, long price_rule_id);

        /// <summary>
        /// Retrieves a list of discount codes
        /// </summary>
        /// <returns>Retrieves a list of discount codes</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("price_rules/{price_rule_id}/discount_codes.json")]
        public abstract System.Threading.Tasks.Task RetrieveListOfDiscountCodes(long price_rule_id);

        /// <summary>
        /// Updates an existing discount code
        /// </summary>
        /// <returns>Updates an existing discount code</returns>
        [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("price_rules/{price_rule_id}/discount_codes/{discount_code_id}.json")]
        public abstract System.Threading.Tasks.Task UpdateExistingDiscountCode([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.UpdateDiscountCodeRequest request, long discount_code_id, long price_rule_id);

        /// <summary>
        /// Retrieves a single discount code
        /// </summary>
        /// <returns>Retrieves a single discount code</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("price_rules/{price_rule_id}/discount_codes/{discount_code_id}.json")]
        public abstract System.Threading.Tasks.Task RetrieveSingleDiscountCode(long discount_code_id, long price_rule_id);

        /// <summary>
        /// Deletes a discount code
        /// </summary>
        /// <returns>Deletes a discount code</returns>
        [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("price_rules/{price_rule_id}/discount_codes/{discount_code_id}.json")]
        public abstract System.Threading.Tasks.Task DeleteDiscountCode(long discount_code_id, long price_rule_id);

        /// <summary>
        /// Retrieves the location of a discount code
        /// </summary>
        /// <param name="code">Retrieves the location of a discount code by code name.</param>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("discount_codes/lookup.json")]
        public abstract System.Threading.Tasks.Task RetrieveLocationOfDiscountCode([Microsoft.AspNetCore.Mvc.FromQuery] string code);

        /// <summary>
        /// Retrieves a count of discount codes for a shop
        /// </summary>
        /// <param name="times_used">Show discount codes with times used.</param>
        /// <param name="times_used_max">Show discount codes used greater than or equal to this value.</param>
        /// <param name="times_used_min">Show discount codes used less than or equal to this value.</param>
        /// <returns>Retrieves a count of discount codes for a shop</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("discount_codes/count.json")]
        public abstract System.Threading.Tasks.Task RetrieveCountOfDiscountCodesForShop([Microsoft.AspNetCore.Mvc.FromQuery] string? times_used, [Microsoft.AspNetCore.Mvc.FromQuery] string? times_used_max, [Microsoft.AspNetCore.Mvc.FromQuery] string? times_used_min);

        /// <summary>
        /// Creates a discount code creation job
        /// </summary>
        /// <returns>Creates a discount code creation job</returns>
        [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("price_rules/{price_rule_id}/batch.json")]
        public abstract System.Threading.Tasks.Task CreateDiscountCodeCreationJob([System.ComponentModel.DataAnnotations.Required] OpenShopify.Admin.Builder.Models.CreateDiscountCodeRequest request, long price_rule_id);

        /// <summary>
        /// Retrieves a discount code creation job
        /// </summary>
        /// <returns>Retrieves a discount code creation job</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("price_rules/{price_rule_id}/batch/{batch_id}.json")]
        public abstract System.Threading.Tasks.Task RetrieveDiscountCodeCreationJob(long batch_id, long price_rule_id);

        /// <summary>
        /// Retrieves a list of discount codes for a discount code creation job
        /// </summary>
        /// <returns>Retrieves a list of discount codes for a discount code creation job</returns>
        [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("price_rules/{price_rule_id}/batch/{batch_id}/discount_codes.json")]
        public abstract System.Threading.Tasks.Task RetrieveListOfDiscountCodesForDiscountCodeCreationJob(long batch_id, long price_rule_id);

    }

    


}

#pragma warning restore 1591
#pragma warning restore 1573
#pragma warning restore  472
#pragma warning restore  114
#pragma warning restore  108
#pragma warning restore 3016
#pragma warning restore 8603