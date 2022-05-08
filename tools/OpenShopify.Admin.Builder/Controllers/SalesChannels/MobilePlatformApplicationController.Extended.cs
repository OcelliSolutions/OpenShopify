using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.SalesChannels;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.SalesChannels)]
[ApiController]
public class MobilePlatformApplicationController : MobilePlatformApplicationControllerBase
{
    public override Task ListAllOfTheMobilePlatformApplicationsAssociatedWithTheApp()
    {
        throw new NotImplementedException();
    }

    public override Task CreateMobilePlatformApplication()
    {
        throw new NotImplementedException();
    }

    public override Task GetMobilePlatformApplication(string mobile_platform_application_id)
    {
        throw new NotImplementedException();
    }

    public override Task UpdateMobilePlatformApplication(string mobile_platform_application_id)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteMobilePlatformApplication(string mobile_platform_application_id)
    {
        throw new NotImplementedException();
    }
}