using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Repositories.IGenericRepository;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopNamesController : ControllerBase
    {
        private readonly IGenericRepository<ShopNames> _repo;
        private readonly ILogger<ShopNamesController> _logger;
        private readonly IMapper _mapper;

        public ShopNamesController(IGenericRepository<ShopNames> repo, ILogger<ShopNamesController> logger, IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var shops = await _repo.GetAllAsync();
            var shopVMs = _mapper.Map<List<ShopNameViewModel>>(shops);
            return Ok(shopVMs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Shop ID.");

            var shop = await _repo.GetByIdAsync(id);
            var shopVM = _mapper.Map<ShopNameViewModel>(shop);
            return Ok(shopVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ShopNameViewModel model)
        {
            var shop = _mapper.Map<ShopNames>(model);
            await _repo.AddAsync(shop);
            await _repo.SaveChangesAsync();
            var shopVM = _mapper.Map<ShopNameViewModel>(shop);
            return CreatedAtAction(nameof(Get), new { id = shop.ShopNamesId }, shopVM);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ShopNameViewModel model)
        {
            if (id != model.ShopNamesId)
                return BadRequest("ID mismatch");

            var shop = await _repo.GetByIdAsync(id);
            _mapper.Map(model, shop);
            _repo.Update(shop);
            await _repo.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var shop = await _repo.GetByIdAsync(id);
            _repo.Remove(shop);
            await _repo.SaveChangesAsync();
            return NoContent();
        }
    }
}
