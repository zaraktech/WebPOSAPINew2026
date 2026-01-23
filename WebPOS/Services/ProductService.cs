using System.Net.Http.Json;
using WebPOS.Models;
namespace WebPOS.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _httpClient.GetFromJsonAsync<List<Product>>("api/Products");
        }

        public async Task<Product> GetProduct(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"api/Products/{id}");
        }

        public async Task AddProduct(Product Item)
        {

            await _httpClient.PostAsJsonAsync("api/Products", Item);
        }

        public async Task UpdateProduct(Product Item)
        {
            await _httpClient.PutAsJsonAsync($"api/Products/{Item.ProductId}", Item);
        }

        public async Task DeleteProduct(int id)
        {
            await _httpClient.DeleteAsync($"api/Products/{id}");
        }
    }
}
