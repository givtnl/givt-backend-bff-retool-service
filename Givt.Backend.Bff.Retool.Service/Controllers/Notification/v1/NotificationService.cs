namespace Givt.Backend.Bff.Retool.Service.Controllers.Notification.v1;

public class NotificationService : INotificationService
{
    private readonly INotificationCoreService _notificationCoreService;
    private readonly IValidator<SendPushNotificationsRequest> _validator;


    public NotificationService(INotificationCoreService notificationCoreService, IValidator<SendPushNotificationsRequest> validator)
    {
        _notificationCoreService = notificationCoreService;
        _validator = validator;
    }

    public async Task<SendPushNotificationsResponse> SendPushNotifications(SendPushNotificationsRequest request, CancellationToken cancelationToken)
    {
        var validatorResult = _validator.Validate(request);

        var coreNotificationRequest = request.Adapt<CoreModels.CreateNotificationsRequest>();

        if(coreNotificationRequest == null)
            throw new ArgumentNullException(nameof(coreNotificationRequest));

        // Call to the core(domain) service
        var result = await _notificationCoreService.CreateNotifications(coreNotificationRequest, cancelationToken);                

        return new SendPushNotificationsResponse
        {
            AffectedUsers = result.Item.AffectedUsers,
            BatchSize = result.Item.BatchSize,
            QueuedMessages = result.Item.QueuedMessages,
            Sucess = !result.IsError,
            ErrorMessage = result.IsError ? result.ErrorMessage : string.Empty 
        };
    }
}