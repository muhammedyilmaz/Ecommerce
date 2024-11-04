using Ecommerce.Base.Client.Models;
using Ecommerce.Notification.API.Models;

namespace Ecommerce.Notification.API.Repositories
{
    public interface INotificationRepository
    {
        #region Methods

        Task<EcommerceClientResponse> Create(NotificationModel model);

        #endregion
    }
}
