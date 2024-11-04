using Ecommerce.Base.Client;
using Ecommerce.Base.Client.Models;
using Ecommerce.Stock.API.Client.Models.Dto;
using Ecommerce.Stock.API.Client.Models.Requests;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ecommerce.Stock.API.Client.ApiClients
{
    public class StockApiClient : ApiClientBase, IStockApiClient
    {
        #region Ctor

        public StockApiClient(string apiBaseUrl = "", string prefix = "", int serviceTimeout = 1000) : base(apiBaseUrl, prefix, serviceTimeout)
        {
        }

        #endregion

        #region Methods

        public async Task<EcommerceClientResponse<List<UpdateStockDto>>> UpdateStock(UpdateStockRequest request)
        {
            return await SendRequestAsync<UpdateStockRequest, EcommerceClientResponse<List<UpdateStockDto>>>(request, "UpdateStock", HttpMethod.Post).ConfigureAwait(false);
        }

        #endregion
    }
}
