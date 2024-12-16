using TdoT_Backend.Dtos;

namespace TdoT_Backend.Services;

public class AdminService
{
    public List<FileDto> GetFiles()
    {
        return Directory.GetFileSystemEntries("Data")
            .SelectMany(f => Directory.Exists(f) ? Directory.GetFiles(f) : [f])
            .Select(f => new FileDto
            {
                Name = Path.GetFileName(f),
                Path = $"/file?name={Path.GetFileName(f)}"
            }).ToList();
    }
}