using System.Configuration;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using VirtoCommerce.SwaggerApiClient;
using VirtoCommerce.SwaggerApiClient.Api;
using VirtoCommerce.SwaggerApiClient.Model;

namespace VirtoCommerce.Azure.ApiApp.Controllers
{
    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {
        private readonly OrderModuleApi _orderClient;

        public OrderController()
        {
            var apiKey = ConfigurationManager.AppSettings.Get("Api_Key");
            var basePath = ConfigurationManager.AppSettings.Get("Base_Path");
            var appId = ConfigurationManager.AppSettings.Get("App_Id");

            var apiClient = new HmacApiClient(basePath, appId, apiKey);
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
