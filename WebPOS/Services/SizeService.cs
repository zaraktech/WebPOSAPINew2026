using Shared.Models;
using System.Net.Http.Json;


namespace WebPOS.Services
{
    public class SizeService
    {
        private readonly HttpClient _httpClient;

        public SizeService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<SizeMaster>> GetSizes()
        {
            return await _httpClient.GetFromJsonAsync<List<SizeMaster>>("api/SizeMaster");
        }

        public async Task<SizeMaster> GetSize(int id)
        {
            return await _httpClient.GetFromJsonAsync<SizeMaster>($"api/SizeMaster/{id}");
        }

        public async Task<bool> AddSize(SizeMaster item)
        {
            var response = await _httpClient.PostAsJsonAsync("api/SizeMaster", item);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Failed to add Size: {errorContent}");
                return false;
            }
        }

        public async Task<bool> UpdateSize(SizeMaster itemsize)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/SizeMaster/{itemsize.SizId}", itemsize);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Failed to add Size: {errorContent}");
                return false;
            }
        }

        public async Task DeleteSize(int id)
        {
            await _httpClient.DeleteAsync($"api/SizeMaster/{id}");
        }
    }
}
