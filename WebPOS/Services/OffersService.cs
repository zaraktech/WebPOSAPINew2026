using System.Net.Http.Json;
using WebPOS.DTO;
using WebPOS.ViewModels;


namespace WebPOS.Services
{
    public class OffersService
    {
        private readonly HttpClient _http;

        public OffersService(HttpClient httpClient)
        {
            _http = httpClient;
        }

        //public async Task<List<ProductLookup>> GetProductLookups()
        //{
        //    return await _http.GetFromJsonAsync<List<ProductLookup>>("api/offers/productlookups")
        //           ?? new List<ProductLookup>();
        //}

        public async Task<List<OfferViewModel>> GetOffers()
        {
            return await _http.GetFromJsonAsync<List<OfferViewModel>>("api/purchases")
                   ?? new List<OfferViewModel>();
        }


        public async Task<bool> UpdateBarcodeAsync(int barcode, decimal newPrice)
        {
            var response = await _http.PutAsJsonAsync(
                $"/api/Purchases/UpdateBarcode/{barcode}",
                new UpdateSalePriceDTO { SalePrice = newPrice });

            return response.IsSuccessStatusCode;
        }




    }
}
