using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.Plus;
[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class GiftCardTests : IClassFixture<SharedFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly PlusService _service;

    public GiftCardTests(ITestOutputHelper testOutputHelper, SharedFixture sharedFixture)
    {
        _testOutputHelper = testOutputHelper;
        Fixture = sharedFixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
        _service = new PlusService(Fixture.MyShopifyUrl, Fixture.AccessToken);
    }

    private SharedFixture Fixture { get; }

    #region Create

    #endregion Create

    #region Read

    [SkippableFact(Skip = "Must be tested on a plus store"), TestPriority(20)]
    public async Task CountGiftCardsAsync_CanGet()
    {
        var response = await _service.GiftCard.CountGiftCardsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact(Skip = "Must be tested on a plus store"), TestPriority(20)]
    public async Task ListGiftCardsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await _service.GiftCard.ListGiftCardsAsync();
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var giftCard in response.Result.GiftCards)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(giftCard, Fixture.MyShopifyUrl);
            if (giftCard.Note != null && giftCard.Note.Contains(Fixture.Company) &&
                !Fixture.CreatedGiftCards.Exists(w => w.Id == giftCard.Id))
                Fixture.CreatedGiftCards.Add(giftCard);
        }
        var list = response.Result.GiftCards;
        Skip.If(!list.Any(), "No results returned. Unable to test");
    }

    [SkippableFact(Skip = "Must be tested on a plus store"), TestPriority(20)]
    public async Task GetGiftCardAsync_AdditionalPropertiesAreEmpty()
    {
        var giftCardListResponse = await _service.GiftCard.ListGiftCardsAsync(limit: 1);
        Skip.If(!giftCardListResponse.Result.GiftCards.Any(), "No results returned. Unable to test");
        var response = await _service.GiftCard.GetGiftCardAsync(giftCardListResponse.Result.GiftCards.First().Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.GiftCard, Fixture.MyShopifyUrl);
    }

    [SkippableFact(Skip = "Must be tested on a plus store"), TestPriority(20)]
    public async Task GetGiftCardAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        var giftCard = Fixture.CreatedGiftCards.First();
        Skip.If(giftCard == null, "No results returned. Unable to test");
        var response = await _service.GiftCard.GetGiftCardAsync(giftCard.Id);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.GiftCard, Fixture.MyShopifyUrl);
    }

    #endregion Read

    #region Update

    #endregion Update

    #region Delete

    #endregion Delete
}
