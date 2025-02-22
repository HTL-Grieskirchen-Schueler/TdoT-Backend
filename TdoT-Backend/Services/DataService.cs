using System.Text.Json;
using TdoT_Backend.Dtos;

namespace TdoT_Backend.Services;
public class DataService()
{
    private readonly string _basePath = AppContext.BaseDirectory + "Data/";
    private readonly JsonSerializerOptions options = new()
    {
        ReadCommentHandling = JsonCommentHandling.Skip,
        AllowTrailingCommas = true,
        PropertyNameCaseInsensitive = true,
    };

    public List<RegistrationDto> GetRegistrations()
    {
        string fileName = _basePath + "registrations.json";

        if (!File.Exists(fileName))
        {
            File.WriteAllText(fileName, "[]");
        }

        string existingJson = File.ReadAllText(fileName);

        var existingRegistrations = JsonSerializer.Deserialize<RegistrationDto[]>(existingJson, options) ?? [];
        return [.. existingRegistrations];
    }

    public void PostRegistration(RegistrationDto registration)
    {
        string fileName = _basePath + "registrations.json";

        var existingRegistrations = GetRegistrations();
        var updatedRegistrations = existingRegistrations.Append(registration);

        string registrationJson = JsonSerializer.Serialize(updatedRegistrations, options);
        File.WriteAllText(fileName, registrationJson);
    }

    public TrialDayDto[] GetTrialdays()
    {
        using FileStream openStream = File.OpenRead(_basePath + "trialdays.json");

        return JsonSerializer.Deserialize<TrialDayDto[]>(openStream, options) ?? throw new FileNotFoundException();
    }

    public ActivityDto[] GetActivities()
    {
        using FileStream openStream = File.OpenRead(_basePath + "activities.json");

        return JsonSerializer.Deserialize<ActivityDto[]>(openStream, options) ?? throw new FileNotFoundException();
    }

    public NodeDto[] GetNodes()
    {
        using FileStream openStream = File.OpenRead(_basePath + "nodes.json");

        return JsonSerializer.Deserialize<NodeDto[]>(openStream, options) ?? throw new FileNotFoundException();
    }

    public byte[] GetFloorPlan(int floor)
    {
        var fileName = floor + ".svg";
        var fileBytes = File.ReadAllBytes(_basePath + "floorPlans/" + fileName);
        return fileBytes;
    }

    public string GetText(string name)
    {
        var text = File.ReadAllText(_basePath + "text/" + name);

        var placeholder = GetPlaceholders();
        if (placeholder != null)
        {
            foreach (var placeholderDto in placeholder)
            {
                text = text.Replace(placeholderDto.Key, placeholderDto.Value);
            }
        }

        return text;
    }

    public PlaceholderDto[]? GetPlaceholders()
    {
        using var openStream = File.OpenRead(_basePath + "placeholder.json");

        return JsonSerializer.Deserialize<PlaceholderDto[]>(openStream, options);
    }
}
