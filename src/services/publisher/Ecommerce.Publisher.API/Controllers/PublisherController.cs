using Ecommerce.Base.Client.Models;
using Ecommerce.Publisher.API.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Publisher.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        #region Fields

        private readonly IPublishEndpoint _publishEndpoint;

        #endregion

        #region Ctor

        public PublisherController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        #endregion

        #region Mertods

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] PublisherOrderCreatedRequest request)
        {
            try
            {
                var orderCreatedEvent = new Events.OrderCreated.OrderCreatedEvent
                {
                    Order = request.Order
                };

                await _publishEndpoint.Publish(orderCreatedEvent);

                var response = new EcommerceClientResponse() { Data= orderCreatedEvent, IsSuccess = true, Message = "Success" };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new PublisherOrderCreatedResponse()
                {
                    Message = ex.Message,
                    Status = "Error"
                };

                return Ok(response);
            }
           
        }

        [HttpPost("UpdateStock")]
        public async Task<IActionResult> UpdateStock([FromBody] PublisherOrderCreatedRequest request)
        {
            try
            {
                var orderCreatedEvent = new Events.StockUpdated.StockUpdatedEvent
                {
                    Order = request.Order
                };

                await _publishEndpoint.Publish(orderCreatedEvent);

                var response = new EcommerceClientResponse() { Data = orderCreatedEvent, IsSuccess = true, Message = "Success" };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new PublisherOrderCreatedResponse()
                {
                    Message = ex.Message,
                    Status = "Error"
                };

                return Ok(response);
            }

        }

        #endregion
    }
}
