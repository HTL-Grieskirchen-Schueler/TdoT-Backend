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
            var registrations = service.GetRegistrations();
            return service.GetTrialdays().Where(t =>
            {
                var participants = registrations.Where(r => r.Date == t.Date).Count();
                return participants < t.MaxParticipants;
            }).Select(x => x.Date).ToList();
        }

        [HttpPost("trialdays/registration")]
        public IActionResult PostRegistration(RegistrationDto registration)
        {
            var maxParticipants = service.GetTrialdays().First(t => t.Date == registration.Date).MaxParticipants;
            var participants = service.GetRegistrations().Where(r => r.Date == registration.Date).Count();

            if (participants > maxParticipants)
            {
                return Problem("There already are too many participants!");
            }
            service.PostRegistration(registration);
            return Ok();
        }
    }
}
