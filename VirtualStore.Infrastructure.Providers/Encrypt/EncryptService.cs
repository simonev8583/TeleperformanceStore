using VirtualStore.Infrastructure.Providers.Encrypt.Config;
using VirtualStore.Application.Interfaces;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;
using System;

namespace VirtualStore.Infrastructure.Providers.Encrypt
{
    public class EncryptService : IPasswordEncryption
    {
        private readonly EncryptSettings _settings;

        public EncryptService(IOptions<EncryptSettings> encryptSettings)
        {
            _settings = encryptSettings.Value;
        }

        public string Encrypt(string password)
        {
            var hashMethod = HashAlgorithmName.SHA384;

            var passwordEncoded = Rfc2898DeriveBytes.Pbkdf2(Encoding.Unicode.GetBytes(password),
                                             Encoding.Unicode.GetBytes(_settings.Salt),
                                             _settings.Iterations,
                                             hashMethod,
                                             _settings.DesiredKeyLength);

            return Convert.ToBase64String(passwordEncoded);
        }
    }
}

