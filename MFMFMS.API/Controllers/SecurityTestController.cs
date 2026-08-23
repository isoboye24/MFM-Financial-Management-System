using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MFMFMS.API.Controllers;

[ApiController]
[Route("api/security-test")]
public class SecurityTestController : ControllerBase
{
    [AllowAnonymous]
    [HttpGet("claims")]
    public IActionResult GetClaims()
    {
        return Ok(User.Claims.Select(c => new
        {
            c.Type,
            c.Value
        }));
    }
}