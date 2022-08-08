using System;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Ocelli.OpenShopify.Tests.Models;
using RichardSzalay.MockHttp;
using shortid;
using shortid.Configuration;

namespace Ocelli.OpenShopify.Tests.Fixtures;

public class SharedFixture
{
    public List<AuthorizationScope> Scopes = new();
    public ITestOutputHelper TestOutputHelper;

    public SharedFixture()
    {
        TestOutputHelper = new TestOutputHelper();
        var apiKeyJson = File.ReadAllText("api_key.json");
        Debug.Assert(!string.IsNullOrWhiteSpace(apiKeyJson), "Please create an `api_key.json` file");

        var config = JsonSerializer.Deserialize<ShopifyConfig>(apiKeyJson) ??
                     throw new InvalidOperationException("Could not deserialize the api_key.json file");
        BatchId = ShortId.Generate(new GenerationOptions(true, false, 8));

        DaysToTest = 1;
#if DEBUG
        DaysToTest = 10;
#endif
        ApiKey = config.ApiKey;
        SecretKey = config.ApiSecret;
        AccessToken = config.AccessToken;
        MyShopifyUrl = config.MyShopifyUrl;
        WebhookTest = config.Webhook;
        //Scopes = new List<AuthorizationScope?>();


        var badRequest = new MockHttpMessageHandler();
        badRequest.When("*").Respond(HttpStatusCode.BadRequest); // Respond with JSON
        BadRequestMockHttpClient = badRequest.ToHttpClient();

        var okEmpty = new MockHttpMessageHandler();
        okEmpty.When("*").Respond(HttpStatusCode.OK, "application/json", string.Empty); // Respond with JSON
        OkEmptyMockHttpClient = okEmpty.ToHttpClient();

        var okInvalidJson = new MockHttpMessageHandler();
        var invalidContent = new { Error = "Sample" };
        okInvalidJson.When("*").Respond(HttpStatusCode.OK, "application/json", "{ bad\"name: 'sample'}"); // Respond with JSON
        OkInvalidJsonMockHttpClient = okInvalidJson.ToHttpClient();

        Task.Run(async () => await LoadScopes()).Wait();
    }

    internal string ApiKey { get; set; }

    internal string SecretKey { get; set; }

    internal string BatchId { get; }
    public int DaysToTest { get; set; }
    public string AccessToken { get; set; }
    public string MyShopifyUrl { get; set; }
    public WebhookTest? WebhookTest { get; set; }
    public string FirstName => "John (OpenShopify)";
    public string LastName => "Doe";
    public string Company => "OpenShopify";
    public string Note => "Test note about this customer.";
    public string Email => $@"foo+{BatchId}@example.com";
    public string CallbackUrl => @"https://sample.com/callback";
    internal HttpClient BadRequestMockHttpClient { get; set; }
    internal HttpClient OkEmptyMockHttpClient { get; set; }
    internal HttpClient OkInvalidJsonMockHttpClient { get; set; }

    public void ValidateScopes(List<AuthorizationScope> requiredPermissions)
    {
        foreach (var requiredPermission in requiredPermissions)
        {
            Skip.If(!Scopes.Contains(requiredPermission),
                $@"`{MyShopifyUrl}` credentials do not have the `{requiredPermission}` scope(s). Endpoint cannot be tested.");
        }
    }

    internal string CommonBaseUrl() =>
        new UriBuilder()
        {
            Scheme = "https://",
            Host = MyShopifyUrl,
            Port = 443,
            Path = $"admin/api/2022-07/"
        }.ToString();

    public string UniqueString([CallerMemberName] string callerName = "")
    {
        var instanceHash = ShortId.Generate(new GenerationOptions(true, false, 8));
        return $@"{Company} {callerName} ({BatchId}:{instanceHash})";
    }

    public async Task LoadScopes()
    {
        try
        {
            var service = new AccessService(MyShopifyUrl, AccessToken);
            var scopes = await service.AccessScope.ListAccessScopesAsync();
            if (scopes.Result.AccessScopes != null)
            {
                Scopes = scopes.Result.AccessScopes.Select(s => (AuthorizationScope)s.Handle).ToList();
            }
        }
        catch (ApiException<ErrorResponse?> ex)
        {
            Console.WriteLine($@"SubDomain: {MyShopifyUrl} - {ex.Message}");
        }
    }
    
    public async Task<FulfillmentService> CreateFulfillmentService([CallerMemberName] string callerName = "")
    {
        var fulfillmentService = new ShippingAndFulfillmentService(MyShopifyUrl, AccessToken);
        var request = CreateFulfillmentServiceRequest(callerName);
        request.FulfillmentService.CallbackUrl += $@"/{callerName}";
        var response = await fulfillmentService.FulfillmentService.CreateFulfillmentServiceAsync(request);
        return response.Result.FulfillmentService;
    }

    public async Task<Product> CreateProduct([CallerMemberName] string callerName = "")
    {
        var productService = new ProductsService(MyShopifyUrl, AccessToken);
        var request = CreateProductRequest(callerName);
        request.Product.Variants ??= new List<ProductVariant>();
        request.Product.Variants.Add(new ProductVariant { Sku = BatchId, InventoryManagement = "shopify" });
        var productResponse = await productService.Product.CreateProductAsync(request);
        return productResponse.Result.Product;
    }

    public async Task<Product> CreateProduct(FulfillmentService fulfillmentService, [CallerMemberName] string callerName = "")
    {
        var productService = new ProductsService(MyShopifyUrl, AccessToken);
        var product = await CreateProduct(callerName);

        if (product.Variants == null) return product;

        var variant = product.Variants.First();
        var variantRequest = new UpdateProductVariantRequest
        {
            Variant = new UpdateProductVariant
            {
                Id = variant.Id,
                Sku = BatchId,
                FulfillmentService = fulfillmentService.Handle,
                Option1 = variant.Option1,
                Price = variant.Price ?? (decimal)10.00, 
                InventoryManagement = fulfillmentService.Handle
            }
        };
        var variantResponse = await productService.ProductVariant.UpdateProductVariantAsync(variant.Id, variantRequest);
        product.Variants.Remove(variant);
        product.Variants.Add(variantResponse.Result.Variant);

        return product;
    }
    
    public async Task<RecurringApplicationCharge> CreateRecurringApplicationCharge([CallerMemberName] string callerName = "")
    {
        var billingService = new BillingService(MyShopifyUrl, AccessToken);
        var request = CreateRecurringApplicationChargeRequest(callerName);
        var response = await billingService.RecurringApplicationCharge.CreateRecurringApplicationChargeAsync(request);
        return response.Result.RecurringApplicationCharge;
    }
    public async Task<PriceRule> CreatePriceRule([CallerMemberName] string callerName = "")
    {
        var discountsService = new DiscountsService(MyShopifyUrl, AccessToken);
        var request = CreatePriceRuleRequest(callerName);
        var response = await discountsService.PriceRule.CreatePriceRuleAsync(request);
        return response.Result.PriceRule;
    }

    public async Task<Order> CreateOrder(ProductVariant productVariant, [CallerMemberName] string callerName = "")
    {
        var orderService = new OrdersService(MyShopifyUrl, AccessToken);
        var request = CreateOrderRequest(productVariant.Id, callerName);
        var response = await orderService.Order.CreateOrderAsync(request);
        return response.Result.Order;
    }
    public async Task<IEnumerable<FulfillmentOrder>> GetFulfillmentOrders(Order order)
    {
        var service = new ShippingAndFulfillmentService(MyShopifyUrl, AccessToken);
        var response = await service.FulfillmentOrder.ListFulfillmentOrdersForSpecificOrderAsync(order.Id);
        return response.Result.FulfillmentOrders;
    }
    /*
    public async Task<Fulfillment> CreateFulfillment(Order order, FulfillmentService fulfillmentService)
    {
        //TODO: Figure out what objects can have a `test` property and validate accordingly.
        var service = new ShippingAndFulfillmentService(MyShopifyUrl, AccessToken);
        var request = CreateFulfillmentRequest(fulfillmentService);
        var response = await service.Fulfillment.CreateFulfillmentAsync(order.Id, request);
        return response.Result.Fulfillment;
    }
    
    public CreateFulfillmentRequest CreateFulfillmentRequest(FulfillmentService fulfillmentService) =>
        new()
        {
            Fulfillment = new CreateFulfillment
            {
                LocationId = fulfillmentService.LocationId,
                TrackingNumbers = new List<string> { "123456789" },
                TrackingUrls = new List<string>
                {
                    "https://shipping.xyz/track.php?num=123456789", "https://anothershipper.corp/track.php?code=abc"
                },
                NotifyCustomer = true
            }
        };*/

    public CreateCustomerRequest CreateCustomerRequest([CallerMemberName] string callerName = "") =>
        new()
        {
            Customer = new CreateCustomer
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = $@"{BatchId}@example.com",
                //AcceptsMarketing = false,
                Addresses = new List<CreateCustomerAddress>
                {
                    new()
                    {
                        Address1 = "SAMPLE",
                        City = "Minneapolis",
                        Province = "Minnesota",
                        ProvinceCode = "MN",
                        Zip = "55401",
                        Phone = "555-555-5555",
                        FirstName = FirstName,
                        LastName = LastName,
                        Company = Company,
                        Country = "United States",
                        CountryCode = "US",
                        Default = true
                    }
                },
                Note = UniqueString(callerName),
                VerifiedEmail = true,
                State = "enabled"
            }
        };

    public CreateDiscountCodeRequest CreateDiscountCodeRequest(long priceRuleId, [CallerMemberName] string callerName = "") =>
        new()
        {
            DiscountCode = new CreateDiscountCode
            {
                Code = UniqueString(callerName),
                PriceRuleId = priceRuleId
            }
        };

    public CreatePriceRuleRequest CreatePriceRuleRequest([CallerMemberName] string callerName = "") =>
        new()
        {
            PriceRule = new CreatePriceRule
            {
                Title = UniqueString(callerName),
                ValueType = "percentage",
                TargetType = "line_item",
                TargetSelection = "all",
                AllocationMethod = "across",
                Value = (decimal)-10.0,
                CustomerSelection = "all",
                OncePerCustomer = false, PrerequisiteCollectionIds = new List<long>(),
                PrerequisiteSubtotalRange = new PrerequisiteValueRange
                {
                    GreaterThanOrEqualTo = 40
                },
                StartsAt = new DateTimeOffset(DateTime.Now)
            }
        };

    public CreateOrderRequest CreateOrderRequest(long variantId, [CallerMemberName] string callerName = "") =>
        new()
        {
            Order = new CreateOrder
            {
                Test = true,
                Email = Email,
                Note = UniqueString(callerName),
                LineItems = new List<LineItem>
                {
                    new()
                    {
                        VariantId = variantId,
                        Quantity = 1
                    }
                }, ShippingLines = new List<ShippingLine>()
                {
                    new ()
                    {
                        Title = UniqueString(callerName),
                        Price = (decimal)2.00
                    }
                }
            }
        };

    public CreateFulfillmentServiceRequest CreateFulfillmentServiceRequest([CallerMemberName] string callerName = "") =>
        new()
        {
            FulfillmentService = new CreateFulfillmentService
            {
                Name = UniqueString(callerName),
                Email = Email,
                Format = FulfillmentServiceFormat.Json,
                CallbackUrl = CallbackUrl,
                FulfillmentOrdersOptIn = true, 
                TrackingSupport = true, 
                IncludePendingStock = true,
                InventoryManagement = true, 
                RequiresShippingMethod = false
            }
        };

    public CreateProductRequest CreateProductRequest([CallerMemberName] string callerName = "") =>
        new()
        {
            Product = new CreateProduct
            {
                Title = UniqueString(callerName),
                BodyHtml = @"\u003cstrong\u003eGood snowboard!\u003c\/strong\u003e",
                Vendor = Company,
                ProductType = "Sample",
                Tags = @"Barnes \u0026 Noble, Big Air, John's Fav"
            }
        };

    public CreateBlogRequest CreateBlogRequest([CallerMemberName] string callerName = "") =>
        new()
        {
            Blog = new CreateBlog
            {
                Title = UniqueString(callerName)
            }
        };
    public CreateApplicationChargeRequest CreateApplicationChargeRequest([CallerMemberName] string callerName = "") =>
        new()
        {
            ApplicationCharge = new()
            {
                Test = true, 
                Name = UniqueString(callerName),
                Price = (decimal)100.0,
                ReturnUrl = $@"{CallbackUrl}/{callerName}"
            }
        };

    public CreateApplicationCreditRequest CreateApplicationCreditRequest([CallerMemberName] string callerName = "") =>
        new()
        {
            ApplicationCredit = new()
            {
                Test = true,
                Description = UniqueString(callerName),
                Amount = (decimal)5.0
            }
        };

    public CreatePageRequest CreatePageRequest([CallerMemberName] string callerName = "") =>
        new()
        {
            Page = new CreatePage
            {
                Title = UniqueString(callerName),
                BodyHtml = @"<h2>Warranty</h2>\n<p>Returns accepted if we receive items <strong>30 days after purchase</strong>.</p>", 
                Metafields = new List<OpenShopify.Metafield>{new()
                {
                    Key = "new", 
                    Value = "new value", 
                    Type = MetafieldType.SingleLineTextField, 
                    Namespace = "global"
                }}
            }
        };

    public CreateRecurringApplicationChargeRequest CreateRecurringApplicationChargeRequest([CallerMemberName] string callerName = "") =>
        new()
        {
            RecurringApplicationCharge = new()
            {
                Test = true,
                Name = UniqueString(callerName), 
                Price = (decimal)5.00,
                ReturnUrl = AuthorizationService.BuildShopUri(MyShopifyUrl, true).ToString(), 
                CappedAmount = (decimal)50.00,
                Terms = "Monthly Fee"
            }
        };


    public CreateTransactionRequest CreateTransactionRequest(Order order, [CallerMemberName] string callerName = "") =>
        new()
        {
            Transaction = new()
            {
                Test = true,
                Currency = "USD",
                Amount = (decimal)10.00,
                Kind = TransactionKind.Capture, 
                ParentId = order.Id
            }
        };


    public CreateArticleRequest CreateArticleRequest([CallerMemberName] string callerName = "") =>
        new()
        {
            Article = new CreateArticle
            {
                Title = UniqueString(callerName),
                Author = $@"{FirstName} {LastName}",
                Tags = "This Post, Has Been Tagged",
                BodyHtml =
                    @"<h1>I like articles</h1>\n<p><strong>Yea</strong>, I like posting them through <span class=\""caps\"">REST</span>.</p>",
                PublishedAt = DateTimeOffset.Now
            }
        };

    public CreateThemeRequest CreateThemeRequest([CallerMemberName] string callerName = "") =>
        new()
        {
            Theme = new CreateTheme
            {
                Name = UniqueString(callerName),
                //Src = "http://themes.shopify.com/theme.zip",
                Role = ThemeRole.Development
            }
        };

    public CreateCarrierServiceRequest CreateCarrierServiceRequest([CallerMemberName] string callerName = "") =>
        new()
        {
            CarrierService = new CreateCarrierService
            {
                Name = UniqueString(callerName),
                CallbackUrl = CallbackUrl,
                ServiceDiscovery = true
            }
        };

    public CreateAddressForCustomerRequest CreateAddressForCustomerRequest([CallerMemberName] string callerName = "") =>
        new()
        {
            CustomerAddress = new CreateCustomerAddress
            {
                Address1 = "1 Rue des Carrieres",
                Address2 = "Suite 1234",
                City = "Montreal",
                Company = Company,
                FirstName = FirstName,
                LastName = LastName,
                Phone = "819-555-5555",
                Province = "Quebec",
                Country = "Canada",
                Zip = "G1R 4P5",
                Name = $@"{FirstName} {LastName}",
                ProvinceCode = "QC",
                CountryCode = "CA", CountryName = "Canada"
            }
        };

    public CreateCustomerSavedSearchRequest
        CreateCustomerSavedSearchRequest([CallerMemberName] string callerName = "") =>
        new()
        {
            CustomerSavedSearch = new CreateCustomerSavedSearch
            {
                Name = BatchId,
                Query = @"total_spent:\u003e50"
            }
        };

    public CreateWebhookRequest CreateWebhookRequest([CallerMemberName] string callerName = "") => new()
    {
        Webhook = new CreateWebhook
        {
            Topic = WebhookTopic.FulfillmentEventsCreate,
            Address = $@"{CallbackUrl}/fulfillment_events_create"
        }
    };

    public CreateGiftCardRequest CreateGiftCardRequest([CallerMemberName] string callerName = "") => new()
    {
        GiftCard = new CreateGiftCard
        {
            Note = UniqueString(callerName),
            InitialValue = (decimal)100.00,
            Code = "ABCD EFGH IJKL MNOP",
            TemplateSuffix = "gift_cards.birthday.liquid"
        }
    };

    public CreateProductImageRequest CreateProductImageRequest([CallerMemberName] string callerName = "") => new()
    {
        Image = new CreateProductImage
        {
            Filename = "rails_logo.gif",
            Attachment =
                @"R0lGODlhbgCMAPf\/APbr48VySrxTO7IgKt2qmKQdJeK8lsFjROG5p\/nz7Zg3\nMNmnd7Q1MLNVS9GId71hSJMZIuzTu4UtKbeEeakhKMl8U8WYjfr18YQaIbAf\nKKwhKdKzqpQtLebFortOOejKrOjZ1Mt7aMNpVbAqLLV7bsNqR+3WwMqEWenN\nsZYxL\/Ddy\/Pm2e7ZxLlUQrIjNPXp3bU5MbhENbEtLtqhj5ZQTfHh0bMxL7Ip\nNsNyUYkZIrZJPcqGdYIUHb5aPKkeJnoUHd2yiJkiLKYiKLRFOsyJXKVDO8up\nosFaS+TBnK4kKti5sNaYg\/z49aqYl5kqLrljUtORfMOlo\/36+H4ZH8yDYq0f\nKKFYTaU9MrY8MrZBNXwXHpgaIdGVYu\/byLZNP9SaZLIyOuXCtHkpJst+Wpcm\nLMyCa8BfP9GMb9KQdPDd1PPk1sd5VP79\/L5dQZ0bI9+ymqssK9WcfIoXHdzG\nxdWWfteib79lSr1YP86MYurQxKdcUKdMQr5ZSfPs6YEZH8uhl4oWIenMuurQ\nttmejaqoqsqBVaAcJLlJN5kvMLlZRMNsSL5fRak0LbdQQMVvSPjw6cJnRpkf\nKtmjhvfu5cJtT7IuOMVvWLY\/M\/37+o0YH9ibhtSYdObErc6HarM9NnYSGNGR\navLi09unje3WyeO8rsVrT7tdRtK3uffu6NWeaL9pTJIjJrM4NPbx8cdyX7M7\nPYYVHu7j4KgoNJAYIKtkV5o9MsOcldicis+RYNutfrhFOZ0hJbqinZ8bI8h5\nUObFuOfItJsfJrJfUOfIqc+PXqQtK8RnSbA4Mcd3Tm0SGbpXQ8aqp7RLNs+s\novHfzpVhV9iggMd1TLtbRKUdKXEQFsd4XrZRPLIgMZUeJ+jKvrAlK6AhJ65A\nMpMpKuC3j5obIsRwS7hAN8l\/YtvDvnYXHbAoLI47SIUsOMenorF4gO\/m4+fH\npo4vLZ8oKMukqp0cJbhVSMV2UuPR0bAfMLIrLrg\/OcJwT8h+Vt+wn8eurLlh\nQrIfKHQOHHQOHf\/\/\/\/\/\/\/yH5BAEAAP8ALAAAAABuAIwAAAj\/AP8JHDhQXjpz\n\/PopXNiPn0OHDRMmbKhQIsOJFS1SxAhxI8SHFzVeDBnx48iNBAeeOkcxokeX\nFRdOnAlSokaaLXNujJkxo8iYHRkKtWkzZSsaOXkAWsoUECynsHgoqEW1qtVa\nU7Mq2Mq1K9cUW8GKTUG2rNkUHNByWMuWLdWva7t1W7UKG4S7eO\/ycEhQHgaK\nsL4VGGyocGE3br5929KuxQFFkEtIlgypsuUDmDMfWGRmUZvPoEHfGU36jgDT\nLQSoVt3IQ2sPsL0IUNZGlZ0H0lo00jEkCytWMspdGzBgn\/F9EBIWnKIQlqHB\nhA0bQpx48Z7UAkoEcMTdUeTJJSxf\/4akOTNnzqHb3GkjrUdp0gKwq77jWdod\nO7dNKWvhRUcWT6zYQI82xB03AAQNCdTKX\/xAAB10hfVCnRtbVIhIAy14oJoZ\nAXS4XXfdQaYIeOGJRx555Z1nRnrqqUeaMtIYY8dmn7Vg2yK57TYEgAzIQGBx\nxyXHj0A0OOTggxFKSN1iWwTTAIYanpYdMtFE4+GVIHrn3XeUmVhZeWiIMoOY\nnVQDGiTgKALJjIssIsADt0mjjI6+AXcDgQYi2M8\/7ijEwzRIFmBIL9NVV+EW\nVzyZ4Wqj9RBABchQWeWkV3aY5ZYjjgieeKL446mnjxwAiZVpliAjZqblt19\/\n\/7HCwIAFGv+X3J4s9fMckoYhphiTQTwJ5Wqn9dDDAWuMUUEFviTrS6STVlmp\npVmKqCkOn34aB6TIBAAOJeHZAYl6ptixSCL8edGbq8HFeqBDcygEyIOCGqYk\nkxUW4euiq7knbA\/gUDHGv\/\/ec2wFayQbaQWinOCslVhmSUq1\/gCDLJXacgtJ\nCYu4J66cjbAKoA3CxapnOgm9g+ughdK7xYX3Rinlvj2YYcYanVBBhTg2Axzw\nG4\/4k4bBzDZbKRUQP1LIsRSX6sgBZtwhzQP68ccbj7AWty4\/5igEoaC9dK3r\noVtgs4evvzKqb8wyQ0JFJzXXbDMVcQBQLTDGVmCssstKGs09oPT\/jQcRoBw9\nMamKgEOeeg\/gqBtvdVZSDnHFIQgRD4RxXWhiYEOQKNn4zncHzDIzHc0ZpHdy\nRicIQOypKDf7q3Pd96ABzSab+E1EIYIvS2o0ijA92gPZiCB1qwL+iJxL78Z7\n2NeHQrAK2YrCZva+bcgcujFUQIEG6WigonoCdLT9tr9UbIIAMMCEkkYacvvT\nxSgsBPKGJKBEAw4yjhx+hyn+PAJFfztyVdWOt5B3RehyimneFuwFvQxFyTSf\n25f1zCAqSFACDXTQ3gwSoDoElI5tZyBAINqnuhJ+Kg9vOIOaVnSHT5ECHucK\n0OMiBxJAPCdXmGseBLoBvei5rFEStB5m\/yBhjFJUIw50oIMoLvCpFRAADduj\nwxvUYMIqmvARCBiDeiwRBk+lQQTEq5qQ3CWdJSkGAlu4y9h66EBgAbF6QhSV\nMUpQilKcQRNLwIenfpFEJebBioC0ohrQQJ8QhMIfSwhgj2YouYTYUEmGqhBe\nFNBDH5otgmgLnRyLWMdq0GEGCMCHJjSBjzQE8pSChMLTCJBI4pXDBeuiiA1T\nprK7PK+SUPphsIQ1wSEag5OUKIUlyiAmAowClci0YizKILUAFi+WDQEEJOmF\nxlnMYnOVbOP0gkjBTdZRmDiwhCuywcRkmtOEpHjC1DzBABto4xqN5AcgdEXN\nNO4Ql0+CB2xctv9LM2SSgpXhZB0t0QlT+iMUkzinQquFihD452P0gGdGAPGN\nHKYxjbOAwBpxqU9+ApGXQgyoQDWRgASwoAMGMMAHDrnQhc5AkQPSU0NgYVF7\nQmAWKcBnPvc5HwGcbUVxJCInEfACQXQACUhFQkqRwAIOttScv9ABO21wA8k1\np5Z3mYXYdNqAjvLzbHDUpFCNIQoUdGAdHUhrUg2gVAOg4AXmvEAaOPEGaCCA\nAASQxBtIYYIq5kEHAaKHVfsRGB3eNBPYxKdXGVWGUnAzdOSxgyg+MIxhoDWt\nal3rUlXABEBeYBQIiMMm0AAKPBBAE1A4nTjWEIAzvGEFqsvDEHqEjZj\/wMKw\n1rwlVxerGkv4AxVoAOkEmXGMOKDgA8i1LFrRioSjKrWtKRVEQlXHBBSKQhLQ\nEG3tCHCLJaSWClD0zgHO8LBqDeIYNsDGTG4ryZtak4G7lZ6G2sBSfyCAaTK7\nAzfgQIEzoOC\/yKVsZS+bWeim1BsdqEG10oCANxDgDZwIRHa3O4hbaA91nlKB\nKA7QBhHo0VPwCFBtAdNea86CZVztKk8FUN5PjQIHxKWABihQBkHY+L\/HTa5l\nMetcAxvAG94wQAQAkA1SIIAUBvUHdkVLgBkMwrvkPSEkVtSCJ\/yCAJ5gZ20l\nwgObziITGk3xTqUHhWoxYQVdAIYINMBmO0TA\/8aCwHGOBbwOAvc4pXj2RieY\nIY69ttgfpJBEHOLQ5ArTAQ2SaPAb4lAC33XsoaxYhUx4kFVrZoKSYlYxbOzg\nPX8kAM1d6AILOuEDDQzBBCaIwJvhjOMAU7bOmE0qdMUhhFozQhVxiMWnuiAJ\nQTfZyahFQydWGwA1cbiZAJL0Qiht6UzoVsxetUQaJhEKZzhDBdh+A5s9AQxU\nq3rVN241ne0sa1rXWgjbqLUd3uqPUYhCFNDAxwzm3d3vjgF\/vTvAHegUaYbw\nwMSZyAR8oX0I2BwiC2eoQQ2srYJA6IDNb2ABqr39bVYDWMfkRgIVzs1xdEOD\nCjhQ4nXlPe9BaOLQNf+rRjQc0eg2DM8TyvZTs3mY6Xwy4xI2YLMGdIAAhTvD\nFWzuhKhZIHGKq9riF381rDtQho53\/Bjpboc1OiEJktMbtaplrbHboCOYT9rS\nOdhopocwgiRowOw6L0MNCKCBKjwA26IW9cRTXfE4i1vAlpUEHJze8XTXehvc\n2AQ05k3vDHaiDGNYeaPNoAzGxbwf\/86EHDCd4kbsyBMySII2NH92nevg4TbI\nA7ZVEGqiF93ocLb7nIdhgGMIoROW4Dvft2GHOqQiDoM3+YWJnT8O7yYL3fgI\nDwK+CrFX0lwBctUxtLH55qNd5xkYxMKvDffSn\/7b4L47JYQgjnW0XvZOv0L\/\nKmz\/BS5sIg5QvtkavDPlO\/Am+FzOBCBqgU8veEJA9LCBDRjQznIw3\/lJEIBs\n5gqhUIALN3rWR3QTh31IFwcUkAiV1QEOCH4ddw8LkAqpUH5cgAtnIGzikHgs\nxzSW1w3+Jgc0Bz32Rw8DoA3lQA8yIAP6xwoj4H\/\/B4BJYAOjoAZqYIDWRn0J\nuIB1Z3fHQAGdgHeJQIEcxwwLQH5csIHEQARE4C9aRx49oAPw5ydyIHaANUPE\nwXwtmH\/6Vw5iKIb\/F4DaoAGisAIroIM7WG0MR3pDd3qoJwjVQAEUAAdvEGAG\nsHcUgITFgAtLmIFNiAtQeAInMAa+UGwiyAEW8QMc\/\/AkgKUNx7EPkLOCLOiC\nNiADIzCDY0iDm2cHLxCKbNiGPueDcVh02McJ\/GWHjfABxyUJdigEfUiB+pAL\ndVAHX1B+uPCERHAChSAw8QAOHMaIE6EF3MAKkjiJxlGJljgC+UcPm7iJnch8\nDJAHoRiKaqiDBRgK01d9LDB0QFiHdmiH1YACSDCE4ziLsscIdRCIGriLhfiL\naxAPOKAKtbARPFAFQKKMywg5XuiC9ACN0TiNOwAAAHCNL5CN2siN3QiHcYhq\nwCAD6WiHomAJEzmO4LcGueCOG4gLf2OIAjOPOHCPEEFT\/KiMzKgNLigDABmN\nnKgL02aQB3mNCkmKB+iNCv+IBjI2Y+O4ihcZi063DcywkReYi04Yj\/ewBmuA\nAyRYEbAAAVVwkv3oj9rwgizJks4okCMwCI+ACqgwCQaJkGq4hm3IjW8YakPn\nCWxmhzz5kxfJd3iwkUx4lL0ojw\/QlAnxlG4glQYCOStplS8YkJuoCwnwCIY5\nCYgZljRJlqTYg9WnbTq3lm3plrGojrVWixuJgRpIDB95AgLTCCRYkjeVAXw5\nlfqXiVa5ks64QSVlmF8JljO5mAtplj4IdJE5YzpHmenYcXCwAHKJi7rIi74Y\nD7oQms1xU71QmpQ4AOVwmvoHmAH5ABcwna3pmompmAnJmDzIcGp5m2upmxMp\ni+f\/Zg9AIJeCeJSG+ACHAH8OwWyzoJyUCIOnCYOAKQP4wATTeQElVZio8AiI\nCZtiSZbbuHAIUAXemZu5CZ4YyQ250KAXeJ6c2YsCYIUYwWyZUADK6QoEwAfO\nOZ8yoANSwAT4SZ37eZjXGZtjOZshoAFQ8HAHOo6TCZ5CgAfluYS4OIhPGA8C\n4AXBtxBP+WXvWZrZ4ClhYAkdmokzgAkhKqIjqp+GaaIyGaAL+XDOEAEueqC4\nGaNuKQTWAAQ1OpceCQktcAgcYFuHJQc+wJfhADFpsAPhcJpewAZKKgVL2qTV\n2ZUnKptqMApJ8ADVZqVYKpkKaodwEAflaYvAuYFE4HIe\/8CIEWGhchCkJ7kE\nJQQAHGoDZcYGckqnTGqnhWmiALqYS5AEdGCAVmqgBvqiMqagquANX3qe8cCo\njpqX1iQHsAALaWogx5FkEBMO7URCmjqnTJqfJQql2LkClpAEwNCGahABapmq\nqqqgjAAE3uCgTFgC6tEIZVoRzCYHckBpJ+kBJoQA+xcCqrOpdeqpT\/qf2JkF\nSQAPOdiGLoqq0QqeVOCqDUp+RMBh+7atDgELX+atPJCPKOkAJmQJ7fRH54oJ\nc7qk+amfn+qfsAkAKqB5SeAFo7CGwBCo3smWlMkMQPaqyAAJi2AaKTBpECB5\nUdFlKJk6qoMK\/McHVsSwdFqnxP9aUv3JrgRghhcbCCswqp0XmdAamTtJmXHg\nqjWaCmqCIwJwsg\/RrSvLA6R5HDIAAyJAAJ3mKQQAAwxwC4Akp8Iqog9bna+5\nA2V4g+kUgM\/HZlUwtB2rparwYzWKB\/nzAG3QtBVaq1HxA5+wl8cBA1iABTCg\nCyGgsK7Af1lrReiariTKn6ggAmTIfDfIAJuntt7pth2bjnAABHKbC74ADi13\nByfLrQG7sp\/AA8dBD4EruIILAy0ABboAA66ATMHKqcMKsZ\/aCNMouWrbu2vb\nthw7kdUgt3VgP41WsinwEPzwb7NgqzzwA3xrCMYBuKu7ujBwvTBAAOYEtrbr\nqQkwg5z\/GLmVa7GWy7EJmo7ccGB4gAxp8i3SMLoNEXnOywOf8AmwsA\/aUL3V\ni726QELJtLi3W1ICWQ7SGLm+67tCi6UeSwGb8GOFkC1L+74uAbAq+7z1Sw0F\nwACXcAmBy8H6O7sLxb22O52k4IwD2Yk0SL69a763KWOJgAQLACnFBgl267Qy\nV8H0+wnUgAEb3MMbrL\/a+1SaWrNMSgpYqZUEPIY1qMICyMJtCQSB4wv2czjw\nC3mla8E6nAzcEA4+jAU\/HLiJG8IAbMRW6ZLgq8S8e8BOPGM4cDtSDLqboQD4\neMV8m8VXkAV47MMeDMJP9SmLiw82oAOpicThm8IHXL6BSgEn\/4AHhbAsaRLH\nMSG\/e3vBjojHWRADeowFg9DHEMO9DmADDjAK1ZCaLknAhZzGaoyl3IALXHAC\nMry0cjwR8juwz0sN1OBs3HDJlpwFl8DLvMrJnqKpUADKIUoKD1DGpVzAZ3vI\nWKoIxNDKr0yysRy\/dKzDP3BTChADunzJlxAOygDMJkQANlAGmMCk+CDI0KiV\nBYzGh9zEOmcDRPCEjEwlI3IACtARkmzB1JBRs9AN3KDN2mzJZQDOJRQGNmAH\nDSuiyhCYL2jGKIzKCMxmdwCFRMDIb9xo07y8V1y\/14wXVxADIA3QWRDEBF0t\nBi0CAOwKgDkCmmjGpzy+anwPvbjIJ\/\/gyBitvLNswRmVVewQ0iL9yyVt0PVA\nAIsLBfVJytK4zuXQzknADIZoiIVABNEsx8vWvN\/6vJRmU6vw0T4tsyWtOvxn\nA+EABQCgpID8gqh5lQ6dxGR4yIrgi78o01MdyVY9sJ+QCd+ARlmVzT490F8N\nMTEQ1gwQDiGwPh260i2dzJ3Yu8eAO\/fw2BVwD408w7UAEv9mqyubQBe1Q\/98\nCCA9A38NMSLAf4JtAyFw2Gnd0Il9wmKotm0Q10o5j41svFQtc\/M7CwmU1\/ZU\nC559CLrwC6FdLSFA2sR9pB5anw4dvlUZDyE5j\/SINKBb2RRx2ZldHUxyFxwQ\nA70d3NUCBa7\/QtyljdrIvdZj6AFKGQ\/oTY84YA8PnCb3ON11PQv0dN0QgA1X\noAuH4Fvc7SkIwABcC97hfdiIvdrgSwnOrd72QAkGDsHSnRDD57wS0g4NcAVb\ncN1bkAKHcAh+vd95cL3+DeABPp+pjcybeAnojQMobg8JTgmqQAlSrAjSHb8q\nOwvT0QDocOMTQAJ6UARk4M+HANr77SnY6+Egrn\/tdKTjHY2LkOIqruCq8OR2\n8MYk6ScqSyiGQAI3fuNRsOVRMAEKcAjAHeT+cARD\/t8g3k5HLuJHLQMMYA\/r\nreAsbhv48QCUYD8NDnmSR+MF0At\/YARGoOXoEAW8QAscMARhHNwh\/1DmHm7m\nxZ3mxw2Y1rDicY4ft\/EAlp4tlS3LkndD3ODnfp7lW14EW7AHYu4pg9C6Zc5\/\njE7a+4fkad3iTy7nlW4KtC4N9hAAU47nR1IAwtAMno4Of77labQHrVDqYWC9\nis61qx7i83kIsU7plk7rppAI1G4K0UCSDp4JbgAdJNAMvv7pOL4YViAPpe4P\n+pvsy87qrT6ftQHtiUPr1K4M+9EC9nDnlOYDg+EDf+Dt3\/7n6EALi0EL+VDu\nD4DsqI69ql7kjo4F7r4IpiAN8T7vjdAIdmDv74DvPsAN\/O7tv14EiUECUQAC\npV4G+ovsqf7hAH6a1jDr8E7tLaAbE+8FMv\/\/3n6S79MwBDuw7xzv6e2gGBMQ\nBadQ6gSABQ5AAA4gAodg8kOe8GduCu8O8S7\/8jHfH5\/HDiWRDH6QA9hwK4PB\nDfbyBLRAAtPxDbaw5X0g5mlwCXzsMwgABUdw8Aif7ocg7fEu9VP\/eUPwCmDw\nAzPxA+TgBxgQ+BBgMpUjKNQR6FEwB6WuDJdw6AAQuMnO9KQNI3UP8x0DQHoP\nBmBABnuxEH4f+KAP+LitPNNRDFq+DCN\/CSQt3Psb+fyXBZU\/8ZevA5mv+Zqf\nAz\/AED+gBeQA+r4f+DkAAShTBKAu8kFOAOFQDQV97oqu6o0g8TFP+7Vv+5Ug\nC9+q+1PQ+7\/\/+1n\/DwFF4O\/osAFiDgB4DNT+UPDWC\/lljgV23zF5b\/vwXwny\njw3f+hE\/kP1TsP36\/wxNABBNeEVBp87fQYQJFS5k2NBOjGoEwvxKSOASFowZ\nscDgyHFIo0ZehrwCU9JkyUopK8nKlIkHP379+P2YMoUcBpw5deZ8RohQE6Cn\nGg4lOnRGDKRZsoS7pMPSA6YXNWLsKJLkSZOVwKhMGSTTrJf9ZNKcomXKTrQY\nevr02cSIvKJxi6aJkaVuXaZMs1ziO5UqPawnuXK9AWEW2Jhja9pMuzMd27YW\nLNga10fuZYUPkdZdqpTv575YbJQbkCHw1sEpb9wQMstwWLFkbfppjJPc\/wTI\nhHhJ5r0BBGbMRzfb7ez5MwwbpTMsx5pa9eob2CBM5yETpmzGtTE8hrybN29b\nc1oBn6trc9K7nhmUy6BcOUrn0KHLcr0FQvWYMxdnb3w7t\/fvwFMiFvKG0uw8\n4kRLYjkGG0RtMPlWc+GGdyCwbwtYrOsHu7K0a+K\/AEO04K0CF8InBvPOg2GE\nKpZTrsHSUotwwgnnmW4LHGGBKbb9bMqhsSly082CW0QMkDLLSvQHFQFiOESX\nLGzQpkUY22swA8Lko9EFLqfBEcdvMhRrwx610OLHtJ5Rc01ahHnCzTeFkXNO\nOfWQkwQ6NNFzTz2X0GQJQAMVdJEYsBhBAyrbK\/9tgBcbrCTCG7bkkstvvvwm\nzPzI7JEcNLXDCYICQhXVkAIMMdWQd0x1Y9VdiuHGA1hjhfWQQzyg9dZDYmBg\nyioSVfRKFwfYZ8ZIJ3XhGhe83OLSSwEZU78ea+pUO2wK8MFaUUMl9dReDOll\n1VXbuYIZWWOl1dZDLpGhV3YZXLTR9vZhUMJijUX2mmveYRZcQDLlsCZOp21s\nCx+uLTjbbE\/11ttv3diFkSHKRReGcthtN1hgrdxH2Awk5fJefK+ZZ9lvVvXW\n2cT+ZSwHgdHCpmCYDb4WYVNL7baXbsN9FdYYbKDA4otddBdYeffZx9iPjw35\nmmlKNtnUfmXSNNqAW9b\/6eWYY8YWYW0V7tYQhxWAwwege61y6OXkbdDoSUFe\nWuR3wP3akKhjUtlHlqklG+YqsjaY620VNgQDMcQQouwrX3zR6KKFZfttyKtw\n+utQnRUL2mjLYjnvtLDpu9e9\/ZYZ8FK3maLwwn8OmlF3lWNc7df3gfzteaZZ\n+NTKx5y6RxJ69\/333mvBwHOLQ\/fhiR2SV34HS47hmnAafJ9gh3AaDMcB7LE\/\nIoPY441dhOzDz94VN3DPNmoeM5drAyfK7lWH34baYetVCidBIT6C5UMhB4r2\nn3FheSANRVGCwhBmObtlbgqXyYYNyuYFAMQFCtPwQf3spxAraGBRR+Af91wX\n\/zsPoCIuCCAV13yAMsWo7zIOaJHFSHEZHZABdWK4X0JoIAENLIeDCXFA2rgX\nuwG8MC6kKGGoZuaDTEhtd\/vBTBoyYLYqeAEzFpihGCagEBqIQQJVGMAOEdLD\n2L0uHJdBAMIOhsTELHExwLnS\/i6zAQlIQItWxKIccejGL\/4wjPvw4kHSQApA\nBhKQUDCiEWE2C93dTSEW2EMjaWABhbgnA3g8SAj4cElK+kMJWoyjBK6YECtw\nUgKZ7N8ejdZHfzjgGgNY5SpnZsisJXFHikwICTLBskzUECFtxJ\/FFKKETmrx\nkwixQiclYAX+mfKUCpnBEZzpzHpkS2Yxm0ViMNcjhf+QABs5uKUuD9KoTOaP\nQb80picxaExk8lCZfIxLNuBhrWnurZpjoiVCbAkBbnrTH2pbTjgZVAVyGnOY\nBylmJ9P5xXWOUS6WEB3ZqgmTazLxMk40WntQub3lbIOc7OjkQP1RUI4e9CCl\nfJ3jjCbEogDAE6KrAiKlVs+4gJF7GUDlDLLnUWCyg6Ps8GgxdyrSVK5zH\/WI\noARjZjFEQhSmRCEFg9SGSqIoQadT7alOJcAOoJJUmeFA6VBIETqk+ssPKizK\nDorxwx9CdShSvapOqzpVoO7ApMocgAdcIb74HeSroEOqEn8w1mgVRR0KyEEw\nKqoctTZEquzggFsVooepskP\/DwqZAAfmakpGvc4HXSXF54CWVLthALASRYhB\nFpmDd4QxsQxRQmNd61HITnWyCVHC9MTnCsY9U7dH4AM8spGQvVrsiRB4Fg\/8\ncFxsJmQDHvUHLQyhWsy01rXs2MFj2ZGC6862KKRgHGY6K9zlEPdyP8AJcteo\n3ClsQCHq0AF0QdkN+HbjlxygL31hO13tMrW7lwkB0BiUoR3x4EfmrYlCNjAF\nCRAoIWmwQexQqQcyxHe+9eXAfVOQAg7k16v7jQsAHGi2Bv0gUzyQQ05Ga+Cy\n0MBEDsZgN8gQ4QnXt7oJ0QOGOZACDTeEu0aTCwC80EKhDcAHMDGHWATMsuMC\nFsVl\/9GnP0Jg0kw24MUv\/qUTOGDlCj8WETfGsVx2vI+UzsATIFZUaTIRk3QY\n+ZYlFq0Ce5QJHBXgdU+MRCSwEYlVBCHPQZhyn7vhhD9fWdAc2DKhKXxhRCc6\n0Yi4LOPcl6hGVUFqc4gJLGaxufKO1s2VkrOj63znOkciCKMedZ+n7ARUp1rQ\niLAyIlyNYURcONaInrWs9ci4JyJOaFYawDzP8Q+ZwAICLckbgd08i290eh9V\nCIadQw3qO5Oa1H1GNRlSjeorO2HLruZ2rLudAm+Dm9Gxcx\/GXmSIMbnjH5W2\nzy2RbOzM+cENBRAWs0N9b3zXWdp8pra1r61tbXdb4N\/2Nv8i5gzeIJd5Gjui\nwT+AzQ9YVGrYnNO0Agm27GBkvNnNzje+921qf\/+b1QEfuMDFPe5lk\/lspUG3\nWKbQCofLBBBuwNEs3C3aikcrB2TTeM81HgmOd3zf\/PZ3yFPNaqSXfODF0EDK\nE9e6liZmCvJwOLD7AQhU2efSbG6zm7VgiG1ofBc+\/\/nGgZ7vbYw67aVux4v\/\nfXSSK53by\/HVrzIwDZTBBANUrzpMeAAIWASeB4P\/AQ9+cHjEJx7xWgDE5nLQ\neMdHXvKbg\/zkMZ23H\/1oFRjYPOc9v3nQ58Aw0xn9LACvO7HQAOZVf\/jl0ii1\nHcXe9bPX3euftaPL5R71tIf97nsy7\/o0WlP2r4\/JOU7B+r5nqva7jz1EdZ97\n4qNe+bonfvCfVXvly1762beOOdLBd+Q7PCAAOw==\n"
        }
    };

    public CreateProductVariantRequest CreateProductVariantRequest([CallerMemberName] string callerName = "") => new()
    {
        Variant = new CreateProductVariant
        {
            Option1 = "Yellow",
            Price = (decimal)1.00
        }
    };

    public CreateMarketingEventRequest CreateMarketingEventRequest([CallerMemberName] string callerName = "") => new()
    {
        MarketingEvent = new CreateMarketingEvent
        {
            StartedAt = DateTimeOffset.Now,
            UtmCampaign = $@"Christmas2022_{BatchId}", 
            UtmSource = "facebook",
            UtmMedium = "cpc",
            EventType = EventType.Ad,
            ReferringDomain = "facebook.com",
            MarketingChannel = MarketingChannel.Social,
            Paid = true
        }
    };

    public CreateMetafieldRequest CreateMetafieldRequest([CallerMemberName] string callerName = "") => new()
    {
        Metafield = new CreateMetafield
        {
            Namespace = "inventory",
            Key = "warehouse",
            Value = "25",
            Type = MetafieldType.NumberInteger
        }
    };

    public CreateDraftOrderRequest CreateDraftOrderRequest([CallerMemberName] string callerName = "") => new()
    {
        DraftOrder = new CreateDraftOrder
        {
            LineItems = new List<DraftLineItem>
            {
                new()
                {
                    Title = UniqueString(),
                    Price = (decimal)20.00,
                    Quantity = 1,
                    AppliedDiscount = new AppliedDiscount
                    {
                        Description = "Custom discount",
                        ValueType = DiscountValueType.FixedAmount,
                        Value = "10.0",
                        Amount = (decimal)10.0,
                        Title = UniqueString(callerName)
                    }
                }
            }
        }
    };

    public CreateMobilePlatformApplicationRequest CreateMobilePlatformApplicationRequest(
        [CallerMemberName] string callerName = "") => new()
    {
        MobilePlatformApplication = new CreateMobilePlatformApplication
        {
            Platform = "ios",
            ApplicationId = "X1Y2.ca.domain.app",
            EnabledUniversalOrAppLinks = true,
            EnabledSharedWebcredentials = true
        }
    };

    public CreatePaymentRequest CreatePaymentRequest([CallerMemberName] string callerName = "") => new()
    {
        Payment = new CreatePayment
        {
            RequestDetails = new PaymentRequestDetail
            {
                IpAddress = "123.1.1.1",
                AcceptLanguage = "en-US,en;q=0.8,fr;q=0.6",
                UserAgent =
                    "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_12_1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/54.0.2840.98 Safari/537.36"
            },
            Amount = (decimal)398.00,
            SessionId = "global-771baf31bac9f4e1",
            UniqueToken = "client-side-idempotency-token"
        }
    };

    public CreateOrderRiskRequest CreateOrderRiskRequest([CallerMemberName] string callerName = "") => new()
    {
        Risk = new CreateOrderRisk
        {
            Message = "This order came from an anonymous proxy",
            Recommendation = RiskRecommendation.Cancel,
            Score = (decimal)1.0,
            Source = "External",
            CauseCancel = true,
            Display = true
        }
    };

    [CollectionDefinition("Shared collection")]
    public class SharedCollection : ICollectionFixture<SharedFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply //[CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}

[AttributeUsage(AttributeTargets.Method)]
public class TestPriorityAttribute : Attribute
{
    public TestPriorityAttribute(int priority) => Priority = priority;
    public int Priority { get; private init; }
}

public class PriorityOrderer : ITestCaseOrderer
{
    public IEnumerable<TTestCase> OrderTestCases<TTestCase>(
        IEnumerable<TTestCase> testCases) where TTestCase : ITestCase
    {
        var assemblyName = typeof(TestPriorityAttribute).AssemblyQualifiedName!;
        var sortedMethods = new SortedDictionary<int, List<TTestCase>>();
        foreach (var testCase in testCases)
        {
            var priority = testCase.TestMethod.Method
                .GetCustomAttributes(assemblyName)
                .FirstOrDefault()
                ?.GetNamedArgument<int>(nameof(TestPriorityAttribute.Priority)) ?? 0;

            GetOrCreate(sortedMethods, priority).Add(testCase);
        }

        foreach (var testCase in
                 sortedMethods.Keys.SelectMany(
                     priority => sortedMethods[priority].OrderBy(
                         testCase => testCase.TestMethod.Method.Name)))
        {
            yield return testCase;
        }
    }

    private static TValue GetOrCreate<TKey, TValue>(
        IDictionary<TKey, TValue> dictionary, TKey key)
        where TKey : struct
        where TValue : new() =>
        dictionary.TryGetValue(key, out var result)
            ? result
            : dictionary[key] = new TValue();
}