using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtMicroservice.Controllers;

// Q3: role-based authorization — only "Admin" role allowed
[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    [HttpGet("dashboard")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetAdminDashboard() => Ok("Welcome to the admin dashboard.");
}
