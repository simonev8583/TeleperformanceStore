using System;
namespace VirtualStore.Infrastructure.Providers.Jwt.Config
{
    public class JwtSettings
    {
        public string SecretKey { get; set; } = null!;

        public string Issuer { get; set; } = null!;

        public string Audience { get; set; } = null!;
    }
}

