using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Repositories.IGenericRepository;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly IGenericRepository<Supplier> _repo;
        private readonly ILogger<SuppliersController> _logger;
        private readonly IMapper _mapper;

        public SuppliersController(IGenericRepository<Supplier> repo, ILogger<SuppliersController> logger, IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var suppliers = await _repo.GetAllAsync();
            var supplierVMs = _mapper.Map<List<SupplierViewModel>>(suppliers);
            return Ok(supplierVMs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var supplier = await _repo.GetByIdAsync(id);
            var supplierVM = _mapper.Map<SupplierViewModel>(supplier);
            return Ok(supplierVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SupplierViewModel model)
        {
            bool exists = await _repo.CheckExistsAsync(c => c.SupplierName.Trim() == model.SupplierName.Trim());

            if (exists)
            {
                return Conflict($"A Supplier  '{model.SupplierName}' already exists.");
            }

            var supplier = _mapper.Map<Supplier>(model);
            await _repo.AddAsync(supplier);
            await _repo.SaveChangesAsync();
            var supplierVM = _mapper.Map<SupplierViewModel>(supplier);
            return CreatedAtAction(nameof(Get), new { id = supplier.SupplierId }, supplierVM);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SupplierViewModel model)
        {
            if (id != model.SupplierId)
                return BadRequest("ID mismatch");


            bool exists = await _repo.CheckExistsAsync(c => c.SupplierName.Trim() == model.SupplierName.Trim());

            if (exists)
            {
                return Conflict($"A Supplier  '{model.SupplierName}' already exists.");
            }

            var supplier = await _repo.GetByIdAsync(id);
            _mapper.Map(model, supplier);
            _repo.Update(supplier);
            await _repo.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var supplier = await _repo.GetByIdAsync(id);
            _repo.Remove(supplier);
            await _repo.SaveChangesAsync();
            return NoContent();
        }
    }
}
