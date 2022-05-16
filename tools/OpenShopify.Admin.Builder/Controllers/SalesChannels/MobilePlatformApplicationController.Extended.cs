using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.SalesChannels;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.SalesChannels)]
[ApiController]
public class MobilePlatformApplicationController : IMobilePlatformApplicationController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("mobile_platform_applications.json")]
    public Task ListAllOfTheMobilePlatformApplicationsAssociatedWithTheAppAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("mobile_platform_applications.json")]
    public Task CreateMobilePlatformApplicationAsync()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("mobile_platform_applications/{mobile_platform_application_id}.json")]
    public Task GetMobilePlatformApplicationAsync(string mobile_platform_application_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("mobile_platform_applications/{mobile_platform_application_id}.json")]
    public Task UpdateMobilePlatformApplicationAsync(string mobile_platform_application_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("mobile_platform_applications/{mobile_platform_application_id}.json")]
    public Task DeleteMobilePlatformApplicationAsync(string mobile_platform_application_id)
    {
        throw new NotImplementedException();
    }
}