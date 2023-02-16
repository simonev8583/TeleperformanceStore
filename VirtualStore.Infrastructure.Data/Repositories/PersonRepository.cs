using VirtualStore.Infrastructure.Data.Context;
using VirtualStore.Infrastructure.Data.Schemas;
using VirtualStore.Domain.Interfaces;
using VirtualStore.Domain.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using System;

namespace VirtualStore.Infrastructure.Data.Repositories
{
    public class PersonRepository : IPersonRepository<Person>
    {
        private readonly DbContext _db;

        public PersonRepository(DbContext context)
        {
            _db = context;
        }

        public Person Create(Person entity)
        {
            var schema = this.MapToSchema(entity);

            _db.Person.InsertOne(schema);

            return this.MapToModel(schema);
        }

        public Person? GetByUsername(string username, string? password)
        {
            var filter = Builders<PersonSchema>.Filter.Eq("username", username);

            if (password != null)
            {
                filter &= Builders<PersonSchema>.Filter.Eq("password", password);
            }

            var result = _db.Person.Find(filter).FirstOrDefault();

            if (result == null) return null;

            return MapToModel(result);
        }

        private PersonSchema MapToSchema(Person person)
        {
            return new()
            {
                Id = new ObjectId(),
                Name = person.Name,
                Username = person.Username,
                Password = person.GetPassword()
            };
        }

        private Person MapToModel(PersonSchema schema)
        {
            var person = new Person(schema.Name, schema.Username, schema.Password);

            person.Id = schema.Id.ToString();

            return person;
        }
    }
}

