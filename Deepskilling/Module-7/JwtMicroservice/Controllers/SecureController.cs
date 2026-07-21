using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtMicroservice.Controllers;

// Q2: endpoint secured with [Authorize] — requires valid Bearer token
[ApiController]
[Route("api/[controller]")]
public class SecureController : ControllerBase
{
    [HttpGet("data")]
    [Authorize]
    public IActionResult GetSecureData() => Ok("This is protected data.");
}
