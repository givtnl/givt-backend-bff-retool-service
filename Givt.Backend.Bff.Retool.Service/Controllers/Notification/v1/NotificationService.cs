namespace Givt.Backend.Bff.Retool.Service.Controllers.Notification.v1;

public class NotificationService : INotificationService
{
    private readonly  INotificationCoreService _notificationCoreService;

    public NotificationService(INotificationCoreService notificationCoreService)
    {
        _notificationCoreService = notificationCoreService;
    }

    public async Task<bool> CreateUsersNotifications([FromBody] CreateUsersNotificationsRequest request, [FromHeader] CancellationToken cancelationToken)
    {
        // Call to the core(domain) service
        var responseCore = await _notificationCoreService.CreateNotifications(new CoreModels.CreateNotificationsRequest()
        {
            Notification = new CoreModels.Notification()
            {
                Title = "Title",
                Message = "Message"
            }
        }, cancelationToken); 
        
        return true;
    }
}