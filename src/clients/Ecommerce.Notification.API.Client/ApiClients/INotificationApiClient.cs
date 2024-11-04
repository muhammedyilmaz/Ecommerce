using Ecommerce.Base.Client.Models;
using Ecommerce.Notification.API.Client.Models.Requests;
using System.Threading.Tasks;

namespace Ecommerce.Notification.API.Client.ApiClients
{
    public interface INotificationApiClient
    {
        #region Methods

        Task<EcommerceClientResponse> Create(NotificationRequest request);

        #endregion
    }
}
