using VirtualStore.Application.Dtos;
using System;

namespace VirtualStore.Application.Interfaces
{
    public interface ISecurityService
    {
        TokenDto SignIn(CredentialsDto credentials);
    }
}

