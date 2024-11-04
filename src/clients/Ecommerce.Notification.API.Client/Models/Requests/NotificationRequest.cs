using System;

namespace Ecommerce.Notification.API.Client.Models.Requests
{
    public class NotificationRequest
    {
        #region Properties

        public int UserId { get; set; }
        public string Message { get; set; }
        public byte Type { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsSuccess { get; set; }

        #endregion
    }
}
