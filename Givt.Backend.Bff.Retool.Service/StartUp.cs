using MapsterMapper;

namespace Givt.Backend.Bff.Retool.Service
{
    public class Startup
    {
        public IConfiguration Configuration
        {
            get;
        }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(); // Allows Cors for App calls
            services.AddOptions();

            services.AddEndpointsApiExplorer();
            services.AddHealthChecks();
            services.AddHttpClient();
            services.AddHttpContextAccessor();
            services.AddApiVersioning();

            var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
            // scans the assembly and gets the IRegister, adding the registration to the TypeAdapterConfig
            typeAdapterConfig.Scan(Assembly.GetExecutingAssembly());            

            // Mapster Mapper Configuration
            services.RegisterNotificationMappings();
            
            // Header Propagation
            services.AddHeaderPropagationConfiguration();
            
            // Services Configuration
            services.AddConfiguredRestClientsEndpoints(Configuration);
            
            // Swagger Configuration
            services.AddSwaggerConfiguration(SwaggerSettings.Title, SwaggerSettings.Version, SwaggerSettings.Description, SwaggerSettings.Contact, Assembly.GetExecutingAssembly().GetName().Name);

            services.AddControllers();
            
            #region AppConfigurations

            services.Configure<ApplicationSettings>(options => Configuration.GetSection("ApplicationSettings").Bind(options));
            services.Configure<NotificationConfiguration>(options => Configuration.GetSection("NotificationConfiguration").Bind(options));

            #endregion

            #region Scopes

            services.AddScoped<INotificationService, NotificationService>();

            #endregion

            #region Model Validators

            services.AddScoped<IValidator<SendPushNotificationsRequest>, NotificationValidator>();

            #endregion
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            app.UseRouting();                        
            app.UseStaticFiles();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseHeaderPropagation();

            // Exception Handling
            app.AddExceptionHandlerConfiguration();

            app.AddSwaggerConfiguration(env, SwaggerSettings.Endpoint, SwaggerSettings.Title);

            app.MapHealthChecks("/liveliness");
            app.MapControllers();
            app.Run();
        }
    }
}