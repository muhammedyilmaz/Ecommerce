using Ecommerce.Base.Client;
using Ecommerce.Base.Client.Models;
using Ecommerce.Notification.API.Client.Models.Requests;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ecommerce.Notification.API.Client.ApiClients
{
    public class NotificationApiClient : ApiClientBase, INotificationApiClient
    {
        #region Ctor

        public NotificationApiClient(string apiBaseUrl = "", string prefix = "", int serviceTimeout = 1000) : base(apiBaseUrl, prefix, serviceTimeout)
        {
        }

        #endregion

        #region Methods

        public async Task<EcommerceClientResponse> Create(NotificationRequest request)
        {
            return await SendRequestAsync<NotificationRequest, EcommerceClientResponse>(request, "Create", HttpMethod.Post).ConfigureAwait(false);
        }

        #endregion
    }
}

