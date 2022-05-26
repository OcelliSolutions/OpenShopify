using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Analytics;

public class ReportFixture : SharedFixture, IAsyncLifetime
{
    public List<Report> CreatedReports = new();
    public AnalyticsService Service;

    public ReportFixture() =>
        Service = new AnalyticsService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;

    async Task IAsyncLifetime.DisposeAsync() => await DeleteReportAsync_CanDelete();

    public async Task DeleteReportAsync_CanDelete()
    {
        foreach (var webhook in CreatedReports)
        {
            _ = await Service.Report.DeleteReportAsync(webhook.Id);
        }
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class ReportTests : IClassFixture<ReportFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;


    public ReportTests(ReportFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private ReportFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateReportAsync_CanUpdate()
    {
        var originalReport = Fixture.CreatedReports.First();
        var request = new UpdateReportRequest
        {
            Report = new UpdateReport
            {
                Id = originalReport.Id,
                Name = $@"Something simple {Fixture.BatchId}"
            }
        };
        var response = await Fixture.Service.Report.UpdateReportAsync(request.Report.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedReports.Remove(originalReport);
        Fixture.CreatedReports.Add(response.Result.Report);
    }

    #endregion Update

    #region Delete

    [SkippableFact]
    [TestPriority(99)]
    public async Task DeleteReportAsync_CanDelete()
    {
        foreach (var webhook in Fixture.CreatedReports)
        {
            _ = await Fixture.Service.Report.DeleteReportAsync(webhook.Id);
        }

        Fixture.CreatedReports.Clear();
    }

    #endregion Delete

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateReportAsync_CanCreate()
    {
        var request = new CreateReportRequest
        {
            Report = new CreateReport
            {
                Name = $@"A new app report ({Fixture.BatchId})",
                ShopifyQl = @"SHOW total_sales BY order_id FROM sales SINCE -1m UNTIL today ORDER BY total_sales"
            }
        };
        var response = await Fixture.Service.Report.CreateReportAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedReports.Add(response.Result.Report);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateReportAsync_IsUnprocessableEntityError()
    {
        var request = new CreateReportRequest
        {
            Report = new CreateReport()
        };
        await Assert.ThrowsAsync<ApiException<ReportError>>(async () =>
            await Fixture.Service.Report.CreateReportAsync(request));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListReportsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Report.ListReportsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var report in response.Result.Reports)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(report, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.Reports.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetReportAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedReports.Any(), "Must be run with create test");
        var report = Fixture.CreatedReports.First();
        var response = await Fixture.Service.Report.GetReportAsync(report.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Report, Fixture.MyShopifyUrl);
    }

    #endregion Read
}