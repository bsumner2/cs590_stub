using BulletinBoard_Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace BulletinBoard_Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TrafficTestingController : ControllerBase {
    private readonly ITrafficTestingService _testingService;

    public TrafficTestingController(ITrafficTestingService testingService) {
        _testingService = testingService;
    }

    [HttpGet("Sieve")]
    public async Task<IActionResult> Sieve(int limit) {
        return Ok(await _testingService.SeiveOfEratosthenese(limit));
        
    }

    
}