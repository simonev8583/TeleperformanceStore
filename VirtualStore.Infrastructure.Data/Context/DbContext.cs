using VirtualStore.Infrastructure.Data.Schemas;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

namespace VirtualStore.Infrastructure.Data.Context
{
    public class DbContext
    {
        private readonly IMongoCollection<PersonSchema> _personCollection;
        private readonly IMongoCollection<ProductSchema> _productCollection;
        private readonly IMongoCollection<CartSchema> _cartCollection;

        public DbContext(IOptions<GeneralSettings> storeSettings)
        {
            var mongoClient = new MongoClient(
                storeSettings.Value.StringConnection);

            var mongoDb = mongoClient.GetDatabase(storeSettings.Value.DataBaseName);

            _personCollection = mongoDb.GetCollection<PersonSchema>(
                storeSettings.Value.PersonCollectionName);

            _productCollection = mongoDb.GetCollection<ProductSchema>(
                storeSettings.Value.ProductCollectionName);

            _cartCollection = mongoDb.GetCollection<CartSchema>(
                storeSettings.Value.CartCollectionName);
        }

        public IMongoCollection<PersonSchema> Person
        {
            get
            {
                return _personCollection;
            }
        }

        public IMongoCollection<ProductSchema> Product
        {
            get
            {
                return _productCollection;
            }
        }

        public IMongoCollection<CartSchema> Cart
        {
            get
            {
                return _cartCollection;
            }
        }
    }
}

