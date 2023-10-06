using Microsoft.AspNetCore.Http;

namespace DroneDelivery.Application.Components.DeliveryOptimizer.Command;

public interface IDeliveryOptimizerCommand
{
    MemoryStream Execute(IFormFile file);
}