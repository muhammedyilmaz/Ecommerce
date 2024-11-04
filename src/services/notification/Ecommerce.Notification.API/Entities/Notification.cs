using Ecommerce.Notification.API.Enums;

namespace Ecommerce.Notification.API.Entities
{
    public class Notification
    {
        #region Properties

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Message { get; set; }
        public NotificationType Type  { get; set; }
        public DateTime SentAt { get; set; } = DateTime.UtcNow; // Bildirimin gönderildiği zaman
        public bool IsSuccess { get; set; } // Bildirimin başarıyla gönderilip gönderilmediği

        #endregion
    }
}
