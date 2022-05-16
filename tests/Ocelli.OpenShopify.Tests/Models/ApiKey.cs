using System.Collections.Generic;
using Xunit;

namespace Ocelli.OpenShopify.Tests.Models;

internal class ApiKey
{
    internal ApiKey(string accessToken, string myShopifyUrl)
    {
        DaysToTest = 1;
#if DEBUG
        DaysToTest = 10;
#endif
        AccessToken = accessToken;
        MyShopifyUrl = myShopifyUrl;
        Scopes = new List<AuthorizationScope?>();
        TestFulfillmentServices = new List<FulfillmentService>();
    }

    public int DaysToTest { get; set; }
    public string AccessToken { get; set; }
    public string MyShopifyUrl { get; set; }

    public List<AuthorizationScope?> Scopes { get; set; }

    public void ValidateScopes(List<AuthorizationScope> requiredPermissions)
    {
        foreach (var requiredPermission in requiredPermissions)
        {
            Skip.If(!Scopes.Contains(requiredPermission), $@"`{MyShopifyUrl}` credentials do not have the `{requiredPermission}` scope(s). Endpoint cannot be tested.");
        }
    }

    public List<FulfillmentService> TestFulfillmentServices { get; set; }
}
