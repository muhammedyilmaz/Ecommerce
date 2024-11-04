using Ecommerce.Stock.API.Models;
using Ecommerce.Stock.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Stock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        #region Fields

        private readonly IStockRepository _stockRepository;

        #endregion

        #region Ctor

        public StockController(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        #endregion

        #region Mertods

        [HttpPost("UpdateStock")]
        public async Task<IActionResult> UpdateStock([FromBody] UpdateStockModel request)
        {
            var response = await _stockRepository.UpdateStock(request);
            return Ok(response);
        }

        #endregion
    }
}
