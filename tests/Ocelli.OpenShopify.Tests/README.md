# Open:Shopify (Tests)

## Basic Setup

The following must be in place for integration testing to work:

* Create a developer/partner account
* Run the [Sample App](../SampleApp)
* Create a new app on the partner account and configure using the following:
  * __App URL__ `http://localhost:5162/signup` _(use the port that the Sample App is running under)_
  * __Allowed redirection URL(s)__ `http://localhost:5162/redirect` _(use the port that the Sample App is running under)_
* Stop the __Sample App__.
* Copy `appsettings.json` as `appsettings.Development.json` file for the __Sample App__.
  * Update the `Shopify:ApiKey` and `Shopify:ApiSecret` in `appsettings.Development.json` with the respective values from the newly created application on Shopify.
* Run the [Sample App](../SampleApp)
* On Shopify application, go to the __Test Your Application__ section and click __Select Store__
  * Select a development store or create a new one if required.
  * Follow the instructions from Shopify to grant access to the new application.
* At the end of the process, you will be redirected to a page that contains a simple json string. Copy this for later.
* Copy [api_key.template.json](api_key.template.json) and rename as [api_key.json](api_key.json).
  * Open the new file and populate the values:
    * __access_token__ from the json string that was displayed by the registration process.
    * __my_shopify_url__ is the url of the store that was just used to register the app. eg: `super-neat.myshopify.com`
    * __api_key__ the same value that was used in the __Sample App__
    * __api_secret__ the same value that was used in the __Sample App__

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
