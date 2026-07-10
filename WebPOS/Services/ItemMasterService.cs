using Shared.Models;
using System.Net.Http.Json;
namespace WebPOS.Services
{
    public class ItemMasterService
    {
        private readonly HttpClient _httpClient;

        public ItemMasterService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<ItemMaster>> GetProducts()
        {
            var response= await _httpClient.GetFromJsonAsync<List<ItemMaster>>(
                "api/ItemMaster") ?? new List<ItemMaster>();

            return response;
        }

        public async Task<ItemMaster> GetProduct(int id)
        {
            return await _httpClient.GetFromJsonAsync<ItemMaster>($"api/ItemMaster/{id}") ?? new ItemMaster();
        }

        public async Task AddProduct(ItemMaster Item)
        {

            await _httpClient.PostAsJsonAsync("api/ItemMaster", Item);
        }

        public async Task UpdateProduct(ItemMaster Item)
        {
            await _httpClient.PutAsJsonAsync($"api/ItemMaster/{Item.ItemId}", Item);
        }

        public async Task DeleteProduct(int id)
        {
            await _httpClient.DeleteAsync($"api/ItemMaster/{id}");
        }
    }
}
