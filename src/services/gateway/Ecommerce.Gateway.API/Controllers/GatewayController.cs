using Ecommerce.Notification.API.Client.ApiClients;
using Ecommerce.Notification.API.Client.Models.Requests;
using Ecommerce.Order.API.Client.ApiClients;
using Ecommerce.Order.API.Client.Models.Requests;
using Ecommerce.Publisher.API.Client.ApiClients;
using Ecommerce.Publisher.API.Client.Models.Requests;
using Ecommerce.Stock.API.Client.ApiClients;
using Ecommerce.Stock.API.Client.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Gateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        #region Fields

        private readonly IPublisherApiClient _publisherApiClient;
        private readonly IOrderApiClient _orderApiClient;
        private readonly IStockApiClient _stockApiClient;
        private readonly INotificationApiClient _notificationApiClient;

        #endregion

        #region Ctor

        public GatewayController(IPublisherApiClient publisherApiClient,
            IOrderApiClient orderApiClient,
            IStockApiClient stockApiClient,
            INotificationApiClient notificationApiClient)
        {
            _publisherApiClient = publisherApiClient;
            _orderApiClient = orderApiClient;
            _stockApiClient = stockApiClient;
            _notificationApiClient = notificationApiClient;
        }

        #endregion

        #region Methots

        [HttpPost("SendOrderToQueue")]
        public async Task<IActionResult> PublishCreateOrder([FromBody] PublisherOrderCreatedRequest request)
        {
            var response = await _publisherApiClient.CreateOrder(request);
            return Ok(response);
        }

        [HttpPost("SendStockUpdateToQueue")]
        public async Task<IActionResult> SendStockUpdateToQueue([FromBody] PublisherOrderCreatedRequest request)
        {
            var response = await _publisherApiClient.StockUpdate(request);
            return Ok(response);
        }

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCreatedRequest request)
        {
            var response = await _orderApiClient.CreateOrder(request);
            return Ok(response);
        }

        [HttpPost("UpdateStock")]
        public async Task<IActionResult> UpdateStock([FromBody] UpdateStockRequest request)
        {
            var response = await _stockApiClient.UpdateStock(request);
            return Ok(response);
        }

        [HttpPost("CreateNotification")]
        public async Task<IActionResult> CreateNotification([FromBody] NotificationRequest request)
        {
            var response = await _notificationApiClient.Create(request);
            return Ok(response);
        }

        #endregion
    }
}
