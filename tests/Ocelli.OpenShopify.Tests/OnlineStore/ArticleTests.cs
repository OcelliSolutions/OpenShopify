using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.OnlineStore;
[Collection("Shared collection")]
[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class ArticleTests : IClassFixture<ArticleFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;
        

    public ArticleTests(ArticleFixture fixture, ITestOutputHelper testOutputHelper)
    {
                Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
            }

    public ArticleFixture Fixture { get; set; }


    #region Create

    #endregion Create

    #region Read
    
    #endregion Read

    #region Update

    #endregion Update

    #region Delete

    #endregion Delete
}

public class ArticleFixture
{
    public ITestOutputHelper TestOutputHelper { get; set; }
}
