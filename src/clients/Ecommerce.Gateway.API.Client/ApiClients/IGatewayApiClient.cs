using Ecommerce.Base.Client;
using Ecommerce.Base.Client.Models;
using Ecommerce.Notification.API.Client.Models.Requests;
using Ecommerce.Order.API.Client.Models.Dto;
using Ecommerce.Order.API.Client.Models.Requests;
using Ecommerce.Publisher.API.Client.Models.Requests;
using Ecommerce.Stock.API.Client.Models.Dto;
using Ecommerce.Stock.API.Client.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Gateway.API.Client.ApiClients
{
    public interface IGatewayApiClient : IApiClientBase
    {

        #region Methods

        Task<EcommerceClientResponse> SendOrderToQueue(PublisherOrderCreatedRequest request);
        Task<EcommerceClientResponse> SendStockUpdateToQueue(PublisherOrderCreatedRequest request);
        Task<EcommerceClientResponse<OrderDto>> CreateOrder(OrderCreatedRequest request);
        Task<EcommerceClientResponse<List<UpdateStockDto>>> UpdateStock(UpdateStockRequest request);
        Task<EcommerceClientResponse> CreateNotification(NotificationRequest request);

        #endregion
    }
}
