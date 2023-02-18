using VirtualStore.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using VirtualStore.Application.Dtos;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System;
using VirtualStore.Infrastructure.API.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VirtualStore.Infrastructure.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class PersonController : Controller
    {
        private readonly IPersonService<PersonDto> _personService;
        private readonly IAuthenticateService _authenticateService;

        public PersonController(IPersonService<PersonDto> personService, IAuthenticateService authenticateService)
        {
            _personService = personService;
            _authenticateService = authenticateService;
        }

        // GET: api/values
        /*
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        */

        // GET api/values/5
        /*
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        */

        // POST api/values
        [HttpPost]
        [MapToApiVersion("1.0")]
        [Authorization]
        public ActionResult<PersonDto> Post([FromBody] PersonDto personDto)
        {
            var token = HttpContext.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();

            var userId = _authenticateService.VerifyToken(token!);
            if (userId == null)
            {
                // attach user to context on successful jwt validation
                return Unauthorized("Sin autorización");
            }

            return Ok(_personService.Create(personDto));
        }

        // PUT api/values/5
        /*
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        */

        // DELETE api/values/5
        /*
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}

