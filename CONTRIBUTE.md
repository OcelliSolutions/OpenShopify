# Contribution &amp; Development

There are several applications in this solution that are used to maintain Open:Shopify.

## Tools

---

Use the following projects to create the OpenAPI specs and Client code for the main project.

### [Scraper](tools/OpenShopify.Scraper/README.md)

The first step is to gather as much data as possible from the official Shopify documentation. This gives a solid starting point and is a quick way to automatically see if a new version has been released, if any endpoints have been added, or parameters have changed. This will also generate the initial controllers in th *Builder* tool. *This app must be executed for results to generate.*

* Download the most current (pseudo-OpenAPI) documentation from Shopify.
* Assign default parameter data types.
* Assign standard parameter naming for request (POST/PUT) bodies.
* Assign default property data types and formats (dates).
* Standardize method names.
* Convert HTML documentation to markdown for OpenAPI compliance.
* Create the default `Controllers` for the **\*.Builder** projects.

### [Admin.Builder](tools/OpenShopify.Admin.Builder/README.md)

The second step is to take the abstract controller that is created by the *Scraper* and add all the missing features. This includes the result model mapping. While, yes, the models can be scraped, that are frequently inaccurate and are not properly mapped in the official docs. The results created the OpenApi specs that are stored at the root folder of this project. Please see all the **open-shopify-\*.yaml** files. *This application only needs to be built for results to be updated.*

* **\*.Controller.Extended.cs** files are used to override default parameters and assign response types.
* The build of this project is used to create the OpenAPI specs. The endpoints should always return a `NotImplementedException` as this is only for documentation.
* `Wrapper.tt` (T4 template) is used to create all the standard wrappers for results. This includes list of items and items themselves to comply with the Shopify responses. Any changes to this or `WrapperErrors.tt` must be done in Visual Studin for the template code to generate the new classes.

### [OAuth.Builder](tools/OpenShopify.OAuth.Builder/README.md)

This is the same as **Admin.Builder** except is specifically designed for the access part of the documentation since it uses a separate base url and other minor differences. *This application only needs to be built for results to be updated.*

### [Client Generator](tools/OpenShopify.ClientGenerator/README.md)

The final step is to create the client code that will be used by the final NuGet package. Even though Open\* projects are built from OpenApi specifications, that does not mean that the original API that is being interfaced with is OpenApi compliant. This takes care of any overrides in the client code generation. *This app must be executed for results to generate. This will also build the Builder app.*

* Since each category is written to a separate yaml file, there can be collisions between models used in different files. This is where certain models can be removed from the generated client code.
* Override some of the parameter names that NSwag uses when creating client code.
* Inject code that allows for testing of private objects.

## Tests

---

All the projects used to test the generated client code and source project.

### [Integration Tests](tests/Ocelli.OpenShopify.Tests/README.md)

Testing is an integral aspect of any Open\* project since it is dealing with a third party api. All endpoints will be tested for the following:

* Parameters - Do the passed in parameters work? If a date type is expected, is it in the correct format?
* Data Structure & Parsing - Do the data types map correctly? Are nullable results marked as nullable?
* Model Completeness - Are there any new properties being returned that are not documented?

### [Sample App](tests/SampleApp/README.md)

A simple application that can be used to register an application with a dev store for testing. This can be used to create the application with different scopes to ensure that the token that is generated has access to the required features. The token is not saved locally, but is printed as a result when the OAuth process completes.
