using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ErrorLoggin : ControllerBase
{
    private readonly ILogger<ErrorLoggin> _logger;

    public ErrorLoggin(ILogger<ErrorLoggin> logger) // ✅ Inject logger
    {
        _logger = logger;
    }

    [HttpPost("log")]
    public IActionResult LogError([FromBody] string errorMessage)
    {
        _logger.LogError("Client-side error: {Error}", errorMessage); // ✅ Now works
        return Ok();
    }
}
