using System;
namespace VirtualStore.Infrastructure.Providers.Encrypt.Config
{
    public class EncryptSettings
    {
        public int Iterations { get; set; }

        public int DesiredKeyLength { get; set; }

        public string Salt { get; set; } = null!;
    }
}

