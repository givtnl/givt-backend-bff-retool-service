namespace Givt.Backend.Bff.Retool.Service.Controllers.Notification.v1.Requests.v1
{
    public class SendPushNotificationsRequest
    {
        public string Country { get; set; }

        public List<BffModels.Detail> Details { get; set; }

        public BffModels.Content Contents { get; set; }
    }
}
