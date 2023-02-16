using VirtualStore.Application.Interfaces;
using VirtualStore.Application.Services;
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
    public class SecurityController : Controller
    {
        private readonly ISecurityService _securityService;

        public SecurityController(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        [HttpPost]
        [MapToApiVersion("1.0")]
        public ActionResult<TokenDto> Post([FromBody] CredentialsDto credentialsDto)
        {
            return Ok(_securityService.SignIn(credentialsDto));
        }
    }
}

