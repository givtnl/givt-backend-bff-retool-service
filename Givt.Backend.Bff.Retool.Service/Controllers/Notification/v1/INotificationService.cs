namespace Givt.Backend.Bff.Retool.Service.Controllers.Notification.v1
{
    public interface INotificationService
    {
        [HttpPost("send-pushnotifications")]
        Task<SendPushNotificationsResponse> SendPushNotifications([FromBody] SendPushNotificationsRequest request, [FromHeader] CancellationToken cancelationToken);
    }
}