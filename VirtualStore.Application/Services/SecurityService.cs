using System;
using VirtualStore.Application.Dtos;
using VirtualStore.Application.Interfaces;
using VirtualStore.Domain.Interfaces;
using VirtualStore.Domain.Models;

namespace VirtualStore.Application.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IPersonRepository<Person> _personProvider;
        private readonly IPasswordEncryption _passwordEncryptionService;
        private readonly IAuthenticateService _authenticateService;

        public SecurityService(IPersonRepository<Person> personRepository, IPasswordEncryption passwordEncryption, IAuthenticateService authenticateService)
        {
            _personProvider = personRepository;
            _passwordEncryptionService = passwordEncryption;
            _authenticateService = authenticateService;
        }

        public TokenDto SignIn(CredentialsDto credentials)
        {
            string password = _passwordEncryptionService.Encrypt(credentials.Password);

            var person = _personProvider.GetByUsername(credentials.Username, password);

            if (person == null) throw new InvalidDataException("No se encontró el usuario, intentelo de nuevo");

            return _authenticateService.Authenticate(person.Id!);
        }
    }
}

