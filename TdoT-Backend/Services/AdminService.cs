using TdoT_Backend.Dtos;

namespace TdoT_Backend.Services;

public class AdminService
{
    public byte[] GetFile(string fileName)
    {
        fileName = fileName.Trim('/');
        fileName = fileName.Trim('\\');
        var path = Path.Combine("Data", fileName);
        if (!File.Exists(path) || path.Contains("..") || fileName.Contains("~"))
        {
            return [];
        }
        return File.ReadAllBytes(path);
    }

    public bool PostFile(Stream file, string fileName)
    {
        fileName = fileName.Trim('/');
        fileName = fileName.Trim('\\');        
        var path = Path.Combine("Data", fileName);

        if (!File.Exists(path) || path.Contains("..") || path.Contains("~"))
        {
            file.Close();
            return false;
        }

        var currentFile = File.OpenWrite(path);
        currentFile.SetLength(0);
        file.CopyTo(currentFile);
        currentFile.Close();
        file.Close();
        return true;
    }
    
    public List<FileDto> GetFiles()
    {
        return
        [
            new FileDto()
            {
                Name = "registration.json",
                Description = "Text für die Schulanmeldung",
                GetUrl = $"/files?fileName=text/registration.json",
                PostUrl = $"/files?fileName=text/registration.json",
            },
            new FileDto()
            {
                Name = "SchnupperTagAnmeldung.txt",
                Description = "Text für den Schnuppertag",
                GetUrl = $"/files?fileName=text/SchnupperTagAnmeldung.txt",
                PostUrl = $"/files?fileName=text/SchnupperTagAnmeldung.txt",
            },
            new FileDto()
            {
                Name = "activities.json",
                Description = "Aktivitäten währen dem Schnuppertag",
                GetUrl = $"/files?fileName=activities.json",
                PostUrl = $"/files?fileName=activities.json",
            },
            new FileDto()
            {
                Name = "nodes.json",
                Description = "Knotenpunkte für die Navigation am Schnuppertag",
                GetUrl = $"/files?fileName=nodes.json",
                PostUrl = $"/files?fileName=nodes.json",
            },
            new FileDto()
            {
                Name = "registrations.json",
                Description = "Liste an Schnuppertaganmeldungen",
                GetUrl = $"/files?fileName=registrations.json",
                PostUrl = $"/files?fileName=registrations.json",
            },
            new FileDto()
            {
                Name = "trialdays.json",
                Description = "Liste an Schnuppertage",
                GetUrl = $"/files?fileName=trialdays.json",
                PostUrl = $"/files?fileName=trialdays.json",
            },
        ];
    }
}