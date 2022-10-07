using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Models;
using ProductMicroservice.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult(productRepository.GetProducts());
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            return new OkObjectResult(productRepository.GetProductById(id));
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            using (var scope = new TransactionScope())
            {
                productRepository.InsertProduct(product);
                scope.Complete();
                return new OkResult();
                //return new CreatedAtActionResult(nameof(Get), new { id = product.Id },, product);
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            if(product != null)
            {
                using(var scope = new TransactionScope())
                {
                    productRepository.UpdateProduct(product);
                    scope.Complete();
                    return new OkResult();
                }
            }
            productRepository.UpdateProduct(product);
            return new NoContentResult();
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            productRepository.DeleteProduct(id);
            return new OkResult();
        }
    }
}
