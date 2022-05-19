using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.SalesChannels;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.SalesChannels)]
[ApiController]
public class MobilePlatformApplicationController : MobilePlatformApplicationControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("mobile_platform_applications.json")]
    public override Task ListAllOfMobilePlatformApplicationsAssociatedWithApp()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("mobile_platform_applications.json")]
    public override Task CreateMobilePlatformApplication(MobilePlatformApplicationItem request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("mobile_platform_applications/{mobile_platform_application_id:long}.json")]
    public override Task GetMobilePlatformApplication(long mobile_platform_application_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("mobile_platform_applications/{mobile_platform_application_id:long}.json")]
    public override Task UpdateMobilePlatformApplication(MobilePlatformApplicationItem request, long mobile_platform_application_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("mobile_platform_applications/{mobile_platform_application_id:long}.json")]
    public override Task DeleteMobilePlatformApplication(long mobile_platform_application_id)
    {
        throw new NotImplementedException();
    }
}