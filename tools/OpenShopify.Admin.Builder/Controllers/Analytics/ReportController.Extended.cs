using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Controllers.Access;
using OpenShopify.Admin.Builder.Data;
using OpenShopify.Admin.Builder.Models;

namespace OpenShopify.Admin.Builder.Controllers.Analytics;

/// <inheritdoc />
[ApiGroup(ApiGroupNames.Analytics)]
[ApiController]
public class ReportController : IReportController
{
    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("reports.json")]
    [ProducesResponseType(typeof(ReportList), StatusCodes.Status200OK)]
    public Task RetrieveListOfReportsAsync(string? fields, string? ids, string limit, string? since_id,
        string? updated_at_max, string? updated_at_min)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPost, Microsoft.AspNetCore.Mvc.Route("reports.json")]
    [ProducesResponseType(typeof(ReportItem), StatusCodes.Status200OK)]
    public Task CreateNewReportAsync(string? name, string? shopify_ql)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpGet, Microsoft.AspNetCore.Mvc.Route("reports/{report_id}.json")]
    [ProducesResponseType(typeof(ReportItem), StatusCodes.Status200OK)]
    public Task RetrieveSingleReportAsync(string report_id, string? fields)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpPut, Microsoft.AspNetCore.Mvc.Route("reports/{report_id}.json")]
    [ProducesResponseType(typeof(ReportItem), StatusCodes.Status200OK)]
    public Task UpdateReportAsync(string report_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [Microsoft.AspNetCore.Mvc.HttpDelete, Microsoft.AspNetCore.Mvc.Route("reports/{report_id}.json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public Task DeleteReportAsync(string report_id)
    {
        throw new NotImplementedException();
    }
}

public class ReportItem
{
    [JsonPropertyName("report")]
    public Report? Report { get; set; }
}

public class ReportList
{
    [JsonPropertyName("reports")]
    public IEnumerable<Report>? Reports { get; set; }
}
