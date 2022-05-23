# Open:Shopify (Admin Builder)

**TODO**: add documentation.

## Developer Notes

### Model Inheritance

The models for Shopify can be complex. OpenShopify scrapes the models from the documentation website and create objects and comments locally. Part of the process overrides some common data types. Below is the hierarchy of inheritance for all objects.

* **Orig** schema is created by the scraper app and should not be modified directly.
  * **Base** is used to override data types and add properties that all create, read, and update operations have.
    * **Official** contains properties and overrides that only exist for read and update operations. _This is the name that Shopify uses and is the root for all other names._
      * **Update** contains any properties only used for the update commands.
        * **UpdateRequest** the wrapper for update operations.
      * **List** is the wrapper for returning a list of items.
      * **Item** is the wrapper for returning a single item.
    * **Create** contains any properties only used for the create commands.
      * **CreateRequest** the wrapper for create operations.
