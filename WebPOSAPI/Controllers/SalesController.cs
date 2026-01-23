using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;
using WebAPI.Helpers;
using WebAPI.Models;
using WebAPI.Repositories.IGenericRepository;
using WebAPI.ViewModels;
using WebPOSAPI.Migrations;
using Settings = WebAPI.Models.Settings;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly IGenericRepository<Sales> _repo;
        private readonly IGenericRepository<Settings>  settings;
        private readonly AppDBContext _context;



        private readonly ILogger<SalesController> _logger;
        private readonly IMapper _mapper;

        public SalesController(IGenericRepository<Sales> repo, ILogger<SalesController> logger, IMapper mapper, IGenericRepository<Settings> genericsettings,AppDBContext appDBContext)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
            settings = genericsettings;
            _context = appDBContext;




        }

        [HttpGet]
     
        public async Task<IActionResult> GetAll()
        {
            try
            {
                // __define-ocg__ Load sales with related data
                var sales = await _repo.GetSalesWithDetailsAsync();

                // Manually map entities to view models
                var varOcg = sales.Select(s => new SaleViewModel
                {
                    Id = s.Id,
                    BillNo = s.BillNo,
                    CustomerId = s.CustomerId,
                    CustomerName = s.Customer != null ? s.Customer.CustomerName : "-",
                    PaymentId = s.PaymentTypeId,
                    MobileNo = s.Customer != null ? s.Customer.MobileNo : string.Empty,
                    SaleDate = s.SaleDate,
                    RewardPoints = s.RewardPoints,
                    GSTPercent = (double)s.GSTPercent,
                   
                    

                    // Map nested SaleItems → SaleItemViewModel
                    SaleItems = s.SaleItems?.Select(i => new SaleItemViewModel
                    {
                        SaleItemId = i.SaleItemId,
                        SaleId = i.SaleId,
                        Barcode = i.Barcode,
                        ProductId = i.ProductId,
                        ProductName = i.Product != null ? i.Product.ProductName : string.Empty,
                       
                        SizeId = i.SizeId,
                        SizeName = i.Sizes != null ? i.Sizes.SizeName : string.Empty,
                        Qty = i.Qty,
                        SalePrice = i.SalePrice,
                        Discount = i.Discount,
                        DiscountAmt = i.DiscountAmount,
                        Amount = i.AmountAfterDiscount,
                      
                    }).ToList() ?? new List<SaleItemViewModel>()
                }).ToList();

                return Ok(varOcg);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading sales: {ex.Message}");
                return StatusCode(500, "Error loading sales data.");
            }
        }

        //       public async Task<IActionResult> GetAll()
        //       {

        //          var sales= await _repo.GetSalesWithDetailsAsync();
        // //          try
        // //          {
        // //              // __define-ocg__
        // //              var sales = await _repo.GetAllAsync(
        // //    s => ((Sales)s).SaleItems,
        // //    s => ((Sales)s).SaleItems.Select(si => si.Product),
        // //    s => ((Sales)s).SaleItems.Select(si => si.Sizes),
        // //    s => ((Sales)s).BillShopNameId
        // //);
        // //              // Map entities to view models
        //var salesVMs = _mapper.Map<List<SaleViewModel>>(sales);
        //        return Ok(salesVMs);
        //           //          }
        //           //          catch (Exception ex)
        //           //          {
        //           //              Console.WriteLine($"Error loading sales: {ex.Message}");
        //           //              return StatusCode(500, "Error loading sales data.");
        //           //          }


        //       }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var sale = await _repo.GetByIdAsync(id);
            var saleVM = _mapper.Map<SaleViewModel>(sale);
            return Ok(saleVM);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaleViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (model?.SaleItems == null || !model.SaleItems.Any())
                    return BadRequest("At least one sale item is required");

                var setting = await _context.Settings
     .FirstOrDefaultAsync(s => s.KeyName == "ShopName");

                var shopName = DbValueHelper.GetColumnValue(setting, "KeyValue");
                var shopnameids=_context.ShopNames.FirstOrDefault(s=>s.ShopName== Convert.ToString( shopName));
               

                // Ensure ShopName is not null or empty
                
                var sales = _mapper.Map<Sales>(model);
               await _repo.AddAsync(sales);
                //await _repo.SaveChangesAsync();

                try
                {
                    await _repo.SaveChangesAsync();
                }
                catch (DbUpdateException ex)
                {
                    var inner = ex.InnerException?.Message;
                    return BadRequest(inner);
                }

                var saleVM = _mapper.Map<SaleViewModel>(sales);
                return CreatedAtAction(nameof(Get), new { id = sales.Id }, saleVM);
            }
            catch (Exception ex)
            {
                // Log the exception here
                _logger.LogError(ex.StackTrace, "Error creating sale");

                return StatusCode(500, "An error occurred while creating the sale");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SaleViewModel model)
        {
            if (id != model.Id)
                return BadRequest("ID mismatch");

            var sale = await _repo.GetByIdAsync(id);
            _mapper.Map(model, sale);
            _repo.Update(sale);
            await _repo.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sale = await _repo.GetByIdAsync(id);
            _repo.Remove(sale);
            await _repo.SaveChangesAsync();
            return NoContent();
        }



    }
}
