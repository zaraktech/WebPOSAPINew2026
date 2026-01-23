using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {

        private readonly AppDBContext _context;
        public OffersController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet("product-lookup")]
        public async Task<ActionResult<List<ProductLookUp>>> GetProductLookup()
        {
            var products = await _context.Products
               
                .Select(p => new ProductLookUp
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                   
                  CostPrice= _context.Purchases
                                    .Where(pr => pr.ProductId == p.ProductId)
                                    .OrderByDescending(pr => pr.Id)
                                    .Select(pr => pr.CostPrice)
                                    .FirstOrDefault(),
                  Barcode= _context.Purchases
                                    .Where(pr => pr.ProductId == p.ProductId)
                                    .OrderByDescending(pr => pr.Id)
                                    .Select(pr => pr.Barcode)
                                    .FirstOrDefault(),  
                })
                .OrderBy(p => p.ProductName)
                .ToListAsync();

            return Ok(products);
        }

        [HttpGet]
        public async Task<ActionResult<List<OfferViewModel>>> GetOffers()
        {
            var offers = await _context.Offers
                .Select(o => new OfferViewModel
                {
                    OfferId = o.OfferId,
                    ProductId = o.ProductId,

                    ProductName = o.ProductName,
                    Barcode = o.Barcode,

                    // ✅ Latest MRP from Purchase
                    SalePrice = _context.Purchases
                        .Where(p => p.ProductId == o.ProductId)
                        .OrderByDescending(p => p.PurchaseDate)
                        .Select(p => p.SalePrice)
                        .FirstOrDefault(),

                    OfferPrice = o.OfferPrice,
                    IsActive = o.IsActive
                })
                .OrderByDescending(o => o.OfferId)
                .ToListAsync();

            return Ok(offers);
        }
        [HttpPost]
        public async Task<IActionResult> SaveOffer([FromBody] OfferViewModel vm)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (vm.OfferId == 0)
            {
                // ADD
                var offer = new Offer
                {
                    ProductId = vm.ProductId,
                    OfferPrice = vm.OfferPrice,
                    IsActive = vm.IsActive
                };

                _context.Offers.Add(offer);
            }
            else
            {
                // UPDATE
                var offer = await _context.Offers
                    .FirstOrDefaultAsync(o => o.OfferId == vm.OfferId);

                if (offer == null)
                    return NotFound("Offer not found");

                offer.ProductId = vm.ProductId;
                offer.OfferPrice = vm.OfferPrice;
                offer.IsActive = vm.IsActive;
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        // ======================================================
        // DELETE: api/offers/{id}
        // ======================================================
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOffer(int id)
        {
            var offer = await _context.Offers
                .FirstOrDefaultAsync(o => o.OfferId == id);

            if (offer == null)
                return NotFound("Offer not found");

            _context.Offers.Remove(offer);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // ======================================================
        // PUT: api/offers/{id}/status
        // ======================================================
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromQuery] bool isActive)
        {
            var offer = await _context.Offers
                .FirstOrDefaultAsync(o => o.OfferId == id);

            if (offer == null)
                return NotFound("Offer not found");

            offer.IsActive = isActive;
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
