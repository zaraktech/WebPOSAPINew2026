using System.Net.Http.Json;
using Shared.Models;

namespace WebPOS.Services
{
    public class PurchaseService
    {
        private readonly HttpClient _http;

        public PurchaseService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Purchase>> GetPurchases()
        {
            return await _http.GetFromJsonAsync<List<Purchase>>("api/purchase");
        }

        public async Task<Purchase> GetPurchase(int id)
        {
            return await _http.GetFromJsonAsync<Purchase>($"api/purchase/{id}");
        }

        public async Task<Purchase> GetBarcodePurchase(int barcdoe)
        {
            return await _http.GetFromJsonAsync<Purchase>($"api/purchase/GetBarcode/{barcdoe}");
        }

        public async Task AddPurchase(Purchase purchase)
        {
            var response = await _http.PostAsJsonAsync("api/purchase", purchase);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"API failed to save: {response.StatusCode} - {error}");
            }
        }

        public async Task UpdatePurchase(Purchase purchase) =>
            await _http.PutAsJsonAsync($"api/purchase/{purchase.Purid}", purchase);




        public async Task DeletePurchase(int id) =>
            await _http.DeleteAsync($"api/purchases/{id}");





    }
}
