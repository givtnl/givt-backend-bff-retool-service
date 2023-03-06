namespace Givt.Backend.Bff.Retool.Service.Configurations
{
    public static class SwaggerSettings
    {
        public static string Title { get; set; } = "Notifications Bff Api";
        public static string Version { get; set; } = "v1.0";
        public static string Description { get; set; } = "An API that disperses notifications incoming from WePay to designated handlers.";
        public static string Endpoint { get; set; } = "/swagger/v1.0/swagger.json";
        public static OpenApiContact Contact { get; } = new OpenApiContact()
        {
            Name = "Mike Pattyn",
            Email = "mike@givtapp.net",
            Url = new Uri("https://github.com/givtnl")
        };
    }
}