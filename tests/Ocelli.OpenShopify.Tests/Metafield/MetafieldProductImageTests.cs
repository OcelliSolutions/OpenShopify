using System;

namespace Ocelli.OpenShopify.Tests.Metafield;

public class MetafieldProductImageFixture : SharedFixture, IAsyncLifetime
{
    public List<ProductImage> CreatedProductImages = new();
    public List<OpenShopify.Metafield> CreatedMetafields = new();
    public IMetafieldService Service;

    public MetafieldProductImageFixture() =>
        Service = new MetafieldService(MyShopifyUrl, AccessToken);


    public async Task InitializeAsync()
    {
        var productsService = new ProductsService(MyShopifyUrl, AccessToken);
        var products = await productsService.Product.ListProductsAsync(limit: 1);
        var product = products.Result.Products.First();

        var productImageRequest = this.CreateProductImageRequest();
        var productImage = await productsService.ProductImage.CreateProductImageAsync(product.Id, productImageRequest, CancellationToken.None);
        CreatedProductImages.Add(productImage.Result.Image);
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DeleteMetafieldForProductImageAsync_CanDelete();
        await DeleteProductImageAsync_CanDelete();
    }

    public async Task DeleteMetafieldForProductImageAsync_CanDelete()
    {
        foreach (var metafield in CreatedMetafields)
        {
            _ = await Service.Metafield.DeleteMetafieldForProductImageAsync(metafield.OwnerId ?? 0, metafield.Id, CancellationToken.None);
        }
        CreatedMetafields.Clear();
    }
    public async Task DeleteProductImageAsync_CanDelete()
    {
        var productsService = new ProductsService(MyShopifyUrl, AccessToken);
        foreach (var productImage in CreatedProductImages)
        {
            _ = await productsService.ProductImage.DeleteProductImageAsync(productImage.Id, productImage.ProductId ?? 0, CancellationToken.None);
        }
        CreatedProductImages.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("MetafieldProductImageTests")]
public class MetafieldProductImageTests : IClassFixture<MetafieldProductImageFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly MetafieldProductImageMockClient _badRequestMockClient;
    private readonly MetafieldProductImageMockClient _okEmptyMockClient;
    private readonly MetafieldProductImageMockClient _okInvalidJsonMockClient;

    public MetafieldProductImageTests(MetafieldProductImageFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new MetafieldProductImageMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new MetafieldProductImageMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new MetafieldProductImageMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private MetafieldProductImageFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateMetafieldForProductImageAsync_CanUpdate()
    {
        Skip.If(!Fixture.CreatedMetafields.Any(), "Please run with the create tests");
        var originalMetafield = Fixture.CreatedMetafields.First();
        var request = new UpdateMetafieldForProductImageRequest
        {
            Metafield = new ()
            {
                Id = originalMetafield.Id,
                Value = "something new",
                Type = MetafieldType.SingleLineTextField
            }
        };
        var response = await Fixture.Service.Metafield.UpdateMetafieldForProductImageAsync(originalMetafield.OwnerId ?? 0, originalMetafield.Id, request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedMetafields.Remove(originalMetafield);
        Fixture.CreatedMetafields.Add(response.Result.Metafield);
    }

    #endregion Update

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateMetafieldForProductImageAsync_CanCreate()
    {
        var productImage = Fixture.CreatedProductImages.First();
        var request = new CreateMetafieldForProductImageRequest()
        {
            Metafield = Fixture.CreateMetafieldRequest().Metafield
        };
        var response = await Fixture.Service.Metafield.CreateMetafieldForProductImageAsync(productImage.Id, request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedMetafields.Add(response.Result.Metafield);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateMetafieldForProductImageAsync_IsUnprocessableEntityError()
    {
        var productImage = Fixture.CreatedProductImages.First();
        var request = new CreateMetafieldForProductImageRequest
        {
            Metafield = new CreateMetafield()
        };
        await Assert.ThrowsAsync<ApiException>(async () =>
            await Fixture.Service.Metafield.CreateMetafieldForProductImageAsync(productImage.Id, request, CancellationToken.None));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task CountMetafieldProductImagesAsync_CanGet()
    {
        var response = await Fixture.Service.Metafield.CountMetafieldsAttachedToProductImageAsync(Fixture.CreatedProductImages.First().Id, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListMetafieldProductImagesAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Metafield.ListMetafieldsAttachedToProductImageAsync(Fixture.CreatedProductImages.First().Id, cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var metafield in response.Result.Metafields)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(metafield, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.Metafields.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetMetafieldForProductImageAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedMetafields.Any(), "Must be run with create test");
        var metafield = Fixture.CreatedMetafields.First();
        var response = await Fixture.Service.Metafield.GetMetafieldAttachedToProductImageAsync(metafield.Id, metafield.OwnerId ?? 0, cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Metafield, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Delete

    [SkippableFact]
    [TestPriority(99)]
    public async Task DeleteMetafieldForProductImageAsync_CanDelete()
    {
        await Fixture.DeleteMetafieldForProductImageAsync_CanDelete();
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

internal class MetafieldProductImageMockClient : MetafieldClient, IMockTests
{
    public MetafieldProductImageMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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

        #region ProductImage

        await Assert.ThrowsAsync<ApiException>(async () => await ListMetafieldsAttachedToProductImageAsync(productImageId: 0, createdAtMax: DateTimeOffset.Now, createdAtMin: DateTimeOffset.Now.AddDays(-1), cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await ListMetafieldsAttachedToProductImageAsync(productImageId: 0, updatedAtMax: DateTimeOffset.Now, updatedAtMin: DateTimeOffset.Now.AddDays(-1), cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await ListMetafieldsAttachedToProductImageAsync(productImageId: 0, fields: "id", limit: 1, pageInfo: "", key: "", @namespace: "", type: MetafieldType.Boolean, sinceId: 0, cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await CountMetafieldsAttachedToProductImageAsync(productImageId: 0, CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await GetMetafieldAttachedToProductImageAsync(0, 0, "id", CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await CreateMetafieldForProductImageAsync(0, new CreateMetafieldForProductImageRequest(), CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await UpdateMetafieldForProductImageAsync(0, 0, new UpdateMetafieldForProductImageRequest(), CancellationToken.None));

        #endregion ProductImage
        
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListMetafieldsAttachedToProductImageAsync(0, cancellationToken: CancellationToken.None));
    }
}
