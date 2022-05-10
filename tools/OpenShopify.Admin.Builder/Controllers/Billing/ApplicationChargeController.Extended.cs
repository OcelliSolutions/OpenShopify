using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Billing
{
    /// <inheritdoc />
    [ApiGroup(ApiGroupNames.Billing)]
    [ApiController]
    public class ApplicationChargeController : ApplicationChargeControllerBase
    {
        /// <inheritdoc />
        [ProducesResponseType(typeof(ApplicationChargeItem), StatusCodes.Status200OK)]
        public override Task CreateApplicationCharge()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        [ProducesResponseType(typeof(ApplicationChargeList), StatusCodes.Status200OK)]
        public override Task RetrieveListOfApplicationCharges(string? fields = null, string? since_id = null)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        [ProducesResponseType(typeof(ApplicationChargeItem), StatusCodes.Status200OK)]
        public override Task RetrieveApplicationCharge(string application_charge_id, string? fields = null)
        {
            throw new NotImplementedException();
        }
    }
}

public class ApplicationChargeItem
{
    [JsonPropertyName("application_charge")]
    public OpenShopify.Admin.Builder.Models.ApplicationCharge? ApplicationCharge { get; set; }
}

public class ApplicationChargeList
{
    [JsonPropertyName("application_charges")]
    public IEnumerable<OpenShopify.Admin.Builder.Models.ApplicationCharge>? ApplicationCharges { get; set; }
}