using System;

namespace Ocelli.OpenShopify.Tests.Metafield;

public class MetafieldProductVariantFixture : SharedFixture, IAsyncLifetime
{
    public List<Product> CreatedProducts = new();
    public List<ProductVariant> CreatedProductVariants = new();
    public List<OpenShopify.Metafield> CreatedMetafields = new();
    public IMetafieldService Service;

    public MetafieldProductVariantFixture() =>
        Service = new MetafieldService(MyShopifyUrl, AccessToken);


    public async Task InitializeAsync()
    {
        var productsService = new ProductsService(MyShopifyUrl, AccessToken);
        var products = await productsService.Product.ListProductsAsync(limit: 1);
        var product = products.Result.Products.First();
        var productVariantRequest = this.CreateProductVariantRequest();
        var productVariant = await productsService.ProductVariant.CreateProductVariantAsync(product.Id, productVariantRequest, CancellationToken.None);
        CreatedProductVariants.Add(productVariant.Result.Variant);
    }

    async Task IAsyncLifetime.DisposeAsync()
    {
        await DeleteMetafieldForProductVariantAsync_CanDelete();
        await DeleteProductVariantAsync_CanDelete();
    }

    public async Task DeleteMetafieldForProductVariantAsync_CanDelete()
    {
        foreach (var metafield in CreatedMetafields)
        {
            _ = await Service.Metafield.DeleteMetafieldForProductVariantAsync(metafield.OwnerId ?? 0, metafield.Id, CancellationToken.None);
        }
        CreatedMetafields.Clear();
    }
    public async Task DeleteProductVariantAsync_CanDelete()
    {
        var productsService = new ProductsService(MyShopifyUrl, AccessToken);
        foreach (var productVariant in CreatedProductVariants)
        {
            _ = await productsService.ProductVariant.DeleteProductVariantAsync(productVariant.ProductId ?? 0, productVariant.Id, CancellationToken.None);
        }
        CreatedProductVariants.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
[Collection("MetafieldProductVariantTests")]
public class MetafieldProductVariantTests : IClassFixture<MetafieldProductVariantFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly MetafieldProductVariantMockClient _badRequestMockClient;
    private readonly MetafieldProductVariantMockClient _okEmptyMockClient;
    private readonly MetafieldProductVariantMockClient _okInvalidJsonMockClient;

    public MetafieldProductVariantTests(MetafieldProductVariantFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _badRequestMockClient = new MetafieldProductVariantMockClient(fixture.BadRequestMockHttpClient, fixture);
        _okEmptyMockClient = new MetafieldProductVariantMockClient(fixture.OkEmptyMockHttpClient, fixture);
        _okInvalidJsonMockClient = new MetafieldProductVariantMockClient(fixture.OkInvalidJsonMockHttpClient, fixture);
    }

    private MetafieldProductVariantFixture Fixture { get; }

    #region Update

    [SkippableFact]
    [TestPriority(30)]
    public async Task UpdateMetafieldForProductVariantAsync_CanUpdate()
    {
        Skip.If(!Fixture.CreatedMetafields.Any(), "Please run with the create tests");
        var originalMetafield = Fixture.CreatedMetafields.First();
        var request = new UpdateMetafieldForProductVariantRequest
        {
            Metafield = new ()
            {
                Id = originalMetafield.Id,
                Value = "something new",
                Type = MetafieldType.SingleLineTextField
            }
        };
        var response = await Fixture.Service.Metafield.UpdateMetafieldForProductVariantAsync(originalMetafield.OwnerId ?? 0, originalMetafield.Id, request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedMetafields.Remove(originalMetafield);
        Fixture.CreatedMetafields.Add(response.Result.Metafield);
    }

    #endregion Update

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateMetafieldForProductVariantAsync_CanCreate()
    {
        var productVariant = Fixture.CreatedProductVariants.First();
        var request = new CreateMetafieldForProductVariantRequest()
        {
            Metafield = Fixture.CreateMetafieldRequest().Metafield
        };
        var response = await Fixture.Service.Metafield.CreateMetafieldForProductVariantAsync(productVariant.Id, request, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedMetafields.Add(response.Result.Metafield);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreateMetafieldForProductVariantAsync_IsUnprocessableEntityError()
    {
        var productVariant = Fixture.CreatedProductVariants.First();
        var request = new CreateMetafieldForProductVariantRequest
        {
            Metafield = new CreateMetafield()
        };
        await Assert.ThrowsAsync<ApiException>(async () =>
            await Fixture.Service.Metafield.CreateMetafieldForProductVariantAsync(productVariant.Id, request, CancellationToken.None));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task CountMetafieldProductVariantsAsync_CanGet()
    {
        var response = await Fixture.Service.Metafield.CountMetafieldsAttachedToProductVariantAsync(Fixture.CreatedProductVariants.First().Id, CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListMetafieldProductVariantsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Metafield.ListMetafieldsAttachedToProductVariantAsync(Fixture.CreatedProductVariants.First().Id, cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var metafield in response.Result.Metafields)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(metafield, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.Metafields.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetMetafieldForProductVariantAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedMetafields.Any(), "Must be run with create test");
        var metafield = Fixture.CreatedMetafields.First();
        var response = await Fixture.Service.Metafield.GetMetafieldAttachedToProductVariantAsync(metafield.Id, metafield.OwnerId ?? 0, cancellationToken: CancellationToken.None);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Metafield, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Delete

    [SkippableFact]
    [TestPriority(99)]
    public async Task DeleteMetafieldForProductVariantAsync_CanDelete()
    {
        await Fixture.DeleteMetafieldForProductVariantAsync_CanDelete();
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

internal class MetafieldProductVariantMockClient : MetafieldClient, IMockTests
{
    public MetafieldProductVariantMockClient(HttpClient httpClient, SharedFixture fixture) : base(httpClient)
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

        #region ProductVariant

        await Assert.ThrowsAsync<ApiException>(async () => await ListMetafieldsAttachedToProductVariantAsync(variantId: 0, createdAtMax: DateTimeOffset.Now, createdAtMin: DateTimeOffset.Now.AddDays(-1), cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await ListMetafieldsAttachedToProductVariantAsync(variantId: 0, updatedAtMax: DateTimeOffset.Now, updatedAtMin: DateTimeOffset.Now.AddDays(-1), cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await ListMetafieldsAttachedToProductVariantAsync(variantId: 0, fields: "id", limit: 1, pageInfo: "", key: "", @namespace: "", type: MetafieldType.Boolean, sinceId: 0, cancellationToken: CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await CountMetafieldsAttachedToProductVariantAsync(variantId: 0, CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await GetMetafieldAttachedToProductVariantAsync(0, 0, "id", CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await CreateMetafieldForProductVariantAsync(0, new CreateMetafieldForProductVariantRequest(), CancellationToken.None));
        await Assert.ThrowsAsync<ApiException>(async () => await UpdateMetafieldForProductVariantAsync(0, 0, new UpdateMetafieldForProductVariantRequest(), CancellationToken.None));

        #endregion ProductVariant
        
        ReadResponseAsString = false;
        //Only one method needs to be tested with `ReadResponseAsString = false`
        await Assert.ThrowsAsync<ApiException>(async () => await ListMetafieldsAttachedToProductVariantAsync(0, cancellationToken: CancellationToken.None));
    }
}
