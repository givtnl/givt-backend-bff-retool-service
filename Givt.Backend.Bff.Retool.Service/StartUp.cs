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

            services.AddHealthChecks();
            services.AddHttpClient();

            services.AddControllers();
            services.AddSwaggerGen();
            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc(SwaggerSettings.Version, new OpenApiInfo
                {
                    Title = SwaggerSettings.Title,
                    Version = SwaggerSettings.Version,
                    Description = SwaggerSettings.Description,
                    Contact = SwaggerSettings.Contact
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments(xmlPath);
            });

            #region AppConfigurations

            services.Configure<ApplicationSettings>(options => Configuration.GetSection("ApplicationSettings").Bind(options));
            
            #endregion

            #region Scopes

            services.AddScoped<INotificationService, NotificationService>();            

            #endregion

            #region Model Validators

            services.AddScoped<IValidator<Model.Notification>, NotificationValidator>();

            #endregion
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();                
                app.UseSwaggerUI(config =>
                {
                    config.SwaggerEndpoint(SwaggerSettings.Endpoint, SwaggerSettings.Title);                    
                });
            }

            app.MapHealthChecks("/liveliness");
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();            
            app.Run();
        }
    }
}