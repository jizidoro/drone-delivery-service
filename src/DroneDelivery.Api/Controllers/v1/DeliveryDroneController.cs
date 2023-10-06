using DroneDelivery.API.Modules.Common;
using DroneDelivery.Application.Components.DeliveryOptimizer.Command;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace DroneDelivery.API.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class DeliveryDroneController : ControllerBase
{
    private readonly IDeliveryOptimizerCommand _deliveryOptimizerCommand;
    private readonly ILogger<DeliveryDroneController> _logger;

    public DeliveryDroneController(ILogger<DeliveryDroneController> logger,
        IDeliveryOptimizerCommand deliveryOptimizerCommand)
    {
        _logger = logger;
        _deliveryOptimizerCommand = deliveryOptimizerCommand;
    }

    [HttpPost("delivery-optimizer")]
    [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Post))]
    public IActionResult DownloadDeliveryReport(IFormFile file)
    {
        try
        {
            var result = _deliveryOptimizerCommand.Execute(file);

            return File(result, "text/plain", "deliveryReport.txt");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                ex);
        }
    }
}