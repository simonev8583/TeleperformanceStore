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

        // POST api/values
        [HttpPost]
        [MapToApiVersion("1.0")]
        [Helpers.AllowAnonymous]
        public ActionResult<PersonDto> Post([FromBody] PersonDto personDto)
        {

            return Ok(_personService.Create(personDto));
        }
    }
}

