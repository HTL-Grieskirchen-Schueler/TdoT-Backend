using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.Json;
using System.Text.Json.Nodes;
using TdoT_Backend.Dtos;

namespace TdoT_Backend.Services
{
    public class DataService()
    {
        private readonly string _basePath = "Data/";

        public void PostRegistration(RegistrationDto registration)
        {
            string fileName = _basePath + "registrations.json";
            using FileStream openStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            var json = JsonSerializer.Deserialize<RegistrationDto[]>(openStream) ?? [];
            
            string registrationJson = JsonSerializer.Serialize(json.Append(registration));
            openStream.Write(System.Text.Encoding.UTF8.GetBytes(registrationJson));
        }

        public TrialDayDto[] GetTrialdays()
        {
            using FileStream openStream = File.OpenRead(_basePath + "trialday.json");

            return JsonSerializer.Deserialize<TrialDayDto[]>(openStream) ?? throw new FileNotFoundException();
        }

        public ActivityDto[] GetActivities()
        {
            using FileStream openStream = File.OpenRead(_basePath + "activities.json");

            return JsonSerializer.Deserialize<ActivityDto[]>(openStream) ?? throw new FileNotFoundException();
        }

        public NodeDto[] GetNodes()
        {
            using FileStream openStream = File.OpenRead(_basePath + "nodes.json");

            return JsonSerializer.Deserialize<NodeDto[]>(openStream) ?? throw new FileNotFoundException();
        }

        public byte[] GetFloorPlan(int floor)   
        {
            var fileName = floor + ".svg";
            var fileBytes = File.ReadAllBytes(_basePath + "floorPlans/" + fileName);
            return fileBytes;
        }

        public string GetText(string name)
        {
            return File.ReadAllText(_basePath + "text/" + name + ".txt");
        }
    }
}
