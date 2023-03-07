using Givt.Common.Library.ConfigurationExtensions;

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
            
            // Header Propagation
            services.AddHeaderPropagationConfiguration();
            
            // Services Configuration
            services.AddConfiguredRestClientsEndpoints(Configuration);
            
            // Swagger Configuration
            services.AddSwaggerConfiguration(SwaggerSettings.Title, SwaggerSettings.Version, SwaggerSettings.Description, SwaggerSettings.Contact, Assembly.GetExecutingAssembly().GetName().Name);

            services.AddControllers();
            
            #region AppConfigurations

            services.Configure<ApplicationSettings>(options => Configuration.GetSection("ApplicationSettings").Bind(options));

            #endregion

            #region Scopes

            services.AddScoped<INotificationService, NotificationService>();

            #endregion

            #region Model Validators

            services.AddScoped<IValidator<BffModels.Notification>, NotificationValidator>();

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