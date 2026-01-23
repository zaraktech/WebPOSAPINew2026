using System.Net.Http.Json;
using WebPOS.Models;

namespace WebPOS.Services
{
    public class SizeService
    {
        private readonly HttpClient _httpClient;

        public SizeService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<Sizes>> GetSizes()
        {
            return await _httpClient.GetFromJsonAsync<List<Sizes>>("api/Sizes");
        }

        public async Task<Sizes> GetSize(int id)
        {
            return await _httpClient.GetFromJsonAsync<Sizes>($"api/Sizes/{id}");
        }

        public async Task<bool> AddSize(Sizes item)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Sizes", item);
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

        public async Task<bool> UpdateSize(Sizes item)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Sizes/{item.SizeId}", item);
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
            await _httpClient.DeleteAsync($"api/Sizes/{id}");
        }
    }
}
