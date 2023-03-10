namespace Givt.Backend.Bff.Retool.Service.Controllers.Notification.v1
{
    public class NotificationValidator : AbstractValidator<SendPushNotificationsRequest>
    {
        private readonly ApplicationSettings _applicationSettings;
        private readonly NotificationConfiguration _notificationConfiguration;

        public NotificationValidator(IOptions<ApplicationSettings> applicationSettings, IOptions<NotificationConfiguration> notificationConfiguration)
        {
            _applicationSettings = applicationSettings.Value;
            _notificationConfiguration = notificationConfiguration.Value;
        }
    }
}