using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;

namespace VirtualStore.Infrastructure.Data.Schemas
{
    public class ProductSchema
    {
        public ObjectId Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("price")]
        public double Price { get; set; }

        [BsonElement("stock")]
        public int Stock { get; set; }

        [BsonElement("owner")]
        public string Owner { get; set; }
    }
}

