using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.SalesChannels;

public class MobilePlatformApplicationFixture : SharedFixture, IAsyncLifetime
{
    public List<MobilePlatformApplication> CreatedMobilePlatformApplications = new();
    public SalesChannelsService Service;

    public MobilePlatformApplicationFixture() =>
        Service = new SalesChannelsService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;

    async Task IAsyncLifetime.DisposeAsync() => await DeleteMobilePlatformApplicationAsync_CanDelete();
    
    public async Task DeleteMobilePlatformApplicationAsync_CanDelete()
    {
        foreach (var mobilePlatformApplication in CreatedMobilePlatformApplications)
        {
            _ = await Service.MobilePlatformApplication.DeleteMobilePlatformApplicationAsync(mobilePlatformApplication
                .Id);
        }
        CreatedMobilePlatformApplications.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class MobilePlatformApplicationTests : IClassFixture<MobilePlatformApplicationFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public MobilePlatformApplicationTests(MobilePlatformApplicationFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private MobilePlatformApplicationFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateMobilePlatformApplicationAsync_CanUpdate()
    {
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
                originalMobilePlatformApplication.Id, request);
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
        var response = await Fixture.Service.MobilePlatformApplication.CreateMobilePlatformApplicationAsync(request);
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
        await Assert.ThrowsAsync<ApiException<MobilePlatformApplicationError>>(async () =>
            await Fixture.Service.MobilePlatformApplication.CreateMobilePlatformApplicationAsync(request));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListMobilePlatformApplicationsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.MobilePlatformApplication
            .ListMobilePlatformApplicationsAssociatedWithAppAsync();
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
            await Fixture.Service.MobilePlatformApplication.GetMobilePlatformApplicationAsync(mobilePlatformApplication
                .Id);
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
    }