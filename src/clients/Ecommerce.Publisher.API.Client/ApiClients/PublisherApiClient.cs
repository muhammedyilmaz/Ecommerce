using Ecommerce.Base.Client;
using Ecommerce.Base.Client.Models;
using Ecommerce.Publisher.API.Client.Models.Requests;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ecommerce.Publisher.API.Client.ApiClients
{
    public class PublisherApiClient : ApiClientBase, IPublisherApiClient
    {
        #region Ctor

        public PublisherApiClient(string apiBaseUrl = "", string prefix = "", int serviceTimeout = 1000) : base(apiBaseUrl, prefix, serviceTimeout)
        {
        }

        #endregion

        #region Methods

        public async Task<EcommerceClientResponse> CreateOrder(PublisherOrderCreatedRequest request)
        {
            return await SendRequestAsync<PublisherOrderCreatedRequest, EcommerceClientResponse>(request, "CreateOrder", HttpMethod.Post).ConfigureAwait(false);
        }

        public async Task<EcommerceClientResponse> StockUpdate(PublisherOrderCreatedRequest request)
        {
            return await SendRequestAsync<PublisherOrderCreatedRequest, EcommerceClientResponse>(request, "UpdateStock", HttpMethod.Post).ConfigureAwait(false);
        }

        #endregion
    }
}
