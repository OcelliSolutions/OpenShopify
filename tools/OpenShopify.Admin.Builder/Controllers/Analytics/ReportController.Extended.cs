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
public class ReportController : ReportControllerBase
{
    /// <inheritdoc />
    [ProducesResponseType(typeof(ReportList), StatusCodes.Status200OK)]
    public override Task RetrieveListOfReports(string? fields = null, string? ids = null, string? limit = "50", string? since_id = null,
        string? updated_at_max = null, string? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [ProducesResponseType(typeof(ReportItem), StatusCodes.Status200OK)]
    public override Task CreateNewReport(string? name = null, string? shopify_ql = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [ProducesResponseType(typeof(ReportItem), StatusCodes.Status200OK)]
    public override Task RetrieveSingleReport([FromRoute] string report_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [ProducesResponseType(typeof(ReportItem), StatusCodes.Status200OK)]
    public override Task UpdateReport([FromRoute] string report_id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    [ProducesResponseType(StatusCodes.Status200OK)]
    public override Task DeleteReport([FromRoute] string report_id)
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
