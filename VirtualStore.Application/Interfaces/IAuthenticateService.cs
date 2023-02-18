using VirtualStore.Application.Dtos;
using System;

namespace VirtualStore.Application.Interfaces
{
    public interface IAuthenticateService
    {
        TokenDto Authenticate(string userId);

        string? VerifyToken(string token);
    }
}

