using Ecommerce.Stock.API.Client.Models.Dto;
using System.Collections.Generic;

namespace Ecommerce.Stock.API.Client.Models.Requests
{
    public class UpdateStockRequest
    {
        public List<UpdateStockDto> Stocks { get; set; }
    }
}
