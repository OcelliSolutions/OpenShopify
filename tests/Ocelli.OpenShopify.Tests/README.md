# Open:Shopify (Tests)

## Basic Setup

Please follow the usage directions for the [Sample App](../SampleApp) to configure the test suite.

## Webhook Validation

To run the webhook validation tests, a webhook must be registered and executed manually.

* Go to [Beeceptor](https://beeceptor.com/) and create a new endpoint.
* Using curl, register a webhook for the `profiles/create` and/or `profiles/update` topic
  * be sure to replace the __access_token__ and __endpoint__

```bash
curl --location --request POST 'https://super-neat.myshopify.com/admin/api/2022-07/webhooks.json' \
--header 'Content-Type: application/json' \
--header 'Accept: application/json' \
--header 'X-Shopify-Access-Token: <access_token>' \
--data-raw '{
  "webhook": {
    "address": "https://<endpoint>.free.beeceptor.com",
    "format": "json",
    "topic": "shop/update"
  }
}'
```

* Go to the store __Settings__, __Shipping and Delivery__, __Custom Shipping Rates__, and __Create a new profile__.
  * Create/Edit the profile and save.
  * A new webhook will be send to the Beeceptor page.
* Inspect the Beeceptor capture and request body in it's raw JSON format. Replace the empty `data` object in `api_key.json` with the content.
  * replace `"data": {}"` with `"data":{"id":85085257901}`.
  * replace the `hmac` value with the header value from `x-shopify-hmac-sha256`.

> ___NOTE:___  The `shop/create` and `shop/update` endpoints were picked because the request payload is simple. In most other endpoints, string content may contain an escaped forward slash (`\/`). .NET will serialize this as just a forward slash (`/`) which will fail validation.
