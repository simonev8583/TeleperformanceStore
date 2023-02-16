using VirtualStore.Infrastructure.Providers.Jwt.Config;
using VirtualStore.Application.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using VirtualStore.Application.Dtos;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using System;

namespace VirtualStore.Infrastructure.Providers.Jwt
{
    public class JwtService : IAuthenticateService
    {
        private readonly JwtSettings _settings;

        public JwtService(IOptions<JwtSettings> jwtSettings)
        {
            _settings = jwtSettings.Value;
        }

        public TokenDto Authenticate(string userId)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Sid,userId)
            };

            var token = new JwtSecurityToken(
                _settings.Issuer,
                _settings.Audience,
                claims,
                expires: DateTime.Now.AddHours(5),
                signingCredentials: credentials);


            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            var dto = new TokenDto();

            dto.Token = jwt;

            return dto;
        }
    }
}

