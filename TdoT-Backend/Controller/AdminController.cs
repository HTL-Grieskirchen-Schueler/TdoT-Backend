using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TdoT_Backend.Services;

namespace TdoT_Backend.Controller;

[Authorize(AuthenticationSchemes = "AdminScheme")]
[ApiController]
public class AdminController(AdminService service) : ControllerBase
{
    [HttpGet("files")]
    public IActionResult GetFiles()
    {
        return Ok(service.GetFiles());
    }
}