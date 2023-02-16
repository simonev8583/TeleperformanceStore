using System;
namespace VirtualStore.Application.Interfaces
{
    public interface IPasswordEncryption
    {
        string Encrypt(string password);

    }
}

