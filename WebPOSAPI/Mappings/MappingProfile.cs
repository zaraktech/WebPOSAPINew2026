using AutoMapper;
using WebAPI.Models;
using WebAPI.Models.WebPOSAPI.Models;
using WebAPI.ViewModels;

namespace WebAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Supplier
            CreateMap<Supplier, SupplierViewModel>().ReverseMap();

            // Customer
            CreateMap<Customer, CustomerViewModel>().ReverseMap();

            // Size
            CreateMap<Sizes, SizeViewModel>().ReverseMap();

            // Item
            CreateMap<Product, ProductViewModel>().ReverseMap();

            // Purchase
            //    CreateMap<PurchaseViewModel, Purchases>()
            //.ForMember(dest => dest.ShopName, opt => opt.Ignore());

            CreateMap<PurchaseViewModel, Purchases>().ReverseMap();
            CreateMap<Purchases, GetPurchaseViewModel>()
   .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.SupplierName))
   .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
   .ForMember(dest => dest.SizeName, opt => opt.MapFrom(src => src.Sizes.SizeName))
   .ForMember(dest => dest.ShopName, opt => opt.MapFrom(src => src.ShopName.ShopName));

            // Sale
            CreateMap<Sales, SaleViewModel>().ReverseMap();

            CreateMap<SaleItems, SaleItemViewModel>().ReverseMap()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.SizeId, opt => opt.MapFrom(src => src.SizeId))

                .ReverseMap();

            // ShopNames
            CreateMap<ShopNames, ShopNameViewModel>().ReverseMap();

            // BarcodeStart
            CreateMap<BarcodeStart, BarcodeStartViewModel>().ReverseMap();

            CreateMap<PaymentTypes, PaymentTypeViewModel>().ReverseMap();
            CreateMap<SaleItems, SaleItemViewModel>()
            .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
            .ForMember(dest => dest.SizeName, opt => opt.MapFrom(src => src.Sizes.SizeName))
            .ForMember(dest => dest.DiscountAmt, opt => opt.MapFrom(src => src.DiscountAmount))
            .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.AmountAfterDiscount))
            .ForMember(dest => dest.ShopNameId, opt => opt.MapFrom(src => src.ShopNamesId));
        }
    }
}
