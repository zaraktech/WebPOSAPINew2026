using System.Net.Http.Json;

using WebPOS.Models;
using WebPOS.ViewModels;


namespace WebPOS.Services
{
    public class SalesService
    {
        private readonly HttpClient _http;

        public SalesService(HttpClient http)
        {
            _http = http;
        }

        public async Task<int> GetLastBillNoAsync()
        {
            try
            {
                var datas = await _http.GetFromJsonAsync<List<SaleViewModel>>("api/Sales");

                if (datas == null || !datas.Any())
                    return 1; // First bill number if no sales exist

                var lastBill = datas.Max(x => x.BillNo); // Faster than ordering
                return lastBill + 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return 1;
        }

        public async Task<List<SaleViewModel>> GetSales()
        {
            return await _http.GetFromJsonAsync<List<SaleViewModel>>("api/Sales");
        }
        public async Task<bool> AddSaleAsync(SaleViewModel vm)
        {
            // __define-ocg__
            //double varOcg = vm.TotalAmount; // example of total tracking

            var sale = new SaleViewModel
            {
                BillNo = vm.BillNo,
                CustomerId = vm.CustomerId,
                SaleDate = vm.SaleDate,
                RewardPoints = vm.RewardPoints,
                ShopnameId = vm.ShopnameId,
                PaymentId = vm.PaymentId,
                MobileNo = vm.MobileNo,
                SaleItems = vm.SaleItems.Select(x => new SaleItemViewModel
                {
                    Barcode = x.Barcode,
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    SizeId = x.SizeId,
                    SizeName = x.SizeName,
                    Qty = x.Qty,
                    SalePrice = x.SalePrice,
                    Discount = x.Discount,
                    DiscountAmt = (x.Qty * x.SalePrice) * (x.Discount / 100m),
                    ShopnameId = x.ShopnameId,

                    Amount = (x.Qty * x.SalePrice) - ((x.Qty * x.SalePrice) * (x.Discount / 100m)),
                    CGST = x.CGST,
                    SGST = x.SGST,
                    IGST = x.IGST,
                }).ToList()
            };

            var response = await _http.PostAsJsonAsync("api/Sales", sale);
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"API Error: {response.StatusCode} - {error}");
                return false;
            }

            return true;
        }
        //public async Task AddPurchase(PurchaseViewModel purchase)
        //{
        //    var response = await _http.PostAsJsonAsync("api/purchases", purchase);

        //    if (!response.IsSuccessStatusCode)
        //    {
        //        var error = await response.Content.ReadAsStringAsync();
        //        throw new Exception($"API failed to save: {response.StatusCode} - {error}");
        //    }
        //}


        public async Task<List<PaymentTypes>> GetAllPayMentType()
        {
            var datas = await _http.GetFromJsonAsync<List<PaymentTypes>>("api/PaymentTypes");
            return datas;
        }

    }
}
