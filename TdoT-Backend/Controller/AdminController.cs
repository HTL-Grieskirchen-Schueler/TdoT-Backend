using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TdoT_Backend.Dtos;
using TdoT_Backend.Services;

namespace TdoT_Backend.Controller;

[Authorize(AuthenticationSchemes = "AdminScheme")]
[ApiController]
public class AdminController(AdminService adminService, DataService dataService) : ControllerBase
{
    [HttpGet("files")]
    public IActionResult GetFiles(string? fileName)
    {
        if (fileName != null)
        {
            var file = adminService.GetFile(fileName);
            if (file.Length == 0)
            {
                return NotFound();
            }
            return File(file, "text/plain", Path.GetFileName(fileName));
        }
        return Ok(adminService.GetFiles());
    }

    [HttpPost("files")]
    public IActionResult PostFiles(IFormFile file, string? fileName)
    {
        return adminService.PostFile(file.OpenReadStream(), fileName ?? file.FileName) ? Ok() : BadRequest();
    }

    [HttpGet("placeholder")]
    public IActionResult GetPlaceholders()
    {
        return Ok(dataService.GetPlaceholders() ?? throw new FileNotFoundException());
    }

    [HttpPut("placeholder")]
    public IActionResult PutPlaceholders(PlaceholderDto[] placeholder)
    {
        return Ok(adminService.PutPlaceholders(placeholder));
    }
}