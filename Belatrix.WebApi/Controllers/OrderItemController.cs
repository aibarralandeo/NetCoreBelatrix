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
    public class OrderItemController : ControllerBase
    {
        private readonly IRepository<OrderItem> _repository;

        public OrderItemController(IRepository<OrderItem> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItems()
        {
            return Ok(await _repository.Read());
        }

        [HttpPost]
        public async Task<ActionResult<OrderItem>> PostOrderItem(OrderItem OrderItem)
        {
            await _repository.Create(OrderItem);
            return Ok(OrderItem.Id);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> PutOrderItem(OrderItem OrderItem)
        {
            return Ok(await _repository.Update(OrderItem));
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteOrderItem(int OrderItemId)
        {
            return Ok(await _repository.Delete(new OrderItem { Id = OrderItemId }));
        }
    }
}
