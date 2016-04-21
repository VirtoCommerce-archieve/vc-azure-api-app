using System;
using System.Collections.Generic;
using System.Linq;
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
    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {
        private readonly OrderModuleApi _orderClient;

        public OrderController(Configuration apiConfiguration)
        {
            _orderClient = new OrderModuleApi(apiConfiguration);
        }

        /// <summary>
        /// Get Order by Id
        /// </summary>
        /// <remarks>Get Order by provided Id.</remarks>
		[HttpGet]        
        [Route("")]
        public VirtoCommerceOrderModuleWebModelCustomerOrder GetById(string orderId)
        {            
            return _orderClient.OrderModuleGetById(orderId);
        }

        /// <summary>
        /// Get Order by criteria
        /// </summary>
        /// <remarks>Get Order by provided Id.</remarks>
		[HttpGet]
        [Route("search/{storeId}/{startDate}/{endDate}/{status}/{responseGroup}")]
        public List<VirtoCommerceOrderModuleWebModelCustomerOrder> GetByCriteria(string storeId, DateTime? startDate, DateTime? endDate, string status, string responseGroup)
        {
            var criteria = new VirtoCommerceDomainOrderModelSearchCriteria
            {
                ResponseGroup = responseGroup ?? "Full"
            };

            if (!string.IsNullOrEmpty(storeId))
                criteria.StoreIds = new List<string> { storeId };

            criteria.StartDate = startDate ?? DateTime.Today;
            criteria.EndDate = endDate ?? DateTime.Today.AddDays(1);


            var response = _orderClient.OrderModuleSearch(criteria).CustomerOrders;
            if (!string.IsNullOrEmpty(status))
                response = response.Where(order=> order.Status.Equals(status)).ToList();

            return response;
        }

        /// <summary>
        /// Updates the specified order.
        /// </summary>
        /// <remarks>Updates the specified order.</remarks>
        /// <param name="order">The order.</param>
        [HttpPut]
        [ResponseType(typeof(void))]
        [Route("")]
        public IHttpActionResult Update(VirtoCommerceOrderModuleWebModelCustomerOrder order)
        {
            _orderClient.OrderModuleUpdate(order);
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
        public IHttpActionResult Create(VirtoCommerceOrderModuleWebModelCustomerOrder order)
        {
            _orderClient.OrderModuleCreateOrder(order);
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
