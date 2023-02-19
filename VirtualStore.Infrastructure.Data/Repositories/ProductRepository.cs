using VirtualStore.Infrastructure.Data.Context;
using VirtualStore.Infrastructure.Data.Schemas;
using VirtualStore.Domain.Interfaces;
using VirtualStore.Domain.Models;
using SharpCompress.Common;
using MongoDB.Driver;
using MongoDB.Bson;
using System;

namespace VirtualStore.Infrastructure.Data.Repositories
{
    public class ProductRepository : IProductRepository<Product>
    {

        private readonly DbContext _db;

        public ProductRepository(DbContext db)
        {
            _db = db;
        }

        public Product Create(Product product)
        {
            var schema = this.MapToSchema(product);

            _db.Product.InsertOne(schema);

            return this.MapToModel(schema);
        }

        public void Delete(string productId, string owner)
        {
            var filter = Builders<ProductSchema>.Filter.Eq("_id", new ObjectId(productId));
            filter &= Builders<ProductSchema>.Filter.Eq("owner", owner);

            _db.Product.DeleteOne(filter);

        }

        public Product GetById(string productId)
        {
            var filter = Builders<ProductSchema>.Filter.Eq("_id", new ObjectId(productId));

            var result = _db.Product.Find(filter).FirstOrDefault();

            if (result == null) return null!;

            return this.MapToModel(result);
        }

        public List<Product> GetProductsOwn(string personId)
        {
            var filter = Builders<ProductSchema>.Filter.Eq("owner", personId);

            var result = _db.Product.Find(filter).ToList();

            var products = new List<Product>();

            if (!result.Any()) return products;

            result.ForEach((schema) =>
            {
                products.Add(this.MapToModel(schema));
            });

            return products;

        }

        public List<Product> GetProductsToBuy(string personId)
        {
            var filter = Builders<ProductSchema>.Filter.Ne("owner", personId);

            var result = _db.Product.Find(filter).ToList();

            var products = new List<Product>();

            if (!result.Any()) return products;

            result.ForEach((schema) =>
            {
                products.Add(this.MapToModel(schema));
            });

            return products;
        }

        public Product Update(Product product)
        {

            var filter = Builders<ProductSchema>.Filter.Eq("_id", new ObjectId(product.Id));

            var query = Builders<ProductSchema>.Update
                .Set("title", product.Title)
                .Set("description", product.Description)
                .Set("price", product.Price)
                .Set("stock", product.Stock);

            var result = _db.Product.FindOneAndUpdate(filter, query);

            return this.MapToModel(result);
        }

        private ProductSchema MapToSchema(Product product)
        {
            return new()
            {
                Id = new ObjectId(),
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                Owner = product.Owner,
            };
        }

        private Product MapToModel(ProductSchema schema)
        {
            var product = new Product(schema.Title, schema.Description);

            product.Price = schema.Price;
            product.Stock = schema.Stock;
            product.Id = schema.Id.ToString();
            product.Owner = schema.Owner;

            return product;
        }
    }
}

