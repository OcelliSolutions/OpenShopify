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
    public override Task RetrieveListOfReports(string? fields, string? ids, int? limit, string? page_info, int? since_id,
        DateTime? updated_at_max, DateTime? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPost, Route("reports.json")]
    [ProducesResponseType(typeof(ReportItem), StatusCodes.Status201Created)]
    public override Task CreateNewReport(ReportItem request, string? name, string? shopify_ql)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpGet, Route("reports/{report_id:long}.json")]
    [ProducesResponseType(typeof(ReportItem), StatusCodes.Status200OK)]
    public override Task RetrieveSingleReport(long report_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpPut, Route("reports/{report_id:long}.json")]
    [ProducesResponseType(typeof(ReportItem), StatusCodes.Status200OK)]
    public override Task UpdateReport(ReportItem request, long report_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [HttpDelete, Route("reports/{report_id:long}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteReport(long report_id)
    {
        throw new NotImplementedException();
    }
}