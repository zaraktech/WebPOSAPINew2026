using System.Net.Http.Json;
using Shared.Models;

namespace WebPOS.Services
{
    public class StoreService
    {
        private readonly HttpClient _httpClient;

        public StoreService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<TblStore>> GetStores()
        {
            return await _httpClient.GetFromJsonAsync<List<TblStore>>("api/Store");
        }

        public async Task<TblStore> GetStore(int id)
        {
            return await _httpClient.GetFromJsonAsync<TblStore>($"api/Store /{id}");
        }

        public async Task AddStore(TblStore store)
        {
            await _httpClient.PostAsJsonAsync("api/Store", store);
        }

        public async Task UpdateStore(TblStore store)
        {
            await _httpClient.PutAsJsonAsync($"api/Store/{store.StoreID}", store);
        }

        public async Task DeleteStore(int id)
        {
            await _httpClient.DeleteAsync($"api/Store/{id}");
        }
    }
}
