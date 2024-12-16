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
            var file = service.GetFile(fileName);
            if (file.Length == 0)
            {
                return NotFound();
            }
            return File(file, "text/plain", Path.GetFileName(fileName));
        }
        return Ok(service.GetFiles());
    }

    [HttpPost("files")]
    public void PostFiles(IFormFile file, string? fileName)
    {
        service.PostFile(file.OpenReadStream(), fileName ?? file.FileName);
    }
}