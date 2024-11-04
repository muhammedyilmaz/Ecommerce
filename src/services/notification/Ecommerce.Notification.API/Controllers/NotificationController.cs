using Ecommerce.Notification.API.Models;
using Ecommerce.Notification.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Notification.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        #region Fields

        private readonly INotificationRepository _notificationRepository;

        #endregion

        #region Ctor

        public NotificationController(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        #endregion

        #region Mertods

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] NotificationModel request)
        {
            var response = await _notificationRepository.Create(request);
            return Ok(response);
        }

        #endregion
    }
}
