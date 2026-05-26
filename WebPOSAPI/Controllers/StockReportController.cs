using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockReportController : ControllerBase
    {
        private readonly AppDBContext _context;

        public StockReportController(AppDBContext dBContext)
        {

            _context = dBContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetStockReport()
        {
            // __define-ocg__ ef core stock report
            var result = await _context.StockReport
                .FromSqlRaw(
                    "EXEC usp_GetStockReport"

                )
                .AsNoTracking()
                .ToListAsync();

            return Ok(result);
        }
    }
}
