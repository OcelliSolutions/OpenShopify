using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Plus;

public class GiftCardFixture : SharedFixture, IAsyncLifetime
{
    public List<GiftCard> CreatedGiftCards = new();
    public PlusService Service;

    public GiftCardFixture() =>
        Service = new PlusService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;

    async Task IAsyncLifetime.DisposeAsync() => await DisableGiftCardAsync();

    
    public async Task DisableGiftCardAsync()
    {
        foreach (var giftCard in CreatedGiftCards)
        {
            _ = await Service.GiftCard.DisableGiftCardAsync(giftCard.Id);
        }
        CreatedGiftCards.Clear();
    }
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class GiftCardTests : IClassFixture<GiftCardFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public GiftCardTests(GiftCardFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private GiftCardFixture Fixture { get; }

    #region Update

    [SkippableFact(Skip = "Must be tested on a plus store")]
    [TestPriority(30)]
    public async Task UpdateGiftCardAsync_CanUpdate()
    {
        var originalGiftCard = Fixture.CreatedGiftCards.First();
        var request = new UpdateGiftCardRequest
        {
            GiftCard = new UpdateGiftCard
            {
                Id = originalGiftCard.Id,
                Note = $@"{originalGiftCard.Note} | Updating with a new note"
            }
        };
        var response = await Fixture.Service.GiftCard.UpdateGiftCardAsync(request.GiftCard.Id, request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedGiftCards.Remove(originalGiftCard);
        Fixture.CreatedGiftCards.Add(response.Result.GiftCard);
    }

    #endregion Update

    #region Create

    [SkippableFact(Skip = "Must be tested on a plus store")]
    [TestPriority(10)]
    public async Task CreateGiftCardAsync_CanCreate()
    {
        var request = Fixture.CreateGiftCardRequest();
        var response = await Fixture.Service.GiftCard.CreateGiftCardAsync(request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedGiftCards.Add(response.Result.GiftCard);
    }

    [SkippableFact(Skip = "Must be tested on a plus store")]
    [TestPriority(10)]
    public async Task CreateGiftCardAsync_IsUnprocessableEntityError()
    {
        var request = new CreateGiftCardRequest
        {
            GiftCard = new CreateGiftCard()
        };
        await Assert.ThrowsAsync<ApiException<GiftCardError>>(async () =>
            await Fixture.Service.GiftCard.CreateGiftCardAsync(request));
    }

    #endregion Create

    #region Read

    [SkippableFact(Skip = "Must be tested on a plus store")]
    [TestPriority(20)]
    public async Task CountGiftCardsAsync_CanGet()
    {
        var response = await Fixture.Service.GiftCard.CountGiftCardsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact(Skip = "Must be tested on a plus store")]
    [TestPriority(20)]
    public async Task ListGiftCardsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.GiftCard.ListGiftCardsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var giftCard in response.Result.GiftCards)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(giftCard, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.GiftCards.Any(), "No results returned. Unable to test");
    }

    [SkippableFact(Skip = "Must be tested on a plus store")]
    [TestPriority(20)]
    public async Task GetGiftCardAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedGiftCards.Any(), "Must be run with create test");
        var giftCard = Fixture.CreatedGiftCards.First();
        var response = await Fixture.Service.GiftCard.GetGiftCardAsync(giftCard.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.GiftCard, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Delete

    [SkippableFact(Skip = "Must be tested on a plus store")]
    [TestPriority(99)]
    public async Task DisableGiftCardAsync()
    {
        await Fixture.DisableGiftCardAsync();
    }

    #endregion Delete
}