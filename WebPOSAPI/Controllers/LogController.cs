using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class LogController : ControllerBase
{
    private readonly ILogger<LogController> _logger;

    public LogController(ILogger<LogController> logger)
    {
        _logger = logger;
    }

    [HttpPost("log")]
    public IActionResult LogError([FromBody] string errorMessage)
    {
        _logger.LogError("Client-side error: {Error}", errorMessage); // ✅ logged to file
        return Ok(new { status = "logged" });
    }
}
