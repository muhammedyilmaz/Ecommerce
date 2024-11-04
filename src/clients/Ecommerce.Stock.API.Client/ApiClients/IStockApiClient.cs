using Ecommerce.Base.Client;
using Ecommerce.Base.Client.Models;
using Ecommerce.Stock.API.Client.Models.Dto;
using Ecommerce.Stock.API.Client.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Stock.API.Client.ApiClients
{
    public interface IStockApiClient : IApiClientBase
    {
        #region Methods

        Task<EcommerceClientResponse<List<UpdateStockDto>>> UpdateStock(UpdateStockRequest request);

        #endregion
    }
}

