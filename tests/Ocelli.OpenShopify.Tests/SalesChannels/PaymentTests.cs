using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelli.OpenShopify.Tests.Fixtures;
using Ocelli.OpenShopify.Tests.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Ocelli.OpenShopify.Tests.SalesChannels;

public class PaymentFixture : SharedFixture, IAsyncLifetime
{
    public List<Payment> CreatedPayments = new();

    public SalesChannelsService Service;

    //TODO: figure out how to get a token for testing.
    public string Token = string.Empty;

    public PaymentFixture() =>
        Service = new SalesChannelsService(MyShopifyUrl, AccessToken);

    public Task InitializeAsync() => Task.CompletedTask;
    public Task DisposeAsync() => Task.CompletedTask;
}

[TestCaseOrderer("Ocelli.OpenShopify.Tests.Fixtures.PriorityOrderer", "Ocelli.OpenShopify.Tests")]
public class PaymentTests : IClassFixture<PaymentFixture>
{
    private readonly AdditionalPropertiesHelper _additionalPropertiesHelper;

    public PaymentTests(PaymentFixture fixture, ITestOutputHelper testOutputHelper)
    {
        Fixture = fixture;
        _additionalPropertiesHelper = new AdditionalPropertiesHelper(testOutputHelper);
    }

    private PaymentFixture Fixture { get; }

    #region Create

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreatePaymentAsync_CanCreate()
    {
        var request = Fixture.CreatePaymentRequest();
        var response = await Fixture.Service.Payment.CreatePaymentAsync("", body: request);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);

        Fixture.CreatedPayments.Add(response.Result.Payment);
    }

    [SkippableFact]
    [TestPriority(10)]
    public async Task CreatePaymentAsync_IsUnprocessableEntityError()
    {
        var request = new CreatePaymentRequest
        {
            Payment = new CreatePayment()
        };
        await Assert.ThrowsAsync<ApiException<PaymentError>>(async () =>
            await Fixture.Service.Payment.CreatePaymentAsync(Fixture.Token, body: request));
    }

    #endregion Create

    #region Read

    [SkippableFact]
    [TestPriority(20)]
    public async Task CountPaymentsAsync_CanGet()
    {
        var response = await Fixture.Service.Payment.CountNumberOfPaymentsAttemptedOnCheckoutAsync(Fixture.Token);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        var count = response.Result.Count;
        Skip.If(count == 0, "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task ListPaymentsAsync_AdditionalPropertiesAreEmpty()
    {
        var response = await Fixture.Service.Payment.ListPaymentsOnParticularCheckoutAsync(Fixture.Token);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        foreach (var payment in response.Result.Payments)
        {
            _additionalPropertiesHelper.CheckAdditionalProperties(payment, Fixture.MyShopifyUrl);
        }

        Skip.If(!response.Result.Payments.Any(), "No results returned. Unable to test");
    }

    [SkippableFact]
    [TestPriority(20)]
    public async Task GetPaymentAsync_TestCreated_AdditionalPropertiesAreEmpty()
    {
        Skip.If(!Fixture.CreatedPayments.Any(), "Must be run with create test");
        var payment = Fixture.CreatedPayments.First();
        var response = await Fixture.Service.Payment.GetPaymentAsync(payment.Id, Fixture.Token);
        _additionalPropertiesHelper.CheckAdditionalProperties(response, Fixture.MyShopifyUrl);
        _additionalPropertiesHelper.CheckAdditionalProperties(response.Result.Payment, Fixture.MyShopifyUrl);
    }

    #endregion Read
}