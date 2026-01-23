

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Repositories.IGenericRepository;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizesController : ControllerBase
    {
        private readonly IGenericRepository<Sizes> _repo;
        private readonly ILogger<SizesController> _logger;
        private readonly IMapper _mapper;

        public SizesController(IGenericRepository<Sizes> repo, ILogger<SizesController> logger, IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sizes = await _repo.GetAllAsync();
            var sizeVMs = _mapper.Map<List<SizeViewModel>>(sizes);
            return Ok(sizeVMs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var size = await _repo.GetByIdAsync(id);
            var sizeVM = _mapper.Map<SizeViewModel>(size);
            return Ok(sizeVM);
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] SizeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            bool exists = await _repo.CheckExistsAsync(c => c.SizeName.Trim() == model.SizeName.Trim());
            if (exists)
            {
                return Conflict($"A Size  '{model.SizeName}' already exists.");
            }


            var size = _mapper.Map<Sizes>(model);
            await _repo.AddAsync(size);
            await _repo.SaveChangesAsync();
            var sizeVM = _mapper.Map<SizeViewModel>(size);
            return CreatedAtAction(nameof(Get), new { id = size.SizeId }, sizeVM);

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SizeViewModel model)
        {
            if (id != model.SizeId)
                return BadRequest("ID mismatch");

            bool exists = await _repo.CheckExistsAsync(c => c.SizeName.Trim() == model.SizeName.Trim());
            if (exists)
            {
                return Conflict($"A Size  '{model.SizeName}' already exists.");
            }

            var size = await _repo.GetByIdAsync(id);
            _mapper.Map(model, size);
            _repo.Update(size);
            await _repo.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var size = await _repo.GetByIdAsync(id);
            _repo.Remove(size);
            await _repo.SaveChangesAsync();
            return NoContent();
        }
    }
}
