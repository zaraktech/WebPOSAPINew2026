using System.Net.Http.Json;
using WebPOS.ViewModels;

namespace WebPOS.Services
{
    public class StockReportService
    {

        private readonly HttpClient _http;

        public StockReportService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<StockReportViewModel>> GetStockReportAsync(int? shopId = null)
        {
            // __define-ocg__ stock report service call

            var result = await _http.GetFromJsonAsync<List<StockReportViewModel>>("api/StockReport")
                   ?? new List<StockReportViewModel>();



            return result;
        }
    }
}
