using DroneDelivery.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace DroneDelivery.Application.Components.DeliveryOptimizer.Core;

public static class ProcessFile
{
    public static (List<Drone> Drones, List<Location> Locations) Execute(IFormFile file)
    {
        var drones = new List<Drone>();
        var locations = new List<Location>();

        using (var reader = new StreamReader(file.OpenReadStream()))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var values = line.Split(new[] {"], ["}, StringSplitOptions.None)
                    .Select(val => val.Trim('[', ' ', ']'))
                    .ToList();

                for (var i = 0; i < values.Count; i += 2)
                {
                    if (line.Contains("Drone"))
                    {
                        drones.Add(new Drone
                        {
                            Name = values[i],
                            MaxWeight = int.Parse(values[i + 1])
                        });
                    }
                    else
                    {
                        locations.Add(new Location
                        {
                            Address = values[i],
                            PackageWeight = int.Parse(values[i + 1])
                        });
                    }
                }
            }
        }

        return (drones, locations);
    }
}