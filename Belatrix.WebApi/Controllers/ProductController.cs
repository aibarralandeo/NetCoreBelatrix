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
    public class ProductController : ControllerBase
    {
        private readonly IRepository<Product> _repository;

        public ProductController(IRepository<Product> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return Ok(await _repository.Read());
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            await _repository.Create(product);
            return Ok(product.Id);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> PutProduct(Product product)
        {
            return Ok(await _repository.Update(product));
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteProduct(int productId)
        {
            return Ok(await _repository.Delete(new Product { Id = productId }));
        }
    }
}
