using Ecommerce.Base.Client;
using Ecommerce.Base.Client.Models;
using Ecommerce.Publisher.API.Client.Models.Requests;
using System.Threading.Tasks;

namespace Ecommerce.Publisher.API.Client.ApiClients
{
    public interface IPublisherApiClient : IApiClientBase
    {
        #region Methods

        Task<EcommerceClientResponse> CreateOrder(PublisherOrderCreatedRequest request);
        Task<EcommerceClientResponse> StockUpdate(PublisherOrderCreatedRequest request);

        #endregion
    }
}
