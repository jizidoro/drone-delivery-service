using DroneDelivery.Domain.Models;

namespace DroneDelivery.Application.Components.DeliveryOptimizer.Core;

public static class CalculateDPTable
{
    public static bool[,] Execute(List<Location> weights, int target)
    {
        var dp = new bool[weights.Count + 1, target + 1];
        dp[0, 0] = true;

        for (var i = 1; i <= weights.Count; i++)
        {
            for (var j = 0; j <= target; j++)
            {
                dp[i, j] = dp[i - 1, j] ||
                           (weights[i - 1].PackageWeight <= j && dp[i - 1, j - weights[i - 1].PackageWeight]);
            }
        }

        return dp;
    }
}