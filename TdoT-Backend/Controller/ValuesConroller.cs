using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Xml.Linq;
using TdoT_Backend.Dtos;
using TdoT_Backend.Services;

namespace TdoT_Backend.Controller
{
    [ApiController]
    public class ValuesController(DataService service) : ControllerBase
    {
        [HttpGet("navigation/floorsvg")]
        public IActionResult GetFloorPlan(int floor)
        {
            if (floor != 0 && floor != 1)
            {
                return NotFound();
            }
            return File(service.GetFloorPlan(floor), contentType: "image/svg+xml");
        }

        [HttpGet("navigation/nodes")]
        public NodeDto[] GetNodes()
        {
            return service.GetNodes();
        }

        [HttpGet("navigation/activities")]
        public ActivityDto[] GetActivities()
        {
            return service.GetActivities();
        }

        [HttpGet("text/info")]
        public string GetInfoText()
        {
            return service.GetText("SchnupperTagAnmeldung");
        }

        [HttpGet("trialdays")]
        public List<DateOnly> GetTrialdays()
        {
            return service.GetTrialdays().Select(x => x.Date).ToList();
        }

        [HttpPost("trialdays/registration")]
        public void PostRegistration(RegistrationDto registration)
        {
            service.PostRegistration(registration);
        }
    }
}
