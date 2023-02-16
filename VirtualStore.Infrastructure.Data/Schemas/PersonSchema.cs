using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace VirtualStore.Infrastructure.Data.Schemas
{
    public class PersonSchema
    {
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("username")]
        public string Username { get; set; }

        [BsonElement("password")]
        public string Password { get; set; }
    }
}

