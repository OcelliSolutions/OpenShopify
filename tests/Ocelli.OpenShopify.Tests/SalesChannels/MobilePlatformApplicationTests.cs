﻿namespace Ocelli.OpenShopify.Tests.SalesChannels;

public class MobilePlatformApplicationFixture : SharedFixture, IAsyncLifetime
{
    public List<MobilePlatformApplication> CreatedMobilePlatformApplications = new();
    public ISalesChannelsService Service;

    public MobilePlatformApplicationFixture() =>
        Service = new SalesChannelsService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;

    async Task IAsyncLifetime.DisposeAsync() => await DeleteMobilePlatformApplicationAsync_CanDelete();
    
    public async Task DeleteMobilePlatformApplicationAsync_CanDelete()
    {
        foreach (var mobilePlatformApplication in CreatedMobilePlatformApplications)
        {
            _ = await Service.MobilePlatformApplication.DeleteMobilePlatformApplicationAsync(
                mobilePlatformApplication.Id, CancellationToken.None);
        }
        CreatedMobilePlatformApplications.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("MobilePlatformApplicationTests")]
public class MobilePlatformApplicationTests : IClassFixture<MobilePlatformApplicationFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly MobilePlatformApplicationMockClient _badRequestMockClient;
    private readonly MobilePlatformApplicationMockClient _okEmptyMockClient;
    private readonly MobilePlatformApplicationMockClient _okInvalidJsonMockClient;

    public MobilePlatformApplicationTests(MobilePlatformApplicationFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new MobilePlatformApplicationMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new MobilePlatformApplicationMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new MobilePlatformApplicationMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private MobilePlatformApplicationFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateMobilePlatformApplicationAsync_CanUpdate()
    {
        Skip.If(!Fixture.CreatedMobilePlatformApplications.Any(), "Must be run with create test");
        var originalMobilePlatformApplication = Fixture.CreatedMobilePlatformApplications.First();
        var request = new UpdateMobilePlatformApplicationRequest
        {
            MobilePlatformApplication = new UpdateMobilePlatformApplication
            {
                Id = originalMobilePlatformApplication.Id,
                ApplicationId = "A1B2.ca.domain.app",
                Platform = "ios",
                EnabledUniversalOrAppLinks = true,
                EnabledSharedWebcredentials = true
            }
        };
        var response =
            await Fixture.Service.MobilePlatformApplication.UpdateMobilePlatformApplicationAsync(
                originalMobilePlatformApplication.Id, request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedMobilePlatformApplications.Remove(originalMobilePlatformApplication);
        Fixture.CreatedMobilePlatformApplications.Add(response.Result.MobilePlatformApplication);
    }

    #endregion Update

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateMobilePlatformApplicationAsync_CanCreate()
    {
        var request = Fixture.CreateMobilePlatformApplicationRequest();
        var response = await Fixture.Service.MobilePlatformApplication.CreateMobilePlatformApplicationAsync(request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedMobilePlatformApplications.Add(response.Result.MobilePlatformApplication);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateMobilePlatformApplicationAsync_IsUnprocessableEntityError()
    {
        var request = new CreateMobilePlatformApplicationRequest
        {
            MobilePlatformApplication = new CreateMobilePlatformApplication()
        };
        await Assert.ThrowsAsync<ApiException>(async () =>
            await Fixture.Service.MobilePlatformApplication.CreateMobilePlatformApplicationAsync(request, CancellationToken.None));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListMobilePlatformApplicationsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.MobilePlatformApplication
            .ListMobilePlatformApplicationsAssociatedWithAppAsync(CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var mobilePlatformApplication in response.Result.MobilePlatformApplications)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(mobilePlatformApplication, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.MobilePlatformApplications.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetMobilePlatformApplicationAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedMobilePlatformApplications.Any(), "Must be run with create test");
        var mobilePlatformApplication = Fixture.CreatedMobilePlatformApplications.First();
        var response =
            await Fixture.Service.MobilePlatformApplication.GetMobilePlatformApplicationAsync(
                mobilePlatformApplication.Id, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.MobilePlatformApplication,
            Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Delete

    [SkippableFact]
    [TestPriority(99)]
    public async Task DeleteMobilePlatformApplicationAsync_CanDelete()
    {
        await Fixture.DeleteMobilePlatformApplicationAsync_CanDelete();
    }


    #endregion Delete


    [SkippableFact]
    public async Task BadRequestResponsesAsync() => await _badRequestMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkEmptyResponsesAsync() => await _okEmptyMockClient.TestAllMethodsThatReturnDataAsync();

    [SkippableFact]
    public async Task OkInvalidJsonResponsesAsync() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnDataAsync();

    [Fact]
    public void ObjectResponseResult_CanReadText() => _okEmptyMockClient.ObjectResponseResult_CanReadText();
}

internal class MobilePlatformApplicationMockClient : MobilePlatformApplicationClient, IMockTests
{
    public MobilePlatformApplicationMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public void ObjectResponseResult_CanReadText()
    {
        var obj = new ObjectResponseResult<ApiException>(default!, string.Empty);
        Assert.Equal(obj.Text, string.Empty);
    }

    public async Task TestAllMethodsThatReturnDataAsync()
    {
        ReadResponseAsString = true;
        //TODO: Validate that all methods are tested in this first section
        await Assert.ThrowsAsync<ApiException>(async () => await ListMobilePlatformApplicationsAssociatedWithAppAsync(CancellationToken.None));
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListMobilePlatformApplicationsAssociatedWithAppAsync(CancellationToken.None));
    }
}
