using Belatrix.WebApi.Models;
using Belatrix.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Belatrix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository<Customer> _repository;

        public CustomerController(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return Ok(await _repository.Read());
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            await _repository.Create(customer);
            return Ok(customer.Id);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> PutCustomer(Customer customer)
        {
            return Ok(await _repository.Update(customer));
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteCustomer(int customerId)
        {
            return Ok(await _repository.Delete(new Customer { Id = customerId }));
        }
    }
}
