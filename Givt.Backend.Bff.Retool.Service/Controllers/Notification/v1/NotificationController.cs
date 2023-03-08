﻿

namespace Givt.Backend.Bff.Retool.Service.Controllers.Notification.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")] //either use this a version 1.0, 2.0, 3.0, ... or the folder style
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;


        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost("UserNotifications")]
        public async Task<bool> CreateUsersNotifications([FromBody] CreateUsersNotificationsRequest request, [FromHeader] CancellationToken cancelationToken)
        {
            return await _notificationService.CreateUsersNotifications(request, cancelationToken);
        }
    }
}