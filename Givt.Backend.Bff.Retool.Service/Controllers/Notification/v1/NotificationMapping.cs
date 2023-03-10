namespace Givt.Backend.Bff.Retool.Service.Controllers.Notification.v1
{
    public static class NotificationMapping
    {
        public static void RegisterNotificationMappings(this IServiceCollection services)
        {
            TypeAdapterConfig<SendPushNotificationsRequest, CoreModels.CreateNotificationsRequest>
                .NewConfig()
                .IgnoreNullValues(true);

            TypeAdapterConfig<BffModels.Detail, CoreModels.Detail>
                .NewConfig()
                .MapWith(src => CustomDetailConverter(src))                 
                .IgnoreNonMapped(true);

            TypeAdapterConfig<BffModels.Content, CoreModels.Content>
                .NewConfig();
        }


        #region Custom Mappings
        
        private static CoreModels.Detail CustomDetailConverter(BffModels.Detail src)
        {
            CoreModels.Detail destination = new CoreModels.Detail();

            if (!string.IsNullOrEmpty(src.Title) && !string.IsNullOrEmpty(src.Message))
            {
                return new CoreModels.Detail()
                {
                    AppLanguage = src.AppLanguage,
                    Title = src.Title,
                    Message = src.Message
                };
            }
            else
            {
                return null;
            }

        } 

        #endregion
    }
}
