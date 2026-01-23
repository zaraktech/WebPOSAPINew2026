using System.Net.Http.Json;
using WebPOS.Models;

namespace WebPOS.Services
{
    public class ShopNamesService
    {
        private readonly HttpClient _httpClient;

        public ShopNamesService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<ShopNames>> GetShopNames()
        {
            return await _httpClient.GetFromJsonAsync<List<ShopNames>>("api/ShopNames");
        }

        public async Task<ShopNames> GetShopName(int id)
        {
            return await _httpClient.GetFromJsonAsync<ShopNames>($"api/ShopNames/{id}");
        }

        public async Task AddShopName(ShopNames shopName)
        {
            await _httpClient.PostAsJsonAsync("api/ShopNames", shopName);
        }

        public async Task UpdateShopName(ShopNames shopName)
        {
            await _httpClient.PutAsJsonAsync($"api/ShopNames/{shopName.ShopNamesId}", shopName);
        }

        public async Task DeleteShopName(int id)
        {
            await _httpClient.DeleteAsync($"api/ShopNames/{id}");
        }
    }
}
