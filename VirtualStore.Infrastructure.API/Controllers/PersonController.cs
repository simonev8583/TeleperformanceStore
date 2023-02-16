using VirtualStore.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
    public class PersonController : Controller
    {
        private readonly IPersonService<PersonDto> _personService;

        public PersonController(IPersonService<PersonDto> personService)
        {
            _personService = personService;
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
        public ActionResult<PersonDto> Post([FromBody] PersonDto personDto)
        {
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

