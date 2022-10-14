# Sample App

## Usage

1. Run the [Sample App](../SampleApp) (yes, it is not configured yet)
1. Create an account at [Shopify Partners](https://partners.shopify.com/)
    1. [Create a new app](https://partners.shopify.com/2098808/apps/new)
    1. Create a new app on the partner account and configure using the following:
    1. **App URL** `http://localhost:5162/signup` *(use the port that the Sample App is running under)*
    1. **Allowed redirection URL(s)** `http://localhost:5162/redirect` *(use the port that the Sample App is running under)*
1. Stop the **Sample App**.
1. Copy `appsettings.json` as `appsettings.Development.json` file for the **Sample App**.
    1. Update the `Shopify:ApiKey` and `Shopify:ApiSecret` in `appsettings.Development.json` with the respective values from the newly created application on Shopify.
1. Run the [Sample App](../SampleApp)
1. On Shopify application, go to the **Test Your Application** section and click **Select Store**
    1. Select a development store or create a new one if required.
    1. Follow the instructions from Shopify to grant access to the new application.
1. At the end of the process, you will be redirected to a page that contains a simple json string. Copy this for later.
1. Copy [api_key.template.json](api_key.template.json) and rename as [api_key.json](api_key.json).
    1. Open the new file and populate the values:
        1. **access_token** from the json string that was displayed by the registration process.
        1. **my_shopify_url** is the url of the store that was just used to register the app. eg: `super-neat.myshopify.com`
        1. **api_key** the same value that was used in the **Sample App**
        1. **api_secret** the same value that was used in the **Sample App**
