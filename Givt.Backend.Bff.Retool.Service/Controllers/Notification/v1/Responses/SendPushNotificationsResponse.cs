namespace Givt.Backend.Bff.Retool.Service.Controllers.Notification.v1.Requests.v1
{
    public class SendPushNotificationsResponse
    {
        public int QueuedMessages { get; set; }
        public int AffectedUsers { get; set; }
        public int BatchSize { get; set; }
        public bool Sucess { get; set; }
        public string ErrorMessage { get; set; }
    }
}
