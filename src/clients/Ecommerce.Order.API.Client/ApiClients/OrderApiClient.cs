using Ecommerce.Base.Client;
using Ecommerce.Base.Client.Models;
using Ecommerce.Order.API.Client.Models.Dto;
using Ecommerce.Order.API.Client.Models.Requests;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ecommerce.Order.API.Client.ApiClients
{
    public class OrderApiClient : ApiClientBase, IOrderApiClient
    {
        #region Ctor

        public OrderApiClient(string apiBaseUrl = "", string prefix = "", int serviceTimeout = 1000) : base(apiBaseUrl, prefix, serviceTimeout)
        {
        }

        #endregion

        #region Methods

        public async Task<EcommerceClientResponse<OrderDto>> CreateOrder(OrderCreatedRequest request)
        {
            return await SendRequestAsync<OrderCreatedRequest, EcommerceClientResponse<OrderDto>>(request, "CreateOrder", HttpMethod.Post).ConfigureAwait(false);
        }

        #endregion
    }
}
