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
    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {        
        /// <summary>
        /// Get Order by Id
        /// </summary>
        /// <remarks>Get Order by provided Id.</remarks>
		[HttpGet]        
        [Route("")]
        public VirtoCommerceOrderModuleWebModelCustomerOrder GetById(string basePath, string appId, string key, string orderId)
        {
            var apiClient = new HmacApiClient(basePath, appId, key);
            var orderClient = new OrderModuleApi(apiClient);
            return orderClient.OrderModuleGetById(orderId);
        }
        
        /// <summary>
        /// Updates the specified order.
        /// </summary>
        /// <remarks>Updates the specified order.</remarks>
        /// <param name="order">The order.</param>
        [HttpPut]
        [ResponseType(typeof(void))]
        [Route("")]
        public IHttpActionResult Update(string basePath, string appId, string key, VirtoCommerceOrderModuleWebModelCustomerOrder order)
        {
            var apiClient = new HmacApiClient(basePath, appId, key);
            var orderClient = new OrderModuleApi(apiClient);
            orderClient.OrderModuleUpdate(order);
            return StatusCode(HttpStatusCode.NoContent);
        }
        
        /// <summary>
        /// Create order.
        /// </summary>
        /// <remarks>Creates new order.</remarks>
        /// <param name="order">The order.</param>
        [HttpPost]
        [ResponseType(typeof(void))]
        [Route("")]
        public IHttpActionResult Create(string basePath, string appId, string key, VirtoCommerceOrderModuleWebModelCustomerOrder order)
        {
            var apiClient = new HmacApiClient(basePath, appId, key);
            var orderClient = new OrderModuleApi(apiClient);
            orderClient.OrderModuleCreateOrder(order);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
