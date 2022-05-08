using Microsoft.AspNetCore.Mvc;
using OpenShopify.Admin.Builder.Attributes;
using OpenShopify.Admin.Builder.Data;

namespace OpenShopify.Admin.Builder.Controllers.Analytics;
[ApiGroup(ApiGroupNames.Analytics)]
[ApiController]
public class ReportController : ReportControllerBase
{
    public override Task RetrieveListOfReports(string? fields = null, string? ids = null, string? limit = "50", string? since_id = null,
        string? updated_at_max = null, string? updated_at_min = null)
    {
        throw new NotImplementedException();
    }

    public override Task CreateNewReport(string? name = null, string? shopify_ql = null)
    {
        throw new NotImplementedException();
    }

    public override Task RetrieveSingleReport(string report_id, string? fields = null)
    {
        throw new NotImplementedException();
    }

    public override Task UpdateReport(string report_id)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteReport(string report_id)
    {
        throw new NotImplementedException();
    }
}
