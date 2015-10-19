using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using VirtoCommerce.SwaggerApiClient;
using VirtoCommerce.SwaggerApiClient.Api;
using VirtoCommerce.SwaggerApiClient.Model;

namespace VirtoCommerce.Azure.ApiApp.Controllers
{
    [RoutePrefix("api/catalog/catalogs")]
    public class CatalogController : ApiController
    {        
        private readonly CatalogModuleApi _catalogClient;

        public CatalogController()
        {
            var apiKey = ConfigurationManager.AppSettings.Get("Api_Key");
            var basePath = ConfigurationManager.AppSettings.Get("Base_Path");
            var appId = ConfigurationManager.AppSettings.Get("App_Id");

            var apiClient = new HmacApiClient(basePath, appId, apiKey);
            _catalogClient = new CatalogModuleApi(apiClient);
        }
        
        /// <summary>
        /// Get Catalogs list
        /// </summary>
        /// <remarks>Get common and virtual Catalogs list with minimal information included. Returns array of Catalog</remarks>
		[HttpGet]        
        [Route("")]
        public IEnumerable<VirtoCommerceCatalogModuleWebModelCatalog> GetAll()
        {
            return _catalogClient.CatalogModuleCatalogsGetCatalogs();
        }

        /// <summary>
        /// Gets Catalog by id.
        /// </summary>
        /// <remarks>Gets Catalog by id with full information loaded</remarks>
        /// <param name="id">The Catalog id.</param>
        [HttpGet]
        [Route("{id}")]
        public VirtoCommerceCatalogModuleWebModelCatalog Get(string catalogId)
        {
            return _catalogClient.CatalogModuleCatalogsGet(catalogId);
        }

        /// <summary>
        /// Updates the specified catalog.
        /// </summary>
        /// <remarks>Updates the specified catalog.</remarks>
        /// <param name="catalog">The catalog.</param>
        [HttpPut]
        [ResponseType(typeof(void))]
        [Route("")]
        public IHttpActionResult Update(VirtoCommerceCatalogModuleWebModelCatalog catalog)
        {
            _catalogClient.CatalogModuleCatalogsUpdate(catalog);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
