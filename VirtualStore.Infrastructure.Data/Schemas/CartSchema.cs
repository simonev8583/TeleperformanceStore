using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace VirtualStore.Infrastructure.Data.Schemas
{
    public class CartSchema
    {
        public ObjectId Id { get; set; }

        [BsonElement("personId")]
        public string PersonId { get; set; }

        [BsonElement("products")]
        public List<ProductSchema> Products { get; set; }
    }
}

