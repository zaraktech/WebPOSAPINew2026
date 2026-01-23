using System.Net.Http.Json;
using WebPOS.Models;
using WebPOS.ViewModels;
using static System.Net.WebRequestMethods;

namespace WebPOS.Services
{
    public class OffersService
    {
        private readonly HttpClient _http;

        public OffersService(HttpClient httpClient)
        {
                
            _http = httpClient;
        }

        public async Task<List<ProductLookup>> GetProductLookups()
        {
            return await _http.GetFromJsonAsync<List<ProductLookup>>("api/offers/productlookups");
        }
        public async Task<List<OfferViewModel>> GetOffers()
        {
            return await _http.GetFromJsonAsync<List<OfferViewModel>>("api/offers");
        }

        public async Task SaveOffer(OfferViewModel offer)
        {
            await _http.PostAsJsonAsync("api/offers", offer);
        }

        public async Task DeleteOffer(int id)
        {
            await _http.DeleteAsync($"api/offers/{id}");
        }

        public async Task UpdateStatus(int id, bool status)
        {
            await _http.PutAsync($"api/offers/{id}/status?isActive={status}", null);
        }

    }
}
