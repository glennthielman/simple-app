// Services/ParkingService.cs
using System.IO;

public class ParkingService : IParkingService
{
    private readonly string _filePath;

    public ParkingService(IWebHostEnvironment env)
    {
        _filePath = Path.Combine(env.ContentRootPath, "data", "parkings.json");
    }

    public async Task<string> GetParkingsJsonAsync()
    {
        if (!File.Exists(_filePath))
        {
            throw new FileNotFoundException("JSON file not found");
        }

        return await File.ReadAllTextAsync(_filePath);
    }
}