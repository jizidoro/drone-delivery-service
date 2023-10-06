namespace DroneDelivery.API.Modules.Common;

/// <summary>
///     Versioning Extensions.
/// </summary>
public static class VersioningExtensions
{
    /// <summary>
    ///     Method that adds versioning to the api.
    /// </summary>
    /// <param name="services"></param>
    public static IServiceCollection AddVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(
            options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });
        services.AddVersionedApiExplorer(
            options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

        return services;
    }
}