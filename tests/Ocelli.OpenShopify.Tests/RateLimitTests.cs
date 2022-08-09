using System;
using System.Net;
using System.Text.Json;
using Moq;
using Moq.Protected;

namespace Ocelli.OpenShopify.Tests;
public class RateLimitFixture : SharedFixture, IAsyncLifetime
{
    public IStorePropertiesService Service;

    public RateLimitFixture() =>
        Service = new StorePropertiesService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;

    Task IAsyncLifetime.DisposeAsync() => Task.CompletedTask;
}

[Collection("RateLimitTests")]
public class RateLimitTests : IClassFixture<RateLimitFixture>
{
    private readonly ITestOutputHelper _testOutputHelper;
    private RateLimitFixture Fixture { get; }

    private HttpClient _client;
    private HttpRequestMessage _httpRequest;
    private Mock<DelegatingHandler> _testHandler;

    private RateLimitHttpMessageHandler _subject;//RateLimitHttpMessageHandler inherits DelegatingHandler

    public RateLimitTests(RateLimitFixture fixture, ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        Fixture = fixture;

        _httpRequest = new HttpRequestMessage(HttpMethod.Get, "/someurl");
        _testHandler = new Mock<DelegatingHandler>();

        _subject = new RateLimitHttpMessageHandler // create subject
        {
            InnerHandler = _testHandler.Object //initialize InnerHandler with our mock
        };

        _client = new HttpClient(_subject)
        {
            BaseAddress = new Uri("http://localhost")
        };

    }
    /*
    [Fact]
    public async Task RateLimit40_CanHit()
    {
        for (var i = 0; i < 20; i++)
        {
            ShopifyResponse<ShopItem>? result = null;
            try
            {
                result = await Fixture.Service.Shop.GetShopsConfigurationAsync("domain");
            }
            catch (ApiException ex)
            {
                _testOutputHelper.WriteLine(ex.Message);
            }
            _testOutputHelper.WriteLine($@"{i}: {JsonSerializer.Serialize(result?.Headers)}");
        }
    }
    */
    /*
    [Fact]
    public async Task Dele()
    {
        var mockedResult = new HttpResponseMessage(HttpStatusCode.Accepted);

        void AssertThatRequestCorrect(HttpRequestMessage request, CancellationToken token)
        {
            Assert.Equal(request, _httpRequest);
            //... Other asserts
        }

        // setup protected SendAsync 
        // our MyCustomHandler will call SendAsync internally, and we want to check this call
        _testHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", _httpRequest, ItExpr.IsAny<CancellationToken>())
            .Callback(
                (Action<HttpRequestMessage, CancellationToken>)AssertThatRequestCorrect)
            .ReturnsAsync(mockedResult);

        //Act
        var actualResponse = await _client.SendAsync(_httpRequest);

        //check that internal call to SendAsync was only Once and with proper request object
        _testHandler
            .Protected()
            .Verify("SendAsync", Times.Once(), _httpRequest, ItExpr.IsAny<CancellationToken>());

        // if our custom handler modifies somehow our response we can check it here
        Assert.True(actualResponse.IsSuccessStatusCode);
        Assert.Equal(actualResponse, mockedResult);
    }
    */
}