using DroneDelivery.API.Modules;
using DroneDelivery.API.Modules.Common;
using DroneDelivery.API.Modules.Common.Swagger;

namespace DroneDelivery.API;

/// <summary>
///     Startup.
/// </summary>
public sealed class Startup
{
    /// <summary>
    ///     Startup constructor.
    /// </summary>
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    private IConfiguration Configuration { get; }

    /// <summary>
    ///     Configure dependencies from application.
    /// </summary>
    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddVersioning()
            .AddSwagger()
            .AddUseCases()
            .AddCustomControllers()
            .AddCustomCors();

        services.AddLogging();
    }

    /// <summary>
    ///     Configure http request pipeline.
    /// </summary>
    public void Configure(
        IApplicationBuilder app,
        IWebHostEnvironment env,
        IApiVersionDescriptionProvider provider)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app
            .UseCustomCors()
            .UseRouting()
            .UseVersionedSwagger(provider, Configuration)
            .UseAuthentication()
            .UseAuthorization()
            .UseSerilogRequestLogging()
            .UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}