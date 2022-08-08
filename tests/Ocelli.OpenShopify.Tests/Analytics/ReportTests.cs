using System;

namespace Ocelli.OpenShopify.Tests.Analytics;

public class ReportFixture : SharedFixture, IAsyncLifetime
{
    public List<Report> CreatedReports = new();
    public IAnalyticsService Service;

    public ReportFixture() =>
        Service = new AnalyticsService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;

    async Task IAsyncLifetime.DisposeAsync() => await DeleteReportAsync_CanDelete();

    public async Task DeleteReportAsync_CanDelete()
    {
        foreach (var webhook in CreatedReports)
        {
            _ = await Service.Report.DeleteReportAsync(webhook.Id, CancellationToken.None);
        }
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
//[Collection("ReportTests")]
public class ReportTests : IClassFixture<ReportFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ReportMockClient _badRequestMockClient;
    private readonly ReportMockClient _okEmptyMockClient;
    private readonly ReportMockClient _okInvalidJsonMockClient;

    public ReportTests(ReportFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new ReportMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new ReportMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new ReportMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
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
        var response = await Fixture.Service.Report.UpdateReportAsync(request.Report.Id, request, CancellationToken.None);
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
            _ = await Fixture.Service.Report.DeleteReportAsync(webhook.Id, CancellationToken.None);
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
        var response = await Fixture.Service.Report.CreateReportAsync(request, CancellationToken.None);
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
            await Fixture.Service.Report.CreateReportAsync(request, CancellationToken.None));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListReportsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Report.ListReportsAsync(cancellationToken: CancellationToken.None);
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
        var response = await Fixture.Service.Report.GetReportAsync(report.Id, cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Report, Fixture.MyShopifyUrl);
    }

    #endregion Read
    
    [SkippableFact]
    public async Task BadRequestResponsesAsync() => await _badRequestMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkEmptyResponsesAsync() => await _okEmptyMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkInvalidJsonResponsesAsync() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnDataAsync();

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class ReportMockClient : ReportClient, IMockTests
{
    public ReportMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
    {
        BaseUrl = fixture.CommonBaseUrl();
    }
    public void ObjectResponseResult_CanReadText()
    {
        var obj = new ObjectResponseResult<ApiException>(default!, string.Empty);
        Assert.Equal(obj.Text, string.Empty);
    }

    public async Task TestAllMethodsThatReturnDataAsync()
    {
        ReadResponseAsString = true;
        await Assert.ThrowsAsync<ApiException>(async () => await ListReportsAsync(fields: "test", ids: new List<long>{0}, limit: 10, pageInfo: "NA", sinceId: 0, updatedAtMax: DateTimeOffset.Now, updatedAtMin: DateTimeOffset.Now.AddDays(-1), cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await CreateReportAsync(new CreateReportRequest(), CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await GetReportAsync(reportId: 0, fields: "test", cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await UpdateReportAsync(0, new UpdateReportRequest(), CancellationToken.None));
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListReportsAsync(cancellationToken: CancellationToken.None));
    }
}
