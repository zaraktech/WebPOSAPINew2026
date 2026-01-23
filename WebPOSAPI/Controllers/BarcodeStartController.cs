using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Repositories.IGenericRepository;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarcodeStartController : ControllerBase
    {
        private readonly IGenericRepository<BarcodeStart> _repo;
        private readonly ILogger<BarcodeStartController> _logger;
        private readonly IMapper _mapper;

        public BarcodeStartController(IGenericRepository<BarcodeStart> repo, ILogger<BarcodeStartController> logger, IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var barcodes = await _repo.GetAllAsync();
            var barcodeVMs = _mapper.Map<List<BarcodeStartViewModel>>(barcodes);
            return Ok(barcodeVMs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var barcode = await _repo.GetByIdAsync(id);
            var barcodeVM = _mapper.Map<BarcodeStartViewModel>(barcode);
            return Ok(barcodeVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] BarcodeStartViewModel model)
        {
            var barcode = _mapper.Map<BarcodeStart>(model);
            await _repo.AddAsync(barcode);
            await _repo.SaveChangesAsync();
            var barcodeVM = _mapper.Map<BarcodeStartViewModel>(barcode);
            return CreatedAtAction(nameof(Get), new { id = barcode.Id }, barcodeVM);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BarcodeStartViewModel model)
        {
            if (id != model.Id)
                return BadRequest("ID mismatch");

            var barcode = await _repo.GetByIdAsync(id);
            _mapper.Map(model, barcode);
            _repo.Update(barcode);
            await _repo.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var barcode = await _repo.GetByIdAsync(id);
            _repo.Remove(barcode);
            await _repo.SaveChangesAsync();
            return NoContent();
        }
    }
}
