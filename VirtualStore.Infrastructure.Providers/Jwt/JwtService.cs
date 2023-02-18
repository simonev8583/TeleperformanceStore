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
                new Claim(ClaimTypes.Sid, userId)
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

        public string? VerifyToken(string token)
        {
            if (token == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.SecretKey);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,

                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = jwtToken.Claims.First(x => x.Type == ClaimTypes.Sid).Value;

                // return user id from JWT token if validation successful
                return userId;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }
    }
}

