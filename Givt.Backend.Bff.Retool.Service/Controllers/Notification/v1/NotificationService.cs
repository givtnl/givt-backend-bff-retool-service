using Microsoft.Extensions.Options;
using System;

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

        // Call to the core(domain) service
        //var responseCore = await _notificationCoreService.CreateNotifications(new CoreModels.CreateNotificationsRequest(), cancelationToken); 
        
        return new SendPushNotificationsResponse() { 
            AffectedUsers = 50,
            BatchSize = 50,
            QueuedMessages = 50,
            Sucess = true
        };
    }
}