using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("2.0")]
public class FleetV2Controller : ControllerBase
{
    [HttpPost]
    public void Post()
    {
        Console.WriteLine("Versão da API: 2.0");
    }
}