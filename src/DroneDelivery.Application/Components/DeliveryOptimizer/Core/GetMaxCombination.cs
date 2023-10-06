﻿using DroneDelivery.Domain.Models;
using Microsoft.IdentityModel.Tokens;

namespace DroneDelivery.Application.Components.DeliveryOptimizer.Core;

public static class GetMaxCombination
{
    public static List<Delivery> Execute(List<Drone> drones, List<Location> locations)
    {
        var optimizedDeliveries = new List<Delivery>();

        var target = drones.Max(x => x.MaxWeight);

        while (!locations.IsNullOrEmpty())
        {
            var dp = CalculateDPTable.Execute(locations, target);

            var combination = ExtractCombination.Execute(locations, dp, target);

            var combinationWeight = combination.Sum(x => x.PackageWeight);

            var assignedDrone = drones
                .Where(n => n.MaxWeight >= combinationWeight)
                .Min();


            optimizedDeliveries.Add(new
                Delivery
                {
                    Locations = combination,
                    AssignedDrone = assignedDrone
                });

            foreach (var item in combination)
            {
                locations.Remove(item);
            }
        }

        return optimizedDeliveries;
    }
}