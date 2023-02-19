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
    public class CartRepository : ICartRepository<Cart>
    {
        private readonly DbContext _db;

        public CartRepository(DbContext db)
        {
            _db = db;
        }

        public Cart? GetById(string cartId, string personId)
        {
            var filter = Builders<CartSchema>.Filter.Eq("_id", new ObjectId(cartId));
            filter &= Builders<CartSchema>.Filter.Eq("personId", personId);

            var result = _db.Cart.Find(filter).FirstOrDefault();

            if (result == null) return null;

            return this.MapToModel(result);
        }

        public Cart? GetByPerson(string personId)
        {
            var filter = Builders<CartSchema>.Filter.Eq("personId", personId);

            var result = _db.Cart.Find(filter).FirstOrDefault();

            if (result == null) return null;

            return this.MapToModel(result);
        }

        public Cart Create(Cart entity)
        {
            var schema = this.MapToSchema(entity);

            _db.Cart.InsertOne(schema);

            return this.MapToModel(schema);
        }

        public Cart Update(Cart entity)
        {
            var filter = Builders<CartSchema>.Filter.Eq("personId", entity.PersonId);

            var productsSchemas = new List<ProductSchema>();

            entity.Products.ForEach((product) =>
            {
                productsSchemas.Add(this.MapToProductSchema(product));
            });

            var query = Builders<CartSchema>.Update
                .Set("products", productsSchemas);

            _db.Cart.FindOneAndUpdate(filter, query);

            return this.GetByPerson(entity.PersonId)!;
        }

        private CartSchema MapToSchema(Cart cart)
        {
            var products = new List<ProductSchema>();

            cart.Products.ForEach((product) =>
            {
                products.Add(this.MapToProductSchema(product));
            });

            return new()
            {
                Id = new ObjectId(),
                PersonId = cart.PersonId,
                Products = products,
            };
        }

        private Cart MapToModel(CartSchema schema)
        {
            var products = new List<Product>();

            schema.Products.ForEach((productSchema) =>
            {
                products.Add(MapToProductModel(productSchema));
            });

            var cart = new Cart(schema.PersonId, products);

            cart.Id = schema.Id.ToString();

            return cart;

        }

        private ProductSchema MapToProductSchema(Product product)
        {
            return new()
            {
                Id = new ObjectId(product.Id),
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock,
                Owner = product.Owner,
                Quantity = product.Quantity,
            };
        }

        private Product MapToProductModel(ProductSchema schema)
        {
            var product = new Product(schema.Title, schema.Description);

            product.Price = schema.Price;
            product.Stock = schema.Stock;
            product.Id = schema.Id.ToString();
            product.Owner = schema.Owner;
            product.Quantity = schema.Quantity;

            return product;
        }
    }
}

