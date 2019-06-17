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
    public class OrderController : ControllerBase
    {
        private readonly IRepository<Order> _repository;

        public OrderController(IRepository<Order> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return Ok(await _repository.Read());
        }

        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order Order)
        {
            await _repository.Create(Order);
            return Ok(Order.Id);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> PutOrder(Order Order)
        {
            return Ok(await _repository.Update(Order));
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteOrder(int OrderId)
        {
            return Ok(await _repository.Delete(new Order { Id = OrderId }));
        }
    }
}
