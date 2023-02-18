using VirtualStore.Application.Interfaces;
using VirtualStore.Application.Dtos;
using System;

namespace VirtualStore.Infrastructure.API.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IAuthenticateService jwtUtils, IPersonService<PersonDto> personService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            var userId = jwtUtils.VerifyToken(token!);

            if (userId != null)
            {
                context.Items["User"] = personService.GetById(userId);
            }

            await _next(context);
        }
    }
}

