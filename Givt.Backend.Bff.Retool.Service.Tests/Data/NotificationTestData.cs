namespace Givt.Backend.Bff.Retool.Service.Tests.Data
{
    internal static class NotificationTestData
    {
        public static SendPushNotificationsRequest PushNotificationsRequest()
        {
            return new SendPushNotificationsRequest()
            {
                Country = "UK",
                Content = new Controllers.Notification.v1.Models.Content() { Version = 1 },
                Details = new List<Controllers.Notification.v1.Models.Detail>()
                {
                    new Controllers.Notification.v1.Models.Detail()
                    {
                        AppLanguage = "en",
                        Message = "Message",
                        Title = "Title"
                    },
                    new Controllers.Notification.v1.Models.Detail()
                    {
                        AppLanguage = "de",
                        Message = "Message",
                        Title = "Title"
                    }
                }

            };
        }
    }
}
