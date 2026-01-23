using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Syncfusion.Blazor;
using System.Globalization;
using WebPOS;
using WebPOS.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5056/")
});






// Add Blazored LocalStorage
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddMudServices();


Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjGyl/Vkd+XU9FcVRDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS3tSd0dmWXpdcHdRRmRUUE91Xg==");
builder.Services.AddSyncfusionBlazor();



//builder.Services.AddDevExpressBlazor();

//builder.Services.AddDevExpressBlazor(configure => configure.BootstrapVersion = DevExpress.Blazor.BootstrapVersion.v5);
builder.Services.AddScoped<ErrorLoggerService>();


// Register Auth Services
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<SupplierService>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<SizeService>();
builder.Services.AddScoped<PurchaseService>();
builder.Services.AddScoped<ShopNamesService>();
builder.Services.AddScoped<SalesService>();
builder.Services.AddScoped<SettingsService>();
builder.Services.AddScoped<ToastService>();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<OffersService>();
builder.Services.AddScoped<StockReportService>();


var culture = new CultureInfo("en-IN");
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;


await builder.Build().RunAsync();
