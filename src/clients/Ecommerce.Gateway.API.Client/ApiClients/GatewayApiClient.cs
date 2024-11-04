using Ecommerce.Base.Client;
using Ecommerce.Base.Client.Models;
using Ecommerce.Notification.API.Client.Models.Requests;
using Ecommerce.Order.API.Client.Models.Dto;
using Ecommerce.Order.API.Client.Models.Requests;
using Ecommerce.Publisher.API.Client.Models.Requests;
using Ecommerce.Stock.API.Client.Models.Dto;
using Ecommerce.Stock.API.Client.Models.Requests;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ecommerce.Gateway.API.Client.ApiClients
{
    public class GatewayApiClient : ApiClientBase, IGatewayApiClient
    {
        #region Ctor

        public GatewayApiClient(string apiBaseUrl = "", string prefix = "", int serviceTimeout = 1000) : base(apiBaseUrl, prefix, serviceTimeout)
        {
        }

        #endregion

        #region Methods

        public async Task<EcommerceClientResponse> SendOrderToQueue(PublisherOrderCreatedRequest request)
        {
            return await SendRequestAsync<PublisherOrderCreatedRequest, EcommerceClientResponse>(request, "SendOrderToQueue", HttpMethod.Post).ConfigureAwait(false);
        }

        public async Task<EcommerceClientResponse> SendStockUpdateToQueue(PublisherOrderCreatedRequest request)
        {
            return await SendRequestAsync<PublisherOrderCreatedRequest, EcommerceClientResponse>(request, "SendStockUpdateToQueue", HttpMethod.Post).ConfigureAwait(false);
        }

        public async Task<EcommerceClientResponse<OrderDto>> CreateOrder(OrderCreatedRequest request)
        {
            return await SendRequestAsync<OrderCreatedRequest, EcommerceClientResponse<OrderDto>>(request, "CreateOrder", HttpMethod.Post).ConfigureAwait(false);
        }

        public async Task<EcommerceClientResponse<List<UpdateStockDto>>> UpdateStock(UpdateStockRequest request)
        {
            return await SendRequestAsync<UpdateStockRequest, EcommerceClientResponse<List<UpdateStockDto>>>(request, "UpdateStock", HttpMethod.Post).ConfigureAwait(false);
        }

        public async Task<EcommerceClientResponse> CreateNotification(NotificationRequest request)
        {
            return await SendRequestAsync<NotificationRequest, EcommerceClientResponse>(request, "CreateNotification", HttpMethod.Post).ConfigureAwait(false);
        }

        #endregion
    }
}