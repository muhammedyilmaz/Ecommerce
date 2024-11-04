using Ecommerce.Order.API.Models;
using Ecommerce.Order.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Order.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        #region Fields

        private readonly IOrderRepository _orderRepository;

        #endregion

        #region Ctor

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        #endregion

        #region Mertods

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCreatedRequest request)
        {
            var response = await _orderRepository.CreateOrder(request);
            return Ok(response);
        }

        #endregion
    }
}
