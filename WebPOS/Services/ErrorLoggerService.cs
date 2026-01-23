using System.Net.Http.Json;

namespace WebPOS.Services
{
    // Services/ErrorLoggerService.cs
    public class ErrorLoggerService
    {
        private readonly HttpClient _http;

        public ErrorLoggerService(HttpClient http)
        {
            _http = http;
        }

        public async Task LogAsync(string errorMessage)
        {
            try
            {
                await _http.PostAsJsonAsync("api/log", errorMessage);
            }
            catch
            {
                // Don't crash UI if logging fails
            }
        }
    }

}
