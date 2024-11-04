using Ecommerce.Base.Client;
using Ecommerce.Base.Client.Models;
using Ecommerce.Order.API.Client.Models.Dto;
using Ecommerce.Order.API.Client.Models.Requests;
using System.Threading.Tasks;

namespace Ecommerce.Order.API.Client.ApiClients
{
    public interface IOrderApiClient : IApiClientBase
    {
        #region Methods

        Task<EcommerceClientResponse<OrderDto>> CreateOrder(OrderCreatedRequest request);

        #endregion
    }
}

