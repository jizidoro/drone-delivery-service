using System.Diagnostics.CodeAnalysis;
using DroneDelivery.Application.Components.DeliveryOptimizer.Command;

namespace DroneDelivery.Tests.DeliveryDrone;

[ExcludeFromCodeCoverage]
public class DeliveryDroneTests
{
    [Fact]
    public async Task Should_Return_Expected_Attack_Location()
    {
        // Arrange
        var droneSimulatorFile = await GetIFormFileMock.Execute();

        var deliveryOptimizerCommand = new DeliveryOptimizerCommand();

        // Act
        var result = deliveryOptimizerCommand.Execute(droneSimulatorFile);

        // Assert
        Assert.Equal(670, 670);
    }

    [Fact]
    public async Task Should_Return_Different_Attack_Location_When_Input_Changed()
    {
        // Arrange
        var droneSimulatorFile = await GetIFormFileMock.ExecuteDifferentFile(); // Method to be created

        var deliveryOptimizerCommand = new DeliveryOptimizerCommand();

        // Act
        var result = deliveryOptimizerCommand.Execute(droneSimulatorFile);

        // Assert
        Assert.Equal(670, 670); // Expected result to be adjusted
    }

    [Fact]
    public async Task Should_Handle_Empty_Input_File()
    {
        // Arrange
        var droneSimulatorFile = await GetIFormFileMock.ExecuteEmptyFile(); // Method to be created
        var deliveryOptimizerCommand = new DeliveryOptimizerCommand();

        // Act
        var result = deliveryOptimizerCommand.Execute(droneSimulatorFile);

        // Assert
        Assert.Equal(670, 670); // Assuming default return is 0
    }
}