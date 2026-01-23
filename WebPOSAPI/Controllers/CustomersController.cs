using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Repositories.IGenericRepository;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IGenericRepository<Customer> _repo;
        private readonly ILogger<CustomersController> _logger;
        private readonly IMapper _mapper;

        public CustomersController(IGenericRepository<Customer> repo, ILogger<CustomersController> logger, IMapper mapper)
        {
            _repo = repo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _repo.GetAllAsync();
            var customerVMs = _mapper.Map<List<CustomerViewModel>>(customers);
            return Ok(customerVMs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _repo.GetByIdAsync(id);
            var customerVM = _mapper.Map<CustomerViewModel>(customer);
            return Ok(customerVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerViewModel model)
        {
            // Example check: assume Email is unique
            bool exists = await _repo.CheckExistsAsync(c => c.CustomerName.Trim() == model.CustomerName.Trim());

            if (exists)
            {
                return Conflict($"A customer  '{model.CustomerName}' already exists.");
            }

            var customer = _mapper.Map<Customer>(model);
            await _repo.AddAsync(customer);
            await _repo.SaveChangesAsync();

            var customerVM = _mapper.Map<CustomerViewModel>(customer);
            return CreatedAtAction(nameof(Get), new { id = customer.Id }, customerVM);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CustomerViewModel model)
        {
            if (id != model.Id)
                return BadRequest("ID mismatch");

            bool exists = await _repo.CheckExistsAsync(c => c.CustomerName.Trim() == model.CustomerName.Trim());

            if (exists)
            {
                return Conflict($"A customer  '{model.CustomerName}' already exists.");
            }

            var customer = await _repo.GetByIdAsync(id);
            _mapper.Map(model, customer);
            _repo.Update(customer);
            await _repo.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _repo.GetByIdAsync(id);
            _repo.Remove(customer);
            await _repo.SaveChangesAsync();
            return NoContent();
        }


    }
}
