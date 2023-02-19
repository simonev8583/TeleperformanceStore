using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VirtualStore.Application.Dtos;
using VirtualStore.Application.Interfaces;
using VirtualStore.Infrastructure.API.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VirtualStore.Infrastructure.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class CartController : Controller
    {
        private readonly ICartService<CartDto> _cartService;

        public CartController(ICartService<CartDto> cartService)
        {
            _cartService = cartService;
        }


        // GET: api/values
        [HttpGet]
        [MapToApiVersion("1.0")]
        [Authorization]
        public ActionResult<CartDto> Get()
        {
            var person = (PersonDto)HttpContext.Items["User"]!;

            return Ok(_cartService.Get(person.Id!));
        }

        // PUT api/values/5
        [HttpPut]
        [MapToApiVersion("1.0")]
        [Authorization]
        public ActionResult<CartDto> Put([FromBody] CartDto cartDto)
        {
            var person = (PersonDto)HttpContext.Items["User"]!;

            return Ok(_cartService.Update(cartDto, person.Id!));
        }

    }
}

