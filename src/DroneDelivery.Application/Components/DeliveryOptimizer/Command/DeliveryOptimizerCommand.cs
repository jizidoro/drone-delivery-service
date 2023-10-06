using DroneDelivery.Application.Components.DeliveryOptimizer.Core;
using DroneDelivery.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace DroneDelivery.Application.Components.DeliveryOptimizer.Command;

public class DeliveryOptimizerCommand : IDeliveryOptimizerCommand
{
    public List<Delivery> Execute(IFormFile file)
    {
        var processedFile = ProcessFile.Execute(file);

        var optimizedDeliveries = GetMaxCombination.Execute(processedFile.Drones, processedFile.Locations);

        GenerateOutput.Execute(optimizedDeliveries, processedFile.Drones);

        return optimizedDeliveries;
    }
}