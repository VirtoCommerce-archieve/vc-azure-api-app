using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using VirtoCommerce.Azure.ApiApp.Common;
using VirtoCommerce.Client;
using VirtoCommerce.Client.Api;
using VirtoCommerce.Client.Client;
using VirtoCommerce.Client.Model;

namespace VirtoCommerce.Azure.ApiApp.Controllers
{
    [RoutePrefix("api/catalog/products")]
    public class ProductController : ApiController
    {
        private readonly CatalogModuleApi _productClient;

        public ProductController(Configuration apiConfiguration)
        {
            _productClient = new CatalogModuleApi(apiConfiguration);
        }

        /// <summary>
        /// Get Product by Id
        /// </summary>
        /// <remarks>Get product by provided id</remarks>
		[HttpGet]        
        [Route("")]
        public VirtoCommerceCatalogModuleWebModelProduct GetById(string productId)
        {
            return _productClient.CatalogModuleProductsGetProductById(productId);
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
