namespace Ocelli.OpenShopify.Tests.ShippingAndFulfillment;

public class CarrierServiceFixture : SharedFixture, IAsyncLifetime
{
    public List<CarrierService> CreatedCarrierServices = new();
    public IShippingAndFulfillmentService Service;

    public CarrierServiceFixture() =>
        Service = new ShippingAndFulfillmentService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;

    async Task IAsyncLifetime.DisposeAsync() => await DeleteCarrierServiceAsync_CanDelete();

    public async Task DeleteCarrierServiceAsync_CanDelete()
    {
        foreach (var carrierService in CreatedCarrierServices)
        {
            _ = await Service.CarrierService.DeleteCarrierServiceAsync(carrierService.Id);
        }

        CreatedCarrierServices.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("CarrierServiceTests")]
public class CarrierServiceTests : IClassFixture<CarrierServiceFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly CarrierServiceMockClient _badRequestMockClient;
    private readonly CarrierServiceMockClient _okEmptyMockClient;
    private readonly CarrierServiceMockClient _okInvalidJsonMockClient;

    public CarrierServiceTests(CarrierServiceFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new CarrierServiceMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new CarrierServiceMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new CarrierServiceMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private CarrierServiceFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateCarrierServiceAsync_CanUpdate()
    {
        var originalCarrierService = Fixture.CreatedCarrierServices.First();
        var request = new UpdateCarrierServiceRequest
        {
            CarrierService = new UpdateCarrierService
            {
                Id = originalCarrierService.Id,
                Active = false
            }
        };
        var response =
            await Fixture.Service.CarrierService.UpdateCarrierServiceAsync(request.CarrierService.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedCarrierServices.Remove(originalCarrierService);
        Fixture.CreatedCarrierServices.Add(response.Result.CarrierService);
    }

    #endregion Update

    #region Delete

    [SkippableFact]
    [TestPriority(99)]
    public async Task DeleteCarrierServiceAsync_CanDelete() => await Fixture.DeleteCarrierServiceAsync_CanDelete();

    #endregion

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateCarrierServiceAsync_CanCreate()
    {
        var request = Fixture.CreateCarrierServiceRequest();
        var response = await Fixture.Service.CarrierService.CreateCarrierServiceAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedCarrierServices.Add(response.Result.CarrierService);
    }

    [SkippableFact]
    [TestPriority(11)]
    public async Task CreateCarrierServiceAsync_IsUnprocessableEntityError()
    {
        Skip.If(!Fixture.CreatedCarrierServices.Any(), "This needs the create test to run at the same time.");
        var request = Fixture.CreateCarrierServiceRequest();
        await Assert.ThrowsAsync<ApiException<CarrierServiceError>>(async () =>
            await Fixture.Service.CarrierService.CreateCarrierServiceAsync(request));
    }

    [SkippableFact]
    [TestPriority(11)]
    public async Task CreateCarrierServiceAsync_IsGeneralError()
    {
        var request = new CreateCarrierServiceRequest
        {
            CarrierService = new CreateCarrierService()
        };
        await Assert.ThrowsAsync<ApiException<CarrierServiceGeneralError>>(async () =>
            await Fixture.Service.CarrierService.CreateCarrierServiceAsync(request));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListCarrierServicesAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.CarrierService.ListCarrierServicesAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var carrierService in response.Result.CarrierServices)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(carrierService, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.CarrierServices.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetCarrierServiceAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedCarrierServices.Any(), "Must be run with create test");
        var carrierService = Fixture.CreatedCarrierServices.First();
        var response = await Fixture.Service.CarrierService.GetCarrierServiceAsync(carrierService.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.CarrierService, Fixture.MyShopifyUrl);
    }

    #endregion Read


    [SkippableFact]
    public async Task BadRequestResponses() => await _badRequestMockClient.TestAllMethodsThatReturnData();

    [SkippableFact]
    public async Task OkEmptyResponses() => await _okEmptyMockClient.TestAllMethodsThatReturnData();

    [SkippableFact]
    public async Task OkInvalidJsonResponses() => await _okInvalidJsonMockClient.TestAllMethodsThatReturnData();
}

internal class CarrierServiceMockClient : CarrierServiceClient, IMockTests
{
    public CarrierServiceMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
    {
        BaseUrl = AuthorizationService.BuildShopUri(fixture.MyShopifyUrl, true).ToString();
    }

    public Task TestAllMethodsThatReturnData()
    {
        Skip.If(0==1,"Not implemented.");
        return Task.CompletedTask;
    }
}
