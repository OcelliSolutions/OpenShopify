using System.ComponentModel.DataAnnotations;
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
    [ProducesResponseType(typeof(MobilePlatformApplicationList), StatusCodes.Status200OK)]
    public override Task ListMobilePlatformApplicationsAssociatedWithApp()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("mobile_platform_applications.json")]
    [ProducesResponseType(typeof(MobilePlatformApplicationItem), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(MobilePlatformApplicationError), StatusCodes.Status422UnprocessableEntity)]
    public override Task CreateMobilePlatformApplication([Required] CreateMobilePlatformApplicationRequest request)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("mobile_platform_applications/{mobile_platform_application_id:long}.json")]
    [ProducesResponseType(typeof(MobilePlatformApplicationItem), StatusCodes.Status200OK)]
    public override Task GetMobilePlatformApplication([Required] long mobile_platform_application_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("mobile_platform_applications/{mobile_platform_application_id:long}.json")]
    [ProducesResponseType(typeof(MobilePlatformApplicationItem), StatusCodes.Status200OK)]
    public override Task UpdateMobilePlatformApplication([Required] UpdateMobilePlatformApplicationRequest request,
        [Required] long mobile_platform_application_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("mobile_platform_applications/{mobile_platform_application_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteMobilePlatformApplication([Required] long mobile_platform_application_id)
    {
        throw new NotImplementedException();
    }
}