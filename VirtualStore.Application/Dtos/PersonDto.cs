using System;
using VirtualStore.Domain.Models;

namespace VirtualStore.Application.Dtos
{
    public class PersonDto
    {
        public string? Id { get; set; }

        public string Name { get; set; } = null!;

        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public static PersonDto FromDomain(Person person)
        {
            if (person is null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            var dto = new PersonDto();

            dto.Id = person.Id;
            dto.Name = person.Name;
            dto.Username = person.Username;


            return dto;
        }

        public static Person ToDomain(PersonDto dto)
        {
            if (dto is null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var person = new Person(dto.Name, dto.Username, dto.Password);


            return person;
        }
    }
}

