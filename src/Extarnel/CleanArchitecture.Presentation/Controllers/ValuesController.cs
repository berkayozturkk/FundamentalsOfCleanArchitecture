using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ValuesController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("ValuesController Api Connection Successful.");
    }
}
