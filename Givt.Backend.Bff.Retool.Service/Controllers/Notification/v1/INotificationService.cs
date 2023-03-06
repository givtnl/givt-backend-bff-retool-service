namespace Givt.Backend.Bff.Retool.Service.Controllers.Notification.v1
{
    public interface INotificationService
    {
        [HttpPost("UserNotifications")]
        Task<bool> CreateUsersNotifications([FromBody] CreateUsersNotificationsRequest request, [FromHeader] CancellationToken cancelationToken);
    }
}