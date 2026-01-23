using System.Net.Http.Json;
using WebPOS.Models;

namespace WebPOS.Services
{
    public class SupplierService
    {
        private readonly HttpClient _httpClient;

        public SupplierService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Supplier>> GetSuppliers()
        {
            return await _httpClient.GetFromJsonAsync<List<Supplier>>("api/suppliers");
        }

        public async Task<Supplier> GetSupplier(int id)
        {
            return await _httpClient.GetFromJsonAsync<Supplier>($"api/suppliers/{id}");
        }

        public async Task<bool> AddSupplier(Supplier supplier)
        {
            var response = await _httpClient.PostAsJsonAsync("api/suppliers", supplier);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Failed to add Supplier: {errorContent}");

                return false;
            }
        }

        public async Task<bool> UpdateSupplier(Supplier supplier)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/suppliers/{supplier.SupplierId}", supplier);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Failed to add Supplier: {errorContent}");

                return false;
            }
        }

        public async Task DeleteSupplier(int id)
        {
            await _httpClient.DeleteAsync($"api/suppliers/{id}");
        }
    }
}
