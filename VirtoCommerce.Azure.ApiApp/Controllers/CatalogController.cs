using System.Collections.Generic;
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
    [RoutePrefix("api/catalog/catalogs")]
    public class CatalogController : ApiController
    {        
        private readonly CatalogModuleApi _catalogClient;

        public CatalogController(Configuration apiConfiguration)
        {
            _catalogClient = new CatalogModuleApi(apiConfiguration);
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
        [Route("{catalogId}")]
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

        protected ApiClient GetApiClient()
        {
            var apiClient = new HmacApiClient(APIAppSettings.BasePath, APIAppSettings.AppId, APIAppSettings.ApiKey);
            return apiClient;
        }
    }
}
