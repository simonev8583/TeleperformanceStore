using VirtualStore.Infrastructure.API.Helpers;
using VirtualStore.Application.Interfaces;
using VirtualStore.Application.Dtos;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VirtualStore.Infrastructure.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ProductController : Controller
    {
        private readonly IProductService<ProductDto> _productService;

        public ProductController(IProductService<ProductDto> productService)
        {
            _productService = productService;
        }

        // GET: api/values
        [HttpGet]
        [MapToApiVersion("1.0")]
        [Authorization]
        public ActionResult<List<ProductDto>> Get()
        {
            var person = (PersonDto)HttpContext.Items["User"]!;

            return Ok(_productService.GetProductsToBuy(person.Id!));
        }

        // GET: api/values
        [HttpGet("Own")]
        [MapToApiVersion("1.0")]
        [Authorization]
        public ActionResult<List<ProductDto>> GetByOwn()
        {
            var person = (PersonDto)HttpContext.Items["User"]!;

            return Ok(_productService.GetProductsOwn(person.Id!));
        }

        // GET api/values/5
        [HttpGet("{productId}")]
        [MapToApiVersion("1.0")]
        [Authorization]
        public ActionResult<ProductDto> Get(string productId)
        {
            return Ok(_productService.GetById(productId));
        }

        // POST api/values
        [HttpPost]
        [MapToApiVersion("1.0")]
        [Authorization]
        public ActionResult<ProductDto> Post([FromBody] ProductDto product)
        {
            var person = (PersonDto)HttpContext.Items["User"]!;
            return Ok(_productService.Create(product, person.Id!));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        [Authorization]
        public ActionResult<ProductDto> Put(string id, [FromBody] ProductDto product)
        {
            var person = (PersonDto)HttpContext.Items["User"]!;

            return Ok(_productService.Update(product, id, person.Id!));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        [Authorization]
        public ActionResult<string> Delete(string id)
        {
            var person = (PersonDto)HttpContext.Items["User"]!;

            return Ok(_productService.Delete(id, person.Id!));
        }
    }
}

