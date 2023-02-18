using VirtualStore.Application.Interfaces;
using VirtualStore.Domain.Interfaces;
using VirtualStore.Application.Dtos;
using VirtualStore.Domain.Models;
using System;

namespace VirtualStore.Application.Services
{
    public class PersonService : IPersonService<PersonDto>
    {
        private readonly IPersonRepository<Person> _personProvider;
        private readonly IPasswordEncryption _passwordEncryptionService;

        public PersonService(IPersonRepository<Person> personRepository, IPasswordEncryption passwordEncryption)
        {
            _personProvider = personRepository;
            _passwordEncryptionService = passwordEncryption;
        }

        public PersonDto Create(PersonDto dto)
        {
            if (dto == null) throw new ArgumentNullException("La información de la Persona es requerida");

            var personRegistered = _personProvider.GetByUsername(dto.Username, null);

            if (personRegistered != null) throw new InvalidDataException("Ya existe un usuario con ese nombre de usuario");

            Person person = PersonDto.ToDomain(dto);

            person.SetPassword(_passwordEncryptionService.Encrypt(dto.Password));

            var personStored = _personProvider.Create(person);

            return PersonDto.FromDomain(person);
        }

        public PersonDto GetById(string id)
        {
            var person = _personProvider.GetById(id);

            if (person == null) throw new ArgumentNullException("No se econtró el usuario");

            return PersonDto.FromDomain(person);
        }
    }
}

