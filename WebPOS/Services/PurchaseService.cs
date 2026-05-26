using System.Net.Http.Json;
using WebPOS.Models;

namespace WebPOS.Services
{
    public class PurchaseService
    {
        private readonly HttpClient _http;

        public PurchaseService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<PurchaseViewModel>> GetPurchases()
        {
            return await _http.GetFromJsonAsync<List<PurchaseViewModel>>("api/purchases");
        }

        public async Task<PurchaseViewModel> GetPurchase(int id)
        {
            return await _http.GetFromJsonAsync<PurchaseViewModel>($"api/purchases/{id}");
        }

        public async Task<PurchaseViewModel> GetBarcodePurchase(int barcdoe)
        {
            return await _http.GetFromJsonAsync<PurchaseViewModel>($"api/purchases/GetBarcode/{barcdoe}");
        }

        public async Task AddPurchase(PurchaseViewModel purchase)
        {
            var response = await _http.PostAsJsonAsync("api/purchases", purchase);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception($"API failed to save: {response.StatusCode} - {error}");
            }
        }

        public async Task UpdatePurchase(PurchaseViewModel purchase) =>
            await _http.PutAsJsonAsync($"api/purchases/{purchase.Id}", purchase);




        public async Task DeletePurchase(int id) =>
            await _http.DeleteAsync($"api/purchases/{id}");





    }
}
