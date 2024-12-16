using TdoT_Backend.Dtos;

namespace TdoT_Backend.Services;

public class AdminService
{
    public List<FileDto> GetFiles()
    {
        return
        [
            new FileDto()
            {
                Name = "Schulanmeldungs Text",
                Description = "Text für die Schulanmeldung",
                GetUrl = $"/files?fileName=text/registration.json",
                PostUrl = $"/files?fileName=text/registration.json",
            },
            new FileDto()
            {
                Name = "Schnuppertag",
                Description = "Text für den Schnuppertag",
                GetUrl = $"/files?fileName=text/SchnupperTagAnmeldung.txt",
                PostUrl = $"/files?fileName=text/SchnupperTagAnmeldung.txt",
            },
            new FileDto()
            {
                Name = "Aktivitäten",
                Description = "Aktivitäten währen dem Schnuppertag",
                GetUrl = $"/files?fileName=activities.json",
                PostUrl = $"/files?fileName=activities.json",
            },
            new FileDto()
            {
                Name = "Knotenpunkte",
                Description = "Knotenpunkte für die Navigation am Schnuppertag",
                GetUrl = $"/files?fileName=nodes.json",
                PostUrl = $"/files?fileName=nodes.json",
            },
            new FileDto()
            {
                Name = "Schnuppertaganmeldungen",
                Description = "Liste an Schnuppertaganmeldungen",
                GetUrl = $"/files?fileName=registrations.json",
                PostUrl = $"/files?fileName=registrations.json",
            },
            new FileDto()
            {
                Name = "Schnuppertage",
                Description = "Liste an Schnuppertage",
                GetUrl = $"/files?fileName=trialdays.json",
                PostUrl = $"/files?fileName=trialdays.json",
            },
        ];
    }
}