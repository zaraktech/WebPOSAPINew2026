using APIDBFirst.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace APIDBFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerMasterController : BaseApiController<CustomerMaster>
    {
        public CustomerMasterController(IGenericRepository<CustomerMaster> repository)
            : base(repository) { }
    }
}
