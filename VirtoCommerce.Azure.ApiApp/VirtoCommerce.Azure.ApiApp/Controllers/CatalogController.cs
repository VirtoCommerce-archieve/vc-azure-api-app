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
    [RoutePrefix("api/catalog/catalogs")]
    public class CatalogController : ApiController
    {        
        /// <summary>
        /// Get Catalogs list
        /// </summary>
        /// <remarks>Get common and virtual Catalogs list with minimal information included. Returns array of Catalog</remarks>
		[HttpGet]        
        [Route("")]
        public IEnumerable<VirtoCommerceCatalogModuleWebModelCatalog> GetAll(string basePath, string appId, string key)
        {
            var apiClient = new HmacApiClient(basePath, appId, key);
            var catalogClient = new CatalogModuleApi(apiClient);
            return catalogClient.CatalogModuleCatalogsGetCatalogs();
        }

        /// <summary>
        /// Gets Catalog by id.
        /// </summary>
        /// <remarks>Gets Catalog by id with full information loaded</remarks>
        /// <param name="id">The Catalog id.</param>
        [HttpGet]
        [Route("{id}")]
        public VirtoCommerceCatalogModuleWebModelCatalog Get(string basePath, string appId, string key, string catalogId)
        {
            var apiClient = new HmacApiClient(basePath, appId, key);
            var catalogClient = new CatalogModuleApi(apiClient);
            return catalogClient.CatalogModuleCatalogsGet(catalogId);
        }

        /// <summary>
        /// Updates the specified catalog.
        /// </summary>
        /// <remarks>Updates the specified catalog.</remarks>
        /// <param name="catalog">The catalog.</param>
        [HttpPut]
        [ResponseType(typeof(void))]
        [Route("")]
        public IHttpActionResult Update(string basePath, string appId, string key, VirtoCommerceCatalogModuleWebModelCatalog catalog)
        {
            var apiClient = new HmacApiClient(basePath, appId, key);
            var catalogClient = new CatalogModuleApi(apiClient);
            UpdateCatalog(catalogClient, catalog);
            return StatusCode(HttpStatusCode.NoContent);
        }
        
        private void UpdateCatalog(CatalogModuleApi apiClient, VirtoCommerceCatalogModuleWebModelCatalog catalog)
        {
            apiClient.CatalogModuleCatalogsUpdate(catalog);
        }


    }
}
