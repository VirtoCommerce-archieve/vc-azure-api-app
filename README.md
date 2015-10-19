# VirtoCommerce API App
This is a VirtoCommerce Azure API App [API App](http://azure.microsoft.com/en-us/documentation/articles/app-service-api-apps-why-best-platform/ "What are API Apps?") for deployment into the Azure App Service. This API App implements integration points with VirtoCommerce platform api using Azure Logic Apps.

## More Information ##
The VirtoCommerce Azure API App uses [VirtoCommerce.Client](https://www.nuget.org/packages/VirtoCommerce.Client/ "library") to consume VirtoCommerce Web Api.

## Deployment ##
Click "Deploy to Azure" to start VirtoCommerce API App deployment to your account.

[![Deploy to Azure](http://azuredeploy.net/deploybutton.png)](https://azuredeploy.net/)

During the setup process provide App Id, Hmac Api Key and VirtoCommerce deployment web api base url.

In order to create Hmac key go to VirtoCommerce admin -> Configuration -> Security.

Create a new user. Create Hmac API key for the user. Give the user permissions to manage Catalogs and orders. For more information read [VirtoCommerce documentation](http://docs.virtocommerce.com/x/jwDr)

Copy & paste the App Id and Api Key values from the just create user Hmac api key to the Azure deployment setup appropriate fields.

The Api base url is the url to the VirtoCommerce platform admin.

Fill other properties (like gateway etc.) with the values required by Azure.

Deploy the API App.

## Usage ##
When the deployment completed successfully the VirtoCommerce.APIApp should appear in the list of API Apps of you Azure subscription. It can be used like any other API App by adding it to your Logic App.

## API provided by the App ##
- Catalog management api.
- Product management api.
- Orders management api.

... more available upon request.

Helpful Links:
- [API App](http://azure.microsoft.com/en-us/documentation/articles/app-service-api-apps-why-best-platform/ "What are API Apps?")
- [Create an API App in Azure App Service](http://azure.microsoft.com/en-us/documentation/articles/app-service-dotnet-create-api-app/)
- [Convert an Existing API to an API App](http://azure.microsoft.com/en-us/documentation/articles/app-service-dotnet-create-api-app-visual-studio/)
- [Remotely Debug an API App](http://azure.microsoft.com/en-us/documentation/articles/app-service-dotnet-remotely-debug-api-app/)
- [Protect an API App](http://azure.microsoft.com/en-us/documentation/articles/app-service-api-dotnet-add-authentication/)
- [Deploy an API App in App Service](http://azure.microsoft.com/en-us/documentation/articles/app-service-dotnet-deploy-api-app/)
