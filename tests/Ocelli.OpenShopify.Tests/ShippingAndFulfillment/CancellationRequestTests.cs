using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.ShippingAndFulfillment;
[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class CancellationRequestTests : IClassFixture<CancellationRequestFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
        

    public CancellationRequestTests(CancellationRequestFixture fixture, ITestOutputHelper testOutputHelper)
    {
                Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
            }

    public CancellationRequestFixture Fixture { get; set; }


    #region Create

    #endregion Create

    #region Read

    #endregion Read

    #region Update

    #endregion Update

    #region Delete

    #endregion Delete
}

public class CancellationRequestFixture
{
    public ITestOutputHelper TestOutputHelper { get; set; }
}