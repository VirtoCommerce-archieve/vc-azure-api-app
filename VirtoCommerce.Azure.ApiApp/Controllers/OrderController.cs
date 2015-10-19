using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using VirtoCommerce.Azure.ApiApp.Common;
using VirtoCommerce.Client;
using VirtoCommerce.Client.Api;
using VirtoCommerce.Client.Model;

namespace VirtoCommerce.Azure.ApiApp.Controllers
{
    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {
        private readonly OrderModuleApi _orderClient;

        public OrderController()
        {
            var apiClient = new HmacApiClient(APIAppSettings.BasePath, APIAppSettings.AppId, APIAppSettings.ApiKey);
            _orderClient = new OrderModuleApi(apiClient);
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
