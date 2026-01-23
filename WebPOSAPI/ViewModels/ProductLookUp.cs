namespace WebAPI.ViewModels
{
    public class ProductLookUp
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }= string.Empty;
        public decimal CostPrice { get; set; }
        public int Barcode { get; set; }
    }
}
