using DroneDelivery.Domain.Models;

namespace DroneDelivery.Application.Components.DeliveryOptimizer.Core;

public static class CalculateDPTable
{
    public static bool[,] Execute(List<Location> weights, int target)
    {
        // Initialize the DP table
        var dp = new bool[weights.Count + 1, target + 1];

        // Base case: there's always a subset with sum 0
        dp[0, 0] = true;

        // Iterate through all items and all weights
        for (var itemIndex = 1; itemIndex <= weights.Count; itemIndex++)
        {
            for (var weightIndex = 0; weightIndex <= target; weightIndex++)
            {
                var currentPackageWeight = weights[itemIndex - 1].PackageWeight;

                // Two possible cases:
                // 1. Without considering the current item
                // 2. Considering the current item
                var isPossibleWithoutCurrent = dp[itemIndex - 1, weightIndex];
                var isPossibleWithCurrent = currentPackageWeight <= weightIndex 
                                            && dp[itemIndex - 1, weightIndex - currentPackageWeight];

                dp[itemIndex, weightIndex] = isPossibleWithoutCurrent || isPossibleWithCurrent;
            }
        }

        return dp;
    }
}