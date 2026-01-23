using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Repositories.IGenericRepository;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly IGenericRepository<Purchases> _repo;
        private readonly IGenericRepository<ShopNames> shoprepo;


        private readonly ILogger<PurchasesController> _logger;
        private readonly IMapper _mapper;

        public PurchasesController(IGenericRepository<Purchases> repo, ILogger<PurchasesController> logger, IMapper mapper, IGenericRepository<ShopNames> reposhop)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
            shoprepo = reposhop;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var purchases = await _repo.GetAllAsync(
        p => p.Supplier,
        p => p.Product,
        p => p.Sizes,
        p => p.ShopName

    );
            var purchaseVMs = _mapper.Map<List<GetPurchaseViewModel>>(purchases);
            return Ok(purchaseVMs);
        }




        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var purchases = await _repo.GetAllAsync(
                p => p.Supplier,
                p => p.Product,
                p => p.Sizes,
                p => p.ShopName
            );

            var purchase = purchases.FirstOrDefault(p => p.Id == id);

            if (purchase == null)
                return NotFound();

            var purchaseVM = _mapper.Map<GetPurchaseViewModel>(purchase);
            return Ok(purchaseVM);
        }

        [HttpGet("GetBarcode/{barcode}")]
        public async Task<IActionResult> GetBarcode(int barcode)
        {
            var purchases = await _repo.GetAllAsync(
                p => p.Supplier,
                p => p.Product,
                p => p.Sizes,
                p => p.ShopName
            );

            var purchase = purchases.FirstOrDefault(p => p.Barcode == barcode);

            if (purchase == null)
                return NotFound();

            var purchaseVM = _mapper.Map<GetPurchaseViewModel>(purchase);
            return Ok(purchaseVM);
        }



        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PurchaseViewModel model)
        {
            try
            {
                var purchase = _mapper.Map<Purchases>(model);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }



                await _repo.AddAsync(purchase);
                await _repo.SaveChangesAsync();

                var purchaseVM = _mapper.Map<PurchaseViewModel>(purchase);
                return CreatedAtAction(nameof(Get), new { id = purchase.Id }, purchaseVM);
            }
            catch (Exception ex)
            {


                return StatusCode(500, new { message = "An error occurred while creating the purchase.", error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PurchaseViewModel model)
        {
            if (id != model.Id)
                return BadRequest("ID mismatch");

            var purchase = await _repo.GetByIdAsync(id);

            _mapper.Map(model, purchase);

            // Update BarcodeText again if ShopName changes
            if (model.ShopNamesId != 0)
            {
                var shopEntity = await shoprepo.GetByIdAsync(model.ShopNamesId);
                string shopName = shopEntity.ShopName;
                var barcodeNumber = model.Barcode.ToString();

                //if (ShopName.ShopName.Equals("Vaniyambadi Boys", StringComparison.OrdinalIgnoreCase))
                //{
                //    purchase.BarcodeText = "V" + barcodeNumber;
                //}
                //else if (ShopName.ShopName.Equals("KurtiHub", StringComparison.OrdinalIgnoreCase))
                //{
                //    purchase.BarcodeText = "W" + barcodeNumber;
                //}
                //else if (ShopName.ShopName.Equals("Kids2Teen", StringComparison.OrdinalIgnoreCase))
                //{
                //    purchase.BarcodeText = "K" + barcodeNumber;
                //}
                //else
                //{
                //    purchase.BarcodeText = barcodeNumber;
                //}
            }

            _repo.Update(purchase);
            await _repo.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var purchase = await _repo.GetByIdAsync(id);
            _repo.Remove(purchase);
            await _repo.SaveChangesAsync();
            return NoContent();
        }
    }
}
