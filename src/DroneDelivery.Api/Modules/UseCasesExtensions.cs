using DroneDelivery.Application.Components.DeliveryOptimizer.Command;

namespace DroneDelivery.API.Modules;

/// <summary>
///     Adds Use Cases classes.
/// </summary>
public static class UseCasesExtensions
{
    /// <summary>
    ///     Adds Use Cases to the ServiceCollection.
    /// </summary>
    /// <param name="services"></param>
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<IDeliveryOptimizerCommand, DeliveryOptimizerCommand>();

        return services;
    }
}