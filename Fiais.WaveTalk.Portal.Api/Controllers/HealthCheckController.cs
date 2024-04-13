using Fiais.WaveTalk.Portal.Api.Middlewares;
using Microsoft.AspNetCore.Mvc;

namespace Fiais.WaveTalk.Portal.Api.Controllers;

[ApiController]
[Route("health-check")]
public class HealthCheckController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => new ApiResult(null, $"Health Check - {DateTime.Now}");
}