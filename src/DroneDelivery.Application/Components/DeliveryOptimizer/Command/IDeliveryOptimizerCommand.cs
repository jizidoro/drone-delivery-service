using DroneDelivery.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace DroneDelivery.Application.Components.DeliveryOptimizer.Command;

public interface IDeliveryOptimizerCommand
{
    List<Delivery> Execute(IFormFile file);
}