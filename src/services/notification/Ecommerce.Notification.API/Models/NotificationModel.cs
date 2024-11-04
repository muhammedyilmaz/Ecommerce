using Ecommerce.Notification.API.Enums;

namespace Ecommerce.Notification.API.Models
{
    public class NotificationModel
    {
        #region Properties

        public int UserId { get; set; }
        public string Message { get; set; }
        public NotificationType Type { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsSuccess { get; set; } 

        #endregion
    }
}
