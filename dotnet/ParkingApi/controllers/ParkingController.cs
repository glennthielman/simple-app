using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("v2/parkings")]
public class ParkingController : ControllerBase
{
    private readonly IParkingService _parkingService;

    public ParkingController(IParkingService parkingService)
    {
        _parkingService = parkingService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var json = await _parkingService.GetParkingsJsonAsync();

        // Return raw JSON
        return Content(json, "application/json");
    }
}