using APIDBFirst.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APIDBFirst.Controllers
{
    //[ApiExplorerSettings(IgnoreApi = true)]

    [ApiController]


    public class BaseApiController<T> : ControllerBase
            where T : class
    {
        protected readonly IGenericRepository<T> _repository;

        public BaseApiController(
            IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            var data = await _repository.GetAllAsync();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(int id)
        {
            var data = await _repository.GetByIdAsync(id);

            return Ok(data);
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create(T entity)
        {
            await _repository.AddAsync(entity);

            await _repository.SaveChangesAsync();

            return Ok(entity);
        }

        [HttpPut]
        public virtual async Task<IActionResult> Update(T entity)
        {
            _repository.Update(entity);

            await _repository.SaveChangesAsync();

            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var entity = await _repository.GetByIdAsync(id);

            _repository.Remove(entity);

            await _repository.SaveChangesAsync();

            return Ok();
        }
    }
}
