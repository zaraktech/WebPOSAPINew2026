using MudBlazor;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;
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



        public async Task<DataResult> GetPagedPurchases(DataManagerRequest request)
        {
            var data = await GetPurchases(); // Load all data from API

            // Searching
            if (request.Search != null && request.Search.Any())
            {
                foreach (var search in request.Search)
                {
                    var key = search.Key.ToString();
                    data = data.Where(p =>
                        (!string.IsNullOrEmpty(p.InvoiceNo) && p.InvoiceNo.Contains(key, StringComparison.OrdinalIgnoreCase)) ||
                        (!string.IsNullOrEmpty(p.SupplierName) && p.SupplierName.Contains(key, StringComparison.OrdinalIgnoreCase)) ||
                        (!string.IsNullOrEmpty(p.ShopName) && p.ShopName.Contains(key, StringComparison.OrdinalIgnoreCase)) ||
                        (!string.IsNullOrEmpty(p.BarcodeText) && p.BarcodeText.Contains(key, StringComparison.OrdinalIgnoreCase))
                    ).ToList();
                }
            }

            // Sorting
            if (request.Sorted != null && request.Sorted.Any())
            {
                foreach (var sort in request.Sorted)
                {
                    var prop = typeof(PurchaseViewModel).GetProperty(sort.Name);
                    if (prop != null)
                    {
                        data = sort.Direction == "descending"
                            ? data.OrderByDescending(x => prop.GetValue(x)).ToList()
                            : data.OrderBy(x => prop.GetValue(x)).ToList();
                    }
                }
            }

            // Paging
            var totalItems = data.Count;
            if (request.Skip != 0)
            {
                data = data.Skip(request.Skip).Take(request.Take).ToList();
            }
            else if (request.Take != 0)
            {
                data = data.Take(request.Take).ToList();
            }

            return new DataResult() { Result = data, Count = totalItems };
        }

    }
}
