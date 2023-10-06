using DroneDelivery.Domain.Models;

namespace DroneDelivery.Application.Components.DeliveryOptimizer.Core;

public static class GenerateOutput
{
    public static void Execute(List<Delivery> optimizedDeliveries, List<Drone> drones)
    {
        var groupedDeliveries = optimizedDeliveries.GroupBy(d => d.AssignedDrone.Name).OrderBy(g => g.Key);

        var result = "";

        foreach (var drone in drones)
        {
            result += $"[{drone.Name}]\n";
            var tripCount = 1;

            var deliveriesByDrone = optimizedDeliveries.Where(x => x.AssignedDrone.Name == drone.Name).ToList();

            foreach (var delivery in deliveriesByDrone)
            {
                result += $"Trip #{tripCount}\n";
                result += string.Join(", ", delivery.Locations.Select(l => $"[{l.Address}]"));
                result += "\n";
                tripCount++;
            }

            result += "\n";
        }

        File.WriteAllText("output.txt", result);
    }
}