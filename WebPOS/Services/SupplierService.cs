using System.Net.Http.Json;
using Shared.Models;
using WebPOS.Pages;

namespace WebPOS.Services
{
    public class SupplierService
    {
        private readonly HttpClient _httpClient;

        public SupplierService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<SupplierMaster>> GetSuppliers()
        {
            return await _httpClient.GetFromJsonAsync<List<SupplierMaster>>("api/SupplierMaster");
        }

        public async Task<SupplierMaster> GetSupplier(int id)
        {
            return await _httpClient.GetFromJsonAsync<SupplierMaster>($"api/SupplierMaster/{id}");
        }

        public async Task<bool> AddSupplier(SupplierMaster supplier)
        {
            var response = await _httpClient.PostAsJsonAsync("api/SupplierMaster", supplier);
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

        public async Task<bool> UpdateSupplier(SupplierMaster supplier)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/SupplierMaster/{supplier.SupplierId}", supplier);
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
