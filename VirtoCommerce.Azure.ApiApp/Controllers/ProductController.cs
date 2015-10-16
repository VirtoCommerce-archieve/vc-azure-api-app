using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using VirtoCommerce.SwaggerApiClient;
using VirtoCommerce.SwaggerApiClient.Api;
using VirtoCommerce.SwaggerApiClient.Client;
using VirtoCommerce.SwaggerApiClient.Model;

namespace VirtoCommerce.Azure.ApiApp.Controllers
{
    [RoutePrefix("api/catalog/products")]
    public class ProductController : ApiController
    {        
        /// <summary>
        /// Get Product by Id
        /// </summary>
        /// <remarks>Get product by provided id</remarks>
		[HttpGet]        
        [Route("")]
        public VirtoCommerceCatalogModuleWebModelProduct GetById(string basePath, string appId, string key, string productId)
        {
            var apiClient = new HmacApiClient(basePath, appId, key);
            var catalogClient = new CatalogModuleApi(apiClient);
            return catalogClient.CatalogModuleProductsGet(productId);
        }

        /// <summary>
        /// Updates the specified product.
        /// </summary>
        /// <remarks>Updates the specified product.</remarks>
        /// <param name="product">The product.</param>
        [HttpPut]
        [ResponseType(typeof(void))]
        [Route("")]
        public IHttpActionResult Update(string basePath, string appId, string key, VirtoCommerceCatalogModuleWebModelProduct product)
        {
            var apiClient = new HmacApiClient(basePath, appId, key);
            var catalogClient = new CatalogModuleApi(apiClient);
            UpdateProduct(catalogClient, product);
            return StatusCode(HttpStatusCode.NoContent);
        }
        
        private void UpdateProduct(CatalogModuleApi apiClient, VirtoCommerceCatalogModuleWebModelProduct product)
        {
            apiClient.CatalogModuleProductsUpdate(product);
        }


    }
}
