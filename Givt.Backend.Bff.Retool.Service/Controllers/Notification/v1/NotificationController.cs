namespace Givt.Backend.Bff.Retool.Service.Controllers.Notification.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;


        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost("send-pushnotifications")]
        public async Task<SendPushNotificationsResponse> CreateUsersNotifications([FromBody] SendPushNotificationsRequest request, [FromHeader] CancellationToken cancelationToken)
        {
            return await _notificationService.SendPushNotifications(request, cancelationToken);
        }
    }
}