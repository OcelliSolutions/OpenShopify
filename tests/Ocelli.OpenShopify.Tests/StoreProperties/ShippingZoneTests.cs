using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.StoreProperties;
[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class ShippingZoneTests : IClassFixture<ShippingZoneFixture>
{
    private ShippingZoneFixture Fixture { get; }
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
        

    public ShippingZoneTests(ShippingZoneFixture fixture, ITestOutputHelper testOutputHelper)
    {
                Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
            }

    
    #region Create

    #endregion Create

    #region Read

    #endregion Read

    #region Update

    #endregion Update

    #region Delete

    #endregion Delete
}

public class ShippingZoneFixture
{
    public ITestOutputHelper TestOutputHelper { get; set; }
}