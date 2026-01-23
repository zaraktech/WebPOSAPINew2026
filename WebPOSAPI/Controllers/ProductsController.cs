using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Repositories.IGenericRepository;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _repo;
        private readonly ILogger<ProductsController> _logger;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> repo, ILogger<ProductsController> logger, IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await _repo.GetAllAsync();
            var itemVMs = _mapper.Map<List<ProductViewModel>>(items);
            return Ok(itemVMs);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _repo.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            var itemVM = _mapper.Map<ProductViewModel>(item);
            return Ok(itemVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var item = _mapper.Map<Product>(model);
            await _repo.AddAsync(item);
            await _repo.SaveChangesAsync();

            var itemVM = _mapper.Map<ProductViewModel>(item);
            return CreatedAtAction(nameof(Get), new { id = item.ProductId }, itemVM);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != model.ProductId)
            {
                return BadRequest("ID mismatch");
            }

            var item = await _repo.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _mapper.Map(model, item);
            _repo.Update(item);
            await _repo.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _repo.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _repo.Remove(item);
            await _repo.SaveChangesAsync();

            return NoContent();
        }
    }
}
