using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Models;
using OpenShopify.Common.Attributes;
using OpenShopify.Common.Data;

namespace OpenShopify.Admin.Builder.Controllers.Analytics;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Analytics)]
[ApiController]
public class ReportController : ReportControllerBase
{
    /// <inheritdoc />
    [HttpGet, Route("reports.json")]
    [ProducesResponseType(typeof(ReportList), StatusCodes.Status200OK)]
    public override Task ListReports(string? fields = null, string? ids = null, int? limit = null, string? page_info = null, long? since_id = null,
        DateTimeOffset? updated_at_max = null, DateTimeOffset? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("reports.json")]
    [ProducesResponseType(typeof(ReportItem), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ReportError), StatusCodes.Status400BadRequest)]
    public override Task CreateReport([Required] CreateReportRequest request, string? name = null, string? shopify_ql = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("reports/{report_id:long}.json")]
    [ProducesResponseType(typeof(ReportItem), StatusCodes.Status200OK)]
    public override Task GetReport([Required] long report_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("reports/{report_id:long}.json")]
    [ProducesResponseType(typeof(ReportItem), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ReportError), StatusCodes.Status422UnprocessableEntity)]
    public override Task UpdateReport([Required] UpdateReportRequest request, [Required] long report_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("reports/{report_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteReport([Required] long report_id)
    {
        throw new NotImplementedException();
    }
}