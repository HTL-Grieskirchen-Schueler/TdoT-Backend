using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TdoT_Backend.Services;

namespace TdoT_Backend.Controller;

[Authorize(AuthenticationSchemes = "AdminScheme")]
[ApiController]
public class AdminController(AdminService service) : ControllerBase
{
    [HttpGet("files")]
    public IActionResult GetFiles(string? fileName)
    {
        if (fileName != null)
        {
            return File(service.GetFile(fileName), "text/plain", Path.GetFileName(fileName));
        }
        return Ok(service.GetFiles());
    }

    [HttpPost("files")]
    public void PostFiles(IFormFile file)
    {
        service.PostFile(file.OpenReadStream(), file.FileName);
    }
}