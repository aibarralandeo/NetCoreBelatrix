using Belatrix.WebApi.Models;
using Belatrix.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Belatrix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly Repository.IRepository<Customer> repository;

        public CustomerController(IRepository<Customer> repository)
        {
            this.repository = repository;
        }

        // GET: api/Customer
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            return Ok(await repository.Read());
        }

        //// GET: api/Customer/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Customer
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Customer/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
