using System.Configuration;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using VirtoCommerce.SwaggerApiClient;
using VirtoCommerce.SwaggerApiClient.Api;
using VirtoCommerce.SwaggerApiClient.Model;

namespace VirtoCommerce.Azure.ApiApp.Controllers
{
    [RoutePrefix("api/catalog/products")]
    public class ProductController : ApiController
    {
        private readonly CatalogModuleApi _productClient;

        public ProductController()
        {
            var apiKey = ConfigurationManager.AppSettings.Get("Api_Key");
            var basePath = ConfigurationManager.AppSettings.Get("Base_Path");
            var appId = ConfigurationManager.AppSettings.Get("App_Id");

            var apiClient = new HmacApiClient(basePath, appId, apiKey);
            _productClient = new CatalogModuleApi(apiClient);
        }

        /// <summary>
        /// Get Product by Id
        /// </summary>
        /// <remarks>Get product by provided id</remarks>
		[HttpGet]        
        [Route("")]
        public VirtoCommerceCatalogModuleWebModelProduct GetById(string productId)
        {
            return _productClient.CatalogModuleProductsGet(productId);
        }

        /// <summary>
        /// Updates the specified product.
        /// </summary>
        /// <remarks>Updates the specified product.</remarks>
        /// <param name="product">The product.</param>
        [HttpPut]
        [ResponseType(typeof(void))]
        [Route("")]
        public IHttpActionResult Update(VirtoCommerceCatalogModuleWebModelProduct product)
        {
            _productClient.CatalogModuleProductsUpdate(product);
            return StatusCode(HttpStatusCode.NoContent);
        }        
    }
}
