

namespace Givt.Backend.Bff.Retool.Service.Controllers.Notification.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BackOfficeController : ControllerBase
    {
        private readonly INotificationService _notificationService;


        public BackOfficeController(INotificationService notificationService)
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
