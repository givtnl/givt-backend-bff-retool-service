namespace Givt.Backend.Bff.Retool.Service.Tests.Notification
{
    public class NotificationServiceTests
    {
        private readonly Mock<INotificationCoreService> _notificationCoreService;
        private readonly Mock<IValidator<SendPushNotificationsRequest>> _notificationValidator;
        private readonly Mapper _mapper;
        private readonly NotificationService _notificationService;

        public NotificationServiceTests()
        {
            _notificationCoreService = new Mock<INotificationCoreService>();
            _notificationValidator = new Mock<IValidator<SendPushNotificationsRequest>>();

            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            _mapper = new Mapper(config);

            _notificationService = new NotificationService(_notificationCoreService.Object, _notificationValidator.Object);
        }

        [Fact]
        public async Task SendPushNotifications_Test_Success()
        {
            var response = new ItemResult<CreateNotificationResponse>()
            {
                Item = new CreateNotificationResponse()
                {
                    AffectedUsers = 100,
                    BatchSize = 50,
                    QueuedMessages = 20
                }
            };
           
            _notificationCoreService.Setup(x => x.CreateNotifications(It.IsAny<CreateNotificationsRequest>(), new CancellationToken()))
                .ReturnsAsync(response);

            var result = await _notificationService.SendPushNotifications(NotificationTestData.PushNotificationsRequest(), new CancellationToken());

            Assert.True(result.Sucess);
            Assert.True(result.QueuedMessages == 20);
            Assert.True(result.AffectedUsers == 100);
            Assert.True(result.BatchSize == 50);
        }

        [Fact]
        public async Task SendPushNotifications_Test_MappingError()
        {
            SendPushNotificationsRequest request = null;
            var response = new ItemResult<CreateNotificationResponse>()
            {
                Item = new CreateNotificationResponse()
                {
                    AffectedUsers = 100,
                    BatchSize = 50,
                    QueuedMessages = 20
                }
            };

            _notificationCoreService.Setup(x => x.CreateNotifications(It.IsAny<CreateNotificationsRequest>(), new CancellationToken()))
                .ReturnsAsync(response);            

            Func<Task> action = () => _notificationService.SendPushNotifications(request, new CancellationToken());
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(action);
            Assert.True(exception.GetType() == typeof(ArgumentNullException));
        }
    }
}