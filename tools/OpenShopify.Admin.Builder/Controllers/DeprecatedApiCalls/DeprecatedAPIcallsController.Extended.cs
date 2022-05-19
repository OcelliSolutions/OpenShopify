using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.DeprecatedApiCalls;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.DeprecatedApiCalls)]
[ApiController]
public class DeprecatedApiCallsController : DeprecatedAPICallsControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("deprecated_api_calls.json")]
    [ProducesResponseType(typeof(DeprecatedApiCallList), StatusCodes.Status200OK)]
    public override Task RetrieveListOfDeprecatedAPICalls()
    {
        throw new NotImplementedException();
    }
}
public class DeprecatedApiCallList
{
    [JsonPropertyName("data_updated_at")]
    public DateTime DataUpdatedAt { get; set; }
    [JsonPropertyName("deprecated_api_calls")]
    public IEnumerable<DeprecatedApiCall>? DeprecatedApiCalls { get; set; }
}